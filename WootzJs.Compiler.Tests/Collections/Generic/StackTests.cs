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
            Assert.AssertEquals(item, "foo");
        }

        [Test]
        public void PopOne()
        {
            var stack = new Stack<string>();
            stack.Push("foo");
            var item = stack.Pop();

            Assert.AssertEquals(item, "foo");
        }
        
        [Test]
        public void PushTwo()
        {
            var stack = new Stack<string>();
            stack.Push("one");
            stack.Push("two");
            var items = stack.ToArray();
            Assert.AssertEquals(items[0], "two");
            Assert.AssertEquals(items[1], "one");
        }

        [Test]
        public void Peek()
        {
            var stack = new Stack<string>();
            stack.Push("one");
            var value = stack.Peek();
            Assert.AssertEquals(value, "one");
        }

        [Test]
        public void PeekEmpty()
        {
            var stack = new Stack<string>();
            try
            {
                stack.Peek();
                Assert.AssertTrue(false);
            }
            catch (Exception e)
            {
                Assert.AssertTrue(true);
            }
        }
    }
}