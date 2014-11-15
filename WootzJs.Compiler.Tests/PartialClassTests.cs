using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class PartialClassTests : TestFixture
    {
        [Test]
        public void TwoProperties()
        {
            var partial = new InnerTwoPropertyPartial();
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