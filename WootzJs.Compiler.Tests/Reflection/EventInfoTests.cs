using System;
using System.Linq;

namespace WootzJs.Compiler.Tests.Reflection
{
    [TestFixture]
    public class EventInfoTests
    {
        [Test]
        public void Name()
        {
            var events = typeof(EventClass).GetEvents();
            var staticEvent = events.Single(x => x.Name == "StaticEvent");
            var stringEvent = events.Single(x => x.Name == "StringEvent");

            QUnit.AreEqual(staticEvent.Name, "StaticEvent");
            QUnit.AreEqual(stringEvent.Name, "StringEvent");
        }

        public class EventClass
        {
            public static event Action StaticEvent;
            public event Action<string> StringEvent;
        }
    }
}