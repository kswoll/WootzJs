namespace WootzJs.Injection
{
    public interface IScope
    {
        object GetLock(Request request);
        Context GetContext(Context current);
        ICache GetCache(Request request);
    }
}