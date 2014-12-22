using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class TypeCollector : CSharpSyntaxWalker
    {
        private List<BaseTypeDeclarationSyntax> typeDeclarations = new List<BaseTypeDeclarationSyntax>();
        private List<DelegateDeclarationSyntax> delegateDeclarations = new List<DelegateDeclarationSyntax>();
        private List<AnonymousObjectCreationExpressionSyntax> anonymousTypeDeclarations = new List<AnonymousObjectCreationExpressionSyntax>();
        private HashSet<ITypeSymbol> types = new HashSet<ITypeSymbol>();
        private Compilation compilation;

        public TypeCollector()
        {
        }

        public TypeCollector(Compilation compilation) 
        {
            this.compilation = compilation;
        }

        public List<ITypeSymbol> Types
        {
            get { return types.ToList(); }
        }

        public List<BaseTypeDeclarationSyntax> TypeDeclarations
        {
            get { return typeDeclarations; }
        }

        public List<DelegateDeclarationSyntax> DelegateDeclarations
        {
            get { return delegateDeclarations; }
        }

        public List<AnonymousObjectCreationExpressionSyntax> AnonymousTypeDeclarations
        {
            get { return anonymousTypeDeclarations; }
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            if (compilation != null)
            {
                var type = compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
                types.Add(type);                
            }
            typeDeclarations.Add(node);
            base.VisitClassDeclaration(node);
        }

        public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            if (compilation != null)
            {
                var type = compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
                types.Add(type);                
            }
            typeDeclarations.Add(node);
            base.VisitInterfaceDeclaration(node);
        }

        public override void VisitStructDeclaration(StructDeclarationSyntax node)
        {
            if (compilation != null)
            {
                var type = compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
                types.Add(type);                
            }
            typeDeclarations.Add(node);
            base.VisitStructDeclaration(node);
        }

        public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            if (compilation != null)
            {
                var type = compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
                types.Add(type);                
            }
            typeDeclarations.Add(node);
            base.VisitEnumDeclaration(node);
        }

        public override void VisitDelegateDeclaration(DelegateDeclarationSyntax node)
        {
            if (compilation != null)
            {
                var type = compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
                types.Add(type);                
            }
            delegateDeclarations.Add(node);
            base.VisitDelegateDeclaration(node);
        }

        public override void VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            if (compilation != null)
            {
                var type = compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
                types.Add(type);                
            }
            anonymousTypeDeclarations.Add(node);
            base.VisitAnonymousObjectCreationExpression(node);
        }
    }
}