using System;
using System.Collections.Generic;
using System.Linq;
using WootzJs.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class ListView<T> : Control
    {
        public CssColor HighlightColor { get; set; }

        private List<T> items = new List<T>();
        private Dictionary<T, Control> childControls = new Dictionary<T, Control>();
        private Func<T, string> textProvider;
        private VerticalPanel list = new VerticalPanel();

        public ListView(Func<T, string> textProvider = null) 
        {
            this.textProvider = textProvider ?? (x => x.ToString());
            HighlightColor = CssColor.Green;
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

        private Control CreateRow(T item)
        {
            var text = new Text(textProvider(item));
            text.MouseEntered += () =>
            {
                text.Style.BackgroundColor = HighlightColor;
            };
            text.MouseExited += () =>
            {
                text.Style.BackgroundColor = Style.BackgroundColor;
            };
            return text;
        }
    }
}