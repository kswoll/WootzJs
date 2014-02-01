using WootzJs.JQuery;

namespace WootzJs.Mvc.Mvc.Views
{
    public class CenteredPanel : Control
    {
        private Control content;
        private jQuery contentContainer;

        public CenteredPanel()
        {
        }

        public CenteredPanel(Control content) 
        {
            Content = content;
        }

        protected override jQuery CreateNode()
        {
            var table = new jQuery("<table></table>");
            table.css("width", "100%");
            table.css("height", "100%");
            table.css("border-collapse", "collapse");

            var row = new jQuery("<tr></tr>");
            table.append(row);

            var td = new jQuery("<td></td>");
            td.attr("align", "center");   // This one little attribute is why table layouts are awesome
            td.css("vertical-align", "middle");
//            contentContainer.css("height", "100%");

            contentContainer = new jQuery("<div></div>");
            td.append(contentContainer);

            row.append(td);

            var outerDiv = new jQuery("<div></div>");
            outerDiv.css("width", "100%");
            outerDiv.css("height", "100%");
            outerDiv.append(table);

            return outerDiv;
        }

        public Control Content
        {
            get { return content; }
            set
            {
                if (content != null)
                {
                    Remove(content);
                    content.Node.remove();
                }

                content = value;

                if (content != null)
                {
                    Add(content);
                    var childNode = value.Node;
                    contentContainer.append(childNode);
                }
            }
        }
    }
}