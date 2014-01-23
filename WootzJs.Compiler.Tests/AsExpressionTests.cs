using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class AsExpressionTests
    {
        [Test]
        public void String()
        {
            object o = "foo";
            var s = o as string;
            QUnit.IsTrue(s is string);
            QUnit.IsTrue(!(s is int));
        }

        [Test]
        public void TestClass()
        {
            object o = new MyClass();
            var myClass = o as MyClass;
            QUnit.IsTrue(myClass is MyClass);
            QUnit.IsTrue(myClass is object);
            QUnit.IsTrue(!(myClass is string));
        }

        public class MyClass {}
    }
}
