using System.Collections.Generic;
using System.Reflection;

namespace System.Linq.Expressions
{
    public class MemberListBinding : MemberBinding
    {
        public List<ElementInit> Initializers { get; private set; }

        public MemberListBinding(MemberBindingType bindingType, MemberInfo member, List<ElementInit> initializers) : base(bindingType, member)
        {
            Initializers = initializers;
        }

        public MemberListBinding Update(List<ElementInit> initializers)
        {
            return this;
        }
    }
}