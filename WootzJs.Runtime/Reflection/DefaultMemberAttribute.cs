using System.Runtime.WootzJs;

namespace System.Reflection
{
    [Js(Export = false)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct)]
    public sealed class DefaultMemberAttribute : Attribute
    {
        public DefaultMemberAttribute(string memberName)
        {
        }

        public string MemberName { get; private set; }
    }
}
