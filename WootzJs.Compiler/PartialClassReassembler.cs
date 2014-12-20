using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    /// <summary>
    /// To simplify the transformation process, we unify partial classes into a single type declaration.  This
    /// implementation performs the following steps:
    /// 
    /// 1) Walks the project's syntax trees, tracking all type declarations with their type symbols.  (You will 
    /// only ever have one type symbol per group of partial classes.)
    /// 2) Filters out all the type symbols that only have one type declaration.
    /// 3) Having identified the partial types, we can then rewrite the compilation where for each partial type,
    /// the first of its type declarations is replaced with an implementation that combines the behavior of all
    /// the partial type declarations.  All subsequent type declarations are simply removed from their parent.
    /// </summary>
    public class PartialClassReassembler 
    {
        private Project project;
        private Compilation compilation;
        private Dictionary<TypeDeclarationSyntax, TypeDeclarationSyntax> typeDeclarationReplacements = new Dictionary<TypeDeclarationSyntax, TypeDeclarationSyntax>();
        private HashSet<TypeDeclarationSyntax> removedTypeDeclarations = new HashSet<TypeDeclarationSyntax>();
        private PartialClassScanner scanner;
        private PartialClassIdentifierFullyQualifier qualifier;

        public PartialClassReassembler(Project project, Compilation compilation)
        {
            this.project = project;
            this.compilation = compilation;
            scanner = new PartialClassScanner(this);
            qualifier = new PartialClassIdentifierFullyQualifier(this);
        }

        public Compilation UnifyPartialTypes()
        {
            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var compilationUnit = (CompilationUnitSyntax)syntaxTree.GetRoot();
                compilationUnit.Accept(scanner);
            }
            var partialTypes = scanner.typeDeclarationsBySymbol.Where(x => x.Value.Count > 1).SelectMany(x => x.Value).ToArray();
            if (!partialTypes.Any())
                return compilation;

            var compilationUnits = new HashSet<CompilationUnitSyntax>(partialTypes.Select(x => (CompilationUnitSyntax)x.SyntaxTree.GetRoot()).Distinct());
            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var compilationUnit = (CompilationUnitSyntax)syntaxTree.GetRoot();
                if (compilationUnits.Contains(compilationUnit))
                {
                    compilationUnit = (CompilationUnitSyntax)compilationUnit.Accept(qualifier);
                    compilation = compilation.ReplaceSyntaxTree(syntaxTree, SyntaxFactory.SyntaxTree(compilationUnit, path: syntaxTree.FilePath));
                }
            }
            Context.Update(project.Solution, project, compilation, new ReflectionCache(project, compilation));

            scanner = new PartialClassScanner(this);
            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var compilationUnit = (CompilationUnitSyntax)syntaxTree.GetRoot();
                compilationUnit.Accept(scanner);
            }
            return CreateNewCompilation();            
        }

        public Compilation CreateNewCompilation()
        {
            var partialTypesA = scanner.typeDeclarationsBySymbol.Where(x => x.Value.Count > 1).SelectMany(x => x.Value).ToArray();
            var partialTypes = scanner.typeDeclarationsBySymbol.Where(x => x.Value.Count > 1).ToDictionary(x => x.Key, x => x.Value);
            if (partialTypes.Any())
            {
                foreach (var item in partialTypes)
                {
                    var type = item.Key;
                    var declarations = item.Value;
                    var newDeclaration = UnifyDeclarations(type, declarations);

                    // Register the first implementation to be replaced by the fully unified type declaration
                    typeDeclarationReplacements[declarations.First()] = newDeclaration;

                    // Register the remaining types for removal
                    foreach (var removedTypeDeclaration in declarations.Skip(1))
                    {
                        removedTypeDeclarations.Add(removedTypeDeclaration);
                    }
                }

                var rewriter = new PartialClassRewriter(this);
                var newCompilationUnits = new List<Tuple<SyntaxTree, CompilationUnitSyntax>>();
                foreach (var syntaxTree in compilation.SyntaxTrees)
                {
                    var compilationUnit = (CompilationUnitSyntax)syntaxTree.GetRoot();
                    compilationUnit = (CompilationUnitSyntax)compilationUnit.Accept(rewriter);
                    newCompilationUnits.Add(Tuple.Create(syntaxTree, compilationUnit));
                }
                foreach (var item in newCompilationUnits)
                {
                    compilation = compilation.ReplaceSyntaxTree(item.Item1, SyntaxFactory.SyntaxTree(item.Item2, path: item.Item1.FilePath));                    
                }
                Context.Update(project.Solution, project, compilation, new ReflectionCache(project, compilation));
            }
            return compilation;
        }

        private TypeDeclarationSyntax UnifyDeclarations(ITypeSymbol type, List<TypeDeclarationSyntax> declarations)
        {
            var unifier = new PartialClassUnifier(this, declarations);
            var newTypeDeclaration = (TypeDeclarationSyntax)declarations.First().Accept(unifier);
            return newTypeDeclaration;
        }

        class PartialClassScanner : CSharpSyntaxWalker
        {
            private PartialClassReassembler reassembler;
            internal Dictionary<ITypeSymbol, List<TypeDeclarationSyntax>> typeDeclarationsBySymbol = new Dictionary<ITypeSymbol, List<TypeDeclarationSyntax>>();

            public PartialClassScanner(PartialClassReassembler reassembler) 
            {
                this.reassembler = reassembler;
            }

            private void AddType(ITypeSymbol symbol, TypeDeclarationSyntax typeDeclaration)
            {
                List<TypeDeclarationSyntax> typeDeclarations;
                if (!typeDeclarationsBySymbol.TryGetValue(symbol, out typeDeclarations))
                {
                    typeDeclarations = new List<TypeDeclarationSyntax>();
                    typeDeclarationsBySymbol[symbol] = typeDeclarations;
                }
                typeDeclarations.Add(typeDeclaration);            
            }

            public override void VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                var symbol = reassembler.compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
                AddType(symbol, node);
                base.VisitClassDeclaration(node);
            }

            public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
            {
                var symbol = reassembler.compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
                AddType(symbol, node);
                base.VisitInterfaceDeclaration(node);
            }
        }
        
        class PartialClassRewriter : CSharpSyntaxRewriter
        {
            private PartialClassReassembler reassembler;

            public PartialClassRewriter(PartialClassReassembler reassembler) 
            {
                this.reassembler = reassembler;
            }

            private SyntaxList<MemberDeclarationSyntax> ReplaceMembers(SyntaxList<MemberDeclarationSyntax> members)
            {
                var newMembers = new List<MemberDeclarationSyntax>();
                foreach (var member in members)
                {
                    if (member is TypeDeclarationSyntax)
                    {
                        var typeDeclaration = (TypeDeclarationSyntax)member;
                        if (reassembler.removedTypeDeclarations.Contains(typeDeclaration))
                            continue;
                        TypeDeclarationSyntax replacement;
                        if (reassembler.typeDeclarationReplacements.TryGetValue(typeDeclaration, out replacement))
                        {
                            newMembers.Add((MemberDeclarationSyntax)replacement.Accept(this));
                            continue;
                        }
                    }
                    newMembers.Add((MemberDeclarationSyntax)member.Accept(this));
                }

                return SyntaxFactory.List(newMembers);
            }

            public override SyntaxNode VisitCompilationUnit(CompilationUnitSyntax node)
            {
                return node.WithMembers(ReplaceMembers(node.Members));
            }

            public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                return node.WithMembers(ReplaceMembers(node.Members));
            }

            public override SyntaxNode VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
            {
                return node.WithMembers(ReplaceMembers(node.Members));
            }

            public override SyntaxNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
            {
                return node.WithMembers(ReplaceMembers(node.Members));
            }
        }

        class PartialClassIdentifierFullyQualifier : CSharpSyntaxRewriter 
        {
            private PartialClassReassembler reassembler;

            public PartialClassIdentifierFullyQualifier(PartialClassReassembler reassembler) 
            {
                this.reassembler = reassembler;
            }

            public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
            {
                var symbol = reassembler.compilation.GetSemanticModel(node.SyntaxTree).GetSymbolInfo(node).Symbol;
                if (symbol is ITypeSymbol)
                {
                    var type = (ITypeSymbol)symbol;
                    if (node.Parent is QualifiedNameSyntax)
                        return base.VisitIdentifierName(node);

                    return type.ToTypeSyntax();
                }
                return base.VisitIdentifierName(node);
            }

            public override SyntaxNode VisitGenericName(GenericNameSyntax node)
            {
                var symbol = reassembler.compilation.GetSemanticModel(node.SyntaxTree).GetSymbolInfo(node).Symbol;
                if (symbol is ITypeSymbol)
                {
                    var type = (ITypeSymbol)symbol;
                    if (node.Parent is QualifiedNameSyntax)
                        return base.VisitGenericName(node);

                    return type.ToTypeSyntax();
                }
                return base.VisitGenericName(node);
            }
        }

        class PartialClassUnifier : CSharpSyntaxVisitor<SyntaxNode>
        {
            private PartialClassReassembler reassembler;
            private List<TypeDeclarationSyntax> declarations;
            private TypeDeclarationGetMembers getMembers = new TypeDeclarationGetMembers();

            public PartialClassUnifier(PartialClassReassembler reassembler, List<TypeDeclarationSyntax> declarations)
            {
                this.reassembler = reassembler;
                this.declarations = declarations;
            }

            private SyntaxList<MemberDeclarationSyntax> UnifyMembers()
            {
                var membersAndSymbol = declarations
                    .SelectMany(x => x.Accept(getMembers))
                    .Select(x => Tuple.Create(reassembler.compilation.GetSemanticModel(x.SyntaxTree).GetDeclaredSymbol(x), x))
                    .ToArray();

                var newMembers = new List<MemberDeclarationSyntax>();
                foreach (var member in membersAndSymbol)
                {
                    var symbol = member.Item1;
                    var declaration = member.Item2;
                    if (symbol is IMethodSymbol)
                    {
                        var method = (IMethodSymbol)symbol;
//                        if (method.PartialDefinitionPart == null)     // !!! This should be the check.  But it seems that the symbol returned is inverted for the implementation and definition.
                        if (method.PartialImplementationPart == null)
                            newMembers.Add(declaration);
                    }
                    else
                    {
                        newMembers.Add(declaration);
                    }
                }

                return SyntaxFactory.List(newMembers);
            }

            public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                return node.WithMembers(UnifyMembers());
            }

            public override SyntaxNode VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
            {
                return node.WithMembers(UnifyMembers());
            }
        }

        class TypeDeclarationGetMembers : CSharpSyntaxVisitor<SyntaxList<MemberDeclarationSyntax>>
        {
            public override SyntaxList<MemberDeclarationSyntax> VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                return node.Members;
            }

            public override SyntaxList<MemberDeclarationSyntax> VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
            {
                return node.Members;
            }
        }
    }
}