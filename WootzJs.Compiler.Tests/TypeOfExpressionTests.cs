using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class TypeOfExpressionTests
    {
        [Test]
        public void TypeOfReturnsName()
        {
            var type = typeof(TestClass);
            var name = type.Name;
            QUnit.AreEqual(name, "TestClass");
        }
         
        public class TestClass {}
    }
}
