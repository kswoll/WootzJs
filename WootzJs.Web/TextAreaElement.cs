using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Export = false)]
    public class TextAreaElement : Element
    {
        [Js(Name = "value")]
        public string Value { get; set; } 
    }
}