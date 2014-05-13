using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class YieldThisFixer : SyntaxRewriter
    {
        public static T Fix<T>(T method) where T : SyntaxNode
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
            return Syntax.IdentifierName("$this");
        }
    }
}