namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class DefaultTests
    {
        [Test]
        public void DefaultInt()
        {
            var value = default(int);
            QUnit.AreEqual(value, 0);
        }

        [Test]
        public void DefaultChar()
        {
            var value = default(int);
            QUnit.AreEqual(value, "");
        }

        [Test]
        public void DefaultBool()
        {
            var value = default(bool);
            QUnit.AreEqual(value, false);
        }

        [Test]
        public void DefaultObject()
        {
            var value = default(object);
            QUnit.AreEqual(value, null);
        }
    }
}