using System;
using WootzJs.JQuery;

namespace WootzJs.Mvc.Mvc.Views
{
    public class CheckBox : Control
    {
        public event Action Changed;

        private jQuery label;
        private jQuery checkbox;

        public CheckBox()
        {
        }

        public CheckBox(string text)
        {
            Text = text;
        }

        protected override jQuery CreateNode()
        {
            label = new jQuery("<span></span>");

            var span = new jQuery("<span></span>");
            checkbox = new jQuery("<input />");
            checkbox.attr("type", "checkbox");
            checkbox.change(OnJsChanged);
            span.append(checkbox);
            span.append(label);

            return span;
        }

        private void OnJsChanged(JqEvent evt)
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
                return checkbox.@is(":checked");
            }
            set
            {
                EnsureNodeExists();
                checkbox.prop("checked", true);
            }
        }

        public string Text
        {
            get
            {
                EnsureNodeExists();
                return label.text();
            }
            set
            {
                EnsureNodeExists();
                label.text(value);
            }
        }
    }
}