using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "HTMLSelectElement", Export = false)]
    public class SelectElement : Element
    {
        [Js(Name = "selectedIndex")]
        public extern long SelectedIndex { get; set; }

        [Js(Name = "options")]
        public extern HtmlOptionsCollection Options { get; set; }

        [Js(Name = "selectedOptions")]
        public extern HtmlOptionsCollection SelectedOptions { get; set; }
    }
}