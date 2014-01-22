using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public static class WootzJsExtensions
    {
        internal static Context context;

        public static bool IsExported(this Symbol symbol)
        {
            var result = symbol.GetAttributeValue(context.JsAttributeType, "Export", true);
            if (!(symbol is TypeSymbol))
                result = result && symbol.ContainingType.IsExported();
            return result;
        }

        public static bool IsBuiltIn(this Symbol symbol)
        {
            return symbol.GetAttributeValue(context.JsAttributeType, "BuiltIn", false);
        }

        public static bool IsExtension(this Symbol symbol)
        {
            return symbol.GetAttributeValue(context.JsAttributeType, "Extension", false);
        }
    }
}
