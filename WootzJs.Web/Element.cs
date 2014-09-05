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
    [Js(Name = "Element", Export = false)]
    public class Element : Node
    {
        public const string InsertPositionBeforeBegin = "beforebegin";
        public const string InsertPositionAfterBegin = "afterbegin";
        public const string InsertPositionBeforeEnd = "beforeend";
        public const string InsertPositionAfterEnd = "afterend";

        [Js(Name = "classList")]
        public extern DomTokenList ClassList { get; }

        [Js(Name = "className")]
        public extern string ClassName { get; set; }

        [Js(Name = "childElementCount")]
        public extern int ChildElementCount { get; }

        [Js(Name = "children")]
        public extern HtmlCollection Children { get; }

        [Js(Name = "firstElementChild")]
        public extern Element FirstElementChild { get; }

        [Js(Name = "lastElementChild")]
        public extern Element LastElementChild { get; }

        [Js(Name = "nextElementSibling")]
        public extern Element NextElementSibling { get; }

        [Js(Name = "previousElementSibling")]
        public extern Element PreviousElementSibling { get; }

        [Js(Name = "id")]
        public extern string Id { get; }

        [Js(Name = "tagName")]
        public extern string TagName { get; }

        [Js(Name = "innerHTML")]
        public extern string InnerHtml { get; set; }

        [Js(Name = "outerHTML")]
        public extern string OuterHtml { get; set; }

        [Js(Name = "addEventListener")]
        public extern void AddEventListener(string type, Action<Event> listener, bool useCapture = false);

        [Js(Name = "dispatchEvent")]
        public extern bool DispatchEvent(Event evt);

        [Js(Name = "getAttribute")]
        public extern string GetAttribute(string name);

        [Js(Name = "getElementsByClassName")]
        public extern HtmlCollection GetElementsByClassName(string className);

        [Js(Name = "getElementsByTagName")]
        public extern HtmlCollection GetElementsByTagName(string tagName);

        [Js(Name = "hasAttribute")]
        public extern bool HasAttribute(string name);

        [Js(Name = "insertAdjacentHTML")]
        public extern void InsertAdjacentHtml(string position, string html);

        [Js(Name = "querySelector")]
        public extern Node QuerySelector(string selectors);

        [Js(Name = "querySelectorAll")]
        public extern NodeList QuerySelectorAll(string selectors);

        [Js(Name = "removeAttribute")]
        public extern void RemoveAttribute(string name);

        [Js(Name = "removeEventListener")]
        public extern void RemoveEventListener(string type, Action<Event> listener, bool useCapture = false);

        [Js(Name = "setAttribute")]
        public extern void SetAttribute(string name, string value);

        [Js(Name = "style")]
        public extern ElementStyle Style { get; }

        [Js(Name = "offsetWidth")]
        public extern int OffsetWidth { get; set; }

        [Js(Name = "offsetHeight")]
        public extern int OffsetHeight { get; set; }

        [Js(Name = "title")]
        public extern string Title { get; set; }

        [Js(Name = "focus")]
        public extern void Focus();
    }
}