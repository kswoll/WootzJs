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
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class DelegateTests
    {
        [Test]
        public void SimpleLambda()
        {
            var myClass = new MyClass { Name = "foo" };
            var lambda = myClass.CreateLambda();
            var name = lambda();
            QUnit.AreEqual(name, "foo");
        }

        [Test]
        public void AnonymousMethod()
        {
            Func<string> lambda = delegate() { return "foo"; };
            var name = lambda();
            QUnit.AreEqual(name, "foo");
        }

        [Test]
        public void ModifyClosedVariable()
        {
            var i = 0; 
            var j = 0;
            Action action = () =>
            {
                i = 5;
                j = i;
            };
            action();
            QUnit.AreEqual(j, 5);
        }

        [Test]
        public void CastDelegate()
        {
            var i = 0;
            Action action = () =>
            {
                i = 5;
            };
            Delegate delgt = action;
            var action2 = (Action)delgt;
            action2();
            QUnit.AreEqual(i, 5);
        }

        public class MyClass
        {
            public string Name { get; set; }

            public Func<string> CreateLambda( )
            {
                return () => Name;
            }
        }
    }
}
