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
    public class EnumerableTests : TestFixture
    {
        [Test]
        public void Aggregate()
        {
            var array = new[] { 1, 2, 3 };
            var result = array.Aggregate((x, y) => x + y);
            AssertEquals(result, 6);
        }

        [Test]
        public void AggregateWithSeed()
        {
            var array = new[] { 1, 2, 3 };
            var result = array.Aggregate(10, (x, y) => x + y);
            AssertEquals(result, 16);
        }

        [Test]
        public void AggregateWithSeedAndResult()
        {
            var array = new[] { 1, 2, 3 };
            var result = array.Aggregate(10, (x, y) => x + y, x => x.ToString());
            AssertEquals(result, "16");
        }

        [Test]
        public void All()
        {
            var array = new[] { 1, 2, 3 };
            AssertEquals(array.All(x => x > 0), true);
            AssertEquals(array.All(x => x > 1), false);
        }

        [Test]
        public void Where()
        {
            var array = new[] { "1", "2", "3" };
            var two = array.Where(x => x == "2").Single();
            AssertEquals(two, "2");
        }

        [Test]
        public void WhereWithIndex()
        {
            var array = new[] { "1", "2", "3" };
            var result = array.Where((x, i) => x == "2" || i == 2).ToArray();
            AssertEquals(result.Length, 2);
            AssertEquals(result[0], "2");
            AssertEquals(result[1], "3");
        }

        [Test]
        public void Select()
        {
            var array = new[] { "1", "2", "3" };
            var two = array.Select(x => x + "a").ToArray();
            AssertEquals(two[0], "1a");
            AssertEquals(two[1], "2a");
            AssertEquals(two[2], "3a");
        }

        [Test]
        public void SelectWithIndex()
        {
            var array = new[] { "1", "2", "3" };
            var two = array.Select((x, i) => x + "a" + i).ToArray();
            AssertEquals(two[0], "1a0");
            AssertEquals(two[1], "2a1");
            AssertEquals(two[2], "3a2");
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
            AssertEquals(elements.Length, 6);
            AssertEquals(elements[0], "1");
            AssertEquals(elements[1], "2");
            AssertEquals(elements[2], "3");
            AssertEquals(elements[3], "4");
            AssertEquals(elements[4], "5");
            AssertEquals(elements[5], "6");
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
            AssertEquals(elements.Length, 6);
            AssertEquals(elements[0], "10");
            AssertEquals(elements[1], "20");
            AssertEquals(elements[2], "30");
            AssertEquals(elements[3], "41");
            AssertEquals(elements[4], "51");
            AssertEquals(elements[5], "61");
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
            AssertEquals(elements.Length, 6);
            AssertEquals(elements[0], 30);
            AssertEquals(elements[1], 60);
            AssertEquals(elements[2], 90);
            AssertEquals(elements[3], 123);
            AssertEquals(elements[4], 153);
            AssertEquals(elements[5], 183);
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
            AssertEquals(elements.Length, 6);
            AssertEquals(elements[0], 3);
            AssertEquals(elements[1], 6);
            AssertEquals(elements[2], 9);
            AssertEquals(elements[3], 12);
            AssertEquals(elements[4], 15);
            AssertEquals(elements[5], 18);
        }

        [Test]
        public void Max()
        {
            AssertEquals(new[] { 1, 2, 3 }.Max(), 3);
            AssertEquals(new[] { 1.3, 2.4, 3.5 }.Max(), 3.5);
        }

        [Test]
        public void Min()
        {
            AssertEquals(new[] { -1, 2, 3 }.Min(), -1);
            AssertEquals(new[] { 1.3, -2.4, 3.5 }.Min(), -2.4);
        }

        [Test]
        public void Take()
        {
            var ints = new[] { 8, 3, 5, 1 }.Take(3).ToArray();
            AssertEquals(ints.Length, 3);
            AssertEquals(ints[0], 8);
            AssertEquals(ints[1], 3);
            AssertEquals(ints[2], 5);
        }

        [Test]
        public void TakeWhile()
        {
            var ints = new[] { 1, 2, 3, 4, 5 }.TakeWhile(x => x < 3).ToArray();
            AssertEquals(ints.Length, 2);
            AssertEquals(ints[0], 1);
            AssertEquals(ints[1], 2);
        }

        [Test]
        public void TakeWhileWithIndex()
        {
            var ints = new[] { 1, 2, 3, 4, 5 }.TakeWhile((x, i) => i < 3).ToArray();
            AssertEquals(ints.Length, 3);
            AssertEquals(ints[0], 1);
            AssertEquals(ints[1], 2);
            AssertEquals(ints[2], 3);
        }

        [Test]
        public void Skip()
        {
            var ints = new[] { 8, 3, 5, 1 }.Skip(2).ToArray();
            AssertEquals(ints.Length, 2);
            AssertEquals(ints[0], 5);
            AssertEquals(ints[1], 1);
        }

        [Test]
        public void SkipWhile()
        {
            var ints = new[] { 1, 2, 3, 4, 5 }.SkipWhile(x => x < 3).ToArray();
            AssertEquals(ints.Length, 3);
            AssertEquals(ints[0], 3);
            AssertEquals(ints[1], 4);
            AssertEquals(ints[2], 5);
        }

        [Test]
        public void SkipWhileWithIndex()
        {
            var ints = new[] { 1, 2, 3, 4, 5 }.SkipWhile((x, i) => i < 3).ToArray();
            AssertEquals(ints.Length, 2);
            AssertEquals(ints[0], 4);
            AssertEquals(ints[1], 5);
        }

        [Test]
        public void Join()
        {
            var ints1 = new[] { 1, 2, 3, 4 };
            var ints2 = new[] { 3, 4, 5, 6 };
            var join = ints1.Join(ints2, x => x, x => x, (x, y) => x + y).ToArray();
            AssertEquals(@join.Length, 2);
            AssertEquals(@join[0], 6);
            AssertEquals(@join[1], 8);
        }

        [Test]
        public void Except()
        {
            var ints1 = new[] { 1, 2, 3, 4 };
            var ints2 = new[] { 3, 4, 5, 6 };
            var join = ints1.Except(ints2).ToArray();
            AssertEquals(@join.Length, 2);
            AssertEquals(@join[0], 1);
            AssertEquals(@join[1], 2);
        }

        [Test]
        public void Single()
        {
            var ints1 = new[] { 1 };
            var int1 = ints1.Single();
            AssertEquals(int1, 1);
        }

        [Test]
        public void SingleThrowsWhenEmpty()
        {
            var ints1 = new int[0];
            try
            {
                var int1 = ints1.Single();
                AssertTrue(false);
            }
            catch (Exception e)
            {
                AssertTrue(true);
            }
        }

        [Test]
        public void SumInt()
        {
            var ints = new[] { 1, 2, 3 };
            var sum = ints.Sum();
            AssertEquals(sum, 6);
        }

        [Test]
        public void SingleThrowsWhenContainsMany()
        {
            var ints1 = new[] { 1, 2 };
            try
            {
                var int1 = ints1.Single();
                AssertTrue(false);
            }
            catch (Exception e)
            {
                AssertTrue(true);
            }
        }

        [Test]
        public void Reverse()
        {
            var ints = new[] { 1, 2, 3 };
            var reverse = ints.Reverse().ToArray();
            AssertEquals(reverse.Length, 3);
            AssertEquals(reverse[0], 3);
            AssertEquals(reverse[1], 2);
            AssertEquals(reverse[2], 1);
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
            AssertEquals(dictionary["John"], "Austria");
            AssertEquals(dictionary["Gary"], "California");
        }

        [Test]
        public void SequenceEqual()
        {
            var ints1 = new[] { 1, 2, 3 };
            var ints2 = new[] { 1, 2, 3 };
            AssertTrue(ints1.SequenceEqual(ints2));
        }

        [Test]
        public void Last()
        {
            var ints = new[] { 1, 2, 3, 4 };
            var last = ints.Last();
            AssertEquals(last, 4);
        }

        [Test]
        public void OfType()
        {
            var objects = new object[] { 1, "5", 5d, "8" };
            var strings = objects.OfType<string>().ToArray();
            AssertEquals(strings[0], "5");
            AssertEquals(strings[1], "8");
        }

        [Test]
        public void OrderBy()
        {
            var list = new[] { 8, 53, 1, 888, 444, 234, 3 }.OrderBy(x => x).ToArray();

            AssertEquals(list[0], 1);
            AssertEquals(list[1], 3);
            AssertEquals(list[2], 8);
            AssertEquals(list[3], 53);
            AssertEquals(list[4], 234);
            AssertEquals(list[5], 444);
            AssertEquals(list[6], 888);
        }

        [Test]
        public void OrderByDescending()
        {
            var list = new[] { 8, 53, 1 }.OrderByDescending(x => x).ToArray();

            AssertEquals(list[0], 53);
            AssertEquals(list[1], 8);
            AssertEquals(list[2], 1);
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

            AssertEquals(list[0].Key, "a");
            AssertEquals(list[0].Value, 1);
            AssertEquals(list[1].Key, "a");
            AssertEquals(list[1].Value, 2);
            AssertEquals(list[2].Key, "b");
            AssertEquals(list[2].Value, 1);
            AssertEquals(list[3].Key, "c");
            AssertEquals(list[3].Value, 1);
            AssertEquals(list[4].Key, "c");
            AssertEquals(list[4].Value, 3);
            AssertEquals(list[5].Key, "c");
            AssertEquals(list[5].Value, 4);
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

            AssertEquals(list[0].Key, "a");
            AssertEquals(list[0].Value, 2);
            AssertEquals(list[1].Key, "a");
            AssertEquals(list[1].Value, 1);
            AssertEquals(list[2].Key, "b");
            AssertEquals(list[2].Value, 1);
            AssertEquals(list[3].Key, "c");
            AssertEquals(list[3].Value, 4);
            AssertEquals(list[4].Key, "c");
            AssertEquals(list[4].Value, 3);
            AssertEquals(list[5].Key, "c");
            AssertEquals(list[5].Value, 1);
        }

        [Test]
        public void Empty()
        {
            var enumerator = Enumerable.Empty<string>().GetEnumerator();
            AssertTrue((!enumerator.MoveNext()));
        }

        [Test]
        public void DefaultIfEmpty()
        {
            var s = new string[0].DefaultIfEmpty().Single();
            AssertEquals(s, null);

            var i = new int[0].DefaultIfEmpty().Single();
            AssertEquals(i, 0);
        }

        [Test]
        public void DefaultIfEmptyExplicitDefault()
        {
            var s = new string[0].DefaultIfEmpty("default").Single();
            AssertEquals(s, "default");

            var i = new int[0].DefaultIfEmpty(5).Single();
            AssertEquals(i, 5);
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
            AssertEquals(a[0], 2);
            AssertEquals(a[1], 1);
            AssertEquals(b[0], 1);
            AssertEquals(c[0], 3);
            AssertEquals(c[1], 4);
            AssertEquals(c[2], 1);
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
            AssertEquals(a[0], 2);
            AssertEquals(a[1], 1);
            AssertEquals(b[0], 1);
            AssertEquals(c[0], 3);
            AssertEquals(c[1], 4);
            AssertEquals(c[2], 1);
        }

        [Test]
        public void Distinct()
        {
            var items = new[] { 1, 3, 6, 3, 4, 1 };
            var distinct = items.Distinct().ToArray();
            AssertEquals(distinct.Length, 4);
            AssertEquals(distinct[0], 1);
            AssertEquals(distinct[1], 3);
            AssertEquals(distinct[2], 6);
            AssertEquals(distinct[3], 4);
        }

        [Test]
        public void ElementAt()
        {
            var items = new[] { 0, 1, 2 };
            AssertEquals(items.ElementAt(0), 0);
            AssertEquals(items.ElementAt(1), 1);
            AssertEquals(items.ElementAt(2), 2);
        }

        [Test]
        public void ElementAtOrDefault()
        {
            var items = new[] { 0, 1, 2 };
            AssertEquals(items.ElementAtOrDefault(0), 0);
            AssertEquals(items.ElementAtOrDefault(1), 1);
            AssertEquals(items.ElementAtOrDefault(2), 2);
            AssertEquals(items.ElementAtOrDefault(3), 0);
        }

        [Test]
        public void Zip()
        {
            var ints1 = new[] { 1, 2, 3 };
            var ints2 = new[] { 4, 5, 6 };
            var zipped = ints1.Zip(ints2, (x, y) => new { x, y }).ToArray();
            AssertEquals(zipped[0].x, 1);
            AssertEquals(zipped[0].y, 4);
            AssertEquals(zipped[1].x, 2);
            AssertEquals(zipped[1].y, 5);
            AssertEquals(zipped[2].x, 3);
            AssertEquals(zipped[2].y, 6);
        }

        [Test]
        public void Union()
        {
            var union = new[] { 1, 1, 2 }.Union(new[] { 1, 2, 2, 3 }).ToArray();
            AssertEquals(union.Length, 3);
            AssertEquals(union[0], 1);
            AssertEquals(union[1], 2);
            AssertEquals(union[2], 3);
        }

        [Test]
        public void Intersect()
        {
            var intersection = new[] { 1, 1, 2 }.Intersect(new[] { 1, 2, 2, 3 }).ToArray();
            AssertEquals(intersection.Length, 2);
            AssertEquals(intersection[0], 1);
            AssertEquals(intersection[1], 2);
        }

        [Test]
        public void AverageDouble()
        {
            AssertEquals(new double[] { 1, 2, 3, 4, 5, 6, 7 }.Average(), 4);
            AssertEquals(new double[] { 1, 2, 3, 4, 5, 6 }.Average(), 3.5);
        }

        [Test]
        public void AverageInt()
        {
            AssertEquals(new[] { 1, 2, 3, 4, 5, 6, 7 }.Average(), 4);
            AssertEquals(new[] { 1, 2, 3, 4, 5, 6 }.Average(), 3.5);
        }

        [Test]
        public void Count()
        {
            var values = new[] { 1, 2, 3, 4, 5 };
            AssertEquals(values.Count(), 5);
        }
        
        [Test]
        public void Contains()
        {
            IEnumerable<string> values = new[] { "one", "two", "three" };
            AssertTrue(values.Contains("one"));
            AssertTrue(values.Contains("two"));
            AssertTrue(values.Contains("three"));
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