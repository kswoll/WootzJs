using System.Threading.Tasks;
using WootzJs.Mvc.Views;

namespace WootzJs.Mvc
{
    public class ViewContext
    {
        public ControllerContext ControllerContext { get; set; } 
        public ActionHelper Action { get; set; }
        public UrlHelper Url { get; set; }
        
        public ViewContext()
        {
            Action = new ActionHelper();
            Url = new UrlHelper();
        }

        public Task Open(string url)
        {
            return ControllerContext.Application.Open(url);
        }
    }
}