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
using System.Linq;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Linq
{
    [TestFixture]
    public class EnumerableTests
    {
        [Test]
        public void Aggregate()
        {
            var array = new[] { 1, 2, 3 };
            var result = array.Aggregate((x, y) => x + y);
            result.AssertEquals(6);
        }

        [Test]
        public void AggregateWithSeed()
        {
            var array = new[] { 1, 2, 3 };
            var result = array.Aggregate(10, (x, y) => x + y);
            result.AssertEquals(16);
        }

        [Test]
        public void AggregateWithSeedAndResult()
        {
            var array = new[] { 1, 2, 3 };
            var result = array.Aggregate(10, (x, y) => x + y, x => x.ToString());
            result.AssertEquals("16");
        }

        [Test]
        public void All()
        {
            var array = new[] { 1, 2, 3 };
            array.All(x => x > 0).AssertEquals(true);
            array.All(x => x > 1).AssertEquals(false);
        }

        [Test]
        public void Where()
        {
            var array = new[] { "1", "2", "3" };
            var two = array.Where(x => x == "2").Single();
            two.AssertEquals("2");
        }

        [Test]
        public void WhereWithIndex()
        {
            var array = new[] { "1", "2", "3" };
            var result = array.Where((x, i) => x == "2" || i == 2).ToArray();
            result.Length.AssertEquals(2);
            result[0].AssertEquals("2");
            result[1].AssertEquals("3");
        }

        [Test]
        public void Select()
        {
            var array = new[] { "1", "2", "3" };
            var two = array.Select(x => x + "a").ToArray();
            two[0].AssertEquals("1a");
            two[1].AssertEquals("2a");
            two[2].AssertEquals("3a");
        }

        [Test]
        public void SelectWithIndex()
        {
            var array = new[] { "1", "2", "3" };
            var two = array.Select((x, i) => x + "a" + i).ToArray();
            two[0].AssertEquals("1a0");
            two[1].AssertEquals("2a1");
            two[2].AssertEquals("3a2");
        }

        [Test]
        public void SelectMany()
        {
            var arrays = new[]
            {
                new[] { "1", "2", "3" },
                new[] { "4", "5", "6" }
            };

            var elements = arrays.SelectMany(x => x).ToArray();
            elements.Length.AssertEquals(6);
            elements[0].AssertEquals("1");
            elements[1].AssertEquals("2");
            elements[2].AssertEquals("3");
            elements[3].AssertEquals("4");
            elements[4].AssertEquals("5");
            elements[5].AssertEquals("6");
        }

        [Test]
        public void SelectManyWithIndex()
        {
            var arrays = new[]
            {
                new[] { "1", "2", "3" },
                new[] { "4", "5", "6" }
            };

            var elements = arrays.SelectMany((x, i) => x.Select(y => y + i)).ToArray();
            elements.Length.AssertEquals(6);
            elements[0].AssertEquals("10");
            elements[1].AssertEquals("20");
            elements[2].AssertEquals("30");
            elements[3].AssertEquals("41");
            elements[4].AssertEquals("51");
            elements[5].AssertEquals("61");
        }

        [Test]
        public void SelectManyWithIndexAndResultSelector()
        {
            var arrays = new[]
            {
                new[] { "1", "2", "3" },
                new[] { "4", "5", "6" }
            };

            var elements = arrays.SelectMany((x, i) => x.Select(y => y + i), (row, item) => row.Length*int.Parse(item)).ToArray();
            elements.Length.AssertEquals(6);
            elements[0].AssertEquals(30);
            elements[1].AssertEquals(60);
            elements[2].AssertEquals(90);
            elements[3].AssertEquals(123);
            elements[4].AssertEquals(153);
            elements[5].AssertEquals(183);
        }

        [Test]
        public void SelectManyWithResultSelector()
        {
            var arrays = new[]
            {
                new[] { "1", "2", "3" },
                new[] { "4", "5", "6" }
            };

            var elements = arrays.SelectMany(x => x, (row, item) => row.Length*int.Parse(item)).ToArray();
            elements.Length.AssertEquals(6);
            elements[0].AssertEquals(3);
            elements[1].AssertEquals(6);
            elements[2].AssertEquals(9);
            elements[3].AssertEquals(12);
            elements[4].AssertEquals(15);
            elements[5].AssertEquals(18);
        }

        [Test]
        public void Max()
        {
            new[] { 1, 2, 3 }.Max().AssertEquals(3);
            new[] { 1.3, 2.4, 3.5 }.Max().AssertEquals(3.5);
        }

        [Test]
        public void Min()
        {
            new[] { -1, 2, 3 }.Min().AssertEquals(-1);
            new[] { 1.3, -2.4, 3.5 }.Min().AssertEquals(-2.4);
        }

        [Test]
        public void Take()
        {
            var ints = new[] { 8, 3, 5, 1 }.Take(3).ToArray();
            ints.Length.AssertEquals(3);
            ints[0].AssertEquals(8);
            ints[1].AssertEquals(3);
            ints[2].AssertEquals(5);
        }

        [Test]
        public void TakeWhile()
        {
            var ints = new[] { 1, 2, 3, 4, 5 }.TakeWhile(x => x < 3).ToArray();
            ints.Length.AssertEquals(2);
            ints[0].AssertEquals(1);
            ints[1].AssertEquals(2);
        }

        [Test]
        public void TakeWhileWithIndex()
        {
            var ints = new[] { 1, 2, 3, 4, 5 }.TakeWhile((x, i) => i < 3).ToArray();
            ints.Length.AssertEquals(3);
            ints[0].AssertEquals(1);
            ints[1].AssertEquals(2);
            ints[2].AssertEquals(3);
        }

        [Test]
        public void Skip()
        {
            var ints = new[] { 8, 3, 5, 1 }.Skip(2).ToArray();
            ints.Length.AssertEquals(2);
            ints[0].AssertEquals(5);
            ints[1].AssertEquals(1);
        }

        [Test]
        public void SkipWhile()
        {
            var ints = new[] { 1, 2, 3, 4, 5 }.SkipWhile(x => x < 3).ToArray();
            ints.Length.AssertEquals(3);
            ints[0].AssertEquals(3);
            ints[1].AssertEquals(4);
            ints[2].AssertEquals(5);
        }

        [Test]
        public void SkipWhileWithIndex()
        {
            var ints = new[] { 1, 2, 3, 4, 5 }.SkipWhile((x, i) => i < 3).ToArray();
            ints.Length.AssertEquals(2);
            ints[0].AssertEquals(4);
            ints[1].AssertEquals(5);
        }

        [Test]
        public void Join()
        {
            var ints1 = new[] { 1, 2, 3, 4 };
            var ints2 = new[] { 3, 4, 5, 6 };
            var join = ints1.Join(ints2, x => x, x => x, (x, y) => x + y).ToArray();
            @join.Length.AssertEquals(2);
            @join[0].AssertEquals(6);
            @join[1].AssertEquals(8);
        }

        [Test]
        public void Except()
        {
            var ints1 = new[] { 1, 2, 3, 4 };
            var ints2 = new[] { 3, 4, 5, 6 };
            var join = ints1.Except(ints2).ToArray();
            @join.Length.AssertEquals(2);
            @join[0].AssertEquals(1);
            @join[1].AssertEquals(2);
        }

        [Test]
        public void Single()
        {
            var ints1 = new[] { 1 };
            var int1 = ints1.Single();
            int1.AssertEquals(1);
        }

        [Test]
        public void SingleThrowsWhenEmpty()
        {
            var ints1 = new int[0];
            try
            {
                var int1 = ints1.Single();
                false.AssertTrue();
            }
            catch (Exception e)
            {
                true.AssertTrue();
            }
        }

        [Test]
        public void SumInt()
        {
            var ints = new[] { 1, 2, 3 };
            var sum = ints.Sum();
            sum.AssertEquals(6);
        }

        [Test]
        public void SingleThrowsWhenContainsMany()
        {
            var ints1 = new[] { 1, 2 };
            try
            {
                var int1 = ints1.Single();
                false.AssertTrue();
            }
            catch (Exception e)
            {
                true.AssertTrue();
            }
        }

        [Test]
        public void Reverse()
        {
            var ints = new[] { 1, 2, 3 };
            var reverse = ints.Reverse().ToArray();
            reverse.Length.AssertEquals(3);
            reverse[0].AssertEquals(3);
            reverse[1].AssertEquals(2);
            reverse[2].AssertEquals(1);
        }

        [Test]
        public void ToDictionary()
        {
            var items = new[]
            {
                new DictionaryClass { Name = "John", Value = "Austria" },
                new DictionaryClass { Name = "Gary", Value = "California" }
            };
            var dictionary = items.ToDictionary(x => x.Name, x => x.Value);
            dictionary["John"].AssertEquals("Austria");
            dictionary["Gary"].AssertEquals("California");
        }

        [Test]
        public void SequenceEqual()
        {
            var ints1 = new[] { 1, 2, 3 };
            var ints2 = new[] { 1, 2, 3 };
            ints1.SequenceEqual(ints2).AssertTrue();
        }

        [Test]
        public void Last()
        {
            var ints = new[] { 1, 2, 3, 4 };
            var last = ints.Last();
            last.AssertEquals(4);
        }

        [Test]
        public void OfType()
        {
            var objects = new object[] { 1, "5", 5d, "8" };
            var strings = objects.OfType<string>().ToArray();
            strings[0].AssertEquals("5");
            strings[1].AssertEquals("8");
        }

        [Test]
        public void OrderBy()
        {
            var list = new[] { 8, 53, 1, 888, 444, 234, 3 }.OrderBy(x => x).ToArray();

            list[0].AssertEquals(1);
            list[1].AssertEquals(3);
            list[2].AssertEquals(8);
            list[3].AssertEquals(53);
            list[4].AssertEquals(234);
            list[5].AssertEquals(444);
            list[6].AssertEquals(888);
        }

        [Test]
        public void OrderByDescending()
        {
            var list = new[] { 8, 53, 1 }.OrderByDescending(x => x).ToArray();

            list[0].AssertEquals(53);
            list[1].AssertEquals(8);
            list[2].AssertEquals(1);
        }

        [Test]
        public void ThenBy()
        {
            var list = new[]
            {
                new KeyValueClass { Key = "a", Value = 2 },
                new KeyValueClass { Key = "a", Value = 1 },
                new KeyValueClass { Key = "b", Value = 1 },
                new KeyValueClass { Key = "c", Value = 3 },
                new KeyValueClass { Key = "c", Value = 4 },
                new KeyValueClass { Key = "c", Value = 1 },
            }.OrderBy(x => x.Key).ThenBy(x => x.Value).ToArray();

            list[0].Key.AssertEquals("a");
            list[0].Value.AssertEquals(1);
            list[1].Key.AssertEquals("a");
            list[1].Value.AssertEquals(2);
            list[2].Key.AssertEquals("b");
            list[2].Value.AssertEquals(1);
            list[3].Key.AssertEquals("c");
            list[3].Value.AssertEquals(1);
            list[4].Key.AssertEquals("c");
            list[4].Value.AssertEquals(3);
            list[5].Key.AssertEquals("c");
            list[5].Value.AssertEquals(4);
        }

        [Test]
        public void ThenByDescending()
        {
            var list = new[]
            {
                new KeyValueClass { Key = "a", Value = 2 },
                new KeyValueClass { Key = "a", Value = 1 },
                new KeyValueClass { Key = "b", Value = 1 },
                new KeyValueClass { Key = "c", Value = 3 },
                new KeyValueClass { Key = "c", Value = 4 },
                new KeyValueClass { Key = "c", Value = 1 }
            }.OrderBy(x => x.Key).ThenByDescending(x => x.Value).ToArray();

            list[0].Key.AssertEquals("a");
            list[0].Value.AssertEquals(2);
            list[1].Key.AssertEquals("a");
            list[1].Value.AssertEquals(1);
            list[2].Key.AssertEquals("b");
            list[2].Value.AssertEquals(1);
            list[3].Key.AssertEquals("c");
            list[3].Value.AssertEquals(4);
            list[4].Key.AssertEquals("c");
            list[4].Value.AssertEquals(3);
            list[5].Key.AssertEquals("c");
            list[5].Value.AssertEquals(1);
        }

        [Test]
        public void Empty()
        {
            var enumerator = Enumerable.Empty<string>().GetEnumerator();
            (!enumerator.MoveNext()).AssertTrue();
        }

        [Test]
        public void DefaultIfEmpty()
        {
            var s = new string[0].DefaultIfEmpty().Single();
            s.AssertEquals(null);

            var i = new int[0].DefaultIfEmpty().Single();
            i.AssertEquals(0);
        }

        [Test]
        public void DefaultIfEmptyExplicitDefault()
        {
            var s = new string[0].DefaultIfEmpty("default").Single();
            s.AssertEquals("default");

            var i = new int[0].DefaultIfEmpty(5).Single();
            i.AssertEquals(5);
        }

        [Test]
        public void GroupBy()
        {
            var items = new[]
            {
                new KeyValueClass { Key = "a", Value = 2 },
                new KeyValueClass { Key = "a", Value = 1 },
                new KeyValueClass { Key = "b", Value = 1 },
                new KeyValueClass { Key = "c", Value = 3 },
                new KeyValueClass { Key = "c", Value = 4 },
                new KeyValueClass { Key = "c", Value = 1 },
            };

            var groups = items.GroupBy(x => x.Key).ToDictionary(x => x.Key, x => x.Select(y => y.Value).ToArray());
            var a = groups["a"];
            var b = groups["b"];
            var c = groups["c"];
            a[0].AssertEquals(2);
            a[1].AssertEquals(1);
            b[0].AssertEquals(1);
            c[0].AssertEquals(3);
            c[1].AssertEquals(4);
            c[2].AssertEquals(1);
        }

        [Test]
        public void ToLookup()
        {
            var items = new[]
            {
                new KeyValueClass { Key = "a", Value = 2 },
                new KeyValueClass { Key = "a", Value = 1 },
                new KeyValueClass { Key = "b", Value = 1 },
                new KeyValueClass { Key = "c", Value = 3 },
                new KeyValueClass { Key = "c", Value = 4 },
                new KeyValueClass { Key = "c", Value = 1 },
            };

            var groups = items.ToLookup(x => x.Key);
            var a = groups["a"].Select(x => x.Value).ToArray();
            var b = groups["b"].Select(x => x.Value).ToArray();
            var c = groups["c"].Select(x => x.Value).ToArray();
            a[0].AssertEquals(2);
            a[1].AssertEquals(1);
            b[0].AssertEquals(1);
            c[0].AssertEquals(3);
            c[1].AssertEquals(4);
            c[2].AssertEquals(1);
        }

        [Test]
        public void Distinct()
        {
            var items = new[] { 1, 3, 6, 3, 4, 1 };
            var distinct = items.Distinct().ToArray();
            distinct.Length.AssertEquals(4);
            distinct[0].AssertEquals(1);
            distinct[1].AssertEquals(3);
            distinct[2].AssertEquals(6);
            distinct[3].AssertEquals(4);
        }

        [Test]
        public void ElementAt()
        {
            var items = new[] { 0, 1, 2 };
            items.ElementAt(0).AssertEquals(0);
            items.ElementAt(1).AssertEquals(1);
            items.ElementAt(2).AssertEquals(2);
        }

        [Test]
        public void ElementAtOrDefault()
        {
            var items = new[] { 0, 1, 2 };
            items.ElementAtOrDefault(0).AssertEquals(0);
            items.ElementAtOrDefault(1).AssertEquals(1);
            items.ElementAtOrDefault(2).AssertEquals(2);
            items.ElementAtOrDefault(3).AssertEquals(0);
        }

        [Test]
        public void Zip()
        {
            var ints1 = new[] { 1, 2, 3 };
            var ints2 = new[] { 4, 5, 6 };
            var zipped = ints1.Zip(ints2, (x, y) => new { x, y }).ToArray();
            zipped[0].x.AssertEquals(1);
            zipped[0].y.AssertEquals(4);
            zipped[1].x.AssertEquals(2);
            zipped[1].y.AssertEquals(5);
            zipped[2].x.AssertEquals(3);
            zipped[2].y.AssertEquals(6);
        }

        [Test]
        public void Union()
        {
            var union = new[] { 1, 1, 2 }.Union(new[] { 1, 2, 2, 3 }).ToArray();
            union.Length.AssertEquals(3);
            union[0].AssertEquals(1);
            union[1].AssertEquals(2);
            union[2].AssertEquals(3);
        }

        [Test]
        public void Intersect()
        {
            var intersection = new[] { 1, 1, 2 }.Intersect(new[] { 1, 2, 2, 3 }).ToArray();
            intersection.Length.AssertEquals(2);
            intersection[0].AssertEquals(1);
            intersection[1].AssertEquals(2);
        }

        [Test]
        public void AverageDouble()
        {
            new double[] { 1, 2, 3, 4, 5, 6, 7 }.Average().AssertEquals(4);
            new double[] { 1, 2, 3, 4, 5, 6 }.Average().AssertEquals(3.5);
        }

        [Test]
        public void AverageInt()
        {
            new[] { 1, 2, 3, 4, 5, 6, 7 }.Average().AssertEquals(4);
            new[] { 1, 2, 3, 4, 5, 6 }.Average().AssertEquals(3.5);
        }

        [Test]
        public void Count()
        {
            var values = new[] { 1, 2, 3, 4, 5 };
            values.Count().AssertEquals(5);
        }
        
        [Test]
        public void Contains()
        {
            IEnumerable<string> values = new[] { "one", "two", "three" };
            values.Contains("one").AssertTrue();
            values.Contains("two").AssertTrue();
            values.Contains("three").AssertTrue();
        }

        public class DictionaryClass
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public class KeyValueClass
        {
            public string Key { get; set; }
            public int Value { get; set; }
        }
    }
}