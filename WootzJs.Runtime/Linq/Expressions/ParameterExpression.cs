namespace System.Linq.Expressions
{
    public class ParameterExpression : Expression
    {
        public Type ParameterType { get; private set; }
        public string Name { get; private set; }

        public ParameterExpression(Type parameterType, string name) : base(ExpressionType.Parameter)
        {
            ParameterType = parameterType;
            Name = name;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitParameter(this);
        }

        public override Type Type
        {
            get { return ParameterType; }
        }
    }
}