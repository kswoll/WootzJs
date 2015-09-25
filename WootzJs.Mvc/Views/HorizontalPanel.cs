using System;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class HorizontalPanel : Control
    {
        public int Spacing { get; set; }
        public VerticalAlignment DefaultAlignment { get; set; }

        private Element row;
        private Element firstSpacer;
        private Element lastSpacer;

        public HorizontalPanel()
        {
            DefaultAlignment = VerticalAlignment.Fill;
        }

        /// <summary>
        /// Controls the overall alignment of the entire panel
        /// </summary>
        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                if (firstSpacer == null && lastSpacer == null)
                    return HorizontalAlignment.Fill;
                else if (firstSpacer != null && lastSpacer != null)
                    return HorizontalAlignment.Center;
                else if (firstSpacer != null)
                    return HorizontalAlignment.Right;
                else if (lastSpacer != null)
                    return HorizontalAlignment.Left;
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
                    case HorizontalAlignment.Fill:
                        break;
                    case HorizontalAlignment.Center:
                        firstSpacer = Browser.Document.CreateElement("td");
                        firstSpacer.Style.Width = "50%";
                        row.Prepend(firstSpacer);
                        lastSpacer = Browser.Document.CreateElement("td");
                        lastSpacer.Style.Width = "50%";
                        row.AppendChild(lastSpacer);
                        break;
                    case HorizontalAlignment.Left:
                        lastSpacer = Browser.Document.CreateElement("td");
                        lastSpacer.Style.Width = "100%";
                        row.AppendChild(lastSpacer);
                        break;
                   case HorizontalAlignment.Right:
                        firstSpacer = Browser.Document.CreateElement("td");
                        firstSpacer.Style.Width = "100%";
                        row.Prepend(firstSpacer);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        protected override Element CreateNode()
        {
            var table = Browser.Document.CreateElement("table");
            row = Browser.Document.CreateElement("tr");
            table.AppendChild(row);
            return table;
        }

        public HorizontalPanel Add(Control child)
        {
            return Add(child, DefaultAlignment, Count == 0 ? 0 : Spacing);
        }

        public HorizontalPanel Add(Control child, VerticalAlignment alignment)
        {
            return Add(child, alignment, Count == 0 ? 0 : Spacing);
        }

        public HorizontalPanel Add(Control child, int spaceBefore)
        {
            return Add(child, DefaultAlignment, (Count == 0 ? 0: Spacing) + spaceBefore);
        }

        public HorizontalPanel Add(Control child, VerticalAlignment alignment, int spaceBefore)
        {
            AddChild(child);

            var cell = Browser.Document.CreateElement("td");
            var div = Browser.Document.CreateElement("div");
            cell.AppendChild(div);

            switch (alignment)
            {
                case VerticalAlignment.Fill:
                    child.Node.Style.Height = "100%";
                    div.Style.Height = "100%";
                    break;
                case VerticalAlignment.Top:
                    cell.Style.VerticalAlign = "top";
                    break;
                case VerticalAlignment.Middle:
                    cell.Style.VerticalAlign = "middle";
                    break;
                case VerticalAlignment.Bottom:
                    cell.Style.VerticalAlign = "bottom";
                    break;
            }
            
            if (spaceBefore != 0)
            {
                div.Style.MarginLeft = spaceBefore + "px";
            }

            div.AppendChild(child.Node);

            if (lastSpacer != null)
                cell.InsertBefore(lastSpacer);
            else
                row.AppendChild(cell);

            return this;
        }
    }
}