using System;
using System.Collections.Generic;

namespace WootzJs.Mvc
{
    public interface IDependencyResolver
    {
        object GetService(Type type, IDictionary<Type, object> parameters = null); 
    }
}