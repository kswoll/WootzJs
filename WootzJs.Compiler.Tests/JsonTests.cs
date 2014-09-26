using System.Runtime.WootzJs;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class JsonTests : TestFixture
    {
        [Test]
        public void Int()
        {
            var s = "5".As<JsObject>();
            int i = s.FromJsonObject<int>();
            AssertEquals(i, 5);
        }
    }
}