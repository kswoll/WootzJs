using System.Collections.Generic;
using System.Reflection;

namespace System.Linq.Expressions
{
    public class ElementInit : IArgumentProvider
    {
        public MethodInfo AddMethod { get; private set; }
        public List<Expression> Arguments { get; private set; }

        public ElementInit(MethodInfo addMethod, List<Expression> args)
        {
            AddMethod = addMethod;
            Arguments = args;
        }

        public ElementInit Update(List<Expression> args)
        {
            return this;
        }
    }
}