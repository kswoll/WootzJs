using System;
using System.Linq;
using System.Reflection;

namespace WootzJs.Mvc
{
    public class ControllerActionInvoker : IActionInvoker
    {
        public void InvokeAction(ControllerContext context, MethodInfo action, Action<ActionResult> continuation)
        {
            var parameters = action.GetParameters();
            var args = new object[parameters.Length];
            var lastParameter = parameters.LastOrDefault();

            // If async
            if (lastParameter != null && lastParameter.ParameterType == typeof(Action<ActionResult>))
            {
                args[args.Length - 1] = continuation;
                action.Invoke(context.Controller, args);
            }
            // If synchronous
            else
            {
                var actionResult = (ActionResult)action.Invoke(context.Controller, args);
                continuation(actionResult);
            }
        }
    }
}