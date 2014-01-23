using System.Collections.Generic;
using System.Reflection;

namespace System.Linq.Expressions
{
    public class IndexExpression : Expression, IArgumentProvider
    {
        public Expression Object { get; private set; }
        public PropertyInfo Indexer { get; private set; }
        public List<Expression> Arguments { get; private set; }

        private Type elementType;

        public IndexExpression(Expression obj, PropertyInfo indexer, Type elementType, List<Expression> args) : base(ExpressionType.Index)
        {
            Object = obj;
            Indexer = indexer;
            Arguments = args;
            
            this.elementType = elementType;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitIndex(this);
        }

        public override Type Type
        {
            get { return elementType; }
        }
    }
}