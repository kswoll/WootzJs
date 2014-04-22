using System;
using System.Reflection;
using System.Threading.Tasks;

namespace WootzJs.Mvc
{
    public interface IActionInvoker
    {
        Task<ActionResult> InvokeAction(ControllerContext context, MethodInfo action);
    }
}