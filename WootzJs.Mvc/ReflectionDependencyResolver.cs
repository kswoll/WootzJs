using System;
using System.Collections.Generic;

namespace WootzJs.Mvc
{
    public class ReflectionDependencyResolver : IDependencyResolver
    {
        public object GetService(Type type, IDictionary<Type, object> parameters = null)
        {
            if (parameters != null)
                throw new Exception("Parameters not supported with this dependency resolver");
            return Activator.CreateInstance(type);
        }
    }
}