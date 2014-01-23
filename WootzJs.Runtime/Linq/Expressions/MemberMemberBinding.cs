using System.Collections.Generic;
using System.Reflection;

namespace System.Linq.Expressions
{
    public class MemberMemberBinding : MemberBinding
    {
        public List<MemberBinding> Bindings { get; private set; }

        public MemberMemberBinding(MemberBindingType bindingType, MemberInfo member, List<MemberBinding> bindings) : base(bindingType, member)
        {
            Bindings = bindings;
        }

        public MemberMemberBinding Update(List<MemberBinding> bindings)
        {
            return this;
        }
    }
}