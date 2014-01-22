using System.Runtime.WootzJs;

namespace System.Runtime.InteropServices
{
    [Js(Export = false)]
    public enum LayoutKind
    {
        Sequential = 0,
        Explicit = 2,
        Auto = 3,
    }
}
