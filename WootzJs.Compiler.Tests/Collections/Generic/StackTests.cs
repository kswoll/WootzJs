using System;
using System.Collections.Generic;
using System.Linq;

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
            QUnit.AreEqual(item, "foo");
        }

        [Test]
        public void PopOne()
        {
            var stack = new Stack<string>();
            stack.Push("foo");
            var item = stack.Pop();

            QUnit.AreEqual(item, "foo");
        }
        
        [Test]
        public void PushTwo()
        {
            var stack = new Stack<string>();
            stack.Push("one");
            stack.Push("two");
            var items = stack.ToArray();
            QUnit.AreEqual(items[0], "two");
            QUnit.AreEqual(items[1], "one");
        }

        [Test]
        public void Peek()
        {
            var stack = new Stack<string>();
            stack.Push("one");
            var value = stack.Peek();
            QUnit.AreEqual(value, "one");
        }

        [Test]
        public void PeekEmpty()
        {
            var stack = new Stack<string>();
            try
            {
                stack.Peek();
                QUnit.IsTrue(false);
            }
            catch (Exception e)
            {
                QUnit.IsTrue(true);
            }
        }
    }
}