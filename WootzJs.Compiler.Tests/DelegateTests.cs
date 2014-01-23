using System;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class DelegateTests
    {
        [Test]
        public void SimpleLambda()
        {
            var myClass = new MyClass { Name = "foo" };
            var lambda = myClass.CreateLambda();
            var name = lambda();
            QUnit.AreEqual(name, "foo");
        }

        [Test]
        public void AnonymousMethod()
        {
            Func<string> lambda = delegate() { return "foo"; };
            var name = lambda();
            QUnit.AreEqual(name, "foo");
        }

        [Test]
        public void ModifyClosedVariable()
        {
            var i = 0; 
            var j = 0;
            Action action = () =>
            {
                i = 5;
                j = i;
            };
            action();
            QUnit.AreEqual(j, 5);
        }

        [Test]
        public void CastDelegate()
        {
            var i = 0;
            Action action = () =>
            {
                i = 5;
            };
            Delegate delgt = action;
            var action2 = (Action)delgt;
            action2();
            QUnit.AreEqual(i, 5);
        }

        public class MyClass
        {
            public string Name { get; set; }

            public Func<string> CreateLambda( )
            {
                return () => Name;
            }
        }
    }
}
