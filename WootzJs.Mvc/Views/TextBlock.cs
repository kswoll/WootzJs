namespace WootzJs.Mvc.Views
{
    public class TextBlock : Control
    {
        public TextBlock() 
        {
            TagName = "div";
        }

        public TextBlock(string value) : this()
        {
            Value = value;
        }

        public string Value
        {
            get { return Node.InnerHtml; }
            set { Node.InnerHtml = value; }
        }
    }
}