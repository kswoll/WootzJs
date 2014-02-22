using System;

namespace WootzJs.Mvc
{
    public class ReflectionDependencyResolver : IDependencyResolver
    {
        public object GetService(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}