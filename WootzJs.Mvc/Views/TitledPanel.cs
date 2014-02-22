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
    public class TitledPanel : Control
    {
        private Element legend;
        private Element contentDiv;
        private Control content;

        public TitledPanel() 
        {
        }

        public TitledPanel(string title) 
        {
            Title = title;
        }

        protected override Element CreateNode()
        {
            legend = Browser.Document.CreateElement("legend");
            contentDiv = Browser.Document.CreateElement("div");

            var fieldset = Browser.Document.CreateElement("fieldset");
            fieldset.Style.BorderColor = "threedface";
            fieldset.Style.BorderWidth = "2px";
            fieldset.Style.BorderStyle = "groove";
            fieldset.Style.Padding = "10px";
            fieldset.AppendChild(legend);
            fieldset.AppendChild(contentDiv);
            return fieldset;
        }

        public string Title
        {
            get
            {
                EnsureNodeExists();
                return legend.InnerHtml;
            }
            set
            {
                EnsureNodeExists();
                legend.InnerHtml = value;
            }
        }

        public Control Content
        {
            get { return content; }
            set
            {
                if (content != null)
                {
                    Remove(content);
                    contentDiv.RemoveChild(content.Node);
                }
                content = value;
                if (content != null)
                {
                    contentDiv.AppendChild(content.Node);
                    Add(content);
                }
            }
        }
    }
}