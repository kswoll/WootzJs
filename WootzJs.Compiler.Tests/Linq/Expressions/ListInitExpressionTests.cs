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
using System.Collections.Generic;
using System.Linq.Expressions;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class ListInitExpressionTests
    {
        [Test]
        public void ListWithInitializer()
        {
            Expression<Func<List<string>>> lambda = () => new List<string> { "foo" };
            var listInitExpression = (ListInitExpression)lambda.Body;
            var newExpression = listInitExpression.NewExpression;
            newExpression.Type.FullName.AssertEquals(typeof(List<string>).FullName);

            var binding = listInitExpression.Initializers[0];
            var value = (ConstantExpression)binding.Arguments[0];
            value.Value.AssertEquals("foo");
        }

        [Test]
        public void ListWithInitializerTwoElements()
        {
            Expression<Func<List<string>>> lambda = () => new List<string> { "foo", "bar" };
            var listInitExpression = (ListInitExpression)lambda.Body;
            var newExpression = listInitExpression.NewExpression;
            newExpression.Type.FullName.AssertEquals(typeof(List<string>).FullName);

            var binding1 = listInitExpression.Initializers[0];
            var binding2 = listInitExpression.Initializers[1];
            var value1 = (ConstantExpression)binding1.Arguments[0];
            var value2 = (ConstantExpression)binding2.Arguments[0];
            value1.Value.AssertEquals("foo");
            value2.Value.AssertEquals("bar");
        }
        
        [Test]
        public void DictionaryWithInitializer()
        {
            Expression<Func<Dictionary<string, int>>> lambda = () => new Dictionary<string, int> { { "foo", 5 } };
            var listInitExpression = (ListInitExpression)lambda.Body;
            var newExpression = listInitExpression.NewExpression;
            newExpression.Type.FullName.AssertEquals(typeof(Dictionary<string, int>).FullName);

            var binding = listInitExpression.Initializers[0];
            var key = (ConstantExpression)binding.Arguments[0];
            var value = (ConstantExpression)binding.Arguments[1];
            key.Value.AssertEquals("foo");
            value.Value.AssertEquals(5);
        }
    }
}
