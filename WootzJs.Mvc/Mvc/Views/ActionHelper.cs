using System;
using System.Linq.Expressions;

namespace WootzJs.Mvc.Mvc.Views
{
    public class ActionHelper
    {
        private ViewContext viewContext;

        public ActionHelper(ViewContext viewContext)
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

            public void To<TActionResult>(Expression<Func<TController, TActionResult>> action)
            {
                viewContext.ControllerContext.Application.Open(UrlGenerator.GenerateUrl(action));
            }
//
//            public Action To<TActionResult>(Expression<Func<TController, TActionResult>> action)
//            {
//                return null;
//            }
        }
    }
}