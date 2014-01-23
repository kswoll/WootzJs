using System.Runtime.InteropServices;

namespace System
{
    /// <summary>
    /// Do not use!  This class is only present to make VS consider this a valid minimal mscorlib.
    /// </summary>
	[StructLayout(LayoutKind.Auto)]
	public struct SByte
	{
		public string Format(string format)
		{
			return null;
		}
		public string LocaleFormat(string format)
		{
			return null;
		}
		public string ToString(int radix)
		{
			return null;
		}
		[CLSCompliant(false)]
		public static implicit operator Number(sbyte i)
		{
			return null;
		}
	}
}
