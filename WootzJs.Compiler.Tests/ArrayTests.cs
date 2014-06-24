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
using System.Collections.Generic;
using System.Runtime.WootzJs;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class ArrayTests : TestFixture
    {
        [Test]
        public void LengthProperty()
        {
            var array = new[] { "1", "2", "3" };
            AssertEquals(array.Length, 3);
        }         

        [Test]
        public void ArrayIndex()
        {
            var array = new[] { "1", "2", "3" };
            AssertEquals(array[2], "3");
        }         

        [Test]
        public void ArrayIndexSet()
        {
            var array = new[] { "1", "2", "3" };
            array[2] = "10";
            AssertEquals(array[2], "10");
        }         

        [Test]
        public void ArrayCopy()
        {
            var array = new[] { "1", "2", "3" };
            var newArray = new string[2];
            array.CopyTo(newArray, 1);
            AssertEquals(newArray[0], "2");
            AssertEquals(newArray[1], "3");
        }         

        [Test]
        public void StringArrayType()
        {
            var array = new[] { "1", "2", "3" };
            AssertEquals(array.GetType().Name, "String[]");
        }         

        [Test]
        public void CreateArray()
        {
            var array = (int[])Array.CreateInstance(typeof(int), 5);
            AssertEquals(array.Length, 5);
        }

        [Test]
        public void GetEnumerator()
        {
            var array = new[] { 1, 2, 3 };
            array.GetEnumerator();
            AssertTrue(true);     // Just making sure the method is present
        }

        [Test]
        public void ExportArray()
        {
            Jsni.reference("window").memberset("ExportTest", Jsni.@object(new { Values = Jsni.array() }));
            ExportTest.Values[0] = Tuple.Create("foo", 1);
            AssertTrue((ExportTest.Values is Tuple<string, int>[]));
        }

        [Test]
        public void IndexerOverride()
        {
            Jsni.reference("window").memberset("IndexerOverride", Jsni.@object(new
            {
                items = Jsni.array(),
                item = Jsni.function((index, value) => 
                {
                    if (Jsni.arguments().As<JsArray>().length == 1)
                        return Jsni.@this().member("items").As<JsArray>()[index];
                    else
                    {
                        Jsni.@this().member("items").As<JsArray>()[index] = value;
                        return null;
                    }
                })
            }));
            var indexerOverride = Jsni.reference("window").member("IndexerOverride").As<IndexerOverrideClass>();
            indexerOverride[3] = "foo";
            AssertEquals(indexerOverride[3], "foo");
        }

        [Test]
        public void MakeArray()
        {
            var arrayType = typeof(string).MakeArrayType(1);
            AssertEquals(arrayType.GetElementType(), typeof(string));
        }

        [Test]
        public void AsReadOnlyList()
        {
            IReadOnlyList<string> strings = new[] { "one", "two", "three" };
            AssertEquals(strings[0], "one");
            AssertEquals(strings[1], "two");
            AssertEquals(strings[2], "three");
        }

        [Js(Name = "ExportTest", Export = false)]
        class ExportTest
        {
            public static Tuple<string, int>[] Values;
        }

        [Js(Name = "IndexerOverride", Export = false)]
        class IndexerOverrideClass
        {
            [Js(Name = "item")]
            public extern string this[int index] { get; set; }
        }
    }
}
