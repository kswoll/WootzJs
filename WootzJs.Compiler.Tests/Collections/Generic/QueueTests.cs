using System;
using System.Collections.Generic;
using System.Linq;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Collections.Generic
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void EnqueueOne()
        {
            var queue = new Queue<string>();
            queue.Enqueue("foo");
            var item = queue.First();
            Assert.AssertEquals(item, "foo");
        }

        [Test]
        public void DequeueOne()
        {
            var queue = new Queue<string>();
            queue.Enqueue("foo");
            var item = queue.Dequeue();

            Assert.AssertEquals(item, "foo");
        }
        
        [Test]
        public void EnqueueTwo()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            queue.Enqueue("two");
            var items = queue.ToArray();
            Assert.AssertEquals(items[0], "one");
            Assert.AssertEquals(items[1], "two");
        }
        
        [Test]
        public void DequeueTwo()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            queue.Enqueue("two");
            Assert.AssertEquals(queue.Dequeue(), "one");
            Assert.AssertEquals(queue.Dequeue(), "two");
        }

        [Test]
        public void Peek()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            var value = queue.Peek();
            Assert.AssertEquals(value, "one");
        }

        [Test]
        public void PeekEmpty()
        {
            var queue = new Queue<string>();
            try
            {
                queue.Peek();
                Assert.AssertTrue(false);
            }
            catch (Exception e)
            {
                Assert.AssertTrue(true);
            }
        }
    }
}