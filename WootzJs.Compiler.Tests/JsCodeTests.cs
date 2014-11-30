using System;
using System.Runtime.WootzJs;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class JsCodeTests : TestFixture
    {
        [Test]
        public void ReturnFoo()
        {
            var result = CodeReturnsFoo();
            AssertEquals(result, "foo");
        }

        [Js(Code = "return 'foo';")]
        private extern string CodeReturnsFoo();

        [Test]
        public void ArrayConstructor()
        {
            // Results in:
            // var fakeArray = [];
            var fakeArray = new NativeArray();

            var length = fakeArray.As<Array>().Length;
            AssertEquals(length, 0);
        }

        private class NativeArray
        {
            [Js(Inline = "[]")]
            public NativeArray()
            {
            }
        }

        [Test]
        public void InlineMethod()
        {
            // Results in:
            // var result = 3 + 4;
            var result = CodeInlineMethod(3, 4);
            AssertEquals(result, 7);
        }

        [Js(Inline = "@x + @y")]
        private extern int CodeInlineMethod(int x, int y);

        [Test]
        public void InlineThis()
        {
            var thisClass = new ThisClass();
            var foo = thisClass.GetFoo();
            AssertEquals(foo, "foo");
        }

        private class ThisClass
        {
            private string foo = "foo";

            [Js(Inline = "@this.foo")]
            public extern string GetFoo();
        }

        // https://github.com/kswoll/WootzJs/issues/3
        public void GithubIssue3()
        {
            var sb = new StringBuilder();
            sb.Append("asdf");
            sb.AppendChar(90); // Z
            var s = sb.ToString();
            AssertEquals(s, "asdfZ");
        }

        [Js(Name = "Array", Export = false)]
        public class StringBuilder
        {
            [Js(Inline = "[]")]
            public StringBuilder()
            {
            }

            [Js(Inline = "@this.push(@s)")]
            public extern void Append(object s);

            [Js(Inline = "@this.push(String.fromCharCode(@i))")]
            public extern void AppendChar(int i);

            [Js(Inline = "@this.push('\\r\\n')")]
            public extern void AppendLine();

            [Js(Inline = "@this.join('')")]
            public extern override string ToString();
        }
/*
        Commented out since the warnings make the console noisy
        [Test]
        public void JsniCodeTest()
        {
            Test(0);
        }
*/

        private string GetFoo()
        {
            return "foo";
        }

        [Js(Name = "test")]
        private void Test(int x) 
        {
            Jsni.code("console.warn('test', x)");
            if (x > 10) 
            {
                Jsni.code("throw { value: x, data: this.GetFoo() }");
            }
            while (Jsni.code("x === 100").As<bool>()) { }
        }

        [Js(Name = "Array", Export = false)]
        public class FastList<T>
        {
            [Js(Inline = "[]")]
            public FastList()
            {
            }

            public int Count
            {
                [Js(Inline = "@this.length", Export = false)]
                get
                {
                    return 0;
                }
            }

            public extern string Foo
            {
                [Js(Inline = "@this.foo")]
                get;

                [Js(Inline = "@this.foo = @value")]
                set;
            }
        }

        [Test]
        public void FastListTest()
        {
            FastList<int> list = new FastList<int>();
            AssertEquals(list.Count, 0);

            list.Foo = "bar";
            AssertEquals(list.As<JsObject>().member("foo"), "bar");

            list.As<JsObject>().memberset("foo", "foobar");
            AssertEquals(list.Foo, "foobar");
        }

        [Test]
        public void MinimalAutoProperties()
        {
            var obj = new MinimalAutoPropertiesClass();
            obj.Foo = 5;
            var value = obj.As<JsObject>().member("Foo");
            AssertEquals(value, 5);
        }

        [Js(AreAutoPropertiesMinimized = true)]
        public class MinimalAutoPropertiesClass
        {
            public int Foo { get; set; }
        }
    }
}