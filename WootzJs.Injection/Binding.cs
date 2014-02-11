namespace WootzJs.Injection
{
    public class Binding : IBinding
    {
        private readonly IResolver resolver;
        private readonly IScope scope;

        public Binding(IResolver resolver, IScope scope) 
        {
            this.resolver = resolver;
            this.scope = scope;
        }

        public IResolver Resolver
        {
            get { return resolver; }
        }

        public IScope Scope
        {
            get { return scope; }
        }
    }
}