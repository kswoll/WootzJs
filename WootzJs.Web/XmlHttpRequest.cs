using System;
using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "XMLHttpRequest", Export = false)]
    public class XmlHttpRequest
    {
        [Js(Name = "response")]
        public extern JsObject Response { get; }

        [Js(Name = "responseText")]
        public extern string ResponseText { get; }

        [Js(Name = "responseType")]
        public extern string ResponseType { get; }

        [Js(Name = "responseXML")]
        public extern Document ResponseXml { get; }

        [Js(Name = "status")]
        public extern int Status { get; }

        [Js(Name = "statusText")]
        public extern string StatusText { get; }

        [Js(Name = "open")]
        public extern void Open(string method, string url, bool isAsync = true, string user = "", 
            string password = "");

        [Js(Name = "send")]
        public extern void Send();

        [Js(Name = "onload")]
        public extern Action OnLoad { get; set; }

        [Js(Name = "onerror")]
        public extern Action OnError { get; set; }

        [Js(Name = "onprogress")]
        public extern Action OnProgress { get; set; }

        [Js(Name = "addEventListener")]
        public extern void AddEventListener(string type, Action<Event> listener);

        [Js(Name = "removeEventListener")]
        public extern void RemoveEventListener(string type, Action<Event> listener);

        [Js(Name = "setRequestHeader")]
        public extern void SetRequestHeader(string header, string value);
    }
}