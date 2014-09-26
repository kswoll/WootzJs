using System;
using System.Runtime.WootzJs;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class ConvertTests : TestFixture
    {
        [Test]
        public void ConvertNumberToInt()
        {
            var number = "5".As<JsObject>().FromJsonObject<int>();
            var i = (int)Convert.ChangeType(number, typeof(int));
            AssertEquals(i, 5);
        }

        [Test]
        public void ConvertNumberToLong()
        {
            var number = "523523223523525".As<JsObject>().FromJsonObject<long>();
            var i = (long)Convert.ChangeType(number, typeof(long));
            AssertEquals(i, (long)523523223523525);
        }
    }
}