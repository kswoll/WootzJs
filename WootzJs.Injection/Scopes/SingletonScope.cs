namespace WootzJs.Injection.Scopes
{
    public class SingletonScope : IScope
    {
        private static SingletonScope instance = new SingletonScope();

        public object GetLock(Request request)
        {
            return request.Container;
        }

        public static SingletonScope Instance
        {
            get { return instance; }
        }

        public Context GetContext(Context current)
        {
            return current;
        }

        public ICache GetCache(Request request)
        {
            return request.Container.Cache;
        }
    }
}