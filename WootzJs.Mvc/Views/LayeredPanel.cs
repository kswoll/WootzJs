using System.Collections.Generic;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class LayeredPanel : Control
    {
        private Element container;
        private Control background;
        private List<Control> layers = new List<Control>();
        private List<Element> wrappers = new List<Element>();
        private Element cell;

        public Control Background
        {
            get { return background; }
            set
            {
                EnsureNodeExists();
                if (background != null)
                {
                    RemoveChild(background);
                    background.Node.Remove();
                }
                this.background = value;
                if (background != null)
                {
                    var childNode = value.Node;
                    container.AppendChild(childNode);
                    AddChild(background);
                }
            }
        }

        public void AddLayer(Control layer, bool allowPointerEvents = true)
        {
            EnsureNodeExists();
            var childNode = layer.Node;
            var wrapper = CreateElement("div");
            wrapper.Style.Position = "absolute";
            wrapper.Style.Left = "0px";
            wrapper.Style.Right = "0px";
            wrapper.Style.Top = "0px";
            wrapper.Style.Bottom = "0px";
            if (!allowPointerEvents)
                wrapper.Style.PointerEvents = "none";
            wrapper.AppendChild(childNode);

            if (background != null)
                wrapper.InsertBefore(background.Node);
            else
                container.AppendChild(wrapper);

            AddChild(layer);
            layers.Add(layer);
            wrappers.Add(wrapper);
        }

        public void RemoveLayer(Control layer)
        {
            EnsureNodeExists();
            var index = layers.IndexOf(layer);
            var wrapper = wrappers[index];
            layer.Node.Remove();
            wrapper.Remove();

            RemoveChild(layer);
            layers.Remove(layer);
            wrappers.Remove(wrapper);
        }

        protected override Element CreateNode()
        {
            var table = CreateElement("table");

            var row = CreateElement("tr");
            cell = CreateElement("td");
            cell.Style.VerticalAlign = "middle";
            cell.Style.Position = "relative";
            container = CreateElement("div");

            cell.AppendChild(container);
            row.AppendChild(cell);
            table.AppendChild(row);

            return table;
        }
    }
}