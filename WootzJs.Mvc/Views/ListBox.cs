using System;
using System.Collections.Generic;
using System.Linq;
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

        public new SelectElement Node
        {
            get { return base.Node.As<SelectElement>(); }
        }

        public bool IsDropDown
        {
            get { return Node.GetAttribute("size") != "1"; }
            set { Node.SetAttribute("size", value ? "1" : "2"); }
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

        public T SelectedItem
        {
            get
            {
                var selectedIndex = Node.SelectedIndex;
                if (selectedIndex >= 0)
                    return items[(int)selectedIndex];
                else
                    return default(T);
            }
            set
            {
                var index = items.IndexOf(value);
                Node.SelectedIndex = index;
            }
        }

        public T[] SelectedItems
        {
            get
            {
                var selectedItems = new List<T>();
                for (var i = 0; i < Node.SelectedOptions.Length; i++)
                {
                    var option = Node.SelectedOptions[i];
                    var item = items[option.Index];
                    selectedItems.Add(item);
                }
                return selectedItems.ToArray();
            }
            set
            {
                var valueSet = new HashSet<T>(value);
                for (var i = 0; i < Node.Options.Length; i++)
                {
                    var option = Node.Options[i];
                    var item = items[option.Index];
                    option.Selected = valueSet.Contains(item);
                }
            }
        }
    }
}