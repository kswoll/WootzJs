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
            MouseEntered += () => Source = highlightedSource;
            MouseExited += () => Source = defaultSource;
        }

        public Image(string defaultSource, string highlightedSource, CssColor highlightColor)
        {
            Source = defaultSource;
            MouseEntered += () =>
            {
                Source = highlightedSource;
                Style.BackgroundColor = highlightColor;
            };
            MouseExited += () =>
            {
                Source = defaultSource;
                Style.BackgroundColor = CssColor.Inherit;
            };
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