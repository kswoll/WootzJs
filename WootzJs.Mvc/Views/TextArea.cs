using System;
using System.Runtime.WootzJs;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class TextArea : Control
    {
        public event Action Changed;

        public new TextAreaElement Node
        {
            get { return base.Node.As<TextAreaElement>(); }
        }

        public TextBoxType Type
        {
            get { return TextBoxTypes.Parse(Node.GetAttribute("type")); }
            set { Node.SetAttribute("type", value.GetInputType()); }
        }

        public string Name
        {
            get { return Node.GetAttribute("name"); }
            set { Node.SetAttribute("name", value); }
        }

        public string Placeholder
        {
            get { return Node.GetAttribute("placeholder"); }
            set { Node.SetAttribute("placeholder", value); }
        }

        public bool IsWrappingEnabled
        {
            get { return Node.GetAttribute("wrap") == "hard"; }
            set { Node.SetAttribute("wrap", value ? "hard" : "soft"); }
        }

        protected override Element CreateNode()
        {
            var textArea = Browser.Document.CreateElement("textarea");
            textArea.AddEventListener("change", OnJsChanged);

            return textArea;
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