using WootzJs.Mvc.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc.Mvc.Views
{
    public class Image : InlineControl
    {
        public Image()
        {
        }

        public Image(string source, int? width = null, int? height = null)
        {
            Source = source;
            if (width != null)
                Width = width.Value;
            if (height != null)
                Height = height.Value;
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

        public int Width
        {
            get { return int.Parse(Node.GetAttribute("width")); }
            set { Node.SetAttribute("width", value.ToString()); }
        }

        public int Height
        {
            get { return int.Parse(Node.GetAttribute("height")); }
            set { Node.SetAttribute("height", value.ToString()); }
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