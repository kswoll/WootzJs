
namespace WootzJs.Mvc
{
    public class ControllerContext
    {
        public MvcApplication Application { get; set; }
        public NavigationContext NavigationContext { get; set; }
        public Controller Controller { get; set; }
    }
}