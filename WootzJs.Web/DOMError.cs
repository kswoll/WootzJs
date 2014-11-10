using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "DOMError", Export = false)]
    public class DOMError
    {
        [Js(Name = "name")]
        public extern string Name { get; }
    }
}