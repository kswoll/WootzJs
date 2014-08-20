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

        private List<T> items = new List<T>();
        private Func<T, string> textProvider;

        public ListView(Func<T, string> textProvider = null) 
        {
            this.textProvider = textProvider ?? (x => x.ToString());
            Style.BackgroundColor = CssColor.White;
            Style.Border = new CssBorder(1, CssBorderStyle.Solid, CssColor.Black);
        }

        protected override Element CreateNode()
        {
            var list = Browser.Document.CreateElement("table");
            return list;
        }

        public void Add(T item)
        {
            items.Add(item);
            Node.AppendChild(CreateRow(item));
        }

        public void Remove(T item)
        {
            var index = items.IndexOf(item);
            var row = Node.Children[index];
            Node.RemoveChild(row);
            items.Remove(item);
        }

        public void Clear()
        {
            while (items.Any())
            {
                Remove(items.Last());
            }
        }

        private Element CreateRow(T item)
        {
            var div = Browser.Document.CreateElement("div");
            div.AppendChild(Browser.Document.CreateTextNode(textProvider(item)));

            var cell = Browser.Document.CreateElement("td");
            cell.AppendChild(div);

            var row = Browser.Document.CreateElement("tr");
            row.AppendChild(cell);

            return row;
        }
    }
}