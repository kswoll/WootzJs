using System;

namespace WootzJs.Mvc
{
    public interface IDependencyResolver
    {
        object GetService(Type type); 
    }
}