using System.Collections.Generic;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class IsExpressionTests
    {
        [Test]
        public void String()
        {
            var s = "foo";
            QUnit.IsTrue(s is string);
            QUnit.IsTrue(!(s is int));
        }

        [Test]
        public void TestClass()
        {
            var o = new MyClass();
            QUnit.IsTrue(o is MyClass);
            QUnit.IsTrue(o is object);
            QUnit.IsTrue(!(o is string));
        }
/*
Primitives like this are going to require more work         
        [Js(Inline = true)]
        public void Int()
        {
            QUnit.RunTest("IsExpressionTests.Int", () =>
            {
                var i = 5;
                QUnit.IsTrue(i is int);
                QUnit.IsTrue(!(i is string));
            });
        }
*/
 
        public class MyClass {}
    }
}
