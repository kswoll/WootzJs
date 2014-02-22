
namespace WootzJs.Mvc
{
    public interface IControllerFactory
    {
        Controller CreateController(NavigationContext request); 
    }
}