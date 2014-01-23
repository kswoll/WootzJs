using System;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class ObjectInitializerTests
    {
        [Test]
        public void OneProperty()
        {
            var o = new OnePropertyClass { MyProperty = "foo" };
            QUnit.AreEqual(o.MyProperty, "foo");
        }
         
        [Test]
        public void OneField()
        {
            var o = new OnePropertyClass { MyField = "foo" };
            QUnit.AreEqual(o.MyField, "foo");
        }
         
        [Test]
        public void Nested()
        {
            var o = new OnePropertyClass { NestedProperty = new OnePropertyClass { MyProperty = "foo" } };
            QUnit.AreEqual(o.NestedProperty.MyProperty, "foo");
        }
         
        public class OnePropertyClass
        {
            public string MyProperty { get; set; }
            public string MyField;
            public OnePropertyClass NestedProperty { get; set; }
        }
    }
}
