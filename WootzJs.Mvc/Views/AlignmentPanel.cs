
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class AlignmentPanel : Control
    {
        private Control content;
        private Element cell;
        private Element cellDiv;

        public static AlignmentPanel Top(Control content)
        {
            return new AlignmentPanel(content, HorizontalAlignment.Fill, VerticalAlignment.Top);
        }

        public static AlignmentPanel Bottom(Control content)
        {
            return new AlignmentPanel(content, HorizontalAlignment.Fill, VerticalAlignment.Bottom);
        }

        public static AlignmentPanel Right(Control content)
        {
            return new AlignmentPanel(content, HorizontalAlignment.Right, VerticalAlignment.Fill);
        }

        public static AlignmentPanel Left(Control content)
        {
            return new AlignmentPanel(content, HorizontalAlignment.Left, VerticalAlignment.Fill);
        }

        public AlignmentPanel(Control content, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment) 
        {
            EnsureNodeExists();
            switch (horizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    cell.SetAttribute("align", "left");
                    break;
                case HorizontalAlignment.Center:
                    cell.SetAttribute("align", "center");
                    break;
                case HorizontalAlignment.Right:
                    cell.SetAttribute("align", "right");
                    break;
                case HorizontalAlignment.Fill:
                    cellDiv.Style.Width = "100%";
                    cell.Style.Width = "100%";
                    break;
            }
            switch (verticalAlignment)
            {
                case VerticalAlignment.Top:
                    cell.Style.VerticalAlign = "top";
                    break;
                case VerticalAlignment.Middle:
                    cell.Style.VerticalAlign = "middle";
                    break;
                case VerticalAlignment.Bottom:
                    cell.Style.VerticalAlign = "bottom";
                    break;
                case VerticalAlignment.Fill:
                    cell.Style.Height = "100%"; 
                    cellDiv.Style.Height = "100%";
                    break;
            }

            Content = content;
        }

        public Control Content
        {
            get { return content; }
            set
            {
                if (content != null)
                {
                    content.Node.Remove();
                    Remove(content);                    
                }
                content = value;
                if (content != null)
                {
                    cellDiv.AppendChild(content.Node);
                    Add(content);                    
                }
            }
        }

        protected override Element CreateNode()
        {
            cellDiv = Browser.Document.CreateElement("div");

            cell = Browser.Document.CreateElement("td");
            cell.Style.Width = "100%";
            cell.Style.Height = "100%";
            cell.AppendChild(cellDiv);

            var row = Browser.Document.CreateElement("tr");
            var table = Browser.Document.CreateElement("table");
            table.Style.Width = "100%";
            table.Style.Height = "100%";

            row.AppendChild(cell);
            table.AppendChild(row);

            return table;
        }
    }
}