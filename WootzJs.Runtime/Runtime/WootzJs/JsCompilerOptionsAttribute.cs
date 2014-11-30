namespace System.Runtime.WootzJs
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class JsCompilerOptionsAttribute : Attribute
    {
        public bool IsReflectionMinimized { get; set; }
    }
}