using System.Runtime.WootzJs;
using System.Text;

namespace WootzJs.Compiler.Tests.Text
{
    [TestFixture]
    public class StringBuilderTests
    {
        [Test]
        public void Append()
        {
            var builder = new StringBuilder();
            builder.Append('a');
            builder.Append("b");
            builder.AppendLine();
            builder.AppendLine('c');
            builder.AppendLine("d");
            QUnit.AreEqual(builder.ToString(), "ab\nc\nd\n");
        }
    }
}
