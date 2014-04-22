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
            var lastParameter = parameters.LastOrDefault();

            // If async
            if (lastParameter != null && lastParameter.ParameterType == typeof(Action<ActionResult>))
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