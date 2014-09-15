using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WootzJs.Mvc.Views
{
    public class ActionHelper
    {
        public ActionHelper()
        {
        }

        public ActionControllerHelper<TController> On<TController>() where TController : Controller
        {
            return new ActionControllerHelper<TController>();
        }

        public class ActionControllerHelper<TController> where TController : Controller
        {
            public Task To<TActionResult>(Expression<Func<TController, TActionResult>> action)
            {
                return MvcApplication.Instance.Open(UrlGenerator.GenerateUrl(action));
            }
        }
    }
}