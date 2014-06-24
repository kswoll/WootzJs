using System;
using System.Collections.Generic;
using System.Linq;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Collections.Generic
{
    public class StackTests : TestFixture
    {
        [Test]
        public void PushOne()
        {
            var stack = new Stack<string>();
            stack.Push("foo");
            var item = stack.First();
            AssertEquals(item, "foo");
        }

        [Test]
        public void PopOne()
        {
            var stack = new Stack<string>();
            stack.Push("foo");
            var item = stack.Pop();

            AssertEquals(item, "foo");
        }
        
        [Test]
        public void PushTwo()
        {
            var stack = new Stack<string>();
            stack.Push("one");
            stack.Push("two");
            var items = stack.ToArray();
            AssertEquals(items[0], "two");
            AssertEquals(items[1], "one");
        }

        [Test]
        public void Peek()
        {
            var stack = new Stack<string>();
            stack.Push("one");
            var value = stack.Peek();
            AssertEquals(value, "one");
        }

        [Test]
        public void PeekEmpty()
        {
            var stack = new Stack<string>();
            try
            {
                stack.Peek();
                AssertTrue(false);
            }
            catch (Exception e)
            {
                AssertTrue(true);
            }
        }
    }
}