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

using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    /// <summary>
    /// Provides a header that remains fixed when scrolling vertically.
    /// </summary>
    public class FixedHeaderPanel : Control
    {
        private Control header;
        private Control content;
        private Element headerNode;
        private Element contentNode;

        public Control Header
        {
            get { return header; }
            set
            {
                EnsureNodeExists();
                if (header != null)
                {
                    Remove(header);
                    headerNode.Clear();
                }
                header = value;
                if (value != null)
                {
                    headerNode.AppendChild(value.Node);
                    if (IsAttachedToDom)
                        FixHeight();
                    else
                        value.AttachedToDom += FixHeight;
                    Add(header);
                }
            }
        }

        private void FixHeight()
        {
            contentNode.Style.PaddingTop = header.Node.OffsetHeight + "px";
            header.AttachedToDom -= FixHeight;
        }

        public Control Content
        {
            get { return content; }
            set
            {
                EnsureNodeExists();
                if (content != null)
                {
                    Remove(content);
                    contentNode.Clear();
                }
                content = value;
                if (value != null)
                {
                    contentNode.AppendChild(value.Node);
                    Add(content);
                }
            }
        }

        protected override Element CreateNode()
        {
            headerNode = Browser.Document.CreateElement("div");
            headerNode.Style.Width = "100%";
            headerNode.Style.Position = "fixed";

            contentNode = Browser.Document.CreateElement("div");
            contentNode.Style.Height = "100%";

            var result = Browser.Document.CreateElement("div");
            result.Style.Height = "100%";
            result.AppendChild(headerNode);
            result.AppendChild(contentNode);

            return result;
        }
    }
}