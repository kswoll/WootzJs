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
    [TestFixture]
    public class ListTests
    {
        [Test]
        public void Add()
        {
            var list = new List<string>();
            list.Add("one");
            list[0].AssertEquals("one");
        }

        [Test]
        public void Remove()
        {
            var list = new List<string>();
            list.Add("one");
            list.Add("two");
            list.Add("three");
            list.Count.AssertEquals(3);
            list.Remove("two");
            list.Count.AssertEquals(2);
            list[0].AssertEquals("one");
            list[1].AssertEquals("three");
        }

        [Test]
        public void IndexOf()
        {
            var list = new List<string>();
            list.Add("one");
            list.Add("two");
            list.Add("three");
            0.AssertEquals(list.IndexOf("one"));
            1.AssertEquals(list.IndexOf("two"));
            2.AssertEquals(list.IndexOf("three"));
            (-1).AssertEquals(list.IndexOf("four"));
        }

        [Test]
        public void Contains()
        {
            var list = new List<string>();
            list.Add("one");
            list.Add("two");
            list.Add("three");
            list.Contains("one").AssertTrue();
            list.Contains("two").AssertTrue();
            list.Contains("three").AssertTrue();
            (!list.Contains("four")).AssertTrue();
        }

        [Test]
        public void ElementGet()
        {
            var list = new List<string>();
            list.Add("one");
            list[0].AssertEquals("one");
        }

        [Test]
        public void ElementSet()
        {
            var list = new List<string>();
            list.Add("one");
            list[0] = "two";
            list[0].AssertEquals("two");
        }

        [Test]
        public void IntegerSort()
        {
            var list = new List<int> { 8, 53, 1, 888, 444, 234, 3 };
            list.Sort();

            list[0].AssertEquals(1);
            list[1].AssertEquals(3);
            list[2].AssertEquals(8);
            list[3].AssertEquals(53);
            list[4].AssertEquals(234);
            list[5].AssertEquals(444);
            list[6].AssertEquals(888);
        }

        [Test]
        public void CustomComparerInt()
        {
            var list = new List<int> { 8, 53, 1, 888, 444, 234, 3 };
            list.Sort((x, y) => y - x);

            list[0].AssertEquals(888);            
            list[1].AssertEquals(444);
            list[2].AssertEquals(234);
            list[3].AssertEquals(53);
            list[4].AssertEquals(8);
            list[5].AssertEquals(3);
            list[6].AssertEquals(1);
        }
    }
}
