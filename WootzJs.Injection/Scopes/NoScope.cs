using System;

namespace WootzJs.Injection.Scopes
{
    public class NoScope : IScope
    {
        private static NoScope instance = new NoScope();

        public static NoScope Instance
        {
            get { return instance; }
        }

        public object GetLock(Request request)
        {
            return null;
        }

        public Context GetContext(Context current)
        {
            return current;
        }

        public ICache GetCache(Request request)
        {
            return new NoCache();
        }

        private class NoCache : ICache
        {
            public object Get(Type type)
            {
                return null;
            }

            public void Set(Type type, object value)
            {
            }
        }
    }
}