using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class InlineControl : Control
    {
        public InlineControl()
        {
        }

        public InlineControl(Element node) : base(node)
        {
        }

        public static implicit operator InlineControl(string text)
        {
            return new Text(text);
        }
    }
}