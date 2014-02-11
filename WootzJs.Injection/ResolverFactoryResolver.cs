using System;

namespace WootzJs.Injection
{
    public class ResolverFactoryResolver : IResolver
    {
        private Type resolverType;

        public ResolverFactoryResolver(Type resolverType)
        {
            this.resolverType = resolverType;
        }

        public object Instantiate(Request request)
        {
            var resolver = (IResolver)request.Get(resolverType);
            return resolver.Instantiate(request);
        }

        public void Activate(Request request, object o)
        {
        }
    }
}