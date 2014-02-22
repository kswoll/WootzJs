using WootzJs.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class FixedPanel : Control
    {
        private Control content;

        public FixedPanel()
        {
        }

        public FixedPanel(CssNumericValue width, CssNumericValue height)
        {
            Style.Width = width;
            Style.Height = height;
        }

        public FixedPanel(CssNumericValue width, CssNumericValue height, Control content)
        {
            Style.Width = width;
            Style.Height = height;
            Content = content;
        }

        protected override Element CreateNode()
        {
            var div = Browser.Document.CreateElement("div");
            return div;
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
                    Node.AppendChild(content.Node);
                    content.Node.Style.Width = "100%";
                    content.Node.Style.Height = "100%";
                    Add(content);
                }
            }
        }
    }
}