using System.Collections.Generic;
using System.Linq;

namespace WootzJs.Compiler.Tests.Collections.Generic
{
    [TestFixture]
    public class DictionaryTests
    {
        [Test]
        public void Count()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("one", 1);
            QUnit.AreEqual(dictionary.Count, 1);
        }
         
        [Test]
        public void ContainsKey()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("one", 1);
            QUnit.IsTrue(dictionary.ContainsKey("one"));
            QUnit.IsTrue(!dictionary.ContainsKey("two"));
        }
         
        [Test]
        public void Keys()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("one", 1);
            dictionary.Add("two", 2);
            var keys = dictionary.Keys.ToArray();
            QUnit.IsTrue(keys[0] == "one" || keys[1] == "one");
            QUnit.IsTrue(keys[0] == "two" || keys[1] == "two");
        }
         
        [Test]
        public void Add()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("one", 1);
            dictionary.Add("two", 2);
            QUnit.AreEqual(dictionary["one"], 1);
        }
         
        [Test]
        public void Set()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary["one"] = 1;
            dictionary["two"] = 2;
            QUnit.AreEqual(dictionary["one"], 1);
            QUnit.AreEqual(dictionary["two"], 2);
        }
         
        [Test]
        public void DupsDontChangeCount()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary["one"] = 1;
            dictionary["one"] = 2;
            QUnit.AreEqual(dictionary["one"], 2);
            QUnit.AreEqual(dictionary.Count, 1);
        }
         
        [Test]
        public void Remove()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary["one"] = 1;
            dictionary.Remove("one");
            QUnit.AreEqual(dictionary.Count, 0);
        }
         
        [Test]
        public void Clear()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary["one"] = 1;
            dictionary.Clear();
            QUnit.AreEqual(dictionary.Count, 0);
        }
         
        [Test]
        public void TryGetValue()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary["one"] = 1;
            dictionary["two"] = 2;
            int i;
            dictionary.TryGetValue("two", out i);
            QUnit.AreEqual(i, 2);
        }
    }
}
