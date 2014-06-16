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

using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class DefaultTests
    {
        [Test]
        public void DefaultInt()
        {
            var value = default(int);
            Assert.AssertEquals(value, 0);
        }

        [Test]
        public void DefaultChar()
        {
            var value = default(char);
            Assert.AssertEquals(value, '\0');
        }

        [Test]
        public void DefaultBool()
        {
            var value = default(bool);
            Assert.AssertEquals(value, false);
        }

        [Test]
        public void DefaultObject()
        {
            var value = default(object);
            Assert.AssertEquals(value, null);
        }

        [Test]
        public void DefaultT()
        {
            Assert.AssertEquals(DefaultOf<string>(), null);
            Assert.AssertEquals(DefaultOf<int>(), 0);
        }

        private T DefaultOf<T>()
        {
            return default(T);
        }
    }
}
