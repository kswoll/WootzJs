using System.Collections.Generic;

namespace System.Linq.Expressions
{
    internal interface IArgumentProvider
    {
        List<Expression> Arguments { get; }
    }
}