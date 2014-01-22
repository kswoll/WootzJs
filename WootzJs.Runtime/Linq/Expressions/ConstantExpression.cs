using System.Runtime.WootzJs;

namespace System.Linq.Expressions
{
    public class ConstantExpression : Expression
    {
        public object Value { get; private set; }
        
        private Type type;

        public ConstantExpression(object value) : base(ExpressionType.Constant)
        {
            Value = value;
        }

        public ConstantExpression(object value, Type type) : this(value)
        {
            this.type = type;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitConstant(this);
        }

        public override Type Type
        {
            get { return type ?? (Value != null ? Value.GetType().As<Type>() : typeof(object).As<Type>()); }
        }
    }
}