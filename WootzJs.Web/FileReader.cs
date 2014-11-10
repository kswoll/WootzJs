using System;
using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "FileReader", Export = false)]
    public class FileReader
    {
        [Js(Name = "error")]
        public extern DOMError Error { get; }

        [Js(Name = "readyState")]
        public extern int ReadyState { get; }

        [Js(Name = "readAsDataURL")]
        public extern void ReadAsDataURL(Blob blob);

        [Js(Name = "readAsText")]
        public extern void ReadAsText(Blob blob);

        public extern 

        [Js(Name = "result")]
        public extern JsObject Result { get; }

        [Js(Name = "onload")]
        public Action<Event> OnLoad { get; set; }

        [Js(Name = "abort")]
        public extern void Abort();
    }
}