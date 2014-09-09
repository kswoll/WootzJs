using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class SwitchStatementTests : TestFixture
    {
        [Test]
        public void Default()
        {
            var flag = false;
            switch (5)
            {
                default: 
                    flag = true;
                    break;
            }
            AssertTrue(flag);
        }
    }
}