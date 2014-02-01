namespace WootzJs.Mvc.Mvc.Views
{
    public class HtmlControl : Control
    {
//        public HtmlControl(string htmlTag) : base(string.Format("<{0}></{0}>", htmlTag))
//        {
//        }

        public HtmlControl(string nodeCreationText) : base(nodeCreationText)
        {
            EnsureNodeExists();
        }

        public new void Add(Control child)
        {
            base.Add(child);
            Node.append(child.Node);
        }

        public new void Remove(Control child)
        {
            base.Remove(child);
            child.Node.remove();
        }
    }
}