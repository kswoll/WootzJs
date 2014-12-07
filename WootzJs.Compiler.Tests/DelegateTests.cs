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
using System.Runtime.WootzJs;
using System.Threading.Tasks;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class DelegateTests : TestFixture
    {
        [Test]
        public void SimpleLambda()
        {
            var myClass = new MyClass { Name = "foo" };
            var lambda = myClass.CreateLambda();
            var name = lambda();
            AssertEquals(name, "foo");
        }

        [Test]
        public void AnonymousMethod()
        {
            Func<string> lambda = delegate() { return "foo"; };
            var name = lambda();
            AssertEquals(name, "foo");
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
            AssertEquals(j, 5);
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
            AssertEquals(i, 5);
        }

        [Test]
        public void DynamicInvoke()
        {
            Func<int, int> adder = x => x + 1;
            var result = adder.DynamicInvoke(1);
            AssertEquals(result, 2);
        }

        [Test]
        public void MethodDelegate()
        {
            var methodClass = new MethodClass("foo");
            Func<string> methodDelegate = methodClass.M;
            var s = methodDelegate();
            AssertEquals(s, "foo");
            AssertEquals(methodDelegate.Target, methodClass);
        }

        [Test]
        public void MethodDelegateOnThis()
        {
            Func<string> methodDelegate = M;
            var s = methodDelegate();
            AssertEquals(s, "bar");
        }

        [Test]
        public void MethodTargets()
        {
            var methodClass1 = new MethodClass("foo1");
            var methodClass2 = new MethodClass("foo2");
            Func<string> delegate1 = methodClass1.M;
            Func<string> delegate2 = methodClass2.M;
            AssertEquals(delegate1(), "foo1");
            AssertEquals(delegate2(), "foo2");
            AssertEquals(delegate1.Target, methodClass1);
            AssertEquals(delegate2.Target, methodClass2);
        }

        [Test]
        public void CombineTwoDelegates()
        {
            var s = "";
            Action<string> a = x => s += x;
            Action<string> b = x => s += x.Length;
            var both = (Action<string>)Delegate.Combine(a, b);
            both("ab");
            AssertEquals(s, "ab2");
        }

        private string M()
        {
            return "bar";
        }

        public class MyClass
        {
            public string Name { get; set; }

            public Func<string> CreateLambda( )
            {
                return () => Name;
            }
        }

        public class MethodClass
        {
            private string s;

            public MethodClass(string s)
            {
                this.s = s;
            }

            public string M()
            {
                return s;
            }
        }

        [Test]
        public void SetFieldInDelegate()
        {
            var obj = new SetFieldInDelegateClass<string>();
            var action = obj.M();
            action("foo");
            AssertEquals(obj.Field, "foo");
        }

        public class SetFieldInDelegateClass<T>
        {
            public T Field;

            public Action<T> M()
            {
                return x => Field = x;
            }
        }
    }
}
