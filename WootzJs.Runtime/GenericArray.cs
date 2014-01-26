using System.Collections;
using System.Collections.Generic;
using System.Runtime.WootzJs;

namespace System
{
    public class GenericArray<T> : Array, IEnumerable<T>
    {
        public new IEnumerator<T> GetEnumerator()
        {
            var array = this.As<JsArray>();
            return new ArrayEnumerator<T>(array);            
        }
    }
}