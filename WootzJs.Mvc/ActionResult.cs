namespace WootzJs.Mvc
{
    public abstract class ActionResult
    {
        public abstract void ExecuteResult(NavigationContext context);
    }
}