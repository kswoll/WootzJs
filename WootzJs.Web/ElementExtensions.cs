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
    }
}