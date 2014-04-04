using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class CsJsni
    {
        private Context context;

        public CsJsni(Context context)
        {
            this.context = context;
        }

        public InvocationExpressionSyntax Function(CSharpSyntaxNode body)
        {
            var method = context.JsniType.GetMembers("function").OfType<IMethodSymbol>().Single(x => !x.Parameters.Any());
            var lambda = SyntaxFactory.ParenthesizedLambdaExpression(body);
            return method.Invoke(lambda);
        }

        public InvocationExpressionSyntax Object(AnonymousObjectCreationExpressionSyntax obj, bool compact = false)
        {
            var method = context.JsniType.GetMembers("object").OfType<IMethodSymbol>().Single();
            return method.Invoke(obj, compact ? Cs.True() : Cs.False());
        }
    }
}