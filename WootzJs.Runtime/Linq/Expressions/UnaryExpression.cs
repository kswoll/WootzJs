using System.Reflection;

namespace System.Linq.Expressions
{
    public class UnaryExpression : Expression
    {
        public Expression Operand { get; private set; }
        public MethodInfo Method { get; private set; }

        private Type type;

        public UnaryExpression(ExpressionType nodeType, Expression operand, MethodInfo method, Type type) : base(nodeType)
        {
            Operand = operand;
            Method = method;

            this.type = type;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitUnary(this);
        }

        public override Type Type
        {
            get { return type; }
        }

        public UnaryExpression Update(Expression operand)
        {
            return this;
        }
    }
}