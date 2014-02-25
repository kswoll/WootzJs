using System;
using System.Collections.Generic;

namespace WootzJs.Injection
{
    public class Context
    {
        private ICache cache;
        private IDictionary<Type, IBinding> transientBindings;

        public Context(Context context = null, ICache cache = null, IDictionary<Type, IBinding> transientBindings = null)
        {
            cache = cache ?? new Cache();
            this.cache = context != null ? new HybridCache(cache, context.Cache) : cache;
            this.transientBindings = transientBindings;
        }

        public ICache Cache
        {
            get { return cache; }
        }

        public IBinding GetCustomBinding(Type type)
        {
            if (transientBindings == null)
                return null;

            while (type != null)
            {
                IBinding result;
                if (transientBindings.TryGetValue(type, out result)) 
                    return result;
                type = type.BaseType;
            }
            return null;
        }
    }
}