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
    }
}
