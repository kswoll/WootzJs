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

using System.Collections.Generic;
using System.Linq;
using System.Runtime.WootzJs;
using System.Text;

namespace System
{
    public class Math
    {
        /// <summary>
        /// Represents the ratio of the circumference of a circle to its diameter, specified by the constant, π.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public const double PI = 3.14159265358979;

        /// <summary>
        /// Represents the natural logarithmic base, specified by the constant, e.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public const double E = 2.71828182845905;

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// 
        /// <returns>
        /// An angle, θ, measured in radians, such that 0 ≤θ≤π-or- <see cref="F:System.Double.NaN"/> if <paramref name="d"/> &lt; -1 or <paramref name="d"/> &gt; 1 or <paramref name="d"/> equals <see cref="F:System.Double.NaN"/>.
        /// </returns>
        /// <param name="d">A number representing a cosine, where <paramref name="d"/> must be greater than or equal to -1, but less than or equal to 1. </param><filterpriority>1</filterpriority>
        public static double Acos(double d)
        {
            return JsMath.acos(d);
        }

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// 
        /// <returns>
        /// An angle, θ, measured in radians, such that -π/2 ≤θ≤π/2 -or- <see cref="F:System.Double.NaN"/> if <paramref name="d"/> &lt; -1 or <paramref name="d"/> &gt; 1 or <paramref name="d"/> equals <see cref="F:System.Double.NaN"/>.
        /// </returns>
        /// <param name="d">A number representing a sine, where <paramref name="d"/> must be greater than or equal to -1, but less than or equal to 1. </param><filterpriority>1</filterpriority>
        public static double Asin(double d)
        {
            return JsMath.asin(d);
        }

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// 
        /// <returns>
        /// An angle, θ, measured in radians, such that -π/2 ≤θ≤π/2.-or- <see cref="F:System.Double.NaN"/> if <paramref name="d"/> equals <see cref="F:System.Double.NaN"/>, -π/2 rounded to double precision (-1.5707963267949) if <paramref name="d"/> equals <see cref="F:System.Double.NegativeInfinity"/>, or π/2 rounded to double precision (1.5707963267949) if <paramref name="d"/> equals <see cref="F:System.Double.PositiveInfinity"/>.
        /// </returns>
        /// <param name="d">A number representing a tangent. </param><filterpriority>1</filterpriority>
        public static double Atan(double d)
        {
            return JsMath.atan(d);
        }

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// 
        /// <returns>
        /// An angle, θ, measured in radians, such that -π≤θ≤π, and tan(θ) = <paramref name="y"/> / <paramref name="x"/>, where (<paramref name="x"/>, <paramref name="y"/>) is a point in the Cartesian plane. Observe the following: For (<paramref name="x"/>, <paramref name="y"/>) in quadrant 1, 0 &lt; θ &lt; π/2.For (<paramref name="x"/>, <paramref name="y"/>) in quadrant 2, π/2 &lt; θ≤π.For (<paramref name="x"/>, <paramref name="y"/>) in quadrant 3, -π &lt; θ &lt; -π/2.For (<paramref name="x"/>, <paramref name="y"/>) in quadrant 4, -π/2 &lt; θ &lt; 0.For points on the boundaries of the quadrants, the return value is the following:If y is 0 and x is not negative, θ = 0.If y is 0 and x is negative, θ = π.If y is positive and x is 0, θ = π/2.If y is negative and x is 0, θ = -π/2.If <paramref name="x"/> or <paramref name="y"/> is <see cref="F:System.Double.NaN"/>, or if <paramref name="x"/> and <paramref name="y"/> are either <see cref="F:System.Double.PositiveInfinity"/> or <see cref="F:System.Double.NegativeInfinity"/>, the method returns <see cref="F:System.Double.NaN"/>.
        /// </returns>
        /// <param name="y">The y coordinate of a point. </param><param name="x">The x coordinate of a point. </param><filterpriority>1</filterpriority>
        public static double Atan2(double y, double x)
        {
            return JsMath.atan2(y, x);
        }

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified decimal number.
        /// </summary>
        /// 
        /// <returns>
        /// The smallest integral value that is greater than or equal to <paramref name="d"/>. Note that this method returns a <see cref="T:System.Decimal"/> instead of an integral type.
        /// </returns>
        /// <param name="d">A decimal number. </param><filterpriority>1</filterpriority>
        public static Decimal Ceiling(Decimal d)
        {
            return JsMath.ceil(d);
        }

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified double-precision floating-point number.
        /// </summary>
        /// 
        /// <returns>
        /// The smallest integral value that is greater than or equal to <paramref name="a"/>. If <paramref name="a"/> is equal to <see cref="F:System.Double.NaN"/>, <see cref="F:System.Double.NegativeInfinity"/>, or <see cref="F:System.Double.PositiveInfinity"/>, that value is returned. Note that this method returns a <see cref="T:System.Double"/> instead of an integral type.
        /// </returns>
        /// <param name="a">A double-precision floating-point number. </param><filterpriority>1</filterpriority>
        public static double Ceiling(double a)
        {
            return JsMath.ceil(a);
        }

