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

using System.Runtime.WootzJs;

namespace System
{
	/// <summary>
	/// Equivalent to the Number type in Javascript.
	/// </summary>
    [Js(Name = "Number", BuiltIn = true, BaseType = typeof(Object))]
	public abstract class Number : IComparable
	{
		public const int MAX_VALUE = 0;
		public const int MIN_VALUE = 0;
		public const int NaN = 0;
		public const int NEGATIVE_INFINITY = 0;
		public const int POSITIVE_INFINITY = 0;

        [Js(Name = "GetType")]
        public new Type GetType()
        {
            return base.GetType();
        }

		public string Format(string format)
		{
			return null;
		}

		public static bool IsFinite(Number n)
		{
			return false;
		}

		public static bool IsNaN(Number n)
		{
			return false;
		}

		public string LocaleFormat(string format)
		{
			return null;
		}

		public static Number Parse(string s)
		{
			return null;
		}

		public static double ParseDouble(string s)
		{
			return 0.0;
		}

		public static float ParseFloat(string s)
		{
			return 0f;
		}

		public static int ParseInt(float f)
		{
			return 0;
		}

		public static int ParseInt(double d)
		{
			return 0;
		}

		public static int ParseInt(string s)
		{
			return 0;
		}
		public static int ParseInt(string s, int radix)
		{
			return 0;
		}

		/// <summary>
		/// Returns a string containing the number represented in exponential notation.
		/// </summary>
		/// <returns>The exponential representation</returns>
		public string ToExponential()
		{
			return null;
		}

		/// <summary>
		/// Returns a string containing the number represented in exponential notation.
		/// </summary>
		/// <param name="fractionDigits">The number of digits after the decimal point (0 - 20)</param>
		/// <returns>The exponential representation</returns>
		public string ToExponential(int fractionDigits)
		{
			return null;
		}

		/// <summary>
		/// Returns a string representing the number in fixed-point notation.
		/// </summary>
		/// <returns>The fixed-point notation</returns>
		public string ToFixed()
		{
			return null;
		}

		/// <summary>
		/// Returns a string representing the number in fixed-point notation.
		/// </summary>
		/// <param name="fractionDigits">The number of digits after the decimal point from 0 - 20</param>
		/// <returns>The fixed-point notation</returns>
		public string ToFixed(int fractionDigits)
		{
			return null;
		}

		/// <summary>
		/// Returns a string containing the number represented either in exponential or
		/// fixed-point notation with a specified number of digits.
		/// </summary>
		/// <returns>The string representation of the value.</returns>
		public string ToPrecision()
		{
			return null;
		}

		/// <summary>
		/// Returns a string containing the number represented either in exponential or
		/// fixed-point notation with a specified number of digits.
		/// </summary>
		/// <param name="precision">The number of significant digits (in the range 1 to 21)</param>
		/// <returns>The string representation of the value.</returns>
		public string ToPrecision(int precision)
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

        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format)) 
                return ToString();

            if (format[0] == 'X')
            {
                var radix = 16;
                var remainingFormat = format.Substring(1);
                var s = this.As<JsNumber>().toString(radix);
                if (remainingFormat.Length > 0)
                {
                    var minimumDigits = int.Parse(remainingFormat);
                    while (s.length < minimumDigits.As<JsNumber>())
                        s = "0" + s;
                }
                return s;
            }
            throw new Exception();
        }

	    public int CompareTo(object obj)
	    {
	        return (this.As<JsNumber>() - obj.As<JsNumber>()).As<int>();
	    }

// ReSharper disable once RedundantOverridenMember
        public override string GetStringHashCode()
        {
            // We need to override it to make sure this method gets added to the String prototype.
            return base.GetStringHashCode();
        }

// ReSharper disable once RedundantOverridenMember
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }
	}
}
