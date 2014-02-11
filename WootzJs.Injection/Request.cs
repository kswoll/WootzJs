using System;

namespace WootzJs.Injection
{
    public class Request
    {
        private Container container;
        private Context context;
        private Request parent;
        private Type type;
        private IBinding binding;
         
        public Request(Container container, Context context, Request parent, Type type, IBinding binding)
        {
            this.container = container;
            this.context = context;
            this.parent = parent;
            this.type = type;
            this.binding = binding;
        }

        public object Resolve()
        {
            return Container.Resolve(this);
        }

        public object Get(Type type)
        {
            return CreateChildRequest(type).Resolve();
        }

        public T Get<T>()
        {
            return (T)CreateChildRequest(typeof(T)).Resolve();
        }

        public Request CreateChildRequest(Type type)
        {
            return Container.CreateRequest(type, context, this);
        }

        public Container Container
        {
            get { return container; }
        }

        public Context Context
        {
            get { return context; }
        }

        public Request Parent
        {
            get { return parent; }
        }

        public Type Type
        {
            get { return type; }
        }

        public IBinding Binding
        {
            get { return binding; }
        }
    }
}