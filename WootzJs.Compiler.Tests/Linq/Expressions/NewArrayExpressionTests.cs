using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class NewArrayExpressionTests
    {
        [Test]
        public void NewArrayOneDimensionNoInitializer()
        {
            Expression<Func<int[]>> lambda = () => new int[5];
            var newArrayExpression = (NewArrayExpression)lambda.Body;
            QUnit.AreEqual(newArrayExpression.NodeType, ExpressionType.NewArrayBounds);
            var value = (ConstantExpression)newArrayExpression.Expressions[0];
            QUnit.AreEqual(value.Value, 5);
        }         

        [Test]
        public void NewArrayWithInitializer()
        {
            Expression<Func<int[]>> lambda = () => new[] { 1 ,2 };
            var newArrayExpression = (NewArrayExpression)lambda.Body;
            QUnit.AreEqual(newArrayExpression.NodeType, ExpressionType.NewArrayInit);
            var value1 = (ConstantExpression)newArrayExpression.Expressions[0];
            var value2 = (ConstantExpression)newArrayExpression.Expressions[1];
            QUnit.AreEqual(value1.Value, 1);
            QUnit.AreEqual(value2.Value, 2);
        }

        [Test]
        public void NewJaggedArrayWithInitializer()
        {
            Expression<Func<int[][]>> lambda = () => new[] { new[] { 1 ,2 }, new [] { 3, 4 }};
            var newArrayExpression = (NewArrayExpression)lambda.Body;
            QUnit.AreEqual(newArrayExpression.NodeType, ExpressionType.NewArrayInit);
            var array1 = (NewArrayExpression)newArrayExpression.Expressions[0];
            var array2 = (NewArrayExpression)newArrayExpression.Expressions[1];
            var value1 = (ConstantExpression)array1.Expressions[0];
            var value2 = (ConstantExpression)array1.Expressions[1];
            var value3 = (ConstantExpression)array2.Expressions[0];
            var value4 = (ConstantExpression)array2.Expressions[1];
            QUnit.AreEqual(value1.Value, 1);
            QUnit.AreEqual(value2.Value, 2);
            QUnit.AreEqual(value3.Value, 3);
            QUnit.AreEqual(value4.Value, 4);
        }
/*

        [JsMethod(GlobalCode = true)]
        public static void NewArrayTwoDimensionsNoInitializer()
        {
            QUnit.RunTest("NewArrayExpressionTests.NewArrayOneDimensionNoInitializer", () =>
            {
                Expression<Func<int[,]>> lambda = () => new int[5, 6];
                var newArrayExpression = (NewArrayExpression)lambda.Body;
//                QUnit.AreEqual(newArrayExpression.Type.FullName, typeof(int[]).FullName);
                QUnit.AreEqual(newArrayExpression.NodeType, ExpressionType.NewArrayBounds);
                var value1 = (ConstantExpression)newArrayExpression.Expressions[0];
                var value2 = (ConstantExpression)newArrayExpression.Expressions[1];
                QUnit.AreEqual(value1.Value, 5);
                QUnit.AreEqual(value2.Value, 6);
            });
        }         
*/
    }
}