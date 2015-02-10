using System.Runtime.InteropServices;
using System.Runtime.WootzJs;

namespace System
{
	[StructLayout(LayoutKind.Auto)]
    public struct Decimal : IFormattable, IComparable, IComparable<Decimal>, IEquatable<Decimal>
    {
        public static extern Decimal operator +(Decimal left, Decimal right);
        public static extern Decimal operator -(Decimal left, Decimal right);
        public static extern Decimal operator /(Decimal left, Decimal right);
        public static extern Decimal operator *(Decimal left, Decimal right);
        public static extern Decimal operator %(Decimal left, Decimal right);
        public static extern bool operator <(Decimal left, Decimal right);
        public static extern bool operator >(Decimal left, Decimal right);
        public static extern bool operator <=(Decimal left, Decimal right);
        public static extern bool operator >=(Decimal left, Decimal right);
        public static extern bool operator ==(Decimal left, Decimal right);
        public static extern bool operator !=(Decimal left, Decimal right);

	    public string ToString(string format, IFormatProvider formatProvider)
	    {
	        return ToString();
	    }

	    public int CompareTo(object obj)
	    {
	        return this.As<Number>().CompareTo(obj.As<Number>());
	    }

	    public int CompareTo(decimal other)
	    {
	        return this.As<Number>().CompareTo(other.As<Number>());
	    }

        public static explicit operator int(Decimal value)
        {
            return SpecialFunctions.Truncate(value.As<JsNumber>());
        }

	    public bool Equals(decimal other)
	    {
	        return this == other;
	    }

        public override int GetHashCode()
        {
// ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
        }

// ReSharper disable once RedundantOverridenMember
        public override bool Equals(object obj)
        {
// ReSharper disable once BaseObjectEqualsIsObjectEquals
            return base.Equals(obj);
        }
    }
}