using System.Runtime.InteropServices;

namespace System
{
	[StructLayout(LayoutKind.Auto)]
	public struct Nullable<T> where T : struct
	{
		public bool HasValue
		{
			get { return false; }
		}

		public T Value
		{
			get { return default(T); }
		}

		public Nullable(T value)
		{
		}

		public T GetValueOrDefault()
		{
			return default(T);
		}

		public static implicit operator T?(T value)
		{
			return null;
		}

		public static explicit operator T(T? value)
		{
			return default(T);
		}
	}
}
