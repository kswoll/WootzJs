using System.Runtime.WootzJs;

namespace System.Runtime.CompilerServices
{
    [Js(Export = false)]
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ExtensionAttribute : Attribute
    {
        public ExtensionAttribute()
        {
        }
    }
}
