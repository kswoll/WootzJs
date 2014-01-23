using System.Collections.Generic;
using System.Reflection;

namespace System.Linq.Expressions
{
    public class MethodCallExpression : Expression, IArgumentProvider
    {
        public Expression Object { get; private set; }
        public MethodInfo Method { get; private set; }
        public List<Expression> Arguments { get; private set; }

        public MethodCallExpression(Expression obj, MethodInfo method, Expression[] args) : base(ExpressionType.Call)
        {
            Object = obj;
            Method = method;
            Arguments = args.ToList();
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitMethodCall(this);
        }

        public override Type Type
        {
            get { return Method.ReturnType; }
        }
    }
}