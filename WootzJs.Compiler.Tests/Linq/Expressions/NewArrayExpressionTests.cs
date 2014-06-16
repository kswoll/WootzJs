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
    public class NewArrayExpressionTests
    {
        [Test]
        public void NewArrayOneDimensionNoInitializer()
        {
            Expression<Func<int[]>> lambda = () => new int[5];
            var newArrayExpression = (NewArrayExpression)lambda.Body;
            Assert.AssertEquals(newArrayExpression.NodeType, ExpressionType.NewArrayBounds);
            var value = (ConstantExpression)newArrayExpression.Expressions[0];
            Assert.AssertEquals(value.Value, 5);
        }         

        [Test]
        public void NewArrayWithInitializer()
        {
            Expression<Func<int[]>> lambda = () => new[] { 1 ,2 };
            var newArrayExpression = (NewArrayExpression)lambda.Body;
            Assert.AssertEquals(newArrayExpression.NodeType, ExpressionType.NewArrayInit);
            var value1 = (ConstantExpression)newArrayExpression.Expressions[0];
            var value2 = (ConstantExpression)newArrayExpression.Expressions[1];
            Assert.AssertEquals(value1.Value, 1);
            Assert.AssertEquals(value2.Value, 2);
        }

        [Test]
        public void NewJaggedArrayWithInitializer()
        {
            Expression<Func<int[][]>> lambda = () => new[] { new[] { 1 ,2 }, new [] { 3, 4 }};
            var newArrayExpression = (NewArrayExpression)lambda.Body;
            Assert.AssertEquals(newArrayExpression.NodeType, ExpressionType.NewArrayInit);
            var array1 = (NewArrayExpression)newArrayExpression.Expressions[0];
            var array2 = (NewArrayExpression)newArrayExpression.Expressions[1];
            var value1 = (ConstantExpression)array1.Expressions[0];
            var value2 = (ConstantExpression)array1.Expressions[1];
            var value3 = (ConstantExpression)array2.Expressions[0];
            var value4 = (ConstantExpression)array2.Expressions[1];
            Assert.AssertEquals(value1.Value, 1);
            Assert.AssertEquals(value2.Value, 2);
            Assert.AssertEquals(value3.Value, 3);
            Assert.AssertEquals(value4.Value, 4);
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
