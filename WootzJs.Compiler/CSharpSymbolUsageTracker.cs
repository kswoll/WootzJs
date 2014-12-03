using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public static class CSharpSymbolUsageTrackerExtensions
    {
        public static bool IsSymbolUsed(this CSharpSymbolUsageTracker tracker, ISymbol symbol)
        {
            return tracker == null || tracker.IsUsed(symbol);
        }        
    }

    public class CSharpSymbolUsageTracker : CSharpSyntaxWalker
    {
        private HashSet<string> usedSymbols = new HashSet<string>();
        private SymbolNamer namer = new SymbolNamer();
        private Dictionary<SyntaxTree, Compilation> compilationsBySyntaxTree = new Dictionary<SyntaxTree, Compilation>();

        public void CollectUsedSymbols(TypeDeclarationSyntax type)
        {
            type.Accept(this);
        }

        public void Initialize(ProjectCompiler projectCompiler)
        {
            foreach (var syntaxTree in projectCompiler.Compilation.SyntaxTrees)
            {
                compilationsBySyntaxTree[syntaxTree] = projectCompiler.Compilation;
            }
        }

        public void FindPreserved(ProjectCompiler projectCompiler)
        {
            var preserveFinder = new PreserveFinder(this);
            foreach (var syntaxTree in projectCompiler.Compilation.SyntaxTrees)
            {
                var compilationUnit = (CompilationUnitSyntax)syntaxTree.GetRoot();
                compilationUnit.Accept(preserveFinder);
            }

            foreach (var attribute in projectCompiler.Compilation.Assembly.GetAttributes())
            {
                foreach (var syntax in attribute.AttributeClass.DeclaringSyntaxReferences)
                {
                    CollectUsedSymbols((TypeDeclarationSyntax)syntax.GetSyntax());
                }
            }
        }

        public bool IsUsed(ISymbol symbol)
        {
            var name = symbol.Accept(namer);
            if (name == null)
                throw new Exception();
            return usedSymbols.Contains(name);
        }

        private void Track(ISymbol symbol)
        {
            var name = symbol.Accept(namer);
//            if (name == null)
//                throw new Exception();
            if (name != null)
            {
                if (usedSymbols.Add(name))
                {
//                    Console.WriteLine(name);
                    foreach (var implReference in symbol.DeclaringSyntaxReferences)
                    {
                        var impl = (CSharpSyntaxNode)implReference.GetSyntax();
                        impl.Accept(this);
                    }
                }
            }
        }

        public override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            base.VisitIdentifierName(node);
            
            var compilation = compilationsBySyntaxTree[node.SyntaxTree];
            var symbol = compilation.GetSemanticModel(node.SyntaxTree).GetSymbolInfo(node).Symbol;
            Track(symbol);
        }

        public override void VisitGenericName(GenericNameSyntax node)
        {
            base.VisitGenericName(node);

            var compilation = compilationsBySyntaxTree[node.SyntaxTree];
            var symbol = compilation.GetSemanticModel(node.SyntaxTree).GetSymbolInfo(node).Symbol;
            Track(symbol);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            base.VisitMethodDeclaration(node);

            var compilation = compilationsBySyntaxTree[node.SyntaxTree];
            var methodSymbol = compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
            Track(methodSymbol);
            Track(methodSymbol.ContainingType);
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            base.VisitClassDeclaration(node);

//            if (node.Identifier.ToString().Contains("Expression"))
//                Console.WriteLine("foo");
            var compilation = compilationsBySyntaxTree[node.SyntaxTree];
            var classSymbol = compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
            Track(classSymbol);
            if (node.BaseList != null)
            {
                foreach (var baseType in node.BaseList.Types)
                {
                    var baseTypeSymbol = compilation.GetSemanticModel(node.SyntaxTree).GetSymbolInfo(baseType.Type).Symbol;
                    Track(baseTypeSymbol);
                }                
            }
            foreach (var attributeList in node.AttributeLists)
            {
                foreach (var attribute in attributeList.Attributes)
                {
                    var symbol = (IMethodSymbol)compilation.GetSemanticModel(node.SyntaxTree).GetSymbolInfo(attribute).Symbol;
                    var type = symbol.ContainingType;
                    Track(type);
                }
            }
        }

/*
        public override void VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            node.Type
            base.VisitVariableDeclaration(node);
        }
*/
        class PreserveFinder : CSharpSyntaxWalker
        {
            private CSharpSymbolUsageTracker tracker;

            public PreserveFinder(CSharpSymbolUsageTracker tracker) 
            {
                this.tracker = tracker;
            }

            public override void VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                base.VisitClassDeclaration(node);
                var compilation = tracker.compilationsBySyntaxTree[node.SyntaxTree];
                var classSymbol = compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
                if (classSymbol.IsPreserved() || compilation.Assembly.AreAllTypesPreserved())
                    tracker.CollectUsedSymbols(node);
            }
        }

        class SymbolNamer : SymbolVisitor<string>
        {
            public override string VisitNamedType(INamedTypeSymbol symbol)
            {
                var result = symbol.MetadataName;
                var containingType = symbol.ContainingType;
                if (containingType != null)
                    result = containingType.Accept(this) + '.' + result;
                else if (symbol.ContainingNamespace != null)
                    result = symbol.ContainingNamespace.GetFullName() + '.' + result;
                    
                return result;
            }

            public override string VisitMethod(IMethodSymbol symbol)
            {
                return symbol.ContainingType.Accept(this) + '.' + symbol.MetadataName + '(' + string.Join(",", symbol.Parameters.Select(x => x.Type.Accept(this))) + ')';
            }

            public override string VisitField(IFieldSymbol symbol)
            {
                return symbol.ContainingType.Accept(this) + '.' + symbol.MetadataName;
            }

            public override string VisitEvent(IEventSymbol symbol)
            {
                return symbol.ContainingType.Accept(this) + '.' + symbol.MetadataName;
            }

            public override string VisitProperty(IPropertySymbol symbol)
            {
                return symbol.ContainingType.Accept(this) + '.' + symbol.MetadataName;
            }
        }
    }
}