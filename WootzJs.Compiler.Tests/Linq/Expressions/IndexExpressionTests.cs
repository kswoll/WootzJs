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

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class IndexExpressionTests
    {
        [Test]
        public void IndexIntoList()
        {
            var list = new List<int> { 1, 2 };
            Expression<Func<int>> lambda = () => list[1];
            var callExpression = (IndexExpression)lambda.Body;
            var target = (ConstantExpression)callExpression.Object;
            QUnit.AreEqual(target.Value, list);
            var index = (ConstantExpression)callExpression.Arguments[0];
            QUnit.AreEqual(index.Value, 1);
        }         

        [Test]
        public void IndexIntoDictionary()
        {
            var dictionary = new Dictionary<int, string> { { 1, "foo" }, { 2, "bar" } };
            Expression<Func<string>> lambda = () => dictionary[1];
            var callExpression = (IndexExpression)lambda.Body;
            var target = (ConstantExpression)callExpression.Object;
            QUnit.AreEqual(target.Value, dictionary);
            var index = (ConstantExpression)callExpression.Arguments[0];
            QUnit.AreEqual(index.Value, 1);
        }         
    }
}
