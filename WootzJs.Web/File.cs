using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "File", Export = false)]
    public class File : Blob
    {
        [Js(Name = "lastModifiedDate")]
        public extern JsDate LastModifiedDate { get; }

        [Js(Name = "name")]
        public extern JsString Name { get; }
    }
}