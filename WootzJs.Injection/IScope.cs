namespace WootzJs.Injection
{
    public interface IScope
    {
        Context GetContext(Context current);
        ICache GetCache(Request request);
    }
}