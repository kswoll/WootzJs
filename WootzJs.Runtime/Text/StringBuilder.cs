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
