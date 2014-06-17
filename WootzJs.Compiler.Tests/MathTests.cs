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
    [TestFixture]
    public class MathTests
    {
        [Test]
        public void Round()
        {
            Math.Round(1.1, 3).AssertEquals(1.1);
            Math.Round(1.12, 3).AssertEquals(1.12);
            Math.Round(1.123, 3).AssertEquals(1.123);
            Math.Round(1.1234, 3).AssertEquals(1.123);
            Math.Round(2.45, 1, MidpointRounding.ToEven).AssertEquals(2.4);
            Math.Round(2.55, 1, MidpointRounding.ToEven).AssertEquals(2.6);
            Math.Round(-2.45, 1, MidpointRounding.ToEven).AssertEquals(-2.4);
            Math.Round(-2.55, 1, MidpointRounding.ToEven).AssertEquals(-2.6);
            Math.Round(2.5, 0, MidpointRounding.ToEven).AssertEquals(2);
            Math.Round(3.5, 0, MidpointRounding.ToEven).AssertEquals(4);
            Math.Round(-2.5, 0, MidpointRounding.ToEven).AssertEquals(-2);
            Math.Round(-3.5, 0, MidpointRounding.ToEven).AssertEquals(-4);
            Math.Round(-2.9999, 3, MidpointRounding.ToEven).AssertEquals(-3);
        }
    }
}