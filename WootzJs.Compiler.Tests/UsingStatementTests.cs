using System;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class UsingStatementTests
    {
        [Test]
        public void SimpleUsing()
        {
            var foo = new Foo();
            using (foo)
            {
            }
            QUnit.IsTrue(foo.IsDisposed);
        }

        [Test]
        public void Declaration()
        {
            Foo _foo;
            using (var foo = new Foo())
            {
                _foo = foo;
            }
            QUnit.IsTrue(_foo.IsDisposed);
        }

        public class Foo : IDisposable
        {
            public bool IsDisposed;

            public void Dispose()
            {
                IsDisposed = true;
            }
        }
    }
}
