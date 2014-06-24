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
using System.Reflection;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    public class MemberExpressionTests : TestFixture
    {
        [Test]
        public void Property()
        {
            Expression<Func<ClassWithMembers, string>> lambda = x => x.StringProperty;
            var memberExpression = (MemberExpression)lambda.Body;
            AssertEquals(memberExpression.Expression, lambda.Parameters[0]);
            AssertTrue((memberExpression.Member is PropertyInfo));
            AssertEquals(memberExpression.Member.Name, "StringProperty");
        }
         
/*
 *  The x => x.IntField crashes the compiler, so fields are not supported for now.
        [JsMethod(GlobalCode = true)]
        public static void Field()
        {
            QUnit.RunTest("MemberExpressionTests.Field", () =>
            {
                Expression<Func<ClassWithMembers, int>> lambda = x => x.IntField;
                var memberExpression = (MemberExpression)lambda.Body;
                QUnit.AreEqual(memberExpression.Expression, lambda.Parameters[0]);
                QUnit.IsTrue(memberExpression.Member is FieldInfo);
                QUnit.AreEqual(memberExpression.Member.Name, "IntField");
            });
        }
*/

        public class ClassWithMembers
        {
            public string StringProperty { get; set; }
            public int IntField;
        }
    }
}
