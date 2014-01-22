using System.Runtime.WootzJs;

namespace System.Runtime.InteropServices
{
    [Js(Export = false)]
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class OutAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.OutAttribute"/> class.
        /// </summary>
        public OutAttribute()
        {
        }
    }
}
