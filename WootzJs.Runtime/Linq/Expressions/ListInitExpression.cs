using System.Collections.Generic;

namespace System.Linq.Expressions
{
    public class ListInitExpression : Expression
    {
        public NewExpression NewExpression { get; private set; }
        public List<ElementInit> Initializers { get; private set; }

        public ListInitExpression(NewExpression newExpression, List<ElementInit> initializers) : base(ExpressionType.ListInit)
        {
            NewExpression = newExpression;
            Initializers = initializers;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitListInit(this);
        }

        public override Type Type
        {
            get { return NewExpression.Type; }
        }

        public ListInitExpression Update(NewExpression NewExpression, List<ElementInit> initializers)
        {
            return this;
        }
    }
}