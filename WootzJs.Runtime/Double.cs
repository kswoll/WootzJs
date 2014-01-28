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
	[StructLayout(LayoutKind.Auto), Js(BaseType = typeof(Number))]
	public struct Double
	{
		public string Format(string format)
		{
			return null;
		}
		public string LocaleFormat(string format)
		{
			return null;
		}

		public static double Parse(string s)
		{
			return Jsni.parseFloat(s.As<JsString>()).As<double>();
		}

		/// <summary>
		/// Returns a string containing the value represented in exponential notation.
		/// </summary>
		/// <returns>The exponential representation</returns>
		public string ToExponential()
		{
			return null;
		}
		/// <summary>
		/// Returns a string containing the value represented in exponential notation.
		/// </summary>
		/// <param name="fractionDigits">The number of digits after the decimal point from 0 - 20</param>
		/// <returns>The exponential representation</returns>
		public string ToExponential(int fractionDigits)
		{
			return null;
		}
		/// <summary>
		/// Returns a string representing the value in fixed-point notation.
		/// </summary>
		/// <returns>The fixed-point notation</returns>
		public string ToFixed()
		{
			return null;
		}
		/// <summary>
		/// Returns a string representing the value in fixed-point notation.
		/// </summary>
		/// <param name="fractionDigits">The number of digits after the decimal point from 0 - 20</param>
		/// <returns>The fixed-point notation</returns>
		public string ToFixed(int fractionDigits)
		{
			return null;
		}
		/// <summary>
		/// Returns a string containing the value represented either in exponential or
		/// fixed-point notation with a specified number of digits.
		/// </summary>
		/// <returns>The string representation of the value.</returns>
		public string ToPrecision()
		{
			return null;
		}
		/// <summary>
		/// Returns a string containing the value represented either in exponential or
		/// fixed-point notation with a specified number of digits.
		/// </summary>
		/// <param name="precision">The number of significant digits (in the range 1 to 21)</param>
		/// <returns>The string representation of the value.</returns>
		public string ToPrecision(int precision)
		{
			return null;
		}
		/// <internalonly />
		public static implicit operator Number(double i)
		{
			return null;
		}

        public static bool IsNaN(double value)
        {
            return value == Number.NaN;
        }
	}
}
