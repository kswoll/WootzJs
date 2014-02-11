using System;

namespace WootzJs.Injection
{
    public interface ICache
    {
        object Get(Type type); 
        void Set(Type type, object value);
    }
}