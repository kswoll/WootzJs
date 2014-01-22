namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class ConversionOperatorTests
    {
        [Test]
        public void Implicit()
        {
            ImplicitClass o = "foo";
            QUnit.AreEqual(o.Value, "foofoo");
        }

        [Test]
        public void Explicit()
        {
            var o = (ExplicitClass)"foo";
            QUnit.AreEqual(o.Value, "foofoo");
        }

        public class ImplicitClass
        {
            public string Value { get; private set; }

            public ImplicitClass(string value)
            {
                Value = value;
            }

            public static implicit operator ImplicitClass(string s)
            {
                return new ImplicitClass(s + s);
            }
        }

        public class ExplicitClass
        {
            public string Value { get; private set; }

            public ExplicitClass(string value)
            {
                Value = value;
            }

            public static explicit operator ExplicitClass(string s)
            {
                return new ExplicitClass(s + s);
            }
        }
    }
}
