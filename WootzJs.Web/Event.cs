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

using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "Event", Export = false)]
    public class Event
    {
        public Event()
        {
        }

        public Event(string name)
        {
        }

        [Js(Name = "bubbles")]
        public extern bool Bubbles { get; set; }

        [Js(Name = "cancelable")]
        public extern bool Cancelable { get; set; }

        [Js(Name = "currentTarget")]
        public extern Element CurrentTarget { get; set; }

        [Js(Name = "defaultPrevented")]
        public extern bool DefaultPrevented { get; }

        [Js(Name = "target")]
        public extern Element Target { get; }

        [Js(Name = "relatedTarget")]
        public extern Element RelatedTarget { get; }

        [Js(Name = "type")]
        public extern string Type { get; }

        [Js(Name = "preventDefault")]
        public extern void PreventDefault();

        [Js(Name = "stopImmediatePropagation")]
        public extern void StopImmediatePropagation();

        [Js(Name = "stopPropagation")]
        public extern void StopPropagation();
    }
}