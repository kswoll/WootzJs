using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WootzJs.Mvc
{
    public class ControllerActionInvoker : IActionInvoker
    {
        public Task<ActionResult> InvokeAction(ControllerContext context, MethodInfo action)
        {
            var parameters = action.GetParameters();
            var args = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                var key = parameters[i].Name;
                object value;
                if (context.NavigationContext.Request.QueryString.ContainsKey(key))
                    value = context.NavigationContext.Request.QueryString[key];
                else
                    value = context.Controller.RouteData[key];
                args[i] = value;
            }

            // If async
            if (action.ReturnType == typeof(Task<ActionResult>))
            {
                return (Task<ActionResult>)action.Invoke(context.Controller, args);
            }
            // If synchronous
            else
            {
                var actionResult = (ActionResult)action.Invoke(context.Controller, args);
                return Task.FromResult(actionResult);
            }
        }
    }
}