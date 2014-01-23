using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class DefaultExpressionTests
    {
        [Test]
        public void DefaultInt()
        {
            Expression<Func<int>> lambda = () => default(int);
            var defaultExpression = (DefaultExpression)lambda.Body;
            QUnit.AreEqual(defaultExpression.Type.FullName, typeof(int).FullName);
        }
    }
}