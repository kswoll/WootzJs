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
        private Dictionary<ITypeSymbol, List<TypeDeclarationSyntax>> typeDeclarationsBySymbol = new Dictionary<ITypeSymbol, List<TypeDeclarationSyntax>>();
        private Dictionary<TypeDeclarationSyntax, TypeDeclarationSyntax> typeDeclarationReplacements = new Dictionary<TypeDeclarationSyntax, TypeDeclarationSyntax>();
        private HashSet<TypeDeclarationSyntax> removedTypeDeclarations = new HashSet<TypeDeclarationSyntax>();
        private PartialClassScanner scanner;

        public PartialClassReassembler(Project project, Compilation compilation)
        {
            this.project = project;
            this.compilation = compilation;
            scanner = new PartialClassScanner(this);
        }

        public Compilation UnifyPartialTypes()
        {
            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var compilationUnit = (CompilationUnitSyntax)syntaxTree.GetRoot();
                compilationUnit.Accept(scanner);
            }
            return CreateNewCompilation();            
        }

        public Compilation CreateNewCompilation()
        {
            var partialTypes = typeDeclarationsBySymbol.Where(x => x.Value.Count > 1).ToDictionary(x => x.Key, x => x.Value);
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
                    compilation = compilation.ReplaceSyntaxTree(item.Item1, SyntaxFactory.SyntaxTree(item.Item2, item.Item1.FilePath));                    
                }
                Context.Update(project.Solution, project, compilation, new ReflectionCache(project, compilation));
                compilation = compilation.Clone();
            }
            return compilation;
        }

        private TypeDeclarationSyntax UnifyDeclarations(ITypeSymbol type, List<TypeDeclarationSyntax> declarations)
        {
            var unifier = new PartialClassUnifier(declarations);
            var newTypeDeclaration = (TypeDeclarationSyntax)declarations.First().Accept(unifier);
            return newTypeDeclaration;
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

        class PartialClassScanner : CSharpSyntaxWalker
        {
            private PartialClassReassembler reassembler;

            public PartialClassScanner(PartialClassReassembler reassembler) 
            {
                this.reassembler = reassembler;
            }

            public override void VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                var symbol = reassembler.compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
                reassembler.AddType(symbol, node);

                base.VisitClassDeclaration(node);
            }

            public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
            {
                var symbol = reassembler.compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
                reassembler.AddType(symbol, node);

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

        class PartialClassUnifier : CSharpSyntaxVisitor<SyntaxNode>
        {
            private List<TypeDeclarationSyntax> declarations;
            private TypeDeclarationGetMembers getMembers = new TypeDeclarationGetMembers();

            public PartialClassUnifier(List<TypeDeclarationSyntax> declarations)
            {
                this.declarations = declarations;
            }

            private SyntaxList<MemberDeclarationSyntax> UnifyMembers()
            {
                return SyntaxFactory.List(declarations.SelectMany(x => x.Accept(getMembers)));
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