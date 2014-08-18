using System;
using System.Collections.Generic;
using System.Runtime.WootzJs;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class ListBox<T> : Control
    {
        public event Action Changed;

        private List<T> items = new List<T>();
        private Func<T, string> textProvider;
        private Func<T, string> valueProvider;

        public ListBox(Func<T, string> textProvider = null, Func<T, string> valueProvider = null) 
        {
            this.textProvider = textProvider ?? (x => x.ToString());
            this.valueProvider = valueProvider ?? textProvider;
        }

        protected override Element CreateNode()
        {
            var listbox = Browser.Document.CreateElement("select");
            listbox.AddEventListener("change", OnJsChanged);
            listbox.SetAttribute("size", "2");
            return listbox;
        }

        public void Add(T item)
        {
            items.Add(item);
            Node.AppendChild(CreateOption(item));
        }

        public void Remove(T item)
        {
            var index = items.IndexOf(item);
            var child = Node.Children[index];
            Node.RemoveChild(child);
            items.Remove(item);
        }

        private Element CreateOption(T item)
        {
            var option = Browser.Document.CreateElement("option");
            option.SetAttribute("value", valueProvider(item));
            option.AppendChild(Browser.Document.CreateTextNode(textProvider(item)));
            return option;
        }

        private void OnJsChanged(Event evt)
        {
            var changed = Changed;
            if (changed != null)
                changed();
        }

        public bool IsMultiselect
        {
            get
            {
                return Node.HasAttribute("multiple") && Node.GetAttribute("multiple") == "true";
            }
            set
            {
                if (value)
                    Node.SetAttribute("multiple", "true");
                else
                    Node.RemoveAttribute("multiple");
            }
        }
    }
}