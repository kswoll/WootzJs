namespace System.Linq.Expressions
{
    public class DefaultExpression : Expression
    {
        private Type type;

        public DefaultExpression(Type type) : base(ExpressionType.Default)
        {
            this.type = type;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitDefault(this);
        }

        public override Type Type
        {
            get { return type; }
        }
    }
}