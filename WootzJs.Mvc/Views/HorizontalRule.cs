namespace WootzJs.Mvc.Views
{
    public class HorizontalRule : Control
    {
        public HorizontalRule() : base("hr")
        {
        }

        public int Size
        {
            get { return Node.HasAttribute("size") ? int.Parse(Node.GetAttribute("size")) : 1; }
            set { Node.SetAttribute("size", value.ToString()); }
        }
    }
}