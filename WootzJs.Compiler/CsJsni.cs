using System.Linq;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class CsJsni
    {
        private Context context;

        public CsJsni(Context context)
        {
            this.context = context;
        }

        public InvocationExpressionSyntax Function(SyntaxNode body)
        {
            var method = context.JsniType.GetMembers("function").OfType<MethodSymbol>().Single(x => x.Parameters.Count == 0);
            var lambda = Syntax.ParenthesizedLambdaExpression(body);
            return method.Invoke(lambda);
        }

        public InvocationExpressionSyntax Object(AnonymousObjectCreationExpressionSyntax obj, bool compact = false)
        {
            var method = context.JsniType.GetMembers("object").OfType<MethodSymbol>().Single();
            return method.Invoke(obj, compact ? Cs.True() : Cs.False());
        }
    }
}