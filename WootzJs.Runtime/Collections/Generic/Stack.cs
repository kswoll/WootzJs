using System.Runtime.WootzJs;

namespace System.Collections.Generic
{
    public class Stack<T> : IEnumerable<T>, ICollection
    {
        private JsArray storage = new JsArray();
 
        public void Push(T item)
        {
            storage.push(item.As<JsObject>());
        }

        public T Pop()
        {
            return storage.pop().As<T>();
        }

        public T Peek()
        {
            if (storage.length == 0)
                throw new InvalidOperationException();
            return storage[storage.length - 1].As<T>();
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
            for (var i = storage.length - 1; i >= 0; i--)
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