        /// <summary>
        /// Returns the cosine of the specified angle.
        /// </summary>
        /// 
        /// <returns>
        /// The cosine of <paramref name="d"/>. If <paramref name="d"/> is equal to <see cref="F:System.Double.NaN"/>, <see cref="F:System.Double.NegativeInfinity"/>, or <see cref="F:System.Double.PositiveInfinity"/>, this method returns <see cref="F:System.Double.NaN"/>.
        /// </returns>
        /// <param name="d">An angle, measured in radians. </param><filterpriority>1</filterpriority>
        public static double Cos(double d)
        {
            return JsMath.cos(d);
        }

        /// <summary>
        /// Returns the hyperbolic cosine of the specified angle.
        /// </summary>
        /// 
        /// <returns>
        /// The hyperbolic cosine of <paramref name="value"/>. If <paramref name="value"/> is equal to <see cref="F:System.Double.NegativeInfinity"/> or <see cref="F:System.Double.PositiveInfinity"/>, <see cref="F:System.Double.PositiveInfinity"/> is returned. If <paramref name="value"/> is equal to <see cref="F:System.Double.NaN"/>, <see cref="F:System.Double.NaN"/> is returned.
        /// </returns>
        /// <param name="value">An angle, measured in radians. </param><filterpriority>1</filterpriority>
        public static double Cosh(double value)
        {
            return JsMath.cosh(value);
        }

        /// <summary>
        /// Returns the largest integer less than or equal to the specified decimal number.
        /// </summary>
        /// 
        /// <returns>
        /// The largest integer less than or equal to <paramref name="d"/>.
        /// </returns>
        /// <param name="d">A decimal number. </param><filterpriority>1</filterpriority>
        public static Decimal Floor(Decimal d)
        {
            return JsMath.floor(d);
        }

        /// <summary>
        /// Returns the largest integer less than or equal to the specified double-precision floating-point number.
        /// </summary>
        /// 
        /// <returns>
        /// The largest integer less than or equal to <paramref name="d"/>. If <paramref name="d"/> is equal to <see cref="F:System.Double.NaN"/>, <see cref="F:System.Double.NegativeInfinity"/>, or <see cref="F:System.Double.PositiveInfinity"/>, that value is returned.
        /// </returns>
        /// <param name="d">A double-precision floating-point number. </param><filterpriority>1</filterpriority>
        public static double Floor(double d)
        {
            return JsMath.floor(d);
        }

        /// <summary>
        /// Returns the sine of the specified angle.
        /// </summary>
        /// 
        /// <returns>
        /// The sine of <paramref name="a"/>. If <paramref name="a"/> is equal to <see cref="F:System.Double.NaN"/>, <see cref="F:System.Double.NegativeInfinity"/>, or <see cref="F:System.Double.PositiveInfinity"/>, this method returns <see cref="F:System.Double.NaN"/>.
        /// </returns>
        /// <param name="a">An angle, measured in radians. </param><filterpriority>1</filterpriority>
        public static double Sin(double a)
        {
            return JsMath.sin(a);
        }

        /// <summary>
        /// Returns the tangent of the specified angle.
        /// </summary>
        /// 
        /// <returns>
        /// The tangent of <paramref name="a"/>. If <paramref name="a"/> is equal to <see cref="F:System.Double.NaN"/>, <see cref="F:System.Double.NegativeInfinity"/>, or <see cref="F:System.Double.PositiveInfinity"/>, this method returns <see cref="F:System.Double.NaN"/>.
        /// </returns>
        /// <param name="a">An angle, measured in radians. </param><filterpriority>1</filterpriority>
        public static double Tan(double a)
        {
            return JsMath.tan(a);
        }

