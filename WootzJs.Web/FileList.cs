using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Export = false)]
    public class FileList
    {
        [Js(Name = "length")]
        public extern int Length { get; }

        [Js(Name = "item")]
        public extern File this[int index] { get; set; }

        [Js(Name = "namedItem")]
        public extern File NamedItem(int index);         
    }
}