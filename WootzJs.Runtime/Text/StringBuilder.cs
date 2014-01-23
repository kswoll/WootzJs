using System.Collections.Generic;
using System.Linq;
using System.Runtime.WootzJs;

namespace System.Text
{
    public class StringBuilder
    {
        private JsArray chunks = new Array().As<JsArray>();

        public void Append(char c)
        {
            chunks.push(c.As<JsObject>());
        }

        public void Append(string s)
        {
            chunks.push(s.As<JsObject>());
        }

        public void Append(object o)
        {
            if (o != null)
                chunks.push(o.ToString().As<JsObject>());
        }

        public void AppendLine()
        {
            chunks.push("\n".As<JsObject>());
        }

        public void AppendLine(char c)
        {
            chunks.push(c.As<JsObject>());
            chunks.push("\n".As<JsObject>());
        }

        public void AppendLine(string s)
        {
            chunks.push(s.As<JsObject>());
            chunks.push("\n".As<JsObject>());
        }

        public override string ToString()
        {
            return chunks.join("".As<JsString>());
        }
    }
}
