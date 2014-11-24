using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class PartialClassTests : TestFixture
    {
        [Test]
        public void TwoPropertiesInner()
        {
            var partial = new InnerTwoPropertyPartial();
            partial.Property1 = "property1";
            partial.Property2 = "property2";
            AssertEquals(partial.Property1, "property1");
            AssertEquals(partial.Property2, "property2");
        }
        
        [Test]
        public void TwoPropertiesOuter()
        {
            var partial = new OuterTwoPropertyPartial();
            partial.Property1 = "property1";
            partial.Property2 = "property2";
            AssertEquals(partial.Property1, "property1");
            AssertEquals(partial.Property2, "property2");
        }

        public partial class InnerTwoPropertyPartial
        {
            public string Property1 { get; set; }
        }

        public partial class InnerTwoPropertyPartial
        {
            public string Property2 { get; set; }
        }

        [Test]
        public void PartialMethodNotImplemented()
        {
            var partial = new PartialMethodNotImplementedClass();
            AssertEquals(partial.Value, "initial");
        }

        public partial class PartialMethodNotImplementedClass
        {
            private string value = "initial";

            partial void Method();

            public PartialMethodNotImplementedClass()
            {
                Method();
            }

            public string Value
            {
                get { return value; }
            }
        }

        /// <summary>
        /// Required since we don't bother treating partial classes without multiple declarations specially
        /// at all.
        /// </summary>
        public partial class PartialMethodNotImplementedClass {}

        [Test]
        public void PartialMethodImplemented()
        {
            var partial = new PartialMethodImplementedClass();
            AssertEquals(partial.Value, "partial");
        }

        public partial class PartialMethodImplementedClass
        {
            private string value;

            partial void Method();

            public PartialMethodImplementedClass()
            {
                value = "initial";
                Method();
            }

            public string Value
            {
                get { return value; }
            }
        }

        /// <summary>
        /// Required since we don't bother treating partial classes without multiple declarations specially
        /// at all.
        /// </summary>
        public partial class PartialMethodImplementedClass
        {
            partial void Method()
            {
                value = "partial";
            }
        }

        [Test]
        public void MultipleFiles()
        {
            var value = PartialClass.Value;
            AssertEquals(value, "initialized");
        }

        [Test]
        public void MultipleFilesWithUsings()
        {
            var value = PartialClassWithUsings.Value;
            AssertEquals(value, "initialized");
        }
    }

    public partial class OuterTwoPropertyPartial
    {
        public string Property1 { get; set; }        
    }

    public partial class OuterTwoPropertyPartial
    {
        public string Property2 { get; set; }                
    }
}