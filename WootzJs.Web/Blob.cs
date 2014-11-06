using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "Blob", Export = false)]
    public class Blob : JsObject
    {
        [Js(Name = "size")]
        public extern long Size { get; }

        [Js(Name = "type")]
        public extern string Type { get; }
    }
}