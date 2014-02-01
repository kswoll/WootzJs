
namespace WootzJs.Mvc.Mvc.Views
{
    public class Text : Control, IInlineControl
    {
        public Text() : base("<span></span>")
        {
        }

        public Text(string value)
        {
            Value = value;
        }

        public string Value
        {
            get { return Node.text(); }
            set { Node.text(value); }
        }
    }
}