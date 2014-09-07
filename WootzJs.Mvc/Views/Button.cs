using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class Button : Control
    {
        public Button()
        {
        }

        public Button(string text)
        {
            Text = text;
        }

        public string Text
        {
            get { return Node.GetAttribute("value"); }
            set { Node.SetAttribute("value", value); }
        }

        protected override Element CreateNode()
        {
            var button = Browser.Document.CreateElement("input");
            button.SetAttribute("type", "button");

            return button;
        }
    }
}