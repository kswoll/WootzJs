using System;
using System.Reflection;
using WootzJs.Mvc.Mvc.Routes;

namespace WootzJs.Mvc.Mvc
{
    public class DefaultControllerFactory : IControllerFactory
    {
        public Controller CreateController(NavigationContext context)
        {
            var controllerType = (Type)context.Request.RouteData[RouteData.ControllerKey];
            return (Controller)Activator.CreateInstance(controllerType);
        }
    }
}