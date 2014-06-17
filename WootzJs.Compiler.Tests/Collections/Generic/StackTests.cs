using System;
using System.Collections.Generic;
using System.Linq;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Collections.Generic
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void PushOne()
        {
            var stack = new Stack<string>();
            stack.Push("foo");
            var item = stack.First();
            item.AssertEquals("foo");
        }

        [Test]
        public void PopOne()
        {
            var stack = new Stack<string>();
            stack.Push("foo");
            var item = stack.Pop();

            item.AssertEquals("foo");
        }
        
        [Test]
        public void PushTwo()
        {
            var stack = new Stack<string>();
            stack.Push("one");
            stack.Push("two");
            var items = stack.ToArray();
            items[0].AssertEquals("two");
            items[1].AssertEquals("one");
        }

        [Test]
        public void Peek()
        {
            var stack = new Stack<string>();
            stack.Push("one");
            var value = stack.Peek();
            value.AssertEquals("one");
        }

        [Test]
        public void PeekEmpty()
        {
            var stack = new Stack<string>();
            try
            {
                stack.Peek();
                false.AssertTrue();
            }
            catch (Exception e)
            {
                true.AssertTrue();
            }
        }
    }
}