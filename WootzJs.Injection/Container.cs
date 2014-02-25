using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WootzJs.Injection.Scopes;

namespace WootzJs.Injection
{
    public class Container : Context
    {
        private static MethodInfo genericRegister = typeof(Container).GetMethod("Register", new[] { typeof(IResolver), typeof(IScope) });
        private static MethodInfo genericCreateRequest = typeof(Container).GetMethod("CreateRequest", new[] { typeof(Context), typeof(Request) });
        private static MethodInfo genericGet = typeof(Container).GetMethod("Get", new[] { typeof(IDictionary<Type, IBinding>) });

        public Container() : base(cache: new ConcurrentCache())
        {
            Register<Container>(SingletonScope.Instance);                   // Make sure the scope is set properly for containers
            Cache.Set(typeof(Container), this);                             // Containers are necessarily encapsulated so there can only be one instance (this).
        }

        public ConstantResolver Register<T>(object constant)
        {
            Cache.Set(typeof(T), constant);                                 // You really shouldn't be overwriting singletons, but if you need to, this makes sure the cache is updated
            return Register(typeof(T), constant, SingletonScope.Instance);
        }

        public ConstantResolver Register(Type type, object constant, IScope scope = null)
        {
            var resolver = new ConstantResolver(type, constant);
            Register(type, resolver, scope);
            return resolver;
        }

        public ReflectionResolver<T> Register<T>(IScope scope = null, Func<PropertyInfo, bool> propertyFilter = null)
        {
            var resolver = new ReflectionResolver<T>(propertyFilter);
            Register<T>(resolver, scope);
            return resolver;
        }

        public ReflectionResolver Register(Type type, IScope scope = null, Func<PropertyInfo, bool> propertyFilter = null)
        {
            var resolver = new ReflectionResolver(type, propertyFilter);
            Register(type, resolver, scope);
            return resolver;
        }

        public MethodResolver<T> Register<T>(Func<Request, T> factory, IScope scope = null)
        {
            var resolver = new MethodResolver<T>(factory);
            Register<T>(resolver, scope);
            return resolver;
        }

        public MethodResolver<object> Register(Type type, Func<Request, object> factory, IScope scope = null)
        {
            var resolver = new MethodResolver<object>(factory);
            Register(type, resolver, scope);
            return resolver;
        }

        public ReflectionResolver Register<T, TTarget>(IScope scope = null, Func<PropertyInfo, bool> propertyFilter = null)
            where TTarget : T
        {
            return Register(typeof(T), typeof(TTarget), scope, propertyFilter);
        }

        public ReflectionResolver Register(Type source, Type target, IScope scope = null, Func<PropertyInfo, bool> propertyFilter = null)
        {
            var resolver = new ReflectionResolver(target, propertyFilter);
            Register(source, resolver, scope);
            return resolver;
        }

        public void RegisterResolver(Type type, Type resolver, IScope scope = null)
        {
            Register(type, new ResolverFactoryResolver(resolver), scope);
        }

        public void RegisterResolver<T, TResolver>(IScope scope = null)
            where TResolver : IResolver
        {
            RegisterResolver(typeof(T), typeof(TResolver), scope);
        }

        public void Register(Type type, IResolver resolver, IScope scope = null)
        {
            genericRegister.MakeGenericMethod(type).Invoke(this, new object[] { resolver, scope });
        } 

        public void Register<T>(IResolver resolver, IScope scope = null)
        {
            scope = scope ?? NoScope.Instance;

            Binding<T>.resolver = resolver;
            Binding<T>.scope = scope;
        }

/*
        public TResolver Register<T, TResolver>(IScope scope = null)
            where TResolver : class, IResolver
        {
            var resolver = Get<TResolver>();
            Register<T>(resolver, scope);
            return resolver;
        }
*/

        public bool TryGet<T>(out T result, IDictionary<Type, IBinding> customBindings = null) where T : class
        {
            var request = CreateRequest<T>(new Context(this, transientBindings: customBindings));
            if (request == null)
            {
                result = null;
                return false;
            }
            else
            {
                result = Resolve<T>(request);
                return true;
            }
        }

