using System;
using System.Linq;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class VerticalPanel : Control
    {
        public HorizontalAlignment DefaultAlignment { get; set; }

        private Element table;
        private Element firstSpacer;
        private Element lastSpacer;
        private int spacing;

        public VerticalPanel()
        {
            DefaultAlignment = HorizontalAlignment.Fill;
        }

        public VerticalAlignment VerticalAlignment
        {
            get
            {
                if (firstSpacer == null && lastSpacer == null)
                    return VerticalAlignment.Fill;
                else if (firstSpacer != null && lastSpacer != null)
                    return VerticalAlignment.Middle;
                else if (firstSpacer != null)
                    return VerticalAlignment.Bottom;
                else if (lastSpacer != null)
                    return VerticalAlignment.Top;
                else
                    throw new InvalidOperationException();
            }
            set
            {
                EnsureNodeExists();
                if (firstSpacer != null)
                {
                    firstSpacer.Remove();
                    firstSpacer = null;
                }
                if (lastSpacer != null)
                {
                    lastSpacer.Remove();
                    lastSpacer = null;
                }
                switch (value)
                {
                    case VerticalAlignment.Fill:
                        break;
                    case VerticalAlignment.Middle:
                    {
                        firstSpacer = Browser.Document.CreateElement("tr");
                        var firstSpacerCell = Browser.Document.CreateElement("td");
                        firstSpacerCell.Style.Height = "50%";
                        firstSpacer.AppendChild(firstSpacerCell);
                        table.Prepend(firstSpacer);

                        lastSpacer = Browser.Document.CreateElement("tr");
                        var lastSpacerCell = Browser.Document.CreateElement("td");
                        lastSpacerCell.Style.Height = "50%";
                        lastSpacer.AppendChild(lastSpacerCell);
                        table.AppendChild(lastSpacer);

                        break;
                    }
                    case VerticalAlignment.Top:
                    {
                        lastSpacer = Browser.Document.CreateElement("tr");
                        var lastSpacerCell = Browser.Document.CreateElement("td");
                        lastSpacerCell.Style.Height = "100%";
                        lastSpacer.AppendChild(lastSpacerCell);
                        table.AppendChild(lastSpacer);
                        break;
                    }
                   case VerticalAlignment.Bottom:
                    {
                        firstSpacer = Browser.Document.CreateElement("tr");
                        var firstSpacerCell = Browser.Document.CreateElement("td");
                        firstSpacerCell.Style.Height = "100%";
                        firstSpacer.AppendChild(firstSpacerCell);
                        table.AppendChild(firstSpacer);
                        break;
                    }
                    default:
                        throw new InvalidOperationException();
                }                
            }
        }

        public int Spacing
        {
            get { return spacing; }
            set
            {
                EnsureNodeExists();
                var difference = value - spacing;
                spacing = value;

                for (var i = 0; i < table.Children.Length; i++)
                {
                    var row = table.Children[i];
                    var div = row.Children[0];
                    var existingMargin = div.Style.MarginTop;
                    var existingSpacing = existingMargin == "" ? 0 : int.Parse(existingMargin.Substring(0, existingMargin.Length - 2));
                    var newSpacing = existingSpacing + difference;
                    div.Style.MarginTop = newSpacing + "px";
                }
            }
        }

        protected override Element CreateNode()
        {
            table = Browser.Document.CreateElement("table");
            table.Style.Width = "100%";

            var div = Browser.Document.CreateElement("div");
            div.AppendChild(table);

            return div;
        }

        public new void Add(Control child)
        {
            Add(child, DefaultAlignment, 0);
        }

        public void Add(Control child, HorizontalAlignment alignment)
        {
            Add(child, alignment, 0);
        }

        public void Add(Control child, int spaceAbove)
        {
            Add(child, DefaultAlignment, spaceAbove);
        }

        public void Add(Control child, HorizontalAlignment alignment, int spaceAbove)
        {
            if (Count > 0)
                spaceAbove += spacing;

            base.Add(child);

            var row = Browser.Document.CreateElement("tr");
            var cell = Browser.Document.CreateElement("td");
            var div = Browser.Document.CreateElement("div");
            cell.AppendChild(div);

            switch (alignment)
            {
                case HorizontalAlignment.Fill:
                    child.Node.Style.Width = "100%";
                    div.Style.Width = "100%";
                    break;
                case HorizontalAlignment.Left:
                    cell.SetAttribute("align", "left");
                    break;
                case HorizontalAlignment.Center:
                    cell.SetAttribute("align", "center");
                    break;
                case HorizontalAlignment.Right:
                    cell.SetAttribute("align", "right");
                    break;
            }
            
            if (spaceAbove != 0)
            {
                div.Style.MarginTop = spaceAbove + "px";   // TODO!?  Shouldn't this be padding?
            }

            div.AppendChild(child.Node);
            row.AppendChild(cell);
            table.AppendChild(row);
        }

        public new void Remove(Control child)
        {
            base.Remove(child);

            var div = child.Node.ParentElement;
            var cell = div.ParentElement;
            var row = cell.ParentElement;

            div.RemoveChild(child.Node);
            table.RemoveChild(row);
        }

        public void Clear()
        {
            foreach (var child in Children.ToArray())
            {
                Remove(child);
            }
        }
    }
}