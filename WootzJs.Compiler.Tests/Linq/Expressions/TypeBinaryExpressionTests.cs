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
            unaryExpression.NodeType.AssertEquals(ExpressionType.TypeIs);
            operand.Value.AssertEquals("foo");
            unaryExpression.TypeOperand.FullName.AssertEquals(typeof(int).FullName);
        }
    }
}
