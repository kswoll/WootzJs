using System;
using System.Linq.Expressions;

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
            public void To<TActionResult>(Expression<Func<TController, TActionResult>> action, Action continuation)
            {
                MvcApplication.Instance.Open(UrlGenerator.GenerateUrl(action), continuation);
            }
        }
    }
}