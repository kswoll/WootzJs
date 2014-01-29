using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Export = false)]
    public class Location
    {
        [Js(Name = "pathname")]
// ReSharper disable once UnassignedReadonlyField
        public readonly string PathName;

        [Js(Name = "host")]
// ReSharper disable once UnassignedReadonlyField
        public readonly string Host;

        [Js(Name = "port")]
// ReSharper disable once UnassignedReadonlyField
        public readonly string Port;

        [Js(Name = "protocol")]
// ReSharper disable once UnassignedReadonlyField
        public readonly string Protocol;

        [Js(Name = "search")]
// ReSharper disable once UnassignedReadonlyField
        public readonly string Search;
    }
}