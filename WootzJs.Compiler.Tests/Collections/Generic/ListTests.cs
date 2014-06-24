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
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Collections.Generic
{
    public class ListTests : TestFixture
    {
        [Test]
        public void Add()
        {
            var list = new List<string>();
            list.Add("one");
            AssertEquals(list[0], "one");
        }

        [Test]
        public void Remove()
        {
            var list = new List<string>();
            list.Add("one");
            list.Add("two");
            list.Add("three");
            AssertEquals(list.Count, 3);
            list.Remove("two");
            AssertEquals(list.Count, 2);
            AssertEquals(list[0], "one");
            AssertEquals(list[1], "three");
        }

        [Test]
        public void IndexOf()
        {
            var list = new List<string>();
            list.Add("one");
            list.Add("two");
            list.Add("three");
            AssertEquals(0, list.IndexOf("one"));
            AssertEquals(1, list.IndexOf("two"));
            AssertEquals(2, list.IndexOf("three"));
            AssertEquals((-1), list.IndexOf("four"));
        }

        [Test]
        public void Contains()
        {
            var list = new List<string>();
            list.Add("one");
            list.Add("two");
            list.Add("three");
            AssertTrue(list.Contains("one"));
            AssertTrue(list.Contains("two"));
            AssertTrue(list.Contains("three"));
            AssertTrue((!list.Contains("four")));
        }

        [Test]
        public void ElementGet()
        {
            var list = new List<string>();
            list.Add("one");
            AssertEquals(list[0], "one");
        }

        [Test]
        public void ElementSet()
        {
            var list = new List<string>();
            list.Add("one");
            list[0] = "two";
            AssertEquals(list[0], "two");
        }

        [Test]
        public void IntegerSort()
        {
            var list = new List<int> { 8, 53, 1, 888, 444, 234, 3 };
            list.Sort();

            AssertEquals(list[0], 1);
            AssertEquals(list[1], 3);
            AssertEquals(list[2], 8);
            AssertEquals(list[3], 53);
            AssertEquals(list[4], 234);
            AssertEquals(list[5], 444);
            AssertEquals(list[6], 888);
        }

        [Test]
        public void CustomComparerInt()
        {
            var list = new List<int> { 8, 53, 1, 888, 444, 234, 3 };
            list.Sort((x, y) => y - x);

            AssertEquals(list[0], 888);            
            AssertEquals(list[1], 444);
            AssertEquals(list[2], 234);
            AssertEquals(list[3], 53);
            AssertEquals(list[4], 8);
            AssertEquals(list[5], 3);
            AssertEquals(list[6], 1);
        }
    }
}