        /// <summary>
        /// Returns the hyperbolic sine of the specified angle.
        /// </summary>
        /// 
        /// <returns>
        /// The hyperbolic sine of <paramref name="value"/>. If <paramref name="value"/> is equal to <see cref="F:System.Double.NegativeInfinity"/>, <see cref="F:System.Double.PositiveInfinity"/>, or <see cref="F:System.Double.NaN"/>, this method returns a <see cref="T:System.Double"/> equal to <paramref name="value"/>.
        /// </returns>
        /// <param name="value">An angle, measured in radians. </param><filterpriority>1</filterpriority>
        public static double Sinh(double value)
        {
            return JsMath.sinh(value);
        }

        /// <summary>
        /// Returns the hyperbolic tangent of the specified angle.
        /// </summary>
        /// 
        /// <returns>
        /// The hyperbolic tangent of <paramref name="value"/>. If <paramref name="value"/> is equal to <see cref="F:System.Double.NegativeInfinity"/>, this method returns -1. If value is equal to <see cref="F:System.Double.PositiveInfinity"/>, this method returns 1. If <paramref name="value"/> is equal to <see cref="F:System.Double.NaN"/>, this method returns <see cref="F:System.Double.NaN"/>.
        /// </returns>
        /// <param name="value">An angle, measured in radians. </param><filterpriority>1</filterpriority>
        public static double Tanh(double value)
        {
            return JsMath.tanh(value);
        }

        /// <summary>
        /// Rounds a double-precision floating-point value to the nearest integral value.
        /// </summary>
        /// 
        /// <returns>
        /// The integer nearest <paramref name="a"/>. If the fractional component of <paramref name="a"/> is halfway between two integers, one of which is even and the other odd, then the even number is returned. Note that this method returns a <see cref="T:System.Double"/> instead of an integral type.
        /// </returns>
        /// <param name="a">A double-precision floating-point number to be rounded. </param><filterpriority>1</filterpriority>
        public static double Round(double a)
        {
            return JsMath.round(a);
        }

        /// <summary>
        /// Rounds a double-precision floating-point value to a specified number of fractional digits.
        /// </summary>
        /// 
        /// <returns>
        /// The number nearest to <paramref name="value"/> that contains a number of fractional digits equal to <paramref name="digits"/>.
        /// </returns>
        /// <param name="value">A double-precision floating-point number to be rounded. </param><param name="digits">The number of fractional digits in the return value. </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="digits"/> is less than 0 or greater than 15. </exception><filterpriority>1</filterpriority>
        public static double Round(double value, int digits)
        {
            if (digits < 0 || digits > 15)
                throw new ArgumentOutOfRangeException("Value is too small or too big.");
            if (digits == 0)
                return Round(value);
            return Round(value, digits, MidpointRounding.ToEven);
        }

        /// <summary>
        /// Returns the absolute value of a 32-bit signed integer.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer, x, such that 0 ≤ x ≤<see cref="F:System.Int32.MaxValue"/>.
        /// </returns>
        /// <param name="value">A number that is greater than or equal to <see cref="F:System.Int32.MinValue"/>, but less than or equal to <see cref="F:System.Int32.MaxValue"/>.</param><filterpriority>1</filterpriority>
        public static int Abs(int value)
        {
            return JsMath.abs(value);
        }

        /// <summary>
        /// Returns the absolute value of a single-precision floating-point number.
        /// </summary>
        /// 
        /// <returns>
        /// A single-precision floating-point number, x, such that 0 ≤ x ≤<see cref="F:System.Single.MaxValue"/>.
        /// </returns>
        /// <param name="value">A number that is greater than or equal to <see cref="F:System.Single.MinValue"/>, but less than or equal to <see cref="F:System.Single.MaxValue"/>.</param><filterpriority>1</filterpriority>
        public static float Abs(float value)
        {
            return JsMath.abs(value);
        }

        /// <summary>
        /// Returns the absolute value of a double-precision floating-point number.
        /// </summary>
        /// 
        /// <returns>
        /// A double-precision floating-point number, x, such that 0 ≤ x ≤<see cref="F:System.Double.MaxValue"/>.
        /// </returns>
        /// <param name="value">A number that is greater than or equal to <see cref="F:System.Double.MinValue"/>, but less than or equal to <see cref="F:System.Double.MaxValue"/>.</param><filterpriority>1</filterpriority>
        public static double Abs(double value)
        {
            return JsMath.abs(value);
        }

