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
    public class ConstantExpressionTests
    {
        [Test]
        public void LocalClosedVariable()
        {
            var s = "foo";              // This variable is being closed and should result in a 
                                        // ConstantExpression when constructing the expression
                                        // tree since it's value is known at that time.
            Expression<Func<string, string>> lambda = x => s;
            var constantExpression = (ConstantExpression)lambda.Body;
            constantExpression.Value.AssertEquals("foo");            
        }

        [Test]
        public void Integer()
        {
            Expression<Func<string, int>> lambda = x => 5;
            var constantExpression = (ConstantExpression)lambda.Body;
            constantExpression.Value.AssertEquals(5);
        }

        [Test]
        public void Float()
        {
            Expression<Func<string, float>> lambda = x => 5.4f;
            var constantExpression = (ConstantExpression)lambda.Body;
            constantExpression.Value.AssertEquals(5.4);
        }

        [Test]
        public void Double()
        {
            Expression<Func<string, double>> lambda = x => 3.40282347E+40;
            var constantExpression = (ConstantExpression)lambda.Body;
            constantExpression.Value.AssertEquals(3.40282347E+40);
        }
         
        [Test]
        public void String()
        {
            Expression<Func<string, string>> lambda = x => "foo";
            var constantExpression = (ConstantExpression)lambda.Body;
            constantExpression.Value.AssertEquals("foo");                
        }
         
        [Test]
        public void Boolean()
        {
            Expression<Func<string, bool>> lambda = x => true;
            var constantExpression = (ConstantExpression)lambda.Body;
            constantExpression.Value.AssertEquals(true);                
        }
    }
}
