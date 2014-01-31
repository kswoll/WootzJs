using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Export = false)]
    public class DomTokenList
    {
        [Js(Name = "length")]
        public readonly int Length;

        [Js(Name = "item")]
        public extern string this[int index] { get; set; }

        [Js(Name = "contains")]
        public extern bool Contains(string token);

        [Js(Name = "add")]
        public extern void Add(string token);

        [Js(Name = "remove")]
        public extern void Remove(string token);

        [Js(Name = "toggle")]
        public extern bool Toggle(string token);
    }
}