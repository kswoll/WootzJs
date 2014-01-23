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

using System.Collections.Generic;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class IsExpressionTests
    {
        [Test]
        public void String()
        {
            var s = "foo";
            QUnit.IsTrue(s is string);
            QUnit.IsTrue(!(s is int));
        }

        [Test]
        public void TestClass()
        {
            var o = new MyClass();
            QUnit.IsTrue(o is MyClass);
            QUnit.IsTrue(o is object);
            QUnit.IsTrue(!(o is string));
        }
/*
Primitives like this are going to require more work         
        [Js(Inline = true)]
        public void Int()
        {
            QUnit.RunTest("IsExpressionTests.Int", () =>
            {
                var i = 5;
                QUnit.IsTrue(i is int);
                QUnit.IsTrue(!(i is string));
            });
        }
*/
 
        public class MyClass {}
    }
}
