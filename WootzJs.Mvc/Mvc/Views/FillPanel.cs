using WootzJs.JQuery;

namespace WootzJs.Mvc.Mvc.Views
{
    /// <summary>
    /// Renders the content by setting width/height at 100% so that it fills inside the parent
    /// element.
    /// </summary>
    public class FillPanel : Control
    {
        private Control content;

        public FillPanel()
        {
        }

        public FillPanel(Control content) 
        {
            Content = content;
        }

        protected override jQuery CreateNode()
        {
            var container = new jQuery("<div></div>");
            container.css("width", "100%");
            container.css("height", "100%");

            return container;
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
                    childNode.css("width", "100%");
                    childNode.css("height", "100%");
                    Node.append(childNode);
                }
            }
        }
    }
}