using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class MethodTests
    {
        [Test]
        public void StaticMethod()
        {
            var s = ClassWithStaticMethods.S();
            QUnit.AreEqual(s, "foo");
        }
         
        [Test]
        public void ExtensionMethod()
        {
            var s = 5.MyExtension();
            QUnit.AreEqual(s, "5");
        }
         
        [Test]
        public void OutParameter()
        {
            string x;
            ClassWithStaticMethods.OutParameter(out x);
            QUnit.AreEqual(x, "foo");
        }         
         
        [Test]
        public void TwoOutParameters()
        {
            string x;
            string y;
            ClassWithStaticMethods.TwoOutParameters(out x, out y);
            QUnit.AreEqual(x, "foo1");
            QUnit.AreEqual(y, "foo2");
        }         
         
        [Test]
        public void RefParameter()
        {
            int x = 5;
            ClassWithStaticMethods.RefParameter(ref x);
            QUnit.AreEqual(x, 6);
        }         
         
        [Test]
        public void TwoRefParameters()
        {
            int x = 5;
            int y = 6;
            ClassWithStaticMethods.TwoRefParameters(ref x, ref y);
            QUnit.AreEqual(x, 6);
            QUnit.AreEqual(y, 12);
        }         
         
        [Test]
        public void RefAndOutParameter()
        {
            int x = 5;
            int y;
            ClassWithStaticMethods.RefAndOutParameter(ref x, out y);
            QUnit.AreEqual(x, 6);
            QUnit.AreEqual(y, 10);
        }         
         
        [Test]
        public void InterfaceMethod()
        {
            ITestInterface test = new TestImplementation();
            var s = test.Method();
            QUnit.AreEqual(s, "foo");
        }         
         
        [Test]
        public void CollisionImplementationBothExplicit()
        {
            var o = new CollisionImplementationBothExplicit();
            ITestInterface test = o;
            ITestInterface2 test2 = o;
            var s = test.Method();
            var s2 = test2.Method();
            QUnit.AreEqual(s, "ITestInterface");
            QUnit.AreEqual(s2, "ITestInterface2");
        }         
         
        [Test]
        public void CollisionImplementationOneExplicit()
        {
            var o = new CollisionImplementationOneExplicit();
            ITestInterface test = o;
            ITestInterface2 test2 = o;
            var s = test.Method();
            var s2 = test2.Method();
            QUnit.AreEqual(s, "ITestInterface");
            QUnit.AreEqual(s2, "ITestInterface2");
        }         
    }

    public static class ClassWithStaticMethods
    {
        public static string S()
        {
            return "foo";
        }

        public static string MyExtension(this int i)
        {
            return i.ToString();
        }

        public static void OutParameter(out string s)
        {
            s = "foo";
        }

        public static void TwoOutParameters(out string s1, out string s2)
        {
            s1 = "foo1";
            s2 = "foo2";
        }

        public static void RefParameter(ref int i)
        {
            i = i + 1;
        }

        public static void TwoRefParameters(ref int i, ref int j)
        {
            i = i + 1;
            j = j * 2;
        }

        public static void RefAndOutParameter(ref int i, out int j)
        {
            i = i + 1;
            j = 10;
        }
    }

    public interface ITestInterface
    {
        string Method();
    }

    public class TestImplementation : ITestInterface 
    {
        public string Method()
        {
            return "foo";
        }
    }

    public interface ITestInterface2
    {
        string Method();
    }

    public class CollisionImplementationBothExplicit : ITestInterface, ITestInterface2
    {
        string ITestInterface.Method()
        {
            return "ITestInterface";
        }

        string ITestInterface2.Method()
        {
            return "ITestInterface2";
        }
    }

    public class CollisionImplementationOneExplicit : ITestInterface, ITestInterface2
    {
        public string Method()
        {
            return "ITestInterface";
        }

        string ITestInterface2.Method()
        {
            return "ITestInterface2";
        }
    }
}
