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

using System;
using System.Runtime.WootzJs;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class NumberTests : TestFixture
    {
        [Test]
        public void ToHex()
        {
            var number = 20;
            AssertEquals(number.ToString("X4"), "0014");
        }

        [Test]
        public void IntTryParse()
        {
            var s = "1";
            int i;
            AssertTrue(int.TryParse(s, out i));
            AssertEquals(i, 1);
        }

        [Test]
        public void IntTryParseFalse()
        {
            var s = "a";
            int i;
            AssertTrue(!int.TryParse(s, out i));
        }

        [Test]
        public void TruncFloatViaCast()
        {
            var f = 1.234f;
            var i = (int)f;
            AssertEquals(i, 1);
        }

        [Test]
        public void ToLocaleString()
        {
            var s = 1.234.As<JsNumber>().toLocaleString();
            AssertEquals(s, "1.234");
        }

        [Test]
        public void FormatException()
        {
            try
            {
                int.Parse("a");
                AssertTrue(false);
            }
            catch (FormatException e)
            {
                AssertTrue(true);                
            }
        }

        [Test]
        public void CastIntToByte()
        {
            var castIntToByteI = 2342342342;
            var b = (byte)castIntToByteI;
            AssertEquals(b, 198);
        }

        [Test]
        public void Byte()
        {
            byte a = (byte)50;
            byte b = 230;
            AssertEquals(a + b, 280);
        }

        [Test]
        public void RightShiftAssign()
        {
            int a = 3;
            a >>= 1;            
            AssertEquals(a, 1);
        }

        [Test]
        public void LeftShiftAssign()
        {
            int a = 3;
            a <<= 1;            
            AssertEquals(a, 6);
        }

        [Test]
        public void BitwiseOrAssign()
        {
            int a = 1;
            a |= 4;
            AssertEquals(a, 5);
        }

        [Test]
        public void BitwiseAndAssign()
        {
            int a = 78;
            a &= 2;
            AssertEquals(a, 2);
        }

        [Test]
        public void ExclusiveOrAssign()
        {
            int a = 77;
            a ^= 55;
            AssertEquals(a, 122);
        }

        [Test]
        public void DefaultByteReturnsValue()
        {
            AssertEquals(DefaultByte(), 255);
        }

        public byte DefaultByte(byte test = 255) // fails
        {
            return test;
        }

        [Test]
        public void DefaultSByteReturnsValue()
        {
            AssertEquals(DefaultSByte(), -127);
        }

        public sbyte DefaultSByte(sbyte test = -127) // fails
        {
            return test;
        }

        [Test]
        public void DefaultShortReturnsValue()
        {
            AssertEquals(DefaultShort(), 432);
        }

        public short DefaultShort(short test = 432) // fails
        {
            return test;
        }

        [Test]
        public void DefaultUShortReturnsValue()
        {
            AssertEquals(DefaultUShort(), 23456);
        }

        public ushort DefaultUShort(ushort test = 23456) // fails
        {
            return test;
        }
/*

        [Test]
        public void AssignmentOperators()
        {
            int a = 3;
            int b = 0;
            a >>= b;
            a <<= b;
            a |= b;
            a &= b;
            a ^= b;            
        }
*/
    }
}
