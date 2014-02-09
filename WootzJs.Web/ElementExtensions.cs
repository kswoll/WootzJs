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
            parent.InnerHtml = "";
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
    }
}