using System;
using System.Linq.Expressions;

namespace WootzJs.Mvc.Views
{
    public class UrlHelper
    {
        public ActionControllerHelper<TController> On<TController>() where TController : Controller
        {
            return new ActionControllerHelper<TController>();
        }

        public class ActionControllerHelper<TController> where TController : Controller
        {
            public string To<TActionResult>(Expression<Func<TController, TActionResult>> action)
            {
                return UrlGenerator.GenerateUrl(action);
            }
        }         
    }
}