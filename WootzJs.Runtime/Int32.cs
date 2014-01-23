#region License
//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------
#endregion

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
