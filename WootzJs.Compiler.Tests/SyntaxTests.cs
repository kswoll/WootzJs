using System;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class SyntaxTests : TestFixture
    {
        [Test]
        public void EscapeIdentifier()
        {
            var @while = "hello";
            AssertEquals(@while, "hello");
        }

        [Test]
        public void EscapeParameter()
        {
            var @while = EscapeParameterMethod("foo");
            AssertEquals(@while, "foo");
        }

        public string EscapeParameterMethod(string @for)
        {
            return @for;
        }

        [Test]
        public void EscapeField()
        {
            var field = new EscapeFieldClass();
            field.@function = "bar";
            AssertEquals(field.function, "bar");
        }

        class EscapeFieldClass
        {
            public string function;
        }

        [Test]
        public void EscapeMethod()
        {
            var method = new EscapeMethodClass();
            AssertEquals(method.@for(), "function");
        }

        class EscapeMethodClass
        {
            public string @for()
            {
                return "function";
            }
        }

        [Test]
        public void EscapeProperty()
        {
            var property = new EscapePropertyClass();
            property.@for = "foo";
            AssertEquals(property.@for, "foo");
        }

        class EscapePropertyClass
        {
            public string @for { get; set; }
        }

        [Test]
        public void EscapeEvent()
        {
            var @event = new EscapeEventClass();
            @event.@while += x => x;
            var s = @event.Fire("bar");
            AssertEquals(s, "bar");
        }

        public class EscapeEventClass
        {
            public event Func<string, string> @while;

            public string Fire(string s)
            {
                if (@while != null)
                    return @while(s);
                return s;
            }
        }
        
        [Test]
        public void UnmatchedEscape()
        {
            var @function = "foo";
            AssertEquals(function, "foo");

            var test = "test";
            AssertEquals(@test, "test");
        }
    }
}