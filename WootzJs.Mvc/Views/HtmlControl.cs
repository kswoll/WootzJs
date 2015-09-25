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

        public void Add(Control child)
        {
            Node.AppendChild(child.Node);
            AddChild(child);
        }

        public void Remove(Control child)
        {
            RemoveChild(child);
            child.Node.Remove();
        }
    }
}