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

using System.Linq;
using WootzJs.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    /// <summary>
    /// A control that renders each successive pairs added to it as a label
    /// and a value.  This control uses a TablePanel to align the labels in
    /// one column with each label aligned right and the values in the right
    /// column occupying the remaining width aligned left.
    /// </summary>
    public class NameValuePanel : Control
    {
        private TablePanel table;

        public NameValuePanel() 
        {
            table = new TablePanel(TableWidth.Preferred(), TableWidth.Weight());
            table.CellSpacing = 10;
        }

        public int Spacing
        {
            get { return table.CellSpacing; }
            set { table.CellSpacing = value; }
        }

        protected override Element CreateNode()
        {
            table.Node.Style.Width = "100%";
            table.Node.Style.Height = "100%";

            var result = Browser.Document.CreateElement("div");
            result.AppendChild(table.Node);

            return result;
        }

        public new void Add(Control control)
        {
            var isNameControl = Count % 2 == 0;
            var lastControl = Children.LastOrDefault();
            base.Add(control);
            var cell = table.Add(control, isNameControl ?
                TableConstraint.Alignment(HorizontalAlignment.Right) :
                TableConstraint.Alignment(HorizontalAlignment.Left));
            if (isNameControl)
                cell.Style.WhiteSpace = "nowrap";
            else
                control.Label = lastControl;
        }

        public void Add(Control name, Control value)
        {
            Add(name);
            Add(value);
            value.Style.Width = new CssNumericValue(100, CssUnit.Percent);
        }
    }
}