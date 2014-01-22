using System.Collections.Generic;

namespace System.Linq.Expressions
{
    public class NewArrayExpression : Expression
    {
        public List<Expression> Expressions { get; private set; }
        
        private Type type;

        public NewArrayExpression(ExpressionType nodeType, Type type, List<Expression> expressions) : base(nodeType)
        {
            this.type = type;
            Expressions = expressions;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitNewArray(this);
        }

        public override Type Type
        {
            get { return type; }
        }

        public Expression Update(List<Expression> expressions)
        {
            return this;
        }
    }
}