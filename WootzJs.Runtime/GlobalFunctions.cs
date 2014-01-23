using System.Runtime.WootzJs;

namespace System
{
    [Js(Inline = true)]
    public static class GlobalFunctions
    {
        [Js(Name = "$int", Native = @"
value['GetType'] = $intGetType;
return value;
")]
        public static JsObject Int32(JsObject value)
        {
            return null;
        }

        [Js(Name = "$intGetType")]
        public static JsObject IntGetType()
        {
            return typeof(int).As<JsObject>();
        }
    }
}
