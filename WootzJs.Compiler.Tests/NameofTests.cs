using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class NameofTests : TestFixture
    {
        [Test]
        public void NameofParameter()
        {
            var name = MethodWithParameter("blah");
            AssertEquals(name, "parameter");
        }

        private string MethodWithParameter(string parameter)
        {
            var name = nameof(parameter);
            return name;
        }
    }
}
