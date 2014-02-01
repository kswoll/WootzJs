using System;
using WootzJs.JQuery;

namespace WootzJs.Mvc.Mvc.Views
{
    public class HorizontalPanel : Control
    {
        public int Spacing { get; set; }

        private jQuery row;
        private jQuery firstSpacer;
        private jQuery lastSpacer;

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
                    firstSpacer.remove();
                    firstSpacer = null;
                }
                if (lastSpacer != null)
                {
                    lastSpacer.remove();
                    lastSpacer = null;
                }
                switch (value)
                {
                    case HorizontalAlignment.Fill:
                        break;
                    case HorizontalAlignment.Center:
                        firstSpacer = new jQuery("<td></td>");
                        firstSpacer.css("width", "50%");
                        row.prepend(firstSpacer);
                        lastSpacer = new jQuery("<td></td>");
                        lastSpacer.css("width", "50%");
                        row.append(lastSpacer);
                        break;
                    case HorizontalAlignment.Left:
                        lastSpacer = new jQuery("<td></td>");
                        lastSpacer.css("width", "100%");
                        row.append(lastSpacer);
                        break;
                   case HorizontalAlignment.Right:
                        firstSpacer = new jQuery("<td></td>");
                        firstSpacer.css("width", "100%");
                        row.prepend(firstSpacer);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        protected override jQuery CreateNode()
        {
            var table = new jQuery("<table></table>");
            row = new jQuery("<tr></tr>");
            table.append(row);
            return table;
        }

        public new void Add(Control child)
        {
            Add(child, VerticalAlignment.Fill, Count == 0 ? 0 : Spacing);
        }

        public void Add(Control child, VerticalAlignment alignment)
        {
            Add(child, alignment, Count == 0 ? 0 : Spacing);
        }

        public void Add(Control child, int spaceBefore)
        {
            Add(child, VerticalAlignment.Fill, (Count == 0 ? 0: Spacing) + spaceBefore);
        }

        public void Add(Control child, VerticalAlignment alignment, int spaceBefore)
        {
            base.Add(child);

            var cell = new jQuery("<td></td>");
            var div = new jQuery("<div></div>");
            cell.append(div);

            switch (alignment)
            {
                case VerticalAlignment.Fill:
                    child.Node.css("height", "100%");
                    div.css("height", "100%");
                    break;
                case VerticalAlignment.Top:
                    cell.css("vertical-align", "top");
                    break;
                case VerticalAlignment.Middle:
                    cell.css("vertical-align", "middle");
                    break;
                case VerticalAlignment.Bottom:
                    cell.css("vertical-align", "bottom");
                    break;
            }
            
            if (spaceBefore != 0)
            {
                div.css("margin-left", spaceBefore);
            }

            div.append(child.Node);

            if (lastSpacer != null)
                cell.insertBefore(lastSpacer);
            else
                row.append(cell);
        }
    }
}