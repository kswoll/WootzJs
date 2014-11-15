using System;
using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "WebSocket", Export = false)]
    public class WebSocket
    {
        public WebSocket(string url)
        {
        }

        public WebSocket(string url, string[] protocols = null)
        {
        }

        [Js(Name = "binaryType")]
        public extern string BinaryType { get; set; }

        [Js(Name = "bufferedAmount")]
        public extern string BufferedAmount { get; set; }

        [Js(Name = "protocol")]
        public extern string Protocol { get; }

        [Js(Name = "readyState")]
        public extern int ReadyState { get; }

        [Js(Name = "url")]
        public extern string Url { get;  }

        [Js(Name = "onclose")]
        public extern Action<CloseEvent> OnClose { get; set; }

        [Js(Name = "onmessage")]
        public extern Action<MessageEvent> OnMessage { get; set; }

        [Js(Name = "onerror")]
        public extern Action OnError { get; set; }

        [Js(Name = "onopen")]
        public extern Action OnOpen { get; set; }

        [Js(Name = "close")]
        public extern void Close(int code = (int)CloseReason.CloseNormal, string reason = null);

        [Js(Name = "send")]
        public extern void Send(string data);

        [Js(Name = "send")]
        public extern void Send(Blob data);
    }
}