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
    public class UnaryExpressionTests : TestFixture
    {
        [Test]
        public void NotBoolean()
        {
            Expression<Func<bool>> lambda = () => !true;
            var unaryExpression = (UnaryExpression)lambda.Body;
            var operand = (ConstantExpression)unaryExpression.Operand;
            AssertEquals(unaryExpression.NodeType, ExpressionType.Not);
            AssertEquals(unaryExpression.Type, typeof(bool));
            AssertEquals(operand.Value, true);
        }

        [Test]
        public void NegateInteger()
        {
            Expression<Func<int>> lambda = () => -5;
            var unaryExpression = (UnaryExpression)lambda.Body;
            var operand = (ConstantExpression)unaryExpression.Operand;
            AssertEquals(unaryExpression.NodeType, ExpressionType.Negate);
            AssertEquals(operand.Value, 5);
        }

        [Test]
        public void AsOperator()
        {
            Expression<Func<object>> lambda = () => "foo" as object;
            var unaryExpression = (UnaryExpression)lambda.Body;
            var operand = (ConstantExpression)unaryExpression.Operand;
            AssertEquals(unaryExpression.NodeType, ExpressionType.TypeAs);
            AssertEquals(operand.Value, "foo");
            AssertEquals(unaryExpression.Type.FullName, typeof(object).FullName);
        }
    }
}
