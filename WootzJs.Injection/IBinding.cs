namespace WootzJs.Injection
{
    public interface IBinding
    {
        IResolver Resolver { get; }
        IScope Scope { get; }
    }
}