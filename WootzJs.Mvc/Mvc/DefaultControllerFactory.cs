using System;
using System.Reflection;
using WootzJs.Mvc.Mvc.Routes;

namespace WootzJs.Mvc.Mvc
{
    public class DefaultControllerFactory : IControllerFactory
    {
        private IDependencyResolver dependencyResolver;

        public DefaultControllerFactory(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public Controller CreateController(NavigationContext context)
        {
            var controllerType = (Type)context.Request.RouteData[RouteData.ControllerKey];
            return (Controller)dependencyResolver.GetService(controllerType);
        }
    }
}