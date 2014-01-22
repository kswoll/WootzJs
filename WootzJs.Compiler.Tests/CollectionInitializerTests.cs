using System.Collections.Generic;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class CollectionInitializerTests
    {
        [Test]
        public void OneString()
        {
            var list = new List<string> { "one" };
            QUnit.AreEqual(list[0], "one");
        }
         
        [Test]
        public void TwoItemDictionary()
        {
            var dictionary = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 }
            };
            var one = dictionary["one"];
            var two = dictionary["two"];
            QUnit.AreEqual(one, 1);
            QUnit.AreEqual(two, 2);
        }
    }
}
