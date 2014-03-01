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
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    /// <summary>
    /// Establishes a header that can be populated with arbitrary content and that can
    /// animate downwards when content is populated and animate upward when content is
    /// cleared.  This is useful for showing validation failures.
    /// </summary>
    public class SlideDownHeaderPanel : Control
    {
        private Element headerDiv;
        private Element headerContainerDiv;
        private Element contentDiv;
        private Control header;
        private Control content;

        protected override Element CreateNode()
        {
            headerDiv = Browser.Document.CreateElement("div");
            headerDiv.Style.Position = "absolute";
            headerDiv.Style.Width = "100%";

            headerContainerDiv = Browser.Document.CreateElement("div");
            headerContainerDiv.Style.Position = "relative";
            headerContainerDiv.Style.Overflow = "hidden";
            headerContainerDiv.Style.ZIndex = "-1";
            headerContainerDiv.AppendChild(headerDiv);

            contentDiv = Browser.Document.CreateElement("div");
            
            var result = Browser.Document.CreateElement("div");
            result.AppendChild(headerContainerDiv);
            result.AppendChild(contentDiv);

            return result;
        }   

        public Control Header
        {
            get { return header; }
            set
            {
                if (header != null)
                {
                    SlideUp();
                    headerDiv.RemoveChild(header.Node);
                    Remove(header);
                }
                header = value;
                if (header != null)
                {
                    headerDiv.AppendChild(header.Node);
                    Add(header);
                    SlideDown();
                }
            }
        }

        public Control Content
        {
            get { return content; }
            set
            {
                if (content != null)
                {
                    contentDiv.RemoveChild(content.Node);
                    Remove(content);
                }
                content = value;
                if (content != null)
                {
                    contentDiv.AppendChild(content.Node);
                    Add(content);
                }
            }
        }

        private const double duration = 300; // milliseconds

        public void SlideUp()
        {
            headerDiv.Style.Position = "absolute";
            headerContainerDiv.Style.Height = "0px";
        }

        public void SlideDown()
        {
            var height = headerDiv.OffsetHeight;
            headerDiv.Style.Top = -height + "px";
            headerDiv.Style.Position = "absolute";

            int? start = null;
            Action<int> step = null;
            step = timestamp =>
            {
                start = start ?? timestamp;
                var progress = Math.Min((timestamp - start.Value) / duration * height, height);
                headerDiv.Style.Top = (-height + progress) + "px";
                headerContainerDiv.Style.Height = progress + "px";
                if (progress < height)
                {
                    Browser.Window.RequestAnimationFrame(step);
                }
                else
                {
                    // Reset the style so that it fits into the normal HTML flow.  This ensure that,
                    // after animating, the slid-down content will resize, refit its contents, etc. 
                    // if the window resizes.
                    headerDiv.Style.Position = "relative";
                    headerContainerDiv.Style.Height = "inherit";
                }
            };
            Browser.Window.RequestAnimationFrame(step);
        }
    }
}