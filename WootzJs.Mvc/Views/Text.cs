
namespace WootzJs.Mvc.Views
{
    public class Text : InlineControl
    {
        public Text()
        {
            TagName = "span";
        }

        public Text(string value)
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