#region License

//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------

#endregion

using System.Runtime.WootzJs;

namespace System.Collections.Generic
{
    public class List<T> : IList<T>, IReadOnlyList<T>, IList
    {
        private JsArray storage = new JsArray();

        public List()
        {
        }

        public List(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
        }

        public int Count
        {
            get { return storage.length; }
        }

        public bool IsSynchronized
        {
            get { return true; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            for (var i = index; i < array.Length; i++)
            {
                array[i] = this[i - index];
            }
        }

        object IList.this[int index]
        {
            get { return this[index]; }
            set { this[index] = (T)value; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public int Add(object value)
        {
            storage.push(value.As<JsObject>());
            return storage.length;
        }

        public bool Contains(object value)
        {
            return storage.indexOf(value.As<JsObject>()) >= 0;
        }

        public void Clear()
        {
            storage.length = 0;
        }

        public int IndexOf(object value)
        {
            return storage.indexOf(value.As<JsObject>());
        }

        public void Insert(int index, object value)
        {
            storage.splice(index, 0, value.As<JsObject>());
        }

        public void Remove(object value)
        {
            var index = IndexOf(value);
            if (index >= 0)
                RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            storage.splice(index, 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator(this);
        }

        public void Add(T item)
        {
            storage.push(item.As<JsObject>());
        }

        public bool Contains(T item)
        {
            return storage.indexOf(item.As<JsObject>()) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (var i = arrayIndex; i < array.Length; i++)
            {
                array[i] = this[i - arrayIndex];
            }
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public T this[int index]
        {
            get { return storage[index].As<T>(); }
            set { storage[index] = value.As<JsObject>(); }
        }

        public int IndexOf(T item)
        {
            return storage.indexOf(item.As<JsObject>());
        }

        public void Insert(int index, T item)
        {
            storage.splice(index, 0, item.As<JsObject>());
        }

        /// <summary>
        /// Sorts the elements in the entire <see cref="T:System.Collections.Generic.List`1"/> using the default comparer.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The default comparer <see cref="P:System.Collections.Generic.Comparer`1.Default"/> cannot find an implementation of the <see cref="T:System.IComparable`1"/> generic interface or the <see cref="T:System.IComparable"/> interface for type <paramref name="T"/>.</exception>
        public void Sort()
        {
            Sort(Comparer<T>.Default);
        }

        /// <summary>
        /// Sorts the elements in the entire <see cref="T:System.Collections.Generic.List`1"/> using the specified comparer.
        /// </summary>
        /// <param name="comparer">The <see cref="T:System.Collections.Generic.IComparer`1"/> implementation to use when comparing elements, or null to use the default comparer <see cref="P:System.Collections.Generic.Comparer`1.Default"/>.</param><exception cref="T:System.InvalidOperationException"><paramref name="comparer"/> is null, and the default comparer <see cref="P:System.Collections.Generic.Comparer`1.Default"/> cannot find implementation of the <see cref="T:System.IComparable`1"/> generic interface or the <see cref="T:System.IComparable"/> interface for type <paramref name="T"/>.</exception><exception cref="T:System.ArgumentException">The implementation of <paramref name="comparer"/> caused an error during the sort. For example, <paramref name="comparer"/> might not return 0 when comparing an item with itself.</exception>
        public void Sort(IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException("comparer");
            if (Count <= 0)
                return;
            storage.sort(Jsni.function((x, y) => comparer.Compare(x.As<T>(), y.As<T>()).As<JsNumber>()));
        }

        /// <summary>
        /// Sorts the elements in the entire <see cref="T:System.Collections.Generic.List`1"/> using the specified <see cref="T:System.Comparison`1"/>.
        /// </summary>
        /// <param name="comparison">The <see cref="T:System.Comparison`1"/> to use when comparing elements.</param><exception cref="T:System.ArgumentNullException"><paramref name="comparison"/> is null.</exception><exception cref="T:System.ArgumentException">The implementation of <paramref name="comparison"/> caused an error during the sort. For example, <paramref name="comparison"/> might not return 0 when comparing an item with itself.</exception>
        public void Sort(Comparison<T> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException("comparison");
            Sort(new ComparisonComparer<T>(comparison));
        }

        private class ListEnumerator : IEnumerator<T>
        {
            private int index = -1;
            private List<T> list;

            public ListEnumerator(List<T> list)
            {
                this.list = list;
            }

            public void Dispose()
            {
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                index++;
                return index < list.Count;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public T Current
            {
                get { return list[index]; }
            }
        }
    }
}