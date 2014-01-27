using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Export = false)]
    public class History
    {
        [Js(Name = "pushState")]
        public extern void PushState(string url, string title, object state);
    }
}