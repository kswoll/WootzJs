using System.Runtime.WootzJs;

namespace System.Linq.Expressions
{
    public class TypeBinaryExpression : Expression
    {
        public Expression Expression { get; private set; }

        private Type typeOperand;

        public TypeBinaryExpression(Expression expression, Type typeOperand, ExpressionType nodeKind) : base(nodeKind)
        {
            Expression = expression;

            this.typeOperand = typeOperand;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitTypeBinary(this);
        }

        public Type TypeOperand
        {
            get { return typeOperand; }
        }

        public override Type Type
        {
            get
            {
                switch (NodeType)
                {
                    case ExpressionType.TypeAs:
                        return TypeOperand;
                    case ExpressionType.TypeIs:
                        return typeof(bool).As<Type>();
                    default:
                        throw new Exception("Unexpected NodeType: " + NodeType);
                }
            }
        }

        public Expression Update(Expression expression)
        {
            return this;
        }
    }
}