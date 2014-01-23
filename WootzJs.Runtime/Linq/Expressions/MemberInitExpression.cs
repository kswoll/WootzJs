using System.Collections.Generic;

namespace System.Linq.Expressions
{
    public class MemberInitExpression : Expression
    {
        public NewExpression NewExpression { get; private set; }
        public List<MemberBinding> Bindings { get; private set; }

        public MemberInitExpression(NewExpression newExpression, List<MemberBinding> bindings) : base(ExpressionType.MemberInit)
        {
            NewExpression = newExpression;
            Bindings = bindings;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitMemberInit(this);
        }

        public override Type Type
        {
            get { return NewExpression.Type; }
        }

        public MemberInitExpression Update(NewExpression newExpression, List<MemberBinding> bindings)
        {
            return this;
        }
    }
}