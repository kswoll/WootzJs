using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Export = false)]
    public class Location
    {
        [Js(Name = "pathname")]
        public readonly string PathName;

        [Js(Name = "host")]
        public readonly string Host;

        [Js(Name = "port")]
        public readonly string Port;

        [Js(Name = "protocol")]
        public readonly string Protocol;

        [Js(Name = "search")]
        public readonly string Search;
    }
}