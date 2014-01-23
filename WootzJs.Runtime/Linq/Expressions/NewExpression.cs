using System.Collections.Generic;
using System.Reflection;

namespace System.Linq.Expressions
{
    public class NewExpression : Expression, IArgumentProvider
    {
        public List<Expression> Arguments { get; private set; }
        public ConstructorInfo Constructor { get; private set; }

        public NewExpression(ConstructorInfo constructor, IEnumerable<Expression> args) : base(ExpressionType.New)
        {
            Constructor = constructor;
            Arguments = args.ToList();
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitNew(this);
        }

        public override Type Type
        {
            get { return Constructor.DeclaringType; }
        }

        public Expression Update(List<Expression> args)
        {
            return this;
        }
    }
}