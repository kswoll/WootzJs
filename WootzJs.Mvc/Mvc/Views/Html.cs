using WootzJs.Web;

namespace WootzJs.Mvc.Mvc.Views
{
    public class Html : Control
    {
        private string html;

        public Html(string html)
        {
            this.html = html;
        }

        protected override Element CreateNode()
        {
            var result = Browser.Document.CreateElement("span");
            result.InnerHtml = html;
            return result;
        }
    }
}