using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Name = "HTMLFormElement", Export = false)]
    public class FormElement : Element
    {
        [Js(Name = "submit")]
        public extern void Submit();
    }
}