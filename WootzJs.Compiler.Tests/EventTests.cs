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

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class EventTests
    {
        [Test]
        public void BasicEvent()
        {
            var o = new EventClass();
            var success = false;
            o.Foo += () => success = true;
            o.OnFoo();
            QUnit.IsTrue(success);
        }                  

        [Test]
        public void BasicEventExplicitThis()
        {
            var o = new EventClass();
            var success = false;
            o.FooThis += () => success = true;
            o.OnFooThis();
            QUnit.IsTrue(success);
        }                  

        [Test]
        public void MulticastEvent()
        {
            var o = new EventClass();
            var success1 = false;
            var success2 = false;
            o.Foo += () => success1 = true;
            o.Foo += () => success2 = true;
            o.OnFoo();
            QUnit.IsTrue(success1);
            QUnit.IsTrue(success2);
        }                  

        [Test]
        public void MulticastEventRemove()
        {
            var o = new EventClass();
            var success1 = false;
            var success2 = false;
            Action foo1 = () => success1 = true;
            o.Foo += foo1;
            o.Foo += () => success2 = true;
            o.Foo -= foo1;
            o.OnFoo();
            QUnit.IsTrue(!success1);
            QUnit.IsTrue(success2);
        }        
        
        [Test]
        public void EventAccessor()
        {
            var eventClass = new EventClass();
            var ran = false;
            Action evt = () => ran = true;
            eventClass.Bar += evt;
            eventClass.OnBar();
            QUnit.IsTrue(ran);

            ran = false;
            eventClass.Bar -= evt;
            eventClass.OnBar();
            QUnit.IsTrue(!ran);
        }

        [Test]
        public void MulticastEventKeepsDelegateType()
        {
            var i = 0;
            var eventClass = new EventClass();
            eventClass.Foo += () => i++;
            eventClass.Foo += () => i++;
            var action = eventClass.GetFoo();
            QUnit.IsTrue(action is Action);
        }

        public class EventClass
        {
            public event Action Foo;

            private Action bar;

            public void OnFoo()
            {
                if (Foo != null)
                    Foo();
            }

            public Action GetFoo()
            {
                return Foo;
            }

            public event Action FooThis;

            public void OnFooThis()
            {
                if (this.FooThis != null)
                    this.FooThis();
            }

            public event Action Bar
            {
                add { bar = (Action)Delegate.Combine(bar, value); }
                remove { bar = null; }
            }

            public void OnBar()
            {
                if (bar != null)
                    bar();
            }
        } 
    }
}
