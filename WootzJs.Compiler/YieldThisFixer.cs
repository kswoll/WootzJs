using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class YieldThisFixer : CSharpSyntaxRewriter
    {
        public static T Fix<T>(T method) where T : CSharpSyntaxNode
        {
            // This idea isn't going to work because it leaves the syntax tree in a bad state.  
            // We need to fix the this references after we've done all the semanatic analysis.
            // Not sure the best timing for that yet.
            var fixer = new YieldThisFixer();
            method = (T)method.Accept(fixer);
            return method;
        }

        public override SyntaxNode VisitThisExpression(ThisExpressionSyntax node)
        {
            return SyntaxFactory.IdentifierName("$this");
        }

/*
        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (node.Parent is TypeArgumentListSyntax)
                return node;
            if (node.Parent is ForEachStatementSyntax && ((ForEachStatementSyntax)node.Parent).Type == node)
                return node;
            if (node.Parent is MemberAccessExpressionSyntax && ((MemberAccessExpressionSyntax)node.Parent).Name == node)
                return node;
            if (node.Parent is VariableDeclarationSyntax && ((VariableDeclarationSyntax)node.Parent).Type == node)
                return node;
            if (node.Parent is ObjectCreationExpressionSyntax && ((ObjectCreationExpressionSyntax)node.Parent).Type == node)
                return node;
            if (node.Parent is CastExpressionSyntax && ((CastExpressionSyntax)node.Parent).Type == node)
                return node;

            return Syntax.MemberAccessExpression(SyntaxKind.MemberAccessExpression, Syntax.IdentifierName("$this"), node);
        }
*/
    }
}