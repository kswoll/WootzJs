using WootzJs.Mvc.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc.Mvc.Views
{
    public class Image : Control, IInlineControl
    {
        public Image()
        {
        }

        public Image(string source)
        {
            Source = source;
        }

        public Image(string defaultSource, string highlightedSource)
        {
            Source = defaultSource;
            MouseEnter(() => Source = highlightedSource);
            MouseLeave(() => Source = defaultSource);
        }

        public Image(string defaultSource, string highlightedSource, CssColor highlightColor)
        {
            Source = defaultSource;
            MouseEnter(() =>
            {
                Source = highlightedSource;
                Style.BackgroundColor = highlightColor;
            });
            MouseLeave(() =>
            {
                Source = defaultSource;
                Style.BackgroundColor = CssColor.Inherit;
            });
        }

        public string Source
        {
            get { return Node.GetAttribute("src"); }
            set { Node.SetAttribute("src", value); }
        }

        protected override Element CreateNode()
        {
            var node = Browser.Document.CreateElement("img");
            node.Style.Display = "block";
            return node;
        }
    }
}