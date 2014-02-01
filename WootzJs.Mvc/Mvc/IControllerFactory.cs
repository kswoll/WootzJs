
namespace WootzJs.Mvc.Mvc
{
    public interface IControllerFactory
    {
        Controller CreateController(NavigationContext request); 
    }
}