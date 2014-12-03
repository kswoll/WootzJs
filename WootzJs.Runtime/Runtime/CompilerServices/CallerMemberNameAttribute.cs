using System.Runtime.WootzJs;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Allows you to obtain the method or property name of the caller to the method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false), Js(Preserve = true)]
    public sealed class CallerMemberNameAttribute : Attribute
    {
    }
}