        public bool TryGet(Type type, out object result, IDictionary<Type, IBinding> customBindings = null)
        {
            var request = CreateRequest(type, new Context(this, transientBindings: customBindings));
            if (request == null)
            {
                result = null;
                return false;
            }
            else
            {
                result = Resolve(request);
                return true;
            }
        }

        public object Get(Type type, IDictionary<Type, IBinding> customBindings = null)
        {
            return genericGet.MakeGenericMethod(type).Invoke(this, new[] { customBindings });
        }
        
        public T Get<T>(IDictionary<Type, IBinding> customBindings = null) where T : class
        {
            T result;
            if (!TryGet(out result, customBindings))
                throw new InvalidOperationException("No resolvers registered for " + typeof(T).FullName + " and type is not instantiatable.");
            return result;
        }

        public void Inject(object target, IDictionary<Type, IBinding> customBindings = null)
        {
            var request = CreateRequest(target.GetType(), new Context(this, transientBindings: customBindings));
            if (request == null)
                throw new InvalidOperationException("No resolvers registered for " + target.GetType().FullName + " and type is not instantiatable.");
            Activate(request, target);
        }

        public Request CreateRequest(Type type, Context context, Request parent = null)
        {
            return (Request)genericCreateRequest.MakeGenericMethod(type).Invoke(this, new object[] { context, parent });
        }

        public Request CreateRequest<T>(Context context, Request parent = null)
        {
            var binding = context.GetCustomBinding(typeof(T)) ?? Binding<T>.Value;

            if (binding == null && !IsInstantiatable(typeof(T)))
            {
                return null;
            }          
            if (binding == null)
            {
                binding = DefaultBinding<T>.Value;
            }

            context = binding.Scope.GetContext(context);

            return new Request(this, context, parent, typeof(T), binding);
        }

        public object Resolve(Request request) 
        {
            var cache = request.Binding.Scope.GetCache(request);

            Func<object> resolve = () =>
            {
                var result = cache.Get(request.Type);
                if (result != null)
                    return result;
                
                result = request.Binding.Resolver.Instantiate(request);
                cache.Set(request.Type, result);
                Activate(request, result);                
                return result;                                    
            };

            return resolve();
        }

        public void Activate(Request request, object o)
        {
            try
            {
                request.Binding.Resolver.Activate(request, o);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(GenerateRequestError("activating", request), e);
            }
        }

        private string GenerateRequestError(string action, Request request)
        {
            var builder = new StringBuilder("Error " + action + " request:\n");
            
            var current = request;
            while (current != null)
            {
                builder.AppendLine("Error activating " + current.Type.FullName);

                current = current.Parent;
            }
            return builder.ToString();
        }

        public T Resolve<T>(Request request) 
        {
            return (T)Resolve(request);
        }

        public static bool IsInstantiatable(Type type)
        {
            return !type.IsPrimitive && !type.IsAbstract && !type.IsInterface && type.GetConstructors().Length > 0;
        }

// ReSharper disable UnusedTypeParameter
        private static class Binding<T>
// ReSharper restore UnusedTypeParameter
        {
            internal static IResolver resolver;
            internal static IScope scope;

            public static IBinding Value
            {
                get
                {
                    return scope == null ? null : new Binding(resolver, scope);
                }
            }
        }

        private static class DefaultBinding<T>
        {
            private static IResolver resolver = CreateResolver();
            private static IScope scope = new NoScope();

            public static IBinding Value
            {
                get
                {
                    return new Binding(resolver, scope);
                }
            }

            private static IResolver CreateResolver()
            {
                if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Func<>))
                {
                    var returnType = typeof(T).GetGenericArguments()[0];
                    return new FactoryResolver(returnType);
                }
                else
                {
                    return new ReflectionResolver(typeof(T));
                }
            }
        }
    }
}