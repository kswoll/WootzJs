using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "window", Export = false)]
    public static class Window
    {
        [Js(Name = "location")]
        public static Location Location;

        [Js(Name = "onpopstate")]
        public static PopStateEventHandler OnPopState;

        [Js(Name = "history")]
// ReSharper disable once UnassignedReadonlyField
        public static readonly History History;
    }
}