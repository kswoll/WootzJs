using System;
using System.Collections.Generic;
using System.Linq;
using WootzJs.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class ListView<T> : Control
    {
        public event Action Changed;

        public CssColor HighlightColor { get; set; }
        public CssColor HighlightTextColor { get; set; }
        public CssColor SelectedColor { get; set; }
        public CssColor SelectedTextColor { get; set; }

        private List<T> items = new List<T>();
        private Dictionary<T, Control> childControls = new Dictionary<T, Control>();
        private Func<T, string> textProvider;
        private VerticalPanel list = new VerticalPanel();
        private int selectedIndex = -1;

        public ListView(Func<T, string> textProvider = null) 
        {
            this.textProvider = textProvider ?? (x => x.ToString());
            HighlightColor = new CssColor(221, 236, 247);
            HighlightTextColor = CssColor.Inherit;
            SelectedColor = new CssColor(0, 0, 150);
            SelectedTextColor = CssColor.White;
            Style.Color = CssColor.Inherit;
            Style.BackgroundColor = CssColor.White;
            Style.Border = new CssBorder(1, CssBorderStyle.Solid, CssColor.Black);

            Add(list);
        }

        protected override Element CreateNode()
        {
            var container = Browser.Document.CreateElement("div");
            container.AppendChild(list.Node);

            return container;
        }

        public void Add(T item)
        {
            items.Add(item);
            var control = CreateRow(item);
            list.Add(control);
            childControls[item] = control;
        }

        public void Remove(T item)
        {
            var row = childControls[item];
            list.Remove(row);
            items.Remove(item);
            childControls.Remove(item);
        }

        public void Clear()
        {
            while (items.Any())
            {
                Remove(items.Last());
            }
        }

        public IList<T> Items
        {
            get { return items; }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (selectedIndex != value)
                {
                    if (selectedIndex != -1)
                    {
                        var item = items[selectedIndex];
                        var control = childControls[item];
                        control.Style.BackgroundColor = Style.BackgroundColor;
                        control.Style.Color = Style.Color;
                    }
                    this.selectedIndex = value;
                    if (selectedIndex != -1)
                    {
                        var item = items[selectedIndex];
                        var control = childControls[item];
                        control.Style.BackgroundColor = SelectedColor;
                        control.Style.Color = SelectedTextColor;
                    }
                    OnChanged();
                }
            }
        }

        protected virtual void OnChanged()
        {
            if (Changed != null)
                Changed();
        }

        public T SelectedItem
        {
            get { return selectedIndex == -1 ? default(T) : items[selectedIndex]; }
            set
            {
                SelectedIndex = items.IndexOf(value);
            }
        }

        private Control CreateRow(T item)
        {
            var text = new Text(textProvider(item));
            text.Style.Padding = new CssPadding
            {
                Left = 5, Right = 5
            };
            text.MouseEntered += () =>
            {
                text.Style.BackgroundColor = HighlightColor;
                text.Style.Color = HighlightTextColor;
            };
            text.MouseExited += () =>
            {
                text.Style.BackgroundColor = Style.BackgroundColor;
                text.Style.Color = Style.Color;
            };
            return text;
        }

        public void SelectNextItem()
        {
            if (items.Count > 0)
            {
                if (SelectedIndex == -1)
                {
                    SelectedIndex = 0;
                }
                else
                {
                    if (items.Count > SelectedIndex + 1)
                        SelectedIndex = SelectedIndex + 1;
                    else
                        SelectedIndex = 0;
                }                    
            }            
        }

        public void SelectPreviousItem()
        {
            if (items.Count > 0)
            {
                if (SelectedIndex == -1)
                {
                    SelectedIndex = items.Count - 1;
                }
                else
                {
                    if (SelectedIndex < 1)
                        SelectedIndex = items.Count - 1;
                    else 
                        SelectedIndex = SelectedIndex - 1;
                }
            }
        }
    }
}