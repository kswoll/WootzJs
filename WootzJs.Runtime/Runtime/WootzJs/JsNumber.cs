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

namespace System.Runtime.WootzJs
{
    [Js(Name = "Number", Export = false)]
    public class JsNumber : JsObject
    {
        public JsNumber valueOf()
        {
            return null;
        }

        /// <summary>
        /// The toString() method returns a string representing the specified Number object.
        /// 
        /// The Number object overrides the toString() method of the Object object; it does not inherit Object.prototype.toString(). For Number objects, the toString() method returns a string representation of the object in the specified radix.
        /// The toString() method parses its first argument, and attempts to return a string representation in the specified radix (base). For radixes above 10, the letters of the alphabet indicate numerals greater than 9. For example, for hexadecimal numbers (base 16), a through f are used.
        /// If the radix is not specified, the preferred radix is assumed to be 10.
        /// If the number is negative, the sign is preserved. Especially if the radix is 2, it's returning the binary (zeros and ones) of the number preceeded by a - sign but the two's complement.
        /// </summary>
        /// <param name="radix">An integer between 2 and 36 specifying the base to use for representing numeric values.</param>
        /// <returns>For Number objects, the toString() method returns a string representation of the object in the specified radix.</returns>
        [Js(Name = "toString")]
        public JsString toString(int radix)
        {
            return null;
        }

        public static extern bool operator <(JsNumber left, JsNumber right);
        public static extern bool operator >(JsNumber left, JsNumber right);
        public static extern JsNumber operator -(JsNumber left, JsNumber right);
        public static extern JsNumber operator +(JsNumber left, JsNumber right);
        public static extern JsNumber operator /(JsNumber left, JsNumber right);
        public static extern JsNumber operator *(JsNumber left, JsNumber right);
        public static extern JsNumber operator %(JsNumber left, JsNumber right);
        public static extern implicit operator JsNumber(int value);
        public static extern implicit operator JsNumber(long value);
        public static extern implicit operator JsNumber(float value);
        public static extern implicit operator JsNumber(double value);
        public static extern implicit operator JsNumber(short value);
        public static extern implicit operator JsNumber(byte value);
        public static extern implicit operator JsNumber(sbyte value);
        public static extern implicit operator JsNumber(ushort value);
        public static extern implicit operator JsNumber(uint value);
        public static extern implicit operator JsNumber(ulong value);
        public static extern implicit operator JsNumber(decimal value);
        public static extern implicit operator int(JsNumber value);
        public static extern implicit operator long(JsNumber value);
        public static extern implicit operator float(JsNumber value);
        public static extern implicit operator double(JsNumber value);
        public static extern implicit operator short(JsNumber value);
        public static extern implicit operator byte(JsNumber value);
        public static extern implicit operator sbyte(JsNumber value);
        public static extern implicit operator ushort(JsNumber value);
        public static extern implicit operator uint(JsNumber value);
        public static extern implicit operator ulong(JsNumber value);
        public static extern implicit operator decimal(JsNumber value);
    }
}
