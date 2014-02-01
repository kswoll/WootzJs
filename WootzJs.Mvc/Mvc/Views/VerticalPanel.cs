using WootzJs.JQuery;

namespace WootzJs.Mvc.Mvc.Views
{
    public class VerticalPanel : Control
    {
        private jQuery table;

        protected override jQuery CreateNode()
        {
            table = new jQuery("<table></table>");
            table.css("width", "100%");

            var div = new jQuery("<div></div>");
            div.append(table);

            return div;
        }

        public new void Add(Control child)
        {
            Add(child, HorizontalAlignment.Fill, 0);
        }

        public void Add(Control child, HorizontalAlignment alignment)
        {
            Add(child, alignment, 0);
        }

        public void Add(Control child, int spaceAbove)
        {
            Add(child, HorizontalAlignment.Fill, spaceAbove);
        }

        public void Add(Control child, HorizontalAlignment alignment, int spaceAbove)
        {
            base.Add(child);

            var row = new jQuery("<tr></tr>");
            var cell = new jQuery("<td></td>");
            var div = new jQuery("<div></div>");
            cell.append(div);

            switch (alignment)
            {
                case HorizontalAlignment.Fill:
                    child.Node.css("width", "100%");
                    div.css("width", "100%");
                    break;
                case HorizontalAlignment.Left:
                    cell.attr("align", "left");
                    break;
                case HorizontalAlignment.Center:
                    cell.attr("align", "center");
                    break;
                case HorizontalAlignment.Right:
                    cell.attr("align", "right");
                    break;
            }
            
            if (spaceAbove != 0)
            {
                div.css("margin-top", spaceAbove); // TODO!?  Shouldn't this be padding?
            }

            div.append(child.Node);
            row.append(cell);
            table.append(row);
        }
    }
}