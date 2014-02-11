using System;
using System.Reflection;

namespace WootzJs.Mvc.Mvc
{
    public class ReflectionDependencyResolver : IDependencyResolver
    {
        public object GetService(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}