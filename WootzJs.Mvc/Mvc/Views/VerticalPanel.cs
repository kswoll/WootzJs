using WootzJs.Web;

namespace WootzJs.Mvc.Mvc.Views
{
    public class VerticalPanel : Control
    {
        public HorizontalAlignment DefaultAlignment { get; set; }

        private Element table;

        public VerticalPanel()
        {
            DefaultAlignment = HorizontalAlignment.Fill;
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
    }
}