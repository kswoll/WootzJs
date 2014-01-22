namespace System.Runtime.WootzJs
{
    [Js(Export = false)]
    public class DependsOnAttribute : Attribute
    {
        public Type Type { get; set; }
    }
}