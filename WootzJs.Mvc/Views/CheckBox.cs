using System;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class CheckBox : Control
    {
        public event Action Changed;

        private Element label;
        private Element checkbox;

        public CheckBox()
        {
        }

        public CheckBox(string text)
        {
            Text = text;
        }

        protected override Element CreateNode()
        {
            label = Browser.Document.CreateElement("span");

            var span = Browser.Document.CreateElement("span");
            checkbox = Browser.Document.CreateElement("input");
            checkbox.SetAttribute("type", "checkbox");
            checkbox.AddEventListener("change", OnJsChanged);
            span.AppendChild(checkbox);
            span.AppendChild(label);

            return span;
        }

        private void OnJsChanged(Event evt)
        {
            var changed = Changed;
            if (changed != null)
                changed();
        }

        public bool IsChecked
        {
            get
            {
                EnsureNodeExists();
                return checkbox.HasAttribute("checked");
            }
            set
            {
                EnsureNodeExists();
                if (value)
                    checkbox.SetAttribute("checked", "checked");
                else
                    checkbox.RemoveAttribute("checked");
            }
        }

        public string Text
        {
            get
            {
                EnsureNodeExists();
                return label.InnerHtml;
            }
            set
            {
                EnsureNodeExists();
                label.InnerHtml = value;
            }
        }
    }
}