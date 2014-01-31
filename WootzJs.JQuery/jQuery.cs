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
using WootzJs.Web;

namespace WootzJs.JQuery
{
    [Js(Export = false, Name = "$", InvokeConstructorAsClass = true)]
    public class jQuery
    {
        public jQuery(string selector)
        {
        }

        public jQuery(Element element)
        {
        }

        [Js(Name = "append")]
        public extern jQuery append(jQuery content);
        [Js(Name = "append")]
        public extern jQuery append(string content);
        public extern jQuery prepend(jQuery content);
        public extern jQuery insertAfter(jQuery target);
        public extern jQuery insertBefore(jQuery target);
        public extern jQuery empty();
        public extern jQuery remove(jQuery selector = null);
        [Js(Name = "text")]
        public extern string text();
        [Js(Name = "text")]
        public extern string text(string newText);

        [Js(Name = "val")]
        public extern string val();
        [Js(Name = "val")]
        public extern void val(string value);
        [Js(Name = "prop")]
        public extern object prop(string attributeName);
        [Js(Name = "prop")]
        public extern void prop(string attributeName, object value);
        [Js(Name = "attr")]
        public extern string attr(string attributeName);
        [Js(Name = "attr")]
        public extern void attr(string attributeName, object value);
        public extern bool @is(string selector);
        [Js(Name = "css")]
        public extern string css(string name);
        [Js(Name = "css")]
        public extern void css(string name, string value);
        [Js(Name = "css")]
        public extern void css(string name, JsNumber value);
        public extern void unbind(string eventName, JqEventHandler eventHandler);
        public extern void click(JqEventHandler handler);
        public extern void change(JqEventHandler handler);
        public extern void mouseenter(JqEventHandler handler);
        public extern void mouseleave(JqEventHandler handler);
    }
}