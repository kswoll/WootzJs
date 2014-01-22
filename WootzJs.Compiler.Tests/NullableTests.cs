using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class NullableTests
    {
        [Test]
        public void HasValue()
        {
            int? i = 5;
            QUnit.IsTrue(i.HasValue);
        }

        [Test]
        public void Value()
        {
            int? i = 5;
            QUnit.AreEqual(i.Value, 5);
        }

        [Test]
        public void GetValueOrDefault()
        {
            int? i = 5;
            int? j = null;
            QUnit.AreEqual(i.GetValueOrDefault(), 5);
            QUnit.AreEqual(j.GetValueOrDefault(), null);
        }
    }
}
