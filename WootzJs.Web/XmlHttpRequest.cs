using System;
using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "XMLHttpRequest", Export = false)]
    public class XmlHttpRequest
    {
        [Js(Name = "response")]
        public extern JsObject Response { get; }

        [Js(Name = "open")]
        public extern void Open(string method, string url, bool isAsync = true, string user = "", 
            string password = "");

        [Js(Name = "send")]
        public extern void Send();

        [Js(Name = "addEventListener")]
        public extern void AddEventListener(string type, Action<Event> listener);

        [Js(Name = "removeEventListener")]
        public extern void RemoveEventListener(string type, Action<Event> listener);

        [Js(Name = "setRequestHeader")]
        public extern void SetRequestHeader(string header, string value);
    }
}