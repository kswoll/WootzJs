using System;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests.Reflection
{
    [TestFixture]
    public class AssemblyTests
    {
        [Test]
        public void FullName()
        {
            var assembly = typeof(TestsApplication).Assembly;
            QUnit.AreEqual(assembly.FullName, "WootzJs.Compiler.Tests");
        }

        [Test]
        public void AllAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var mscorlib = assemblies[0];
            var tests = assemblies[1];

            QUnit.AreEqual(mscorlib.FullName, "mscorlib");
            QUnit.AreEqual(tests.FullName, "WootzJs.Compiler.Tests");
        }

        [Test]
        public void TypeByName()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies()[1];
            var type = assembly.GetType("WootzJs.Compiler.Tests.Reflection.AssemblyTests.TestClass");
            QUnit.IsTrue(type != null);
        }

        [Test]
        public void TypeByNameThrowsOnNotFound()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies()[1];
            try
            {
                var type = assembly.GetType("WootzJs.Compiler.Tests.Reflection.AssemblyTests.InvalidClass", true);
                QUnit.IsTrue(false);
            }
            catch (Exception e)
            {
                QUnit.IsTrue(true);
            }
        }

        [Test]
        public void TypeByNameIgnoreCase()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies()[1];
            var type = assembly.GetType("WOOTZJS.COMPILER.TESTS.REFLECTION.ASSEMBLYTESTS.TESTCLASS", false, true);
            QUnit.IsTrue(type != null);
        }
/*

        [Js(Inline = true)]
        public void GetTypes()
        {
            QUnit.RunTest("AssemblyTests.FullName", () =>
            {
                var assembly = typeof(TestsApplication).Assembly;
                QUnit.AreEqual(assembly.FullName, "WootzJs.Compiler.Tests");
            });
        }
*/

        public class TestClass
        {
        }
    }
}
