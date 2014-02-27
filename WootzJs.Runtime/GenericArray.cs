using System.Collections;
using System.Collections.Generic;
using System.Runtime.WootzJs;

namespace System
{
    public class GenericArray<T> : Array, IReadOnlyList<T>
    {
        public new IEnumerator<T> GetEnumerator()
        {
            var array = this.As<JsArray>();
            return new ArrayEnumerator<T>(array);            
        }

        T IReadOnlyList<T>.this[int index]
        {
            get
            {
                var array = this.As<JsArray>();
                var result = array[index];
                return result.As<T>();
            }
        }
    }
}