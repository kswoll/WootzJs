using System.Reflection;

namespace System.Linq.Expressions
{
    public abstract class MemberExpression : Expression
    {
        public Expression Expression { get; private set; }
        public MemberInfo Member { get; private set; }

        public MemberExpression(Expression expression, MemberInfo member) : base(ExpressionType.MemberAccess)
        {
            Expression = expression;
            Member = member;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitMember(this);
        }

        internal static MemberExpression Make(Expression expression, MemberInfo member)
        {
            if (member.MemberType == MemberTypes.Field)
            {
                return new FieldExpression(expression, (FieldInfo)member);
            }
            else
            {
                return new PropertyExpression(expression, (PropertyInfo)member);
            }
        }

        public Expression Update(Expression Expression)
        {
            return this;
        }
    }
}