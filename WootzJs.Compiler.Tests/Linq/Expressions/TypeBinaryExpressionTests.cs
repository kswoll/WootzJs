using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class TypeBinaryExpressionTests
    {
        [Test]
        public void IsOperator()
        {
#pragma warning disable 184
            // Disable warning because we're just testing expression trees, we don't care
            // that the condition could never be satisfied.
            Expression<Func<bool>> lambda = () => "foo" is int;
#pragma warning restore 184
            var unaryExpression = (TypeBinaryExpression)lambda.Body;
            var operand = (ConstantExpression)unaryExpression.Expression;
            QUnit.AreEqual(unaryExpression.NodeType, ExpressionType.TypeIs);
            QUnit.AreEqual(operand.Value, "foo");
            QUnit.AreEqual(unaryExpression.TypeOperand.FullName, typeof(int).FullName);
        }
    }
}