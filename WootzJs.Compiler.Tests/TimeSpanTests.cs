using System;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class TimeSpanTests : TestFixture
    {
        [Test]
        public void Hours()
        {
            var date1 = new DateTime(2014, 1, 1, 21, 10, 0);
            var date2 = new DateTime(2014, 1, 2, 6, 20, 0);
            var timespan = date2 - date1;
            AssertEquals(timespan.Hours, 9);
        }
        [Test]
        public void Minutes()
        {
            var date1 = new DateTime(2014, 1, 1, 21, 10, 0);
            var date2 = new DateTime(2014, 1, 2, 6, 20, 0);
            var timespan = date2 - date1;
            AssertEquals(timespan.Minutes, 10);
        }
    }
}