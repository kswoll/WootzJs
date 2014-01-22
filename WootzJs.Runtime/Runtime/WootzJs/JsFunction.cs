namespace System.Runtime.WootzJs
{
    [Js(Export = false, Name = "Function")]
    public class JsFunction : JsObject
    {
        [Js(Name = "prototype")]
        public JsObject prototype;

        public JsObject invoke(params object[] args)
        {
            return null;
        }

        public JsObject call(JsObject thisInstance, params object[] args)
        {
            return null;
        }

        public JsObject apply(JsObject thisInstance, JsArray args)
        {
            return null;
        }
    }
}
