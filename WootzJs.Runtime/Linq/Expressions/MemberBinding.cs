using System.Reflection;

namespace System.Linq.Expressions
{
    public class MemberBinding
    {
        public MemberBindingType BindingType { get; private set; }

        public MemberInfo Member { get; private set; }

        public MemberBinding(MemberBindingType bindingType, MemberInfo member)
        {
            BindingType = bindingType;
            Member = member;
        }
    }
}