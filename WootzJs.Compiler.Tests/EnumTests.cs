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
    public class EnumTests : TestFixture
    {
        [Test]
        public void Name()
        {
            var s = TestEnum.One.ToString();
            AssertEquals(s, "One");
        }
         
        [Test]
        public void Value()
        {
            AssertEquals(((int)TestEnum.One), 0);
            AssertEquals(((int)TestEnum.Two), 1);
            AssertEquals(((int)TestEnum.Three), 2);
        }

        [Test]
        public void Flags()
        {
            var oneAndTwo = FlagsEnum.One | FlagsEnum.Two;

            AssertTrue(((oneAndTwo & FlagsEnum.One) == FlagsEnum.One));
        }

        [Test]
        public void RemoveFlag()
        {
            var oneAndTwo = FlagsEnum.One | FlagsEnum.Two;
            var one = oneAndTwo & ~FlagsEnum.Two;
            AssertTrue(one == FlagsEnum.One);
        }

        [Test]
        public void ThreeFlags()
        {
            var oneAndTwo = FlagsEnum.One | FlagsEnum.Two | FlagsEnum.Three;
            AssertTrue(((oneAndTwo & FlagsEnum.One) == FlagsEnum.One));
        }

        [Test]
        public void EnumType()
        {
            var value = TestEnum.One;
            var type = value.GetType();
            AssertEquals(type, typeof(TestEnum));
        }

        [Test]
        public void NumberToEnumCast()
        {
            var two = (TestEnum)1;
            AssertEquals(two, TestEnum.Two);
        }

        [Test]
        public void InvalidEnum()
        {
            var testEnum = (TestEnum)323432;
            AssertEquals(testEnum, 323432);
        }

        [Test]
        public void EnumNames()
        {
            var names = Enum.GetNames(typeof(EnumNamesClass));
            AssertEquals(names[0], "One");
            AssertEquals(names[1], "Two");
            AssertEquals(names[2], "Three");
        }

        [Test]
        public void ByteEnums()
        {
            AssertEquals((byte)ByteEnum.One, (byte)1);
            AssertEquals((byte)ByteEnum.Two, (byte)2);
        }

        [Test]
        public void SByteEnums()
        {
            AssertEquals((sbyte)SByteEnum.One, (sbyte)1);
            AssertEquals((sbyte)SByteEnum.Two, (sbyte)2);
        }

        [Test]
        public void ShortEnums()
        {
            AssertEquals((short)ByteEnum.One, (short)1);
            AssertEquals((short)ByteEnum.Two, (short)2);
        }

        [Test]
        public void UShortEnums()
        {
            AssertEquals((ushort)ByteEnum.One, (ushort)1);
            AssertEquals((ushort)ByteEnum.Two, (ushort)2);
        }

        public enum TestEnum
        {
            One = 0, 
            Two = 1, 
            Three = 2
        }

        [Flags]
        public enum FlagsEnum
        {
            None = 0,
            One = 1 << 0,
            Two = 1 << 1,
            Three = 1 << 2
        }

        public enum EnumNamesClass
        {
            One, Two, Three
        }

        public enum ByteEnum : byte
        {
            One = 1,
            Two = 2
        }

        public enum SByteEnum : sbyte
        {
            One = 1,
            Two = 2
        }

        public enum ShortEnum : short
        {
            One = 1,
            Two = 2
        }

        public enum UShortEnum : ushort
        {
            One = 1,
            Two = 2
        }
    }
}
