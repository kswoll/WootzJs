using System.Collections;
using System.Runtime.WootzJs;

namespace System
{
    internal class ArrayEnumerator : IEnumerator, IDisposable
    {
        private JsArray array;
        private int index = -1;

        public ArrayEnumerator(JsArray array)
        {
            this.array = array;
        }

        public object Current
        {
            get { return array[index]; }
        }

        public bool MoveNext()
        {
            index++;
            return index < array.length;
        }

        public void Dispose()
        {
        }
            
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
