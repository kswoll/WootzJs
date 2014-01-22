using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class VirtualMethodTests
    {
        [Test]
        public void Override()
        {
            var baseClass = new BaseClass();
            var subClass = new SubClass();
            BaseClass subClassAsBaseClass = subClass;
            QUnit.AreEqual(baseClass.Foo(), "base");
            QUnit.AreEqual(subClass.Foo(), "sub");
            QUnit.AreEqual(subClassAsBaseClass.Foo(), "sub");
        }
         
        class BaseClass
        {
            public virtual string Foo()
            {
                return "base";
            }
        }

        class SubClass : BaseClass
        {
            public override string Foo()
            {
                return "sub";
            }
        }
    }
}
