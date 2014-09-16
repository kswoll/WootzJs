using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class CharTests : TestFixture
    {
        [Test]
        public void PrependCharToString()
        {
            var s = "1";
            s = '0' + s;
            AssertEquals("01", s);
        }
    }
}