using System.Linq;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests.Reflection
{
    [TestFixture]
    public class ConstructorInfoTests
    {
        [Test]
        public void InvokeParameterless()
        {
            var type = typeof(TestClass);
            var constructor = type.GetConstructors().Single(x => x.GetParameters().Length == 0);
            var testClass = (TestClass)constructor.Invoke(new object[0]);
            QUnit.AreEqual(testClass.Foo, "parameterless");
        }

        [Test]
        public void InvokeNoConstructor()
        {
            var type = typeof(NoConstructorClass);
            var constructor = type.GetConstructors().Single(x => x.GetParameters().Length == 0);
            var testClass = (NoConstructorClass)constructor.Invoke(new object[0]);
            QUnit.AreEqual(testClass.Foo, "noconstructor");
        }

        public class TestClass
        {
            public string Foo;

            public TestClass()
            {
                Foo = "parameterless";
            }
        }

        public class NoConstructorClass
        {
            public string Foo = "noconstructor";
        }
    }
}
