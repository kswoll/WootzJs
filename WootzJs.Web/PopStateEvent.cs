using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "Event", BuiltIn = true)]
    public class PopStateEvent
    {
        [Js(Name = "state", Export = false)]
        public readonly object State;
    }
}