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
    [TestFixture]
    public class EnumTests
    {
        [Test]
        public void Name()
        {
            var s = TestEnum.One.ToString();
            s.AssertEquals("One");
        }
         
        [Test]
        public void Value()
        {
            ((int)TestEnum.One).AssertEquals(0);
            ((int)TestEnum.Two).AssertEquals(1);
            ((int)TestEnum.Three).AssertEquals(2);
        }

        [Test]
        public void Flags()
        {
            var oneAndTwo = FlagsEnum.One | FlagsEnum.Two;

            ((oneAndTwo & FlagsEnum.One) == FlagsEnum.One).AssertTrue();
        }

        [Test]
        public void ThreeFlags()
        {
            var oneAndTwo = FlagsEnum.One | FlagsEnum.Two | FlagsEnum.Three;
            ((oneAndTwo & FlagsEnum.One) == FlagsEnum.One).AssertTrue();
        }

        [Test]
        public void EnumType()
        {
            var value = TestEnum.One;
            var type = value.GetType();
            type.AssertEquals(typeof(TestEnum));
        }

        [Test]
        public void NumberToEnumCast()
        {
            var two = (TestEnum)1;
            two.AssertEquals(TestEnum.Two);
        }

        [Test]
        public void InvalidEnum()
        {
            var testEnum = (TestEnum)323432;
            testEnum.AssertEquals(323432);
        }

        [Test]
        public void EnumNames()
        {
            var names = Enum.GetNames(typeof(EnumNamesClass));
            names[0].AssertEquals("One");
            names[1].AssertEquals("Two");
            names[2].AssertEquals("Three");
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
    }
}
