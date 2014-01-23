using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class UnaryExpressionTests
    {
        [Test]
        public void NotBoolean()
        {
            Expression<Func<bool>> lambda = () => !true;
            var unaryExpression = (UnaryExpression)lambda.Body;
            var operand = (ConstantExpression)unaryExpression.Operand;
            QUnit.AreEqual(unaryExpression.NodeType, ExpressionType.Not);
            QUnit.AreEqual(unaryExpression.Type, typeof(bool));
            QUnit.AreEqual(operand.Value, true);
        }

        [Test]
        public void NegateInteger()
        {
            Expression<Func<int>> lambda = () => -5;
            var unaryExpression = (UnaryExpression)lambda.Body;
            var operand = (ConstantExpression)unaryExpression.Operand;
            QUnit.AreEqual(unaryExpression.NodeType, ExpressionType.Negate);
            QUnit.AreEqual(operand.Value, 5);
        }

        [Test]
        public void AsOperator()
        {
            Expression<Func<object>> lambda = () => "foo" as object;
            var unaryExpression = (UnaryExpression)lambda.Body;
            var operand = (ConstantExpression)unaryExpression.Operand;
            QUnit.AreEqual(unaryExpression.NodeType, ExpressionType.TypeAs);
            QUnit.AreEqual(operand.Value, "foo");
            QUnit.AreEqual(unaryExpression.Type.FullName, typeof(object).FullName);
        }
    }
}