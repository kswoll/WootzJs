namespace WootzJs.Web
{
    public static class ElementExtensions
    {
        public static bool IsDescendentOf(this Element descendent, Element ancestor)
        {
            return ancestor.Contains(descendent);
        }

        public static bool IsAncestorOf(this Element ancestor, Element descendent)
        {
            return ancestor.Contains(descendent);
        }

        public static void Clear(this Element parent)
        {
            while (parent.FirstChild != null) 
            {
                parent.RemoveChild(parent.FirstChild);
            }        
        }

        public static bool IsAttachedToDom(this Element element)
        {
            var current = element;
            while (current.ParentElement != null)
            {
                current = current.ParentElement;
            }
            return current == Browser.Document.Body.ParentElement;
        }

        public static bool IsMouseInElement(this Element element)
        {
            var mousedNodes = Browser.Document.QuerySelectorAll(":hover");
            for (var i = 0; i < mousedNodes.Length; i++)
            {
                if (mousedNodes[i] == element) 
                    return true;
            }
            return false;
        }

        /// <summary>
        /// If offsetHeight is non-zero, will return that. Otherwise will temporarily place the element in a hidden
        /// container in order to get a valid offsetHeight value.  
        /// </summary>
        public static int MeasureOffsetHeight(this Element element)
        {
            var measuringContainer = Browser.Document.CreateElement("div");
            measuringContainer.Style.Position = "absolute";
            measuringContainer.Style.Visibility = "hidden";
            Browser.Document.Body.AppendChild(measuringContainer);
            measuringContainer.AppendChild(element);
            var result = element.OffsetHeight;
            measuringContainer.RemoveChild(element);
            Browser.Document.Body.RemoveChild(element);
            return result;
        }
    }
}