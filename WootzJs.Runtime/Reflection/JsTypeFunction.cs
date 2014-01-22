using System.Runtime.WootzJs;

namespace System.Reflection
{
    [Js(Export = false, Name = "Function")]
    public class JsTypeFunction : JsFunction
    {
        [Js(Name = SpecialNames.TypeField)]
        public Type Type;

        [Js(Name = SpecialNames.TypeName)]
        public string TypeName;

        [Js(Name = SpecialNames.BaseType)]
        public JsTypeFunction BaseType;

        [Js(Name = SpecialNames.ArrayType)]
        public JsTypeFunction ArrayType;

        [Js(Name = SpecialNames.GetTypeFromType)]
        public JsFunction GetTypeFromType;

        [Js(Name = SpecialNames.TypeInitializer)]
        public JsFunction TypeInitializer;

        [Js(Name = SpecialNames.CreateType)]
        public JsFunction CreateTypeField;

        [Js(Name = SpecialNames.GetAssembly)]
        public JsFunction GetAssembly;

        [Js(Name = "$CreateType")]
        public Type CreateType()
        {
            return null;
        }
    }
}
