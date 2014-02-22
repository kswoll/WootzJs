using System.Collections;
using System.Collections.Generic;

namespace System.Linq
{
    internal class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private TKey key;
        private IEnumerable<TElement> elements;

        public Grouping(TKey key, IEnumerable<TElement> elements)
        {
            this.key = key;
            this.elements = elements;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        public TKey Key
        {
            get { return key; }
        }
    }
}