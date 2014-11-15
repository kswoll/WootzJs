using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "MessageEvent", Export = false)]
    public class MessageEvent
    {
        [Js(Name = "data")]
        public JsObject Data { get; set; } 
    }
}