
namespace WootzJs.Mvc.Views
{
    public class Text : InlineControl
    {
        public Text()
        {
            TagName = "span";
        }

        public Text(string value) : this()
        {
            Value = value;
        }

        public string Value
        {
            get { return Node.InnerHtml; }
            set { Node.InnerHtml = value; }
        }

        public static implicit operator Text(string text)
        {
            return new Text(text);
        }
    }
}