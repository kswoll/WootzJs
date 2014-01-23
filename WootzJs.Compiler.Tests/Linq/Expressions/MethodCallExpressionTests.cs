using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class MethodCallExpressionTests
    {
        [Test]
        public void CallZeroParameterStaticMethod()
        {
            Expression<Action> lambda = () => ClassWithMethods.ZeroParameterStaticMethod();
            var methodCallExpression = (MethodCallExpression)lambda.Body;
            QUnit.AreEqual(methodCallExpression.Method.Name, "ZeroParameterStaticMethod");
        }         

        [Test]
        public void CallOneParameterStaticMethod()
        {
            Expression<Action> lambda = () => ClassWithMethods.OneParameterStaticMethod("foo");
            var methodCallExpression = (MethodCallExpression)lambda.Body;
            QUnit.AreEqual(methodCallExpression.Method.Name, "OneParameterStaticMethod");
            var argument = (ConstantExpression)methodCallExpression.Arguments[0];
            QUnit.AreEqual(argument.Value, "foo");
        }         

        [Test]
        public void CallZeroParameterInstanceMethod()
        {
            var instance = new ClassWithMethods();
            Expression<Action> lambda = () => instance.ZeroParameterInstanceMethod();
            var methodCallExpression = (MethodCallExpression)lambda.Body;
            QUnit.AreEqual(methodCallExpression.Method.Name, "ZeroParameterInstanceMethod");
            var target = (ConstantExpression)methodCallExpression.Object;
            QUnit.AreEqual(target.Value, instance);
        }         
   
/*
        [Test]
        public void ArrayIndexMultiDimensional()
        {
            var array = new[,] { { 1, 2 }, { 3, 4 } };
            Expression<Func<int>> lambda = () => array[5, 6];
            var callExpression = (MethodCallExpression)lambda.Body;
            var target = (ConstantExpression)callExpression.Object;
            QUnit.AreEqual(target.Value, array);
            var index1 = (ConstantExpression)callExpression.Arguments[0];
            var index2 = (ConstantExpression)callExpression.Arguments[1];
            QUnit.AreEqual(index1.Value, 5);
            QUnit.AreEqual(index2.Value, 6);
            QUnit.AreEqual(callExpression.Method.Name, "Get");
        }
*/

        public class ClassWithMethods
        {
            public static void ZeroParameterStaticMethod()
            {
            }            

            public static void OneParameterStaticMethod(string parameter)
            {
            }            

            public void ZeroParameterInstanceMethod()
            {
            }            
        }
    }
}