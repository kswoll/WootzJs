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

namespace System.Runtime.WootzJs
{
    [Js(Name = "Object", Export = false)]
    public class JsObject : IEnumerable<string>
    {
        public extern JsObject this[JsObject key] { get; set; }
        public extern JsObject this[JsString key] { get; set; }
        public extern JsString toString();
        public extern IEnumerator<string> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static implicit operator JsObject(bool value)
        {
            return value.As<JsObject>();
        }

        public static implicit operator JsObject(string value)
        {
            return value.As<JsObject>();
        }

        public static implicit operator bool(JsObject value)
        {
            return value.As<bool>();
        }

        public static implicit operator int(JsObject value)
        {
            return value.As<int>();
        }

        public static implicit operator short(JsObject value)
        {
            return value.As<short>();
        }

        public static implicit operator byte(JsObject value)
        {
            return value.As<byte>();
        }

        public static implicit operator long(JsObject value)
        {
            return value.As<long>();
        }

        public static implicit operator float(JsObject value)
        {
            return value.As<float>();
        }

        public static implicit operator double(JsObject value)
        {
            return value.As<double>();
        }
    }
}