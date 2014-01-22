using System.Collections;
using System.Collections.Generic;

namespace System.Runtime.WootzJs
{
    [Js(Name = "Array", Export = false)]
    public class JsArray : JsObject
    {
        public JsObject this[int index]
        {
            get { return null; }
            set {}
        }

        [Js(Name = "length")]
        public int length
        {
            get { return 0; }
            set { }
        }

        [Js(Name = "join")]
        public JsString join()
        {
            return null;
        }

        [Js(Name = "join")]
        public JsString join(JsString separator)
        {
            return null;
        }

        [Js(Name = "slice")]
        public JsArray slice(int start, int end = 0)
        {
            return null;
        }

        [Js(Name = "splice")]
        public void splice(int index, int howManyToRemove, params JsObject[] elements)
        {
        }

        [Js(Name = "push")]
        public void push(params JsObject[] elements)
        {
        }

        [Js(Name = "indexOf")]
        public int indexOf(JsObject o)
        {
            return 0;
        }
    }
}