        public static double Round(double value, int digits, MidpointRounding mode)
        {
            var s = value.ToString();

            var isNegative = value < 0;
            if (isNegative)
                s = s.Substring(1);

            var decimalIndex = s.IndexOf('.');
            if (decimalIndex == -1)
                return value;

            var integerPart = s.Substring(0, decimalIndex);
            var intValue = int.Parse(integerPart);

            var firstDecimalDigit = int.Parse(s[decimalIndex + 1].ToString());
            if (digits == 0 && firstDecimalDigit == 5)
            {
                switch (mode)
                {
                    case MidpointRounding.AwayFromZero:
                        intValue++;
                        break;
                    case MidpointRounding.ToEven:
                        if (intValue%2 == 1)
                            intValue++;
                        break;
                }
                if (isNegative)
                    intValue = -intValue;
                return intValue;
            }
            else
            {
                var decimalPart = new Stack<int>();
                var digit = digits;
                var carry = 0;
                for (var i = Min(decimalIndex + digits, s.Length - 1); i > decimalIndex && digit >= 1; i--, digit--)
                {
                    var digitValue = int.Parse(s[i].ToString()) + carry;
                    if (i < s.Length - 1)
                    {
                        var nextDigit = s[i + 1];
                        var nextDigitValue = int.Parse(nextDigit.ToString());
                        if (digit == digits && nextDigitValue == 5)
                        {
                            switch (mode)
                            {
                                case MidpointRounding.AwayFromZero:
                                    digitValue++;
                                    break;
                                case MidpointRounding.ToEven:
                                    if (digitValue%2 == 1)
                                    {
                                        digitValue++;
                                    }
                                    break;
                            }
                        }
                        else if (digit == digits && nextDigitValue > 5)
                            digitValue++;
                    }
                    if (digitValue == 10)
                    {
                        digitValue = 0;
                        carry = 1;
                    }
                    else
                    {
                        carry = 0;
                    }
                    if (decimalPart.Count > 0 || digitValue != 0)
                        decimalPart.Push(digitValue);
                }
                if (carry > 0)
                    intValue++;
                var newString = intValue + "." + decimalPart.ToArray().As<JsArray>().join("");
                if (isNegative)
                    newString = "-" + newString;
                return double.Parse(newString);
            }
        }

