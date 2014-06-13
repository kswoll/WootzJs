using System.Collections.Generic;
using WootzJs.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class ItemList<T> : Control
    {
        public Style ItemStyle { get; set; }
        public Style HighlightedItemStyle { get; set; }

        private Dictionary<T, Item<T>> itemControlsByItem = new Dictionary<T, Item<T>>();
        private List<Item<T>> itemElements = new List<Item<T>>();

        public ItemList()
        {
            ItemStyle = new Style();
            HighlightedItemStyle = new Style();
        }

        protected override Element CreateNode()
        {
            var result = Browser.Document.CreateElement("div");
            return result;
        }

        public void Add(T item)
        {
            var itemControl = new Item<T>(this, item);
            itemControlsByItem[item] = itemControl;
            itemElements.Add(itemControl);

            Node.AppendChild(itemControl.Node);
        }

        public void Remove(T item)
        {
            var itemElement = itemControlsByItem[item];
            itemElements.Remove(itemElement);
            itemControlsByItem.Remove(item);

            Node.RemoveChild(itemElement.Node);
        }

        public class Item<T> : Control
        {
            private ItemList<T> list;
            private T item;
            private Element content;
            private TextNode contentText;
            private bool isHighlighted;

            public Item(ItemList<T> list, T item)
            {
                this.list = list;
                this.item = item;
            }

            public string Text
            {
                get
                {
                    return contentText.NodeValue;
                }
                set
                {
                    contentText.NodeValue = value;
                }
            }

            public bool IsHighlighted
            {
                get { return isHighlighted; }
                set
                {
                    isHighlighted = value;
                    list.DefaultItemBackgroundStyle.ApplyTo(Style);
/*
                    if (isHighlighted)
                    {
                        Style.BackgroundColor = 
                    }
                    else
                    {
                        
                    }
*/
                }
            }

            protected override Element CreateNode()
            {
                content = Browser.Document.CreateElement("div");
                contentText = Browser.Document.CreateTextNode("");
                content.AppendChild(contentText);
                return content;
            }
        }
    }
}