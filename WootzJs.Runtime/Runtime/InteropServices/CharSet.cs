using System.Runtime.WootzJs;

namespace System.Runtime.InteropServices
{
    [Js(Export = false)]
    public enum CharSet
    {
        None = 1,
        Ansi = 2,
        Unicode = 3,
        Auto = 4,
    }
}
