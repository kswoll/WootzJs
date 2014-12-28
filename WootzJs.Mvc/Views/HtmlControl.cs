using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class HtmlControl : Control
    {
//        public HtmlControl(string htmlTag) : base(string.Format("<{0}></{0}>", htmlTag))
//        {
//        }

        public HtmlControl(Element node) : base(node)
        {
        }

        public new void Add(Control child)
        {
            Node.AppendChild(child.Node);
            base.AddChild(child);
        }

        public new void Remove(Control child)
        {
            base.RemoveChild(child);
            child.Node.Remove();
        }
    }
}