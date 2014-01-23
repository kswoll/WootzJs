namespace System.Runtime.WootzJs
{
    [Js(Export = false, Name = "Error")]
    public class JsError
    {
        [Js(Name = "stack")]
        public string stack;
    }
}
