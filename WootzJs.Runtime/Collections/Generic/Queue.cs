using System.Runtime.WootzJs;

namespace System.Collections.Generic
{
    public class Queue<T> : IEnumerable<T>, ICollection
    {
        private JsArray storage = new JsArray();

        public Queue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Collections.Generic.Queue`1"/> class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new <see cref="T:System.Collections.Generic.Queue`1"/>.</param><exception cref="T:System.ArgumentNullException"><paramref name="collection"/> is null.</exception>
        public Queue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            foreach (T obj in collection)
                Enqueue(obj);
        }

        public void Enqueue(T item)
        {
            storage.push(item.As<JsObject>());
        }

        public T Dequeue()
        {
            return storage.shift().As<T>();
        }

        public T Peek()
        {
            if (storage.length == 0)
                throw new InvalidOperationException();
            return storage[0].As<T>();
        }

        public T Peek(int lookAhead = 0)
        {
            if (lookAhead >= storage.length || lookAhead < 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return storage[lookAhead].As<T>();
            }
        }

        public int Count
        {
            get { return storage.length; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerable().GetEnumerator();
        }

        private IEnumerable<T> GetEnumerable()
        {
            for (var i = 0; i < storage.length; i++)
            {
                yield return storage[i].As<T>();
            }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public bool IsSynchronized
        {
            get { return true; }
        }

        public void CopyTo(Array array, int index)
        {
            for (int i = 0, j = index; index < array.Length && i < storage.length; i++, j++)
            {
                array[index] = storage[i];
            }
        }
    }
}