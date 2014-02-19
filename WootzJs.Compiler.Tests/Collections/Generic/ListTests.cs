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
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests.Collections.Generic
{
    [TestFixture]
    public class ListTests
    {
        [Test]
        public void Add()
        {
            var list = new List<string>();
            list.Add("one");
            QUnit.AreEqual(list[0], "one");
        }

        [Test]
        public void Remove()
        {
            var list = new List<string>();
            list.Add("one");
            list.Add("two");
            list.Add("three");
            QUnit.AreEqual(list.Count, 3);
            list.Remove("two");
            QUnit.AreEqual(list.Count, 2);
            QUnit.AreEqual(list[0], "one");
            QUnit.AreEqual(list[1], "three");
        }

        [Test]
        public void IndexOf()
        {
            var list = new List<string>();
            list.Add("one");
            list.Add("two");
            list.Add("three");
            QUnit.AreEqual(0, list.IndexOf("one"));
            QUnit.AreEqual(1, list.IndexOf("two"));
            QUnit.AreEqual(2, list.IndexOf("three"));
            QUnit.AreEqual(-1, list.IndexOf("four"));
        }

        [Test]
        public void Contains()
        {
            var list = new List<string>();
            list.Add("one");
            list.Add("two");
            list.Add("three");
            QUnit.IsTrue(list.Contains("one"));
            QUnit.IsTrue(list.Contains("two"));
            QUnit.IsTrue(list.Contains("three"));
            QUnit.IsTrue(!list.Contains("four"));
        }

        [Test]
        public void ElementGet()
        {
            var list = new List<string>();
            list.Add("one");
            QUnit.AreEqual(list[0], "one");
        }

        [Test]
        public void ElementSet()
        {
            var list = new List<string>();
            list.Add("one");
            list[0] = "two";
            QUnit.AreEqual(list[0], "two");
        }

        [Test]
        public void IntegerSort()
        {
            var list = new List<int> { 8, 53, 1, 888, 444, 234, 3 };
            list.Sort();

            QUnit.AreEqual(list[0], 1);
            QUnit.AreEqual(list[1], 3);
            QUnit.AreEqual(list[2], 8);
            QUnit.AreEqual(list[3], 53);
            QUnit.AreEqual(list[4], 234);
            QUnit.AreEqual(list[5], 444);
            QUnit.AreEqual(list[6], 888);
        }

        [Test]
        public void CustomComparerInt()
        {
            var list = new List<int> { 8, 53, 1, 888, 444, 234, 3 };
            list.Sort((x, y) => y - x);

            QUnit.AreEqual(list[0], 888);            
            QUnit.AreEqual(list[1], 444);
            QUnit.AreEqual(list[2], 234);
            QUnit.AreEqual(list[3], 53);
            QUnit.AreEqual(list[4], 8);
            QUnit.AreEqual(list[5], 3);
            QUnit.AreEqual(list[6], 1);
        }
    }
}
