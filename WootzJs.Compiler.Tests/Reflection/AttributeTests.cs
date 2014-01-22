using System;
using System.Linq;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests.Reflection
{
    [TestFixture]
    public class AttributeTests
    {
        [Test]
        public void Method()
        {
            var method = typeof(TestClass).GetMethods().Single(x => x.Name == "Method");
            var attribute = (FooAttribute)method.GetCustomAttributes(typeof(FooAttribute), false)[0];
            QUnit.AreEqual(attribute.ConstructorValue, 1);
            QUnit.AreEqual(attribute.PropertyValue, "One");
        }

        [Test]
        public void Field()
        {
            var field1 = typeof(TestClass).GetFields().Single(x => x.Name == "Field1");
            var field2 = typeof(TestClass).GetFields().Single(x => x.Name == "Field2");
            var attribute1 = (FooAttribute)field1.GetCustomAttributes(typeof(FooAttribute), false)[0];
            var attribute2 = (FooAttribute)field2.GetCustomAttributes(typeof(FooAttribute), false)[0];
            QUnit.AreEqual(attribute1.ConstructorValue, 2);
            QUnit.AreEqual(attribute1.PropertyValue, "Two");
            QUnit.AreEqual(attribute2.ConstructorValue, 3);
        }

        [Test]
        public void Parameter()
        {
            var method = typeof(TestClass).GetMethods().Single(x => x.Name == "Parameter");
            var parameter1 = method.GetParameters()[0];
            var parameter2 = method.GetParameters()[1];
            var attribute1 = (FooAttribute)parameter1.GetCustomAttributes(typeof(FooAttribute), false)[0];
            var attribute2 = (FooAttribute)parameter2.GetCustomAttributes(typeof(FooAttribute), false)[0];
            QUnit.AreEqual(attribute1.ConstructorValue, 4);
            QUnit.AreEqual(attribute1.PropertyValue, "Four");
            QUnit.AreEqual(attribute2.ConstructorValue, 5);
            QUnit.AreEqual(attribute2.PropertyValue, "Five");
        }

        [Test]
        public void EnumMember()
        {
            var field = typeof(TestEnum).GetFields().Single();
            var attribute = (FooAttribute)field.GetCustomAttributes(typeof(FooAttribute), false)[0];
            QUnit.AreEqual(attribute.ConstructorValue, 6);
            QUnit.AreEqual(attribute.PropertyValue, "Six");
        }

        public class FooAttribute : Attribute
        {
            public string PropertyValue { get; set; }

            private int constructorValue;

            public FooAttribute(int constructorValue)
            {
                this.constructorValue = constructorValue;
            }

            public int ConstructorValue
            {
                get { return constructorValue; }
            }
        }

        public class TestClass
        {
            [Foo(2, PropertyValue = "Two")]
            public object Field1;

            [Foo(3)]
            public object Field2;

            [Foo(1, PropertyValue = "One")]
            public void Method()
            {
            }

            public void Parameter([Foo(4, PropertyValue = "Four")]int parameter1, [Foo(5, PropertyValue = "Five")]string parameter2)
            {
            }
        }

        public enum TestEnum
        {
            [Foo(6, PropertyValue = "Six")]
            One
        }
    }
}
