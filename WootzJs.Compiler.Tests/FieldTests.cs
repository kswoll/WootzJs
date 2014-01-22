using System;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class FieldTests
    {
        [Test]
        public void FieldsDoNotCollide()
        {
            var subClass = new SubClass();
            QUnit.AreEqual(subClass.GetFoo1(), "base");
            QUnit.AreEqual(subClass.GetFoo2(), "sub");
        }

        [Test]
        public void StaticFieldsAreStatic()
        {
            StaticFieldClass.MyField = "foo";
            QUnit.AreEqual(StaticFieldClass.MyField, "foo");
        }

        [Test]
        public void ReferencedField()
        {
            var reference = new ReferenceClass();
            reference.Target = new TargetClass();
            reference.Target.Foo = "foo";

            QUnit.AreEqual(reference.Target.Foo, "foo");
        }

        public class StaticFieldClass
        {
            public static string MyField;
        }

        public class BaseClass : Object
        {
            private string foo;

            public BaseClass()
            {
                foo = "base";
            }

            public string GetFoo1()
            {
                return foo;
            }
        }

        public class SubClass : BaseClass
        {
            private string foo;

            public SubClass()
            {
                System.Runtime.CompilerServices.ExtensionAttribute x = null;
                foo = "sub";
            }

            public string GetFoo2()
            {
                GetFoo1();
                return foo;
            }
        }

        public class ReferenceClass
        {
            public TargetClass Target { get; set; }
        }

        public class TargetClass
        {
            public string Foo { get; set; }
        }
    }
}
