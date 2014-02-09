using WootzJs.Web;

namespace WootzJs.Mvc.Mvc.Views
{
    public class CenteredPanel : Control
    {
        private Control content;
        private Element contentContainer;

        public CenteredPanel()
        {
        }

        public CenteredPanel(Control content) 
        {
            Content = content;
        }

        protected override Element CreateNode()
        {
            var table = Browser.Document.CreateElement("table");
            table.Style.Width = "100%";
            table.Style.Height = "100%";
            table.Style.BorderCollapse = "collapse";

            var row = Browser.Document.CreateElement("tr");
            table.AppendChild(row);

            var td = Browser.Document.CreateElement("td");
            td.SetAttribute("align", "center");   // This one little attribute is why table layouts are awesome
            td.Style.VerticalAlign = "middle";

            contentContainer = Browser.Document.CreateElement("div");
            td.AppendChild(contentContainer);

            row.AppendChild(td);

            var outerDiv = Browser.Document.CreateElement("div");
            outerDiv.Style.Width = "100%";
            outerDiv.Style.Height = "100%";
            outerDiv.AppendChild(table);

            return outerDiv;
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
                    content.Node.Remove();
                }

                content = value;

                if (content != null)
                {
                    var childNode = value.Node;
                    contentContainer.AppendChild(childNode);
                    Add(content);
                }
            }
        }
    }
}