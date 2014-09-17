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
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class MathTests : TestFixture
    {
        [Test]
        public void Round()
        {
            AssertEquals(Math.Round(1.1, 3), 1.1);
            AssertEquals(Math.Round(1.12, 3), 1.12);
            AssertEquals(Math.Round(1.123, 3), 1.123);
            AssertEquals(Math.Round(1.1234, 3), 1.123);
            AssertEquals(Math.Round(2.45, 1, MidpointRounding.ToEven), 2.4);
            AssertEquals(Math.Round(2.55, 1, MidpointRounding.ToEven), 2.6);
            AssertEquals(Math.Round(-2.45, 1, MidpointRounding.ToEven), -2.4);
            AssertEquals(Math.Round(-2.55, 1, MidpointRounding.ToEven), -2.6);
            AssertEquals(Math.Round(2.5, 0, MidpointRounding.ToEven), 2);
            AssertEquals(Math.Round(3.5, 0, MidpointRounding.ToEven), 4);
            AssertEquals(Math.Round(-2.5, 0, MidpointRounding.ToEven), -2);
            AssertEquals(Math.Round(-3.5, 0, MidpointRounding.ToEven), -4);
            AssertEquals(Math.Round(-2.9999, 3, MidpointRounding.ToEven), -3);
        }

        [Test]
        public void IntDivision()
        {
            var value = 2014 / 100;
            AssertEquals(value, 20);
        }

        [Test]
        public void IntDivisionAssign()
        {
            var value = 2014;
            value /= 100;
            AssertEquals(value, 20);
        }
    }
}