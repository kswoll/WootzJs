using WootzJs.JQuery;
using WootzJs.Mvc.Mvc.Views.Css;

namespace WootzJs.Mvc.Mvc.Views
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

        protected override jQuery CreateNode()
        {
            var div = new jQuery("<div></div>");
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
                    content.Node.remove();
                }
                content = value;
                if (content != null)
                {
                    Add(content);
                    Node.append(content.Node);
                    content.Node.css("width", "100%");
                    content.Node.css("height", "100%");
                }
            }
        }
    }
}