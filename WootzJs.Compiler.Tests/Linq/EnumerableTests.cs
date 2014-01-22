using System.Collections.Generic;
using System.Runtime.WootzJs;
using System.Linq;

namespace WootzJs.Compiler.Tests.Linq
{
    [TestFixture]
    public class EnumerableTests
    {
        [Test]
        public void Aggregate()
        {
            var array = new[] { 1, 2, 3, };
            var result = array.Aggregate((x, y) => x + y);
            QUnit.AreEqual(result, 6);
        }

        [Test]
        public void AggregateWithSeed()
        {
            var array = new[] { 1, 2, 3, };
            var result = array.Aggregate(10, (x, y) => x + y);
            QUnit.AreEqual(result, 16);
        }

        [Test]
        public void AggregateWithSeedAndResult()
        {
            var array = new[] { 1, 2, 3, };
            var result = array.Aggregate(10, (x, y) => x + y, x => x.ToString());
            QUnit.AreEqual(result, "16");
        }

        [Test]
        public void All()
        {
            var array = new[] { 1, 2, 3, };
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
    }
}
