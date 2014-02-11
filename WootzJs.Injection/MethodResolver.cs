using System;

namespace WootzJs.Injection
{
    public class MethodResolver<T> : IResolver
    {
        private Func<Request, T> factory;

        public MethodResolver(Func<Request, T> factory)
        {
            this.factory = factory;
        }

        public object Instantiate(Request request)
        {
            return factory(request);
        }

        public void Activate(Request request, object o)
        {
        }
    }
}