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
            item.AssertEquals("foo");
        }

        [Test]
        public void DequeueOne()
        {
            var queue = new Queue<string>();
            queue.Enqueue("foo");
            var item = queue.Dequeue();

            item.AssertEquals("foo");
        }
        
        [Test]
        public void EnqueueTwo()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            queue.Enqueue("two");
            var items = queue.ToArray();
            items[0].AssertEquals("one");
            items[1].AssertEquals("two");
        }
        
        [Test]
        public void DequeueTwo()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            queue.Enqueue("two");
            queue.Dequeue().AssertEquals("one");
            queue.Dequeue().AssertEquals("two");
        }

        [Test]
        public void Peek()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            var value = queue.Peek();
            value.AssertEquals("one");
        }

        [Test]
        public void PeekEmpty()
        {
            var queue = new Queue<string>();
            try
            {
                queue.Peek();
                false.AssertTrue();
            }
            catch (Exception e)
            {
                true.AssertTrue();
            }
        }
    }
}