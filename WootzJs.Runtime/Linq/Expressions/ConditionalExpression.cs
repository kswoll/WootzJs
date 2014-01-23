namespace System.Linq.Expressions
{
    public class ConditionalExpression : Expression
    {
        public Expression Test { get; private set; }
        public Expression IfTrue { get; private set; }
        public Expression IfFalse { get; private set; }
        
        private Type type;

        public ConditionalExpression(Expression test, Expression ifTrue, Expression ifFalse) : 
            base(ExpressionType.Conditional)
        {
            Test = test;
            IfTrue = ifTrue;
            IfFalse = ifFalse;
        }

        public ConditionalExpression(Expression test, Expression ifTrue, Expression ifFalse, Type type) : 
            base(ExpressionType.Conditional)
        {
            Test = test;
            IfTrue = ifTrue;
            IfFalse = ifFalse;
            this.type = type;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitConditional(this);
        }

        public override Type Type
        {
            get { return type ?? IfTrue.Type; }
        }

        public Expression Update(Expression test, Expression ifTrue, Expression ifFalse)
        {
            return this;
        }
    }
}