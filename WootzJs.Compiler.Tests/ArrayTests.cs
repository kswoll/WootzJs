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

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class ArrayTests
    {
        [Test]
        public void LengthProperty()
        {
            var array = new[] { "1", "2", "3" };
            QUnit.AreEqual(array.Length, 3);
        }         

        [Test]
        public void ArrayIndex()
        {
            var array = new[] { "1", "2", "3" };
            QUnit.AreEqual(array[2], "3");
        }         

        [Test]
        public void ArrayIndexSet()
        {
            var array = new[] { "1", "2", "3" };
            array[2] = "10";
            QUnit.AreEqual(array[2], "10");
        }         

        [Test]
        public void ArrayCopy()
        {
            var array = new[] { "1", "2", "3" };
            var newArray = new string[2];
            array.CopyTo(newArray, 1);
            QUnit.AreEqual(newArray[0], "2");
            QUnit.AreEqual(newArray[1], "3");
        }         

        [Test]
        public void StringArrayType()
        {
            var array = new[] { "1", "2", "3" };
            QUnit.AreEqual(array.GetType().Name, "String[]");
        }         

        [Test]
        public void CreateArray()
        {
            var array = (int[])Array.CreateInstance(typeof(int), 5);
            QUnit.AreEqual(array.Length, 5);
        }
    }
}
