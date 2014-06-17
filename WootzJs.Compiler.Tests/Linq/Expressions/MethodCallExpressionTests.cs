#region License
//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------
#endregion

using System;
using System.Linq.Expressions;
using WootzJs.Testing;

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
            methodCallExpression.Method.Name.AssertEquals("ZeroParameterStaticMethod");
        }         

        [Test]
        public void CallOneParameterStaticMethod()
        {
            Expression<Action> lambda = () => ClassWithMethods.OneParameterStaticMethod("foo");
            var methodCallExpression = (MethodCallExpression)lambda.Body;
            methodCallExpression.Method.Name.AssertEquals("OneParameterStaticMethod");
            var argument = (ConstantExpression)methodCallExpression.Arguments[0];
            argument.Value.AssertEquals("foo");
        }         

        [Test]
        public void CallZeroParameterInstanceMethod()
        {
            var instance = new ClassWithMethods();
            Expression<Action> lambda = () => instance.ZeroParameterInstanceMethod();
            var methodCallExpression = (MethodCallExpression)lambda.Body;
            methodCallExpression.Method.Name.AssertEquals("ZeroParameterInstanceMethod");
            var target = (ConstantExpression)methodCallExpression.Object;
            target.Value.AssertEquals(instance);
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
