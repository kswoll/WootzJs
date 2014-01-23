namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class PropertyTests
    {
        [Test]
        public void StaticProperty()
        {
            StaticPropertyClass.StringProperty = "foo";
            QUnit.AreEqual(StaticPropertyClass.StringProperty, "foo");
        }

        public class StaticPropertyClass
        {
            public static string StringProperty { get; set; }
        }
    }
}