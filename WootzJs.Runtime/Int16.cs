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
	[StructLayout(LayoutKind.Auto)]
	public struct Int16
	{
        [Js(Name = "GetType")]
        public new Type GetType()
        {
            return base.GetType();
        }

        public static short Parse(string s)
		{
			var result = Jsni.parseInt(s);
            if (Jsni.isNaN(result))
                throw new FormatException("String not convertible to int: " + s);
            return result.As<short>();
		}

        public static short Parse(string s, int radix)
		{
			var result = Jsni.parseInt(s, radix);
            if (Jsni.isNaN(result))
                throw new FormatException("String not convertible to int: " + s);
            return result.As<short>();
		}

        public string ToString(string format)
        {
            return this.As<Number>().ToString(format);
        }

        /// <summary>
        /// Converts the value to its string representation.
        /// </summary>
        /// <param name="radix">The radix used in the conversion (eg. 10 for decimal, 16 for hexadecimal)</param>
        /// <returns>The string representation of the value.</returns>
        public string ToString(int radix)
        {
            return this.As<Number>().ToString(radix);
        }

	    public int CompareTo(object obj)
	    {
	        return CompareTo((short)obj);
	    }

	    public int CompareTo(short other)
	    {
	        return this - other;
	    }

        public static bool TryParse(string s, out short result)
        {
            var returnValue = Jsni.parseInt(s);
            if (Jsni.isNaN(returnValue))
            {
                result = 0;
                return false;
            }
            result = returnValue.As<short>();
            return true;
        }
	}
}
