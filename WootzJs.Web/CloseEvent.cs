using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "CloseEvent", Export = false)]
    public class CloseEvent
    {
        [Js(Name = "code")]
        public int Code { get; set; }

        [Js(Name = "reason")]
        public string Reason { get; set; }

        [Js(Name = "wasClean")]
        public bool WasClean { get; set; }
    }
}