using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Export = false)]
    public class HtmlOptionsCollection : HtmlCollection
    {
        [Js(Name = "item")]
        public new extern OptionElement this[int index] { get; set; }

        [Js(Name = "namedItem")]
        public new extern OptionElement NamedItem(int index);
    }
}