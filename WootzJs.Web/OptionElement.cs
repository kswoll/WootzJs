using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Export = false)]
    public class OptionElement : Element
    {
        [Js(Name = "index")]
        public extern int Index { get; }

        [Js(Name = "value")]
        public extern string Value { get; }

        [Js(Name = "text")]
        public extern string Text { get; }

        [Js(Name = "selected")]
        public extern bool Selected { get; set; }
    }
}