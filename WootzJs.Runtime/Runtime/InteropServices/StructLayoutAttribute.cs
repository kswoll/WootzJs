using System.Runtime.WootzJs;

namespace System.Runtime.InteropServices
{
    [Js(Export = false)]
    [AttributeUsage(AttributeTargets.Struct)]
    public class StructLayoutAttribute : Attribute
    {
        internal LayoutKind _val;

        public int Pack;
        public int Size;
        public CharSet CharSet;

        private const int DEFAULT_PACKING_SIZE = 8;

        public LayoutKind Value
        {
            get { return this._val; }
        }

        internal StructLayoutAttribute(LayoutKind layoutKind, int pack, int size, CharSet charSet)
        {
            this._val = layoutKind;
            this.Pack = pack;
            this.Size = size;
            this.CharSet = charSet;
        }

        public StructLayoutAttribute(LayoutKind layoutKind)
        {
            this._val = layoutKind;
        }

        public StructLayoutAttribute(short layoutKind)
        {
            this._val = (LayoutKind)layoutKind;
        }
    }
}
