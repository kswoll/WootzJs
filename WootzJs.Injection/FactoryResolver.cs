using System;
using System.Linq.Expressions;
using System.Reflection;

namespace WootzJs.Injection
{
    public class FactoryResolver : IResolver
    {
        private Func<Request, Delegate> factory;
        private static MethodInfo requestCreateChildRequest;
        private static MethodInfo requestResolve;

        static FactoryResolver()
        {
            requestCreateChildRequest = typeof(Request).GetMethod("CreateChildRequest");
            requestResolve = typeof(Request).GetMethod("Resolve");
        }

        public FactoryResolver(Type type)
        {
            var requestParameter = Expression.Parameter(typeof(Request), "_");

            // Pseudo-code of what this expression tree is building toward
            // var childRequest = requestParameter.CreateChildRequest(type);
            var createChildRequest = Expression.Call(requestParameter, requestCreateChildRequest, Expression.Constant(type));

            // var resolution = childRequest.Resolve();
            var resolution = Expression.Call(createChildRequest, requestResolve);

            // var internalFactoryBody = (type)resolution;
            var internalFactoryBody = Expression.Convert(resolution, type);
            var internalFactoryType = typeof(Func<>).MakeGenericType(type);

            // Func<type> internalFactory = internalFactoryBody;
            var internalFactory = Expression.Lambda(internalFactoryType, internalFactoryBody);

            // Func<Request, Func<Type>> factory = requestParameter => internalFactory;
            var factory = Expression.Lambda<Func<Request, Delegate>>(internalFactory, requestParameter);

            this.factory = factory.Compile();
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