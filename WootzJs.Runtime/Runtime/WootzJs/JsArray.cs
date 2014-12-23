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
    [Js(Name = "Array", Export = false)]
    public class JsArray : JsObject
    {
        public JsArray()
        {
        }

        public JsArray(int size)
        {
        }

        public extern JsObject this[int index] { get; set; }
        public extern int length { get; set; }

        [Js(Name = "join")]
        public extern JsString join();

        [Js(Name = "join")]
        public extern JsString join(JsString separator);

        [Js(Name = "slice")]
        public extern JsArray slice(int start, int end = 0);

        [Js(Name = "splice")]
        public extern void splice(int index, int howManyToRemove, params JsObject[] elements);

        [Js(Name = "push")]
        public extern void push(params JsObject[] elements);

        public extern JsObject pop();

        [Js(Name = "indexOf")]
        public extern int indexOf(JsObject o);

        public extern void unshift(params JsObject[] prepend);
        public extern JsObject shift(params JsObject[] prepend);

        public extern void sort(JsFunction compareFunction);

        public extern JsArray concat(JsObject elements);
        public extern JsArray concat(JsObject[] elements);
    }
}
