using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.WootzJs;

namespace System
{
    public abstract class YieldIterator<T> : IEnumerable<T>, IEnumerator<T>
    {
        public T Current { get; protected set; }

        public abstract IEnumerator<T> GetEnumerator();
        public abstract bool MoveNext();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}