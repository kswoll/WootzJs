using System;
using System.Reflection;

namespace WootzJs.Mvc
{
    public interface IActionInvoker
    {
        void InvokeAction(ControllerContext context, MethodInfo action, Action<ActionResult> continuation);
    }
}