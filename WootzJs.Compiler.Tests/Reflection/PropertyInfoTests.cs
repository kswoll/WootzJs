using System.Linq;

namespace WootzJs.Compiler.Tests.Reflection
{
    [TestFixture]
    public class PropertyInfoTests
    {
        [Test]
        public void Name()
        {
            var properties = typeof(PropertyClass).GetProperties();
            var staticProperty = properties.Single(x => x.Name == "StaticProperty");
            var stringProperty = properties.Single(x => x.Name == "StringProperty");

            QUnit.AreEqual(staticProperty.Name, "StaticProperty");
            QUnit.AreEqual(stringProperty.Name, "StringProperty");
        }

        public class PropertyClass
        {
            public static string StaticProperty { get; set; }
            public string StringProperty { get; set; }
        }
    }
}