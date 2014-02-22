using System.Reflection;

namespace WootzJs.Mvc
{
    public interface IActionInvoker
    {
        ActionResult InvokeAction(ControllerContext context, MethodInfo action);
    }
}