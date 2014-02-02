
namespace WootzJs.Mvc.Mvc.Views
{
    public class Text : Control, IInlineControl
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