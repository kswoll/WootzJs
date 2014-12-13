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

using System;
using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "window", Export = false)]
    public class Window : Element
    {
        [Js(Name = "location")]
        public extern Location Location { get; set; }

        [Js(Name = "onpopstate")]
        public extern PopStateEventHandler OnPopState { get; set; }

        [Js(Name = "history")]
        public extern History History { get; }

        [Js(Name = "requestAnimationFrame")]
        public extern int RequestAnimationFrame(Action<int> step);

        [Js(Name = "navigator")]
        public extern Navigator Navigator { get; }

        [Js(Name = "alert")]
        public extern void Alert(string message);

        [Js(Name = "confirm")]
        public extern bool Confirm(string message);
    }
}