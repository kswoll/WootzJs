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
    [Js(Export = false)]
    public class Node
    {
        [Js(Name = "childNodes")]
        public extern NodeList ChildNodes { get; }

        [Js(Name = "firstChild")]
        public extern Node FirstChild { get; }

        [Js(Name = "lastChild")]
        public extern Node LastChild { get; }

        [Js(Name = "nextSibling")]
        public extern Node NextSibling { get; }

        [Js(Name = "nodeType")]
        public extern NodeType NodeType { get; }

        [Js(Name = "nodeValue")]
        public extern string NodeValue { get; set; }

        [Js(Name = "ownerDocument")]
        public extern Document OwnerDocument { get; }

        [Js(Name = "parentNode")]
        public extern Node ParentNode { get; }

        [Js(Name = "parentElement")]
        public extern Element ParentElement { get; }

        [Js(Name = "previousSibling")]
        public extern Node PreviousSibling { get; }

        [Js(Name = "appendChild")]
        public extern void AppendChild(Node child);

        [Js(Name = "cloneNode")]
        public extern Node CloneNode(bool deep);

        [Js(Name = "contains")]
        public extern bool Contains(Node node);

        [Js(Name = "hasChildNodes")]
        public extern bool HasChildNodes();

        [Js(Name = "insertBefore")]
        public extern void InsertBefore(Node newNode, Node referenceNode);

        [Js(Name = "isEqualNode")]
        public extern bool IsEqualNode(Node node);

        [Js(Name = "normalize")]
        public extern void Normalize();

        [Js(Name = "removeChild")]
        public extern void RemoveChild(Node node);

        [Js(Name = "replaceChild")]
        public extern Node ReplaceChild(Node newChild, Node oldChild);
    }
}