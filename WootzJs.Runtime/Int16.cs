using System.Runtime.InteropServices;

namespace System
{
	[StructLayout(LayoutKind.Auto)]
	public struct Int16
	{
		public string Format(string format)
		{
			return null;
		}
		public string LocaleFormat(string format)
		{
			return null;
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
		public static implicit operator Number(short i)
		{
			return null;
		}
	}
}
