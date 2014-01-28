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

namespace System.Runtime.WootzJs
{
    [Js(Name = "String", Export = false)]
    public class JsString : JsObject
    {
        [Js(Name = "length")]
        public readonly JsNumber length;

        [Js(Name = "substring")]
        public extern string substring(int startIndex, int endIndex = 0);

        [Js(Name = "split")]
        public extern JsArray split(string separator, int count = 0);

        [Js(Name = "split")]
        public extern JsArray split(JsRegExp separator, int count = 0);

        [Js(Name = "charCodeAt")]
        public extern int charCodeAt(int index);

        [Js(Name = "charAt")]
        public extern char charAt(int index);

        public extern int indexOf(JsString substring);

        [Js(Name = "replace")]
        public extern JsString replace(JsRegExp regexp, JsString replaceWith);

        [Js(Name = "replace")]
        public extern JsString replace(JsString substring, JsString replaceWith);

        [Js(Name = "replace")]
        public extern JsString replace(JsRegExp regexp, JsFunction replaceWith);

        [Js(Name = "replace")]
        public extern JsString replace(JsString substring, JsFunction replaceWith);

        public static implicit operator string(JsString s)
        {
            return s.As<string>();
        }

        public static implicit operator JsString(string s)
        {
            return s.As<JsString>();
        }
    }
}
