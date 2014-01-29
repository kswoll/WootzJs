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

        public extern JsObject pop();

        [Js(Name = "indexOf")]
        public int indexOf(JsObject o)
        {
            return 0;
        }

        public extern void unshift(params JsObject[] prepend);
        public extern JsObject shift(params JsObject[] prepend);
    }
}