        /// <summary>
        /// Returns the larger of two 8-bit signed integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is larger.
        /// </returns>
        /// <param name="val1">The first of two 8-bit signed integers to compare. </param><param name="val2">The second of two 8-bit signed integers to compare. </param><filterpriority>1</filterpriority>
        public static sbyte Max(sbyte val1, sbyte val2)
        {
            if (val1 < val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the larger of two 8-bit unsigned integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is larger.
        /// </returns>
        /// <param name="val1">The first of two 8-bit unsigned integers to compare. </param><param name="val2">The second of two 8-bit unsigned integers to compare. </param><filterpriority>1</filterpriority>
        public static byte Max(byte val1, byte val2)
        {
            if (val1 < val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the larger of two 16-bit signed integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is larger.
        /// </returns>
        /// <param name="val1">The first of two 16-bit signed integers to compare. </param><param name="val2">The second of two 16-bit signed integers to compare. </param><filterpriority>1</filterpriority>
        public static short Max(short val1, short val2)
        {
            if (val1 < val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the larger of two 16-bit unsigned integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is larger.
        /// </returns>
        /// <param name="val1">The first of two 16-bit unsigned integers to compare. </param><param name="val2">The second of two 16-bit unsigned integers to compare. </param><filterpriority>1</filterpriority>
        public static ushort Max(ushort val1, ushort val2)
        {
            if (val1 < val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the larger of two 32-bit signed integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is larger.
        /// </returns>
        /// <param name="val1">The first of two 32-bit signed integers to compare. </param><param name="val2">The second of two 32-bit signed integers to compare. </param><filterpriority>1</filterpriority>
        public static int Max(int val1, int val2)
        {
            if (val1 < val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the larger of two 32-bit unsigned integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is larger.
        /// </returns>
        /// <param name="val1">The first of two 32-bit unsigned integers to compare. </param><param name="val2">The second of two 32-bit unsigned integers to compare. </param><filterpriority>1</filterpriority>
        public static uint Max(uint val1, uint val2)
        {
            if (val1 < val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the larger of two 64-bit signed integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is larger.
        /// </returns>
        /// <param name="val1">The first of two 64-bit signed integers to compare. </param><param name="val2">The second of two 64-bit signed integers to compare. </param><filterpriority>1</filterpriority>
        public static long Max(long val1, long val2)
        {
            if (val1 < val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the larger of two 64-bit unsigned integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is larger.
        /// </returns>
        /// <param name="val1">The first of two 64-bit unsigned integers to compare. </param><param name="val2">The second of two 64-bit unsigned integers to compare. </param><filterpriority>1</filterpriority>
        public static ulong Max(ulong val1, ulong val2)
        {
            if (val1 < val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the larger of two single-precision floating-point numbers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is larger. If <paramref name="val1"/>, or <paramref name="val2"/>, or both <paramref name="val1"/> and <paramref name="val2"/> are equal to <see cref="F:System.Single.NaN"/>, <see cref="F:System.Single.NaN"/> is returned.
        /// </returns>
        /// <param name="val1">The first of two single-precision floating-point numbers to compare. </param><param name="val2">The second of two single-precision floating-point numbers to compare. </param><filterpriority>1</filterpriority>
        public static float Max(float val1, float val2)
        {
            if (val1 > val2 || float.IsNaN(val1))
                return val1;
            else
                return val2;
        }

        /// <summary>
        /// Returns the larger of two double-precision floating-point numbers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is larger. If <paramref name="val1"/>, <paramref name="val2"/>, or both <paramref name="val1"/> and <paramref name="val2"/> are equal to <see cref="F:System.Double.NaN"/>, <see cref="F:System.Double.NaN"/> is returned.
        /// </returns>
        /// <param name="val1">The first of two double-precision floating-point numbers to compare. </param><param name="val2">The second of two double-precision floating-point numbers to compare. </param><filterpriority>1</filterpriority>
        public static double Max(double val1, double val2)
        {
            if (val1 > val2 || double.IsNaN(val1))
                return val1;
            else
                return val2;
        }

        /// <summary>
        /// Returns the larger of two decimal numbers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is larger.
        /// </returns>
        /// <param name="val1">The first of two decimal numbers to compare. </param><param name="val2">The second of two decimal numbers to compare. </param><filterpriority>1</filterpriority>
        public static Decimal Max(Decimal val1, Decimal val2)
        {
            if (val1 > val2)
                return val1;
            else
                return val2;
        }

        /// <summary>
        /// Returns the smaller of two 8-bit signed integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is smaller.
        /// </returns>
        /// <param name="val1">The first of two 8-bit signed integers to compare. </param><param name="val2">The second of two 8-bit signed integers to compare. </param><filterpriority>1</filterpriority>
        public static sbyte Min(sbyte val1, sbyte val2)
        {
            if (val1 > val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the smaller of two 8-bit unsigned integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is smaller.
        /// </returns>
        /// <param name="val1">The first of two 8-bit unsigned integers to compare. </param><param name="val2">The second of two 8-bit unsigned integers to compare. </param><filterpriority>1</filterpriority>
        public static byte Min(byte val1, byte val2)
        {
            if (val1 > val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the smaller of two 16-bit signed integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is smaller.
        /// </returns>
        /// <param name="val1">The first of two 16-bit signed integers to compare. </param><param name="val2">The second of two 16-bit signed integers to compare. </param><filterpriority>1</filterpriority>
        public static short Min(short val1, short val2)
        {
            if (val1 > val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the smaller of two 16-bit unsigned integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is smaller.
        /// </returns>
        /// <param name="val1">The first of two 16-bit unsigned integers to compare. </param><param name="val2">The second of two 16-bit unsigned integers to compare. </param><filterpriority>1</filterpriority>
        public static ushort Min(ushort val1, ushort val2)
        {
            if (val1 > val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the smaller of two 32-bit signed integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is smaller.
        /// </returns>
        /// <param name="val1">The first of two 32-bit signed integers to compare. </param><param name="val2">The second of two 32-bit signed integers to compare. </param><filterpriority>1</filterpriority>
        public static int Min(int val1, int val2)
        {
            if (val1 > val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the smaller of two 32-bit unsigned integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is smaller.
        /// </returns>
        /// <param name="val1">The first of two 32-bit unsigned integers to compare. </param><param name="val2">The second of two 32-bit unsigned integers to compare. </param><filterpriority>1</filterpriority>
        public static uint Min(uint val1, uint val2)
        {
            if (val1 > val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the smaller of two 64-bit signed integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is smaller.
        /// </returns>
        /// <param name="val1">The first of two 64-bit signed integers to compare. </param><param name="val2">The second of two 64-bit signed integers to compare. </param><filterpriority>1</filterpriority>
        public static long Min(long val1, long val2)
        {
            if (val1 > val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the smaller of two 64-bit unsigned integers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is smaller.
        /// </returns>
        /// <param name="val1">The first of two 64-bit unsigned integers to compare. </param><param name="val2">The second of two 64-bit unsigned integers to compare. </param><filterpriority>1</filterpriority>
        public static ulong Min(ulong val1, ulong val2)
        {
            if (val1 > val2)
                return val2;
            else
                return val1;
        }

        /// <summary>
        /// Returns the smaller of two single-precision floating-point numbers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is smaller. If <paramref name="val1"/>, <paramref name="val2"/>, or both <paramref name="val1"/> and <paramref name="val2"/> are equal to <see cref="F:System.Single.NaN"/>, <see cref="F:System.Single.NaN"/> is returned.
        /// </returns>
        /// <param name="val1">The first of two single-precision floating-point numbers to compare. </param><param name="val2">The second of two single-precision floating-point numbers to compare. </param><filterpriority>1</filterpriority>
        public static float Min(float val1, float val2)
        {
            if (val1 < val2 || float.IsNaN(val1))
                return val1;
            else
                return val2;
        }

        /// <summary>
        /// Returns the smaller of two double-precision floating-point numbers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is smaller. If <paramref name="val1"/>, <paramref name="val2"/>, or both <paramref name="val1"/> and <paramref name="val2"/> are equal to <see cref="F:System.Double.NaN"/>, <see cref="F:System.Double.NaN"/> is returned.
        /// </returns>
        /// <param name="val1">The first of two double-precision floating-point numbers to compare. </param><param name="val2">The second of two double-precision floating-point numbers to compare. </param><filterpriority>1</filterpriority>
        public static double Min(double val1, double val2)
        {
            if (val1 < val2 || double.IsNaN(val1))
                return val1;
            else
                return val2;
        }

        /// <summary>
        /// Returns the smaller of two decimal numbers.
        /// </summary>
        /// 
        /// <returns>
        /// Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is smaller.
        /// </returns>
        /// <param name="val1">The first of two decimal numbers to compare. </param><param name="val2">The second of two decimal numbers to compare. </param><filterpriority>1</filterpriority>
        public static Decimal Min(Decimal val1, Decimal val2)
        {
            return JsMath.min(val1, val2);
        }

        /// <summary>
        /// Returns the square root of a specified number.
        /// </summary>
        /// 
        /// <returns>
        /// One of the values in the following table. 
        /// <table>
        ///     <tr>
        ///         <th>d parameter</th>
        ///         <th>Return value</th>
        ///     </tr>
        ///     <tr>
        ///         <td>Zero or positive</td>
        ///         <td>The positive square root of d</td>
        ///     </tr>
        ///     <tr>
        ///         <td>Negative</td>
        ///         <td><see cref="L:System.Double.NaN"/></td>
        ///     </tr>
        ///     <tr>
        ///         <td>Equals <see cref="L:System.Double.NaN"/></td>
        ///         <td><see cref="L:System.Double.NaN"/></td>
        ///     </tr>
        ///     <tr>
        ///         <td>Equals <see cref="L:System.Double.PositiveInfinity"/></td>
        ///         <td><see cref="L:System.Double.PositiveInfinity"/></td>
        ///     </tr>
        /// </table>
        /// </returns>
        /// <param name="d">The number whose square root is to be found.</param><filterpriority>1</filterpriority>
        public static double Sqrt(double d)
        {
            return JsMath.sqrt(d);
        }

        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// </summary>
        /// 
        /// <returns>
        /// The number x raised to the power y.
        /// </returns>
        /// <param name="x">A double-precision floating-point number to be raised to a power.</param>
        /// <param name="y">A double-precision floating-point number that specifies a power.</param>
        /// <filterpriority>1</filterpriority>
        public static double Pow(double x, double y)
        {
            return JsMath.pow(x, y);
        }
    }
}