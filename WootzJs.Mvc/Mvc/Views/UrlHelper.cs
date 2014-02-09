using System;
using System.Linq.Expressions;

namespace WootzJs.Mvc.Mvc.Views
{
    public class UrlHelper
    {
        private ViewContext viewContext;

        public UrlHelper(ViewContext viewContext)
        {
            this.viewContext = viewContext;
        }

        public ActionControllerHelper<TController> On<TController>() where TController : Controller
        {
            return new ActionControllerHelper<TController>(viewContext);
        }

        public class ActionControllerHelper<TController> where TController : Controller
        {
            private ViewContext viewContext;

            public ActionControllerHelper(ViewContext viewContext)
            {
                this.viewContext = viewContext;
            }

            public string To<TActionResult>(Expression<Func<TController, TActionResult>> action)
            {
                return UrlGenerator.GenerateUrl(action);
            }
        }         
    }
}