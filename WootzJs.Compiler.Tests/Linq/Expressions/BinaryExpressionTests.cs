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
    public class BinaryExpressionTests
    {
        [Test]
        public static void AddTwoInts()
        {
            Expression<Func<int>> lambda = () => 5 + 4;
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            binaryExpression.NodeType.AssertEquals(ExpressionType.Add);
            left.Value.AssertEquals(5);
            right.Value.AssertEquals(4);
        }         
         
        [Test]
        public static void AddTwoStrings()
        {
            Expression<Func<string>> lambda = () => "foo" + "bar";
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            binaryExpression.NodeType.AssertEquals(ExpressionType.Add);
            left.Value.AssertEquals("foo");
            right.Value.AssertEquals("bar");
        }         
         
        [Test]
        public static void AddStringAndInt()
        {
            Expression<Func<string>> lambda = () => "foo" + 5;
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            binaryExpression.NodeType.AssertEquals(ExpressionType.Add);
            left.Value.AssertEquals("foo");
            right.Value.AssertEquals(5);
        }         
         
        [Test]
        public static void SubtractTwoInts()
        {
            Expression<Func<int>> lambda = () => 5 - 4;
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            binaryExpression.NodeType.AssertEquals(ExpressionType.Subtract);
            left.Value.AssertEquals(5);
            right.Value.AssertEquals(4);
        }         
         
        [Test]
        public static void MultiplyTwoInts()
        {
            Expression<Func<int>> lambda = () => 5 * 4;
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            binaryExpression.NodeType.AssertEquals(ExpressionType.Multiply);
            left.Value.AssertEquals(5);
            right.Value.AssertEquals(4);
        }         
         
        [Test]
        public static void DivideTwoInts()
        {
            Expression<Func<int>> lambda = () => 5 / 4;
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            binaryExpression.NodeType.AssertEquals(ExpressionType.Divide);
            left.Value.AssertEquals(5);
            right.Value.AssertEquals(4);
        }         
         
        [Test]
        public static void ModuloTwoInts()
        {
            Expression<Func<int>> lambda = () => 5 % 4;
            var binaryExpression = (BinaryExpression)lambda.Body;
            var left = (ConstantExpression)binaryExpression.Left;
            var right = (ConstantExpression)binaryExpression.Right;
            binaryExpression.NodeType.AssertEquals(ExpressionType.Modulo);
            left.Value.AssertEquals(5);
            right.Value.AssertEquals(4);
        }      
   
        [Test]
        public static void ArrayIndex()
        {
            var array = new[] { 5 };
            Expression<Func<int>> lambda = () => array[4];
            var binaryExpression = (BinaryExpression)lambda.Body;
            var target = (ConstantExpression)binaryExpression.Left;
            target.Value.AssertEquals(array);
            var index = (ConstantExpression)binaryExpression.Right;
            index.Value.AssertEquals(4);
        }
    }
}
