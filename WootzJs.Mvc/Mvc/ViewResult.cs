using WootzJs.Mvc.Mvc.Views;

namespace WootzJs.Mvc.Mvc
{
    public class ViewResult : ActionResult
    {
        public View View { get; private set; }

        public ViewResult(View view)
        {
            View = view;
        }

        public override void ExecuteResult(NavigationContext context)
        {
        }
    }
}