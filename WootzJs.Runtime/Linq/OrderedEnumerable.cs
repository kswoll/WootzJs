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

using System.Collections;
using System.Collections.Generic;

namespace System.Linq
{
    public class OrderedEnumerable<T> : IOrderedEnumerable<T>
    {
        private List<IComparer> comparers;
        private IEnumerable<T> source;
        private List<T> storage;

        private OrderedEnumerable(IEnumerable<T> source, IComparer[] comparers)
        {
            this.source = source;
            this.comparers = comparers.ToList();
        }

        internal static OrderedEnumerable<T> Create<TKey>(IEnumerable<T> source, 
            Func<T, TKey> keySelector, IComparer<TKey> comparer, bool isDescending)
        {
            return new OrderedEnumerable<T>(source, new IComparer[] { new KeyComparer<T, TKey>(keySelector, comparer, isDescending) });
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (storage == null)
            {
                storage = source.ToList();
                storage.Sort((x, y) =>
                {
                    foreach (var comparer in comparers)
                    {
                        var result = comparer.Compare(x, y);
                        if (result != 0)
                            return result;
                    }
                    return 0;
                });
            }
            return storage.GetEnumerator();
        }

        public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            return new OrderedEnumerable<T>(source, comparers.Concat(new IComparer[] { new KeyComparer<T, TKey>(keySelector, comparer, descending) }).ToArray());
        }

        private class KeyComparer<T, TKey> : IComparer
        {
            private Func<T, TKey> keySelector;
            private IComparer<TKey> comparer;
            private bool isDescending;

            public KeyComparer(Func<T, TKey> keySelector, IComparer<TKey> comparer, bool isDescending)
            {
                this.keySelector = keySelector;
                this.comparer = comparer;
                this.isDescending = isDescending;
            }

            public int Compare(object x, object y)
            {
                var xKey = keySelector((T)x);
                var yKey = keySelector((T)y);
                var result = comparer.Compare(xKey, yKey);
                if (isDescending)
                    result = -result;
                return result;
            }
        }
    }
}