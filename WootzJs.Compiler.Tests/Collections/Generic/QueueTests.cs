using System;
using System.Collections.Generic;
using System.Linq;

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
            QUnit.AreEqual(item, "foo");
        }

        [Test]
        public void DequeueOne()
        {
            var queue = new Queue<string>();
            queue.Enqueue("foo");
            var item = queue.Dequeue();

            QUnit.AreEqual(item, "foo");
        }
        
        [Test]
        public void EnqueueTwo()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            queue.Enqueue("two");
            var items = queue.ToArray();
            QUnit.AreEqual(items[0], "one");
            QUnit.AreEqual(items[1], "two");
        }
        
        [Test]
        public void DequeueTwo()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            queue.Enqueue("two");
            QUnit.AreEqual(queue.Dequeue(), "one");
            QUnit.AreEqual(queue.Dequeue(), "two");
        }

        [Test]
        public void Peek()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            var value = queue.Peek();
            QUnit.AreEqual(value, "one");
        }

        [Test]
        public void PeekEmpty()
        {
            var queue = new Queue<string>();
            try
            {
                queue.Peek();
                QUnit.IsTrue(false);
            }
            catch (Exception e)
            {
                QUnit.IsTrue(true);
            }
        }
    }
}