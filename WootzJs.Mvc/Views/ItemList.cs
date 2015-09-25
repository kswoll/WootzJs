using System.Collections.Generic;
using WootzJs.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class ItemList<T> : Control
    {
        public Style ItemStyle { get; set; }
        public Style HighlightedItemStyle { get; set; }

        private Dictionary<T, Item> itemControlsByItem = new Dictionary<T, Item>();
        private List<Item> itemElements = new List<Item>();

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
            var itemControl = new Item(this, item);
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

        public class Item : Control
        {
            public ItemList<T> List { get; }
            public T Value { get; }

            private Element content;
            private TextNode contentText;
            private bool isHighlighted;

            public Item(ItemList<T> list, T value)
            {
                List = list;
                Value = value;
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
/*
                    list.DefaultItemBackgroundStyle.ApplyTo(Style);
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