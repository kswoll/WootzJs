using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    /// <summary>
    /// Detect if at bottom:
    /// window.innerHeight + window.scrollY >= (really just ==) document.body.scrollHeight
    /// </summary>
    [Js(Name = "WheelEvent", Export = false)]
    public class WheelEvent : MouseEvent
    {
        [Js(Name = "wheelDelta")]
        public int WheelDelta { get; set; }

        [Js(Name = "wheelDeltaX")]
        public int WheelDeltaX { get; set; }

        [Js(Name = "wheelDeltaY")]
        public int WheelDeltaY { get; set; }
    }
}