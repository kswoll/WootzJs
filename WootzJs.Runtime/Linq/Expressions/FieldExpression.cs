using System.Reflection;
using System.Runtime.WootzJs;

namespace System.Linq.Expressions
{
    public class FieldExpression : MemberExpression
    {
        public FieldExpression(Expression expression, FieldInfo member) : base(expression, member)
        {
        }

        public override Type Type
        {
            get { return ((FieldInfo)Member).FieldType.As<Type>(); }
        }
    }
}