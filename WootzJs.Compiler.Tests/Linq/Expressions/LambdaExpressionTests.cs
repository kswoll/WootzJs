using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class LambdaExpressionTests
    {
        [Test]
        public void Func()
        {
            Expression<Func<Func<int, int>>> lambda = () => x => x;
            var expression = (LambdaExpression)lambda.Body;

            QUnit.AreEqual(expression.Parameters.Count, 1);
            QUnit.AreEqual(expression.Body, expression.Parameters[0]);
        }
    }
}