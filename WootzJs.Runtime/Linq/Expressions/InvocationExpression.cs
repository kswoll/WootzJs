using System.Collections.Generic;

namespace System.Linq.Expressions
{
    public class InvocationExpression : Expression, IArgumentProvider
    {
        public Expression Expression { get; private set; }
        public List<Expression> Arguments { get; private set; }

        private Type returnType;

        public InvocationExpression(Expression expression, List<Expression> args, Type returnType) : base(ExpressionType.Invoke)
        {
            Expression = expression;
            Arguments = args;

            this.returnType = returnType;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitInvocation(this);
        }

        public override Type Type
        {
            get { return returnType; }
        }

        internal InvocationExpression Rewrite(Expression lambda, Expression[] args)
        {
            return this; 
//            Expression expression = lambda;
//            Expression[] expressionArray = arguments;
//            IList<Expression> list = expressionArray != null ? (IList<Expression>)expressionArray : Arguments;
//            return Expression.Invoke(expression, (IEnumerable<Expression>)list);
        }
    }
}