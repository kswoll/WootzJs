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
            return JsMath.acos(d).As<double>();
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
            return JsMath.asin(d).As<double>();
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
            return JsMath.atan(d).As<double>();
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
            return JsMath.atan2(y, x).As<double>();
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
            return JsMath.ceil(d.As<JsNumber>()).As<Decimal>();
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
            return JsMath.ceil(a).As<double>();
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
            return JsMath.cos(d).As<double>();
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
            return JsMath.cosh(value).As<double>();
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
            return JsMath.floor(d.As<JsNumber>()).As<Decimal>();
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
            return JsMath.floor(d).As<double>();
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
            return JsMath.sin(a).As<double>();
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
            return JsMath.tan(a).As<double>();
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
            return JsMath.sinh(value).As<double>();
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
            return JsMath.tanh(value).As<double>();
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
            return JsMath.round(a).As<double>();
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
            return InternalRound(value, digits, MidpointRounding.ToEven);
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
            return JsMath.abs(value).As<float>();
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
            return JsMath.abs(value).As<double>();
        }

        private static double InternalRound(double value, int digits, MidpointRounding mode)
        {
            var s = value.ToString();
            var decimalIndex = s.IndexOf('.');
            if (decimalIndex == -1)
                return value;

            var isNegative = value < 0;
            if (isNegative)
                s = s.Substring(1);

            var integerPart = s.Substring(0, decimalIndex);
            var intValue = int.Parse(integerPart);

            var firstDecimalDigit = int.Parse(s[decimalIndex + 1].ToString());
            if (digits == 0 && firstDecimalDigit == 5)
            {
                switch (mode)
                {
                    case MidpointRounding.AwayFromZero:
                        if (!isNegative)
                            intValue++;
                        else
                            intValue--;
                        break;
                    case MidpointRounding.ToEven:
                        if (firstDecimalDigit % 2 == 1)
                            intValue++;
                        break;
                }
                return intValue;
            }
            else
            {
                var decimalPart = new StringBuilder();
                var digit = 1;
                for (var i = decimalIndex + 1; i < s.Length && digit <= digits; i++, digit++)
                {
                    var c = s[i];
                    var digitValue = int.Parse(c.ToString());
                    if (digit == digits && i < s.Length - 1 && s[i + 1] == 5)
                    {
                        switch (mode)
                        {
                            case MidpointRounding.AwayFromZero:
                                digitValue++;
                                break;
                            case MidpointRounding.ToEven:
                                if (digitValue % 2 == 1)
                                    digitValue++;
                                break;
                        }                    
                    }
                    decimalPart.Append(digitValue);
                }
                return double.Parse(intValue + "." + decimalPart);                
            }
        }
    }
}