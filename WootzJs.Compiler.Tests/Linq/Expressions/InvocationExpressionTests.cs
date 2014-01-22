using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class InvocationExpressionTests
    {
        [Test]
        public void CallDelegate()
        {
            Func<int, int> func = x => x + 1;
            Expression<Func<int>> lambda = () => func(5);
            var invocation = (InvocationExpression)lambda.Body;

            var target = (ConstantExpression)invocation.Expression;
            QUnit.AreEqual(target.Value, func);

            var arg = (ConstantExpression)invocation.Arguments[0];
            QUnit.AreEqual(arg.Value, 5);
        }
    }
}