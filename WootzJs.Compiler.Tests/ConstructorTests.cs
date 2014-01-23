using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void ConstructorsWithOverloads()
        {
            var test1 = new TestClass();
            var test2 = new TestClass("foo");
            var test3 = new TestClass(5);

            QUnit.AreEqual(test1.Arg1, "none");
            QUnit.AreEqual(test2.Arg1, "string");
            QUnit.AreEqual(test3.Arg1, "int");
        }
         
        [Test]
        public void InitializedStaticField()
        {
            QUnit.AreEqual(ClassWithStaticInitializedField.InitializedValue, "foo");
        }
         
        [Test]
        public void StaticConstructor()
        {
            QUnit.AreEqual(ClassWithStaticConstructor.InitializedValue, "foo");
        }
         
        public class TestClass
        {
            private string arg1;

            public TestClass()
            {
                arg1 = "none";
            }

            public TestClass(string arg1)
            {
                this.arg1 = "string";
            }

            public TestClass(int arg1)
            {
                this.arg1 = "int";
            }

            public string Arg1
            {
                get { return arg1; }
            }
        }

        public class ClassWithStaticInitializedField
        {
            public static string InitializedValue = "foo";
        }

        public class ClassWithStaticConstructor
        {
            public static string InitializedValue;

            static ClassWithStaticConstructor()
            {
                InitializedValue = "foo";
            }
        }
    }
}
