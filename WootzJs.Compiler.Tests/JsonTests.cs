using System;
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

        [Test]
        public void Enum()
        {
            var s = "Value1".As<JsObject>();
            TestEnum testEnum = s.FromJsonObject<TestEnum>();
            AssertEquals(testEnum, TestEnum.Value1);
        }

        [Test]
        public void NullableDateTime()
        {
            var o = new JsObject();
            o["MyDate"] = "2015-11-02T23:00:54.237".As<JsObject>();

            var obj = o.FromJsonObject<NullableDateTimeClass>();
            AssertEquals(54, obj.MyDate.Value.Second);
        }

        class NullableDateTimeClass
        {
            public DateTime? MyDate { get; set; }
        }

        enum TestEnum
        {
            Value1 = 1, 
            Value2 = 2
        }
    }
}