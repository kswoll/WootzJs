using System.Runtime.InteropServices;
using System.Runtime.WootzJs;

namespace System
{
	/// <summary>
	/// The int data type which is mapped to the Number type in Javascript.
	/// </summary>
	[StructLayout(LayoutKind.Auto)]
	public struct Int32 : IComparable, IComparable<int>
	{
        /// <summary>
        /// Represents the largest possible value of an <see cref="T:System.Int32"/>. This field is constant.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public const int MaxValue = 2147483647;

        /// <summary>
        /// Represents the smallest possible value of <see cref="T:System.Int32"/>. This field is constant.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public const int MinValue = -2147483648;

        [Js(Name = "GetType")]
        public new Type GetType()
        {
            return base.GetType();
        }

		public string Format(string format)
		{
			return null;
		}
		public string LocaleFormat(string format)
		{
			return null;
		}

        public static int Parse(string s)
		{
			var result = Jsni.parseInt(s);
            if (Jsni.isNaN(result))
                throw new FormatException("String not convertible to int: " + s);
            return result.As<int>();
		}

        public static int Parse(string s, int radix)
		{
			var result = Jsni.parseInt(s, radix);
            if (Jsni.isNaN(result))
                throw new FormatException("String not convertible to int: " + s);
            return result.As<int>();
		}

		/// <summary>
		/// Converts the value to its string representation.
		/// </summary>
		/// <param name="radix">The radix used in the conversion (eg. 10 for decimal, 16 for hexadecimal)</param>
		/// <returns>The string representation of the value.</returns>
		public string ToString(int radix)
		{
			return null;
		}
		/// <internalonly />
		public static implicit operator Number(int i)
		{
			return null;
		}

	    public int CompareTo(object obj)
	    {
	        return CompareTo((int)obj);
	    }

	    public int CompareTo(int other)
	    {
	        return this - other;
	    }
	}
}
