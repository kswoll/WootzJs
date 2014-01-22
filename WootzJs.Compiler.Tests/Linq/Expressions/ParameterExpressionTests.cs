using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class ParameterExpressionTests
    {
        [Test]
        public void LambdaReturnsParameter()
        {
            Expression<Func<string, string>> lambda = x => x;
            var parameterExpression = (ParameterExpression)lambda.Body;
            QUnit.AreEqual(lambda.Parameters[0], parameterExpression);
            QUnit.AreEqual(parameterExpression.Name, "x");
        }
    }
}