using System.Runtime.InteropServices;

namespace System
{
    /// <summary>
    /// Do not use!  This class is only present to make VS consider this a valid minimal mscorlib.
    /// </summary>
	[StructLayout(LayoutKind.Auto)]
	public struct Single
	{
		public string Format(string format)
		{
			return null;
		}
		public string LocaleFormat(string format)
		{
			return null;
		}
		public static float Parse(string s)
		{
			return 0f;
		}
		public string ToExponential()
		{
			return null;
		}
		public string ToExponential(int fractionDigits)
		{
			return null;
		}
		public string ToFixed()
		{
			return null;
		}
		public string ToFixed(int fractionDigits)
		{
			return null;
		}
		public string ToPrecision()
		{
			return null;
		}
		public string ToPrecision(int precision)
		{
			return null;
		}
		public static implicit operator Number(float i)
		{
			return null;
		}
	}
}
