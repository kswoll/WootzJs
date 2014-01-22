using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class ArrayTests
    {
        [Test]
        public void LengthProperty()
        {
            var array = new[] { "1", "2", "3" };
            QUnit.AreEqual(array.Length, 3);
        }         

        [Test]
        public void ArrayIndex()
        {
            var array = new[] { "1", "2", "3" };
            QUnit.AreEqual(array[2], "3");
        }         

        [Test]
        public void ArrayIndexSet()
        {
            var array = new[] { "1", "2", "3" };
            array[2] = "10";
            QUnit.AreEqual(array[2], "10");
        }         

        [Test]
        public void ArrayCopy()
        {
            var array = new[] { "1", "2", "3" };
            var newArray = new string[2];
            array.CopyTo(newArray, 1);
            QUnit.AreEqual(newArray[0], "2");
            QUnit.AreEqual(newArray[1], "3");
        }         

        [Test]
        public void StringArrayType()
        {
            var array = new[] { "1", "2", "3" };
            QUnit.AreEqual(array.GetType().Name, "String[]");
        }         
    }
}
