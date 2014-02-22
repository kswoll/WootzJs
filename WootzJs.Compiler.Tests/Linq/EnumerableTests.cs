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
using System.Linq;

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
            QUnit.AreEqual(result, 6);
        }

        [Test]
        public void AggregateWithSeed()
        {
            var array = new[] { 1, 2, 3 };
            var result = array.Aggregate(10, (x, y) => x + y);
            QUnit.AreEqual(result, 16);
        }

        [Test]
        public void AggregateWithSeedAndResult()
        {
            var array = new[] { 1, 2, 3 };
            var result = array.Aggregate(10, (x, y) => x + y, x => x.ToString());
            QUnit.AreEqual(result, "16");
        }

        [Test]
        public void All()
        {
            var array = new[] { 1, 2, 3 };
            QUnit.AreEqual(array.All(x => x > 0), true);
            QUnit.AreEqual(array.All(x => x > 1), false);
        }

        [Test]
        public void Where()
        {
            var array = new[] { "1", "2", "3" };
            var two = array.Where(x => x == "2").Single();
            QUnit.AreEqual(two, "2");
        }

        [Test]
        public void WhereWithIndex()
        {
            var array = new[] { "1", "2", "3" };
            var result = array.Where((x, i) => x == "2" || i == 2).ToArray();
            QUnit.AreEqual(result.Length, 2);
            QUnit.AreEqual(result[0], "2");
            QUnit.AreEqual(result[1], "3");
        }

        [Test]
        public void Select()
        {
            var array = new[] { "1", "2", "3" };
            var two = array.Select(x => x + "a").ToArray();
            QUnit.AreEqual(two[0], "1a");
            QUnit.AreEqual(two[1], "2a");
            QUnit.AreEqual(two[2], "3a");
        }

        [Test]
        public void SelectWithIndex()
        {
            var array = new[] { "1", "2", "3" };
            var two = array.Select((x, i) => x + "a" + i).ToArray();
            QUnit.AreEqual(two[0], "1a0");
            QUnit.AreEqual(two[1], "2a1");
            QUnit.AreEqual(two[2], "3a2");
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
            QUnit.AreEqual(elements.Length, 6);
            QUnit.AreEqual(elements[0], "1");
            QUnit.AreEqual(elements[1], "2");
            QUnit.AreEqual(elements[2], "3");
            QUnit.AreEqual(elements[3], "4");
            QUnit.AreEqual(elements[4], "5");
            QUnit.AreEqual(elements[5], "6");
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
            QUnit.AreEqual(elements.Length, 6);
            QUnit.AreEqual(elements[0], "10");
            QUnit.AreEqual(elements[1], "20");
            QUnit.AreEqual(elements[2], "30");
            QUnit.AreEqual(elements[3], "41");
            QUnit.AreEqual(elements[4], "51");
            QUnit.AreEqual(elements[5], "61");
        }

        [Test]
        public void SelectManyWithIndexAndResultSelector()
        {
            var arrays = new[]
            {
                new[] { "1", "2", "3" },
                new[] { "4", "5", "6" }
            };

            var elements = arrays.SelectMany((x, i) => x.Select(y => y + i), (row, item) => row.Length * int.Parse(item)).ToArray();
            QUnit.AreEqual(elements.Length, 6);
            QUnit.AreEqual(elements[0], 30);
            QUnit.AreEqual(elements[1], 60);
            QUnit.AreEqual(elements[2], 90);
            QUnit.AreEqual(elements[3], 123);
            QUnit.AreEqual(elements[4], 153);
            QUnit.AreEqual(elements[5], 183);
        }

        [Test]
        public void SelectManyWithResultSelector()
        {
            var arrays = new[]
            {
                new[] { "1", "2", "3" },
                new[] { "4", "5", "6" }
            };

            var elements = arrays.SelectMany(x => x, (row, item) => row.Length * int.Parse(item)).ToArray();
            QUnit.AreEqual(elements.Length, 6);
            QUnit.AreEqual(elements[0], 3);
            QUnit.AreEqual(elements[1], 6);
            QUnit.AreEqual(elements[2], 9);
            QUnit.AreEqual(elements[3], 12);
            QUnit.AreEqual(elements[4], 15);
            QUnit.AreEqual(elements[5], 18);
        }

        [Test]
        public void Max()
        {
            QUnit.AreEqual(new[] { 1, 2, 3 }.Max(), 3);
            QUnit.AreEqual(new[] { 1.3, 2.4, 3.5 }.Max(), 3.5);
        }

        [Test]
        public void Min()
        {
            QUnit.AreEqual(new[] { -1, 2, 3 }.Min(), -1);
            QUnit.AreEqual(new[] { 1.3, -2.4, 3.5 }.Min(), -2.4);
        }

        [Test]
        public void Take()
        {
            var ints = new[] { 8, 3, 5, 1 }.Take(3).ToArray();
            QUnit.AreEqual(ints.Length, 3);
            QUnit.AreEqual(ints[0], 8);
            QUnit.AreEqual(ints[1], 3);
            QUnit.AreEqual(ints[2], 5);
        }

        [Test]
        public void TakeWhile()
        {
            var ints = new[] { 1, 2, 3, 4, 5 }.TakeWhile(x => x < 3).ToArray();
            QUnit.AreEqual(ints.Length, 2);
            QUnit.AreEqual(ints[0], 1);
            QUnit.AreEqual(ints[1], 2);
        }

        [Test]
        public void TakeWhileWithIndex()
        {
            var ints = new[] { 1, 2, 3, 4, 5 }.TakeWhile((x, i) => i < 3).ToArray();
            QUnit.AreEqual(ints.Length, 3);
            QUnit.AreEqual(ints[0], 1);
            QUnit.AreEqual(ints[1], 2);
            QUnit.AreEqual(ints[2], 3);
        }

        [Test]
        public void Skip()
        {
            var ints = new[] { 8, 3, 5, 1 }.Skip(2).ToArray();
            QUnit.AreEqual(ints.Length, 2);
            QUnit.AreEqual(ints[0], 5);
            QUnit.AreEqual(ints[1], 1);
        }

        [Test]
        public void SkipWhile()
        {
            var ints = new[] { 1, 2, 3, 4, 5 }.SkipWhile(x => x < 3).ToArray();
            QUnit.AreEqual(ints.Length, 3);
            QUnit.AreEqual(ints[0], 3);
            QUnit.AreEqual(ints[1], 4);
            QUnit.AreEqual(ints[2], 5);
        }

        [Test]
        public void SkipWhileWithIndex()
        {
            var ints = new[] { 1, 2, 3, 4, 5 }.SkipWhile((x, i) => i < 3).ToArray();
            QUnit.AreEqual(ints.Length, 2);
            QUnit.AreEqual(ints[0], 4);
            QUnit.AreEqual(ints[1], 5);
        }

        [Test]
        public void Join()
        {
            var ints1 = new[] { 1, 2, 3, 4 };
            var ints2 = new[] { 3, 4, 5, 6 };
            var join = ints1.Join(ints2, x => x, x => x, (x, y) => x + y).ToArray();
            QUnit.AreEqual(join.Length, 2);
            QUnit.AreEqual(join[0], 6);
            QUnit.AreEqual(join[1], 8);
        }

        [Test]
        public void Except()
        {
            var ints1 = new[] { 1, 2, 3, 4 };
            var ints2 = new[] { 3, 4, 5, 6 };
            var join = ints1.Except(ints2).ToArray();
            QUnit.AreEqual(join.Length, 2);
            QUnit.AreEqual(join[0], 1);
            QUnit.AreEqual(join[1], 2);
        }

        [Test]
        public void Single()
        {
            var ints1 = new[] { 1 };
            var int1 = ints1.Single();
            QUnit.AreEqual(int1, 1);
        }

        [Test]
        public void SingleThrowsWhenEmpty()
        {
            var ints1 = new int[0];
            try
            {
                var int1 = ints1.Single();
                QUnit.IsTrue(false);
            }
            catch (Exception e)
            {
                QUnit.IsTrue(true);
            }
        }

        [Test]
        public void SumInt()
        {
            var ints = new[] { 1, 2, 3 };
            var sum = ints.Sum();
            QUnit.AreEqual(sum, 6);
        }

        [Test]
        public void SingleThrowsWhenContainsMany()
        {
            var ints1 = new[] { 1, 2 };
            try
            {
                var int1 = ints1.Single();
                QUnit.IsTrue(false);
            }
            catch (Exception e)
            {
                QUnit.IsTrue(true);
            }
        }

        [Test]
        public void Reverse()
        {
            var ints = new[] { 1, 2, 3 };
            var reverse = ints.Reverse().ToArray();
            QUnit.AreEqual(reverse.Length, 3);
            QUnit.AreEqual(reverse[0], 3);
            QUnit.AreEqual(reverse[1], 2);
            QUnit.AreEqual(reverse[2], 1);
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
            QUnit.AreEqual(dictionary["John"], "Austria");
            QUnit.AreEqual(dictionary["Gary"], "California");
        }

        [Test]
        public void SequenceEqual()
        {
            var ints1 = new[] { 1, 2, 3 };
            var ints2 = new[] { 1, 2, 3 };
            QUnit.IsTrue(ints1.SequenceEqual(ints2));
        }

        [Test]
        public void Last()
        {
            var ints = new[] { 1, 2, 3, 4 };
            var last = ints.Last();
            QUnit.AreEqual(last, 4);
        }

        [Test]
        public void OfType()
        {
            var objects = new object[] { 1, "5", 5d, "8" };
            var strings = objects.OfType<string>().ToArray();
            QUnit.AreEqual(strings[0], "5");
            QUnit.AreEqual(strings[1], "8");
        }

        [Test]
        public void OrderBy()
        {
            var list = new[] { 8, 53, 1, 888, 444, 234, 3 }.OrderBy(x => x).ToArray();

            QUnit.AreEqual(list[0], 1);
            QUnit.AreEqual(list[1], 3);
            QUnit.AreEqual(list[2], 8);
            QUnit.AreEqual(list[3], 53);
            QUnit.AreEqual(list[4], 234);
            QUnit.AreEqual(list[5], 444);
            QUnit.AreEqual(list[6], 888);            
        }

        [Test]
        public void OrderByDescending()
        {
            var list = new[] { 8, 53, 1 }.OrderByDescending(x => x).ToArray();

            QUnit.AreEqual(list[0], 53);
            QUnit.AreEqual(list[1], 8);
            QUnit.AreEqual(list[2], 1);
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

            QUnit.AreEqual(list[0].Key, "a");
            QUnit.AreEqual(list[0].Value, 1);
            QUnit.AreEqual(list[1].Key, "a");
            QUnit.AreEqual(list[1].Value, 2);
            QUnit.AreEqual(list[2].Key, "b");
            QUnit.AreEqual(list[2].Value, 1);
            QUnit.AreEqual(list[3].Key, "c");
            QUnit.AreEqual(list[3].Value, 1);
            QUnit.AreEqual(list[4].Key, "c");
            QUnit.AreEqual(list[4].Value, 3);
            QUnit.AreEqual(list[5].Key, "c");
            QUnit.AreEqual(list[5].Value, 4);
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

            QUnit.AreEqual(list[0].Key, "a");
            QUnit.AreEqual(list[0].Value, 2);
            QUnit.AreEqual(list[1].Key, "a");
            QUnit.AreEqual(list[1].Value, 1);
            QUnit.AreEqual(list[2].Key, "b");
            QUnit.AreEqual(list[2].Value, 1);
            QUnit.AreEqual(list[3].Key, "c");
            QUnit.AreEqual(list[3].Value, 4);
            QUnit.AreEqual(list[4].Key, "c");
            QUnit.AreEqual(list[4].Value, 3);
            QUnit.AreEqual(list[5].Key, "c");
            QUnit.AreEqual(list[5].Value, 1);
        }

        [Test]
        public void Empty()
        {
            var enumerator = Enumerable.Empty<string>().GetEnumerator();
            QUnit.IsTrue(!enumerator.MoveNext());
        }

        [Test]
        public void DefaultIfEmpty()
        {
            var s = new string[0].DefaultIfEmpty().Single();
            QUnit.AreEqual(s, null);

            var i = new int[0].DefaultIfEmpty().Single();
            QUnit.AreEqual(i, 0);
        }

        [Test]
        public void DefaultIfEmptyExplicitDefault()
        {
            var s = new string[0].DefaultIfEmpty("default").Single();
            QUnit.AreEqual(s, "default");

            var i = new int[0].DefaultIfEmpty(5).Single();
            QUnit.AreEqual(i, 5);
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
            QUnit.AreEqual(a[0], 2);
            QUnit.AreEqual(a[1], 1);
            QUnit.AreEqual(b[0], 1);
            QUnit.AreEqual(c[0], 3);
            QUnit.AreEqual(c[1], 4);
            QUnit.AreEqual(c[2], 1);
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
