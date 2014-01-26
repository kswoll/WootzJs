using System.Runtime.InteropServices;

namespace System
{
	[StructLayout(LayoutKind.Auto)]
    public struct Decimal
    {
        public extern static Decimal operator +(Decimal left, Decimal right);
        public extern static Decimal operator -(Decimal left, Decimal right);
        public extern static Decimal operator /(Decimal left, Decimal right);
        public extern static Decimal operator *(Decimal left, Decimal right);
        public extern static Decimal operator %(Decimal left, Decimal right);
    }
}