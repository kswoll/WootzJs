using WootzJs.JQuery;
using WootzJs.Mvc.Mvc.Views.Css;

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
            get { return Node.attr("src"); }
            set { Node.attr("src", value); }
        }

        protected override jQuery CreateNode()
        {
            var node = new jQuery("<img />");
            node.css("display", "block");
            return node;
        }
    }
}