namespace System.Runtime.WootzJs
{
    [Js(Export = false)]
    public static class AsExtension
    {
        [Js(Export = false)]
        public static T As<T>(this object o)
        {
            return default(T);
        }
    }
}
