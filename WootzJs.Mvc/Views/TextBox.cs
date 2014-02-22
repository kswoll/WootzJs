using System;
using System.Runtime.WootzJs;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class TextBox : Control
    {
        public event Action Changed;

        public new InputElement Node
        {
            get { return base.Node.As<InputElement>(); }
        }

        public TextBoxType Type
        {
            get { return TextBoxTypes.Parse(Node.GetAttribute("type")); }
            set { Node.SetAttribute("type", value.GetInputType()); }
        }

        protected override Element CreateNode()
        {
            var textBox = Browser.Document.CreateElement("input");
            textBox.SetAttribute("type", "text");
            textBox.AddEventListener("change", OnJsChanged);

            return textBox;
        }

        private void OnJsChanged(Event evt)
        {
            var changed = Changed;
            if (changed != null)
                changed();
        }

        public string Text
        {
            get
            {
                EnsureNodeExists();
                return Node.Value;
            }
            set
            {
                EnsureNodeExists();
                Node.Value = value;
            }
        }
    }
}