using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "KeyboardEvent", Export = false)]
    public class KeyboardEvent : Event
    {
        [Js(Name = "altKey")]
        public extern bool AltKey { get; }

        [Js(Name = "code")]
        public extern string Code { get; }

        [Js(Name = "ctrlKey")]
        public extern bool CtrlKey { get; }

        [Js(Name = "isComposing")]
        public extern bool IsComposing { get; }

        [Js(Name = "key")]
        public extern string Key { get; }

        [Js(Name = "locale")]
        public extern string Locale { get; }

        [Js(Name = "location")]
        public extern ulong Location { get; }

        [Js(Name = "metaKey")]
        public extern bool MetaKey { get; }

        [Js(Name = "repeat")]
        public extern bool Repeat { get; }

        [Js(Name = "shiftKey")]
        public extern bool ShiftKey { get; }
    }
}