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

        public static bool operator <(JsNumber left, JsNumber right)
        {
            return false;
        }

        public static bool operator >(JsNumber left, JsNumber right)
        {
            return false;            
        }

        public static JsNumber operator -(JsNumber left, JsNumber right)
        {
            return null;
        }

        public static JsNumber operator +(JsNumber left, JsNumber right)
        {
            return null;
        }

        public static JsNumber operator /(JsNumber left, JsNumber right)
        {
            return null;
        }

        public static JsNumber operator *(JsNumber left, JsNumber right)
        {
            return null;
        }

        public static JsNumber operator %(JsNumber left, JsNumber right)
        {
            return null;
        }

        public static implicit operator JsNumber(int value)
        {
            return value.As<JsNumber>();
        }

        public static implicit operator JsNumber(long value)
        {
            return value.As<JsNumber>();
        }

        public static implicit operator JsNumber(float value)
        {
            return value.As<JsNumber>();
        }

        public static implicit operator JsNumber(double value)
        {
            return value.As<JsNumber>();
        }

        public static implicit operator JsNumber(short value)
        {
            return value.As<JsNumber>();
        }

        public static implicit operator JsNumber(byte value)
        {
            return value.As<JsNumber>();
        }

        public static implicit operator JsNumber(sbyte value)
        {
            return value.As<JsNumber>();
        }

        public static implicit operator JsNumber(ushort value)
        {
            return value.As<JsNumber>();
        }

        public static implicit operator JsNumber(uint value)
        {
            return value.As<JsNumber>();
        }

        public static implicit operator JsNumber(ulong value)
        {
            return value.As<JsNumber>();
        }

        public static implicit operator JsNumber(decimal value)
        {
            return value.As<JsNumber>();
        }

        public static implicit operator int(JsNumber value)
        {
            return value.As<int>();
        }

        public static implicit operator long(JsNumber value)
        {
            return value.As<long>();
        }

        public static implicit operator float(JsNumber value)
        {
            return value.As<float>();
        }

        public static implicit operator double(JsNumber value)
        {
            return value.As<double>();
        }

        public static implicit operator short(JsNumber value)
        {
            return value.As<short>();
        }

        public static implicit operator byte(JsNumber value)
        {
            return value.As<byte>();
        }

        public static implicit operator sbyte(JsNumber value)
        {
            return value.As<sbyte>();
        }

        public static implicit operator ushort(JsNumber value)
        {
            return value.As<ushort>();
        }

        public static implicit operator uint(JsNumber value)
        {
            return value.As<uint>();
        }

        public static implicit operator ulong(JsNumber value)
        {
            return value.As<ulong>();
        }

        public static implicit operator decimal(JsNumber value)
        {
            return value.As<decimal>();
        }
    }
}
