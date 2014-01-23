using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class AnonymousTypeTests
    {
        [Test]
        public void OneProperty()
        {
            var o = new { MyProperty = "foo" };
            QUnit.AreEqual(o.MyProperty, "foo");
        }
    }
}
