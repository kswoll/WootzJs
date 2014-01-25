using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Export = false)]
    public class PopStateEvent
    {
        [Js(Name = "state")]
        public readonly object State;
    }
}