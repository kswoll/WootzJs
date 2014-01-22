using System.Runtime.WootzJs;

namespace System.Runtime.CompilerServices
{
    [Js(Export = false)]
    public class CallSite
    {
        public static CallSite Create(Type delegateType, CallSiteBinder binder)
        {
            return null;
        }
    }

    [Js(Export = false)]
    public class CallSite<T> : CallSite where T : class
    {
        public T Target;

        public static CallSite<T> Create(CallSiteBinder binder)
        {
            return null;
        }
    }
}
