using System.Reflection;

namespace System.Linq.Expressions
{
    public class MemberAssignment : MemberBinding
    {
        public Expression Expression { get; private set; }

        public MemberAssignment(MemberInfo member, Expression expression) : base(MemberBindingType.Assignment, member)
        {
            Expression = expression;
        }

        public MemberAssignment Update(Expression Expression)
        {
            return this;
        }
    }
}