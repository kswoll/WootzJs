using WootzJs.Web;

namespace WootzJs.Mvc.Views
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

        protected override Element CreateNode()
        {
            var container = Browser.Document.CreateElement("div");
            container.Style.Width = "100%";
            container.Style.Height = "100%";

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
                    content.Node.Remove();
                }

                content = value;

                if (content != null)
                {
                    var childNode = value.Node;
                    childNode.Style.Width = "100%";
                    childNode.Style.Height = "100%";
                    Node.AppendChild(childNode);
                    Add(content);
                }
            }
        }
    }
}