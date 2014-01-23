using System.Runtime.WootzJs;

namespace System.Runtime.Versioning
{
    [Js(Export = false)]
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public class TargetFrameworkAttribute : Attribute
    {
        public TargetFrameworkAttribute(string frameworkName)
        {
        }

        public string FrameworkName { get; private set; }
        public string FrameworkDisplayName { get; set; }
    }
}
