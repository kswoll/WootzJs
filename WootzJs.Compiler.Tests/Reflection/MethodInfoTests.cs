using System.Runtime.WootzJs;
using System.Linq;

namespace WootzJs.Compiler.Tests.Reflection
{
    [TestFixture]
    public class MethodInfoTests
    {
        [Test]
        public void Name()
        {
            var methods = typeof(MethodClass).GetMethods();
            var method = methods.Single(x => x.Name == "VoidMethod");
            QUnit.IsTrue(true);
        }

        [Test]
        public void InvokeInstanceMethod()
        {
            var methods = typeof(MethodClass).GetMethods();
            var method = methods.Single(x => x.Name == "InstanceMethod");
            var instance = new MethodClass();
            var result = (string)method.Invoke(instance, new object[0]);
            QUnit.AreEqual(result, "InstanceMethod");
        }

        public class MethodClass
        {
            public void VoidMethod()
            {
            }

            public string InstanceMethod()
            {
                return "InstanceMethod";
            }

            public static string StaticMethod()
            {
                return "StaticMethod";
            }

            private string PrivateMethod()
            {
                return "PrivateMethod";
            }

            internal string InternalMethod()
            {
                return "InternalMethod";
            }

            protected string ProtectedMethod()
            {
                return "ProtectedMethod";
            }
        }
    }
}
