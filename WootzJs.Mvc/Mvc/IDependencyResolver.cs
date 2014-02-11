using System;

namespace WootzJs.Mvc.Mvc
{
    public interface IDependencyResolver
    {
        object GetService(Type type); 
    }
}