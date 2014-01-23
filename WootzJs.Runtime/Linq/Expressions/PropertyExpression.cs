using System.Reflection;
using System.Runtime.WootzJs;

namespace System.Linq.Expressions
{
    public class PropertyExpression : MemberExpression
    {
        public PropertyExpression(Expression expression, PropertyInfo member) : base(expression, member)
        {
        }

        public override Type Type
        {
            get { return ((PropertyInfo)Member).PropertyType.As<Type>(); }
        }
    }
}