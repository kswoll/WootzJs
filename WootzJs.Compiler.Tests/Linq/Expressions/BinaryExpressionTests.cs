using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    public class BinaryExpressionTests
    {
        [Test]
        public static void AddTwoInts()
        {
            Expression<Func<int>> lambda = () => 5 + 4;
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            QUnit.AreEqual(binaryExpression.NodeType, ExpressionType.Add);
            QUnit.AreEqual(left.Value, 5);
            QUnit.AreEqual(right.Value, 4);
        }         
         
        [Test]
        public static void AddTwoStrings()
        {
            Expression<Func<string>> lambda = () => "foo" + "bar";
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            QUnit.AreEqual(binaryExpression.NodeType, ExpressionType.Add);
            QUnit.AreEqual(left.Value, "foo");
            QUnit.AreEqual(right.Value, "bar");
        }         
         
        [Test]
        public static void AddStringAndInt()
        {
            Expression<Func<string>> lambda = () => "foo" + 5;
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            QUnit.AreEqual(binaryExpression.NodeType, ExpressionType.Add);
            QUnit.AreEqual(left.Value, "foo");
            QUnit.AreEqual(right.Value, 5);
        }         
         
        [Test]
        public static void SubtractTwoInts()
        {
            Expression<Func<int>> lambda = () => 5 - 4;
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            QUnit.AreEqual(binaryExpression.NodeType, ExpressionType.Subtract);
            QUnit.AreEqual(left.Value, 5);
            QUnit.AreEqual(right.Value, 4);
        }         
         
        [Test]
        public static void MultiplyTwoInts()
        {
            Expression<Func<int>> lambda = () => 5 * 4;
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            QUnit.AreEqual(binaryExpression.NodeType, ExpressionType.Multiply);
            QUnit.AreEqual(left.Value, 5);
            QUnit.AreEqual(right.Value, 4);
        }         
         
        [Test]
        public static void DivideTwoInts()
        {
            Expression<Func<int>> lambda = () => 5 / 4;
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            QUnit.AreEqual(binaryExpression.NodeType, ExpressionType.Divide);
            QUnit.AreEqual(left.Value, 5);
            QUnit.AreEqual(right.Value, 4);
        }         
         
        [Test]
        public static void ModuloTwoInts()
        {
            Expression<Func<int>> lambda = () => 5 % 4;
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            QUnit.AreEqual(binaryExpression.NodeType, ExpressionType.Modulo);
            QUnit.AreEqual(left.Value, 5);
            QUnit.AreEqual(right.Value, 4);
        }      
   
        [Test]
        public static void ArrayIndex()
        {
            var array = new[] { 5 };
            Expression<Func<int>> lambda = () => array[4];
            var binaryExpression = (BinaryExpression)lambda.Body;
            var target = (ConstantExpression)binaryExpression.Left;
            QUnit.AreEqual(target.Value, array);
            var index = (ConstantExpression)binaryExpression.Right;
            QUnit.AreEqual(index.Value, 4);
        }
    }
}