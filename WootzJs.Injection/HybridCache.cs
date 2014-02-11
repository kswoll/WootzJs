using System;

namespace WootzJs.Injection
{
    public class HybridCache : ICache
    {
        private ICache primaryCache;
        private ICache secondaryCache;

        public HybridCache(ICache primaryCache, ICache secondaryCache)
        {
            this.primaryCache = primaryCache;
            this.secondaryCache = secondaryCache;
        }

        public object Get(Type type)
        {
            return primaryCache.Get(type) ?? secondaryCache.Get(type);
        }

        public void Set(Type type, object value)
        {
            primaryCache.Set(type, value);
        }
    }
}