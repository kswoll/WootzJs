using System;
using System.Threading;
using System.Threading.Tasks;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Threading
{
    public class TimerTests : TestFixture
    {
/*
        [Test]
        public async Task NoIntervalChange()
        {
            var fired = false;
            new Timer(x => fired = true).Change(20, 0);
            await Task.Delay(30);
            AssertTrue(fired);
        }

        [Test]
        public async Task NoIntervalConstructor()
        {
            var fired = false;
            new Timer(x => fired = true, null, 20, 0);
            await Task.Delay(30);
            AssertTrue(fired);
        }

        [Test]
        public async Task State()
        {
            var state = "foo";
            string newState = null;
            new Timer(x => newState = (string)x, state, 20, 0);
            await Task.Delay(30);
            AssertEquals(newState, "foo");
        }

        [Test]
        public async Task IntervalConstructor()
        {
            var counter = 0;
            Timer timer = null;
            timer = new Timer(x =>
            {
                if (counter < 2)
                    counter++;
                else 
                    timer.Stop();
            }, null, 10, 10);
            await Task.Delay(5000);
            AssertEquals(counter, 2);
        }
*/
    }
}