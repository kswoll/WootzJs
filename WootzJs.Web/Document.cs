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

// ReSharper disable UnassignedReadonlyField
namespace WootzJs.Web
{
    [Js(Name = "document", Export = false)]
    public class Document : Element
    {
        [Js(Name = "getElementById")]
        public extern Element GetElementById(string id);

        [Js(Name = "createElement")]
        public extern Element CreateElement(string tagName);

        [Js(Name = "createEvent")]
        public extern Event CreateEvent(string type);

        [Js(Name = "createAttribute")]
        public extern Attr CreateAttribute(string name);

        [Js(Name = "createTextNode")]
        public extern TextNode CreateTextNode(string data);

        [Js(Name = "head")]
        public Element Head;

        [Js(Name = "body")]
        public Element Body;

        [Js(Name = "cookie")]
        public string Cookie;

        [Js(Name = "title")]
        public string Title;

        [Js(Name = "open")]
        public extern void Open();

        [Js(Name = "close")]
        public extern void Close();

        [Js(Name = "write")]
        public extern void Write();

        [Js(Name = "writeln")]
        public extern void WriteLine();

        [Js(Name = "styleSheets")]
        public readonly StyleSheet[] StyleSheets;
    }
}