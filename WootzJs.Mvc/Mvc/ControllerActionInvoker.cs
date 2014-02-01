using System.Reflection;

namespace WootzJs.Mvc.Mvc
{
    public class ControllerActionInvoker : IActionInvoker
    {
        public ActionResult InvokeAction(ControllerContext context, MethodInfo action)
        {
            return (ActionResult)action.Invoke(context.Controller, new object[0]);
        }
    }
}