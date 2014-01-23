using System.Runtime.InteropServices;

namespace System
{
	[StructLayout(LayoutKind.Auto)]
	public struct Char
	{
		/// <internalonly />
		public static explicit operator string(char ch)
		{
			return null;
		}
	}
}
