using System.Linq;

namespace WootzJs.Web
{
    public static class DocumentExtensions
    {
        public static Element GetElementByTagName(this Document document, string tagName)
        {
            return document.GetElementsByTagName(tagName).SingleOrDefault();
        }
    }
}