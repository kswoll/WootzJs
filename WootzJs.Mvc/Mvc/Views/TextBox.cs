using System;
using WootzJs.JQuery;

namespace WootzJs.Mvc.Mvc.Views
{
    public class TextBox : Control
    {
        public event Action Changed;

        protected override jQuery CreateNode()
        {
            var textBox = new jQuery("<input />");
            textBox.attr("type", "text");
            textBox.change(OnJsChanged);

            return textBox;
        }

        private void OnJsChanged(JqEvent evt)
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
                return Node.val().ToString();
            }
            set
            {
                EnsureNodeExists();
                Node.val(value);
            }
        }
    }
}