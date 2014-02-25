namespace WootzJs.Injection.Scopes
{
    public class TransientScope : IScope
    {
        private static TransientScope instance = new TransientScope();

        public static TransientScope Instance
        {
            get { return instance; }
        }

        public Context GetContext(Context current)
        {
            return current;
        }

        public ICache GetCache(Request request)
        {
            return request.Context.Cache;
        }
    }
}