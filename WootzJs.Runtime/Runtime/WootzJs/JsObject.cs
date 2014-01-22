using System.Collections;
using System.Collections.Generic;

namespace System.Runtime.WootzJs
{
    [Js(Name = "Object", Export = false)]
    public class JsObject : IEnumerable<string>
    {
        public JsObject this[JsObject key]
        {
            get { return null; }
            set { }
        }

        public JsObject this[JsString key]
        {
            get { return null; }
            set { }
        }

        public JsString toString()
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
