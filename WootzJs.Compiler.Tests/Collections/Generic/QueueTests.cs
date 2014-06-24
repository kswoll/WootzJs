using System;
using System.Collections.Generic;
using System.Linq;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Collections.Generic
{
    public class QueueTests : TestFixture
    {
        [Test]
        public void EnqueueOne()
        {
            var queue = new Queue<string>();
            queue.Enqueue("foo");
            var item = queue.First();
            AssertEquals(item, "foo");
        }

        [Test]
        public void DequeueOne()
        {
            var queue = new Queue<string>();
            queue.Enqueue("foo");
            var item = queue.Dequeue();

            AssertEquals(item, "foo");
        }
        
        [Test]
        public void EnqueueTwo()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            queue.Enqueue("two");
            var items = queue.ToArray();
            AssertEquals(items[0], "one");
            AssertEquals(items[1], "two");
        }
        
        [Test]
        public void DequeueTwo()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            queue.Enqueue("two");
            AssertEquals(queue.Dequeue(), "one");
            AssertEquals(queue.Dequeue(), "two");
        }

        [Test]
        public void Peek()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            var value = queue.Peek();
            AssertEquals(value, "one");
        }

        [Test]
        public void PeekEmpty()
        {
            var queue = new Queue<string>();
            try
            {
                queue.Peek();
                AssertTrue(false);
            }
            catch (Exception e)
            {
                AssertTrue(true);
            }
        }
    }
}