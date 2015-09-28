using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class NullPropagatingTests : TestFixture
    {
        [Test]
        public void NullFieldReturnInt()
        {
            NullPropagatingTestClass foo = null;
            var val = foo?.Field;
            AssertEquals(val, 0);
        }

        [Test]
        public void NullPropertyReturnInt()
        {
            NullPropagatingTestClass foo = null;
            var val = foo?.Property;
            AssertEquals(val, 0);
        }

        [Test]
        public void NullMethodNoParameters()
        {
            NullPropagatingTestClass foo = null;
            var val = foo?.MethodNoParameters();
            AssertEquals(val, 0);
        }

        [Test]
        public void NullMethodTwoParameters()
        {
            NullPropagatingTestClass foo = null;
            var val = foo?.MethodTwoParameters(1, 2);
            AssertEquals(val, 0);
        }

        [Test]
        public void NotNullFieldReturnInt()
        {
            NullPropagatingTestClass foo = new NullPropagatingTestClass();
            var val = foo?.Field;
            AssertEquals(val, 6);
        }

        [Test]
        public void NotNullPropertyReturnInt()
        {
            NullPropagatingTestClass foo = new NullPropagatingTestClass();
            var val = foo?.Property;
            AssertEquals(val, 7);
        }

        [Test]
        public void NotNullMethodNoParameters()
        {
            NullPropagatingTestClass foo = new NullPropagatingTestClass();
            var val = foo?.MethodNoParameters();
            AssertEquals(val, 5);
        }

        [Test]
        public void NotNullMethodTwoParameters()
        {
            NullPropagatingTestClass foo = new NullPropagatingTestClass();
            var val = foo?.MethodTwoParameters(1, 2);
            AssertEquals(val, 3);
        }

        private string field;

        [Test]
        public void NullPropagationUsingThis()
        {
            var list = new List<int>();
            list.Add(1);
            list?.Select(x => field = x.ToString()).ToArray();
            AssertEquals(field, "1");
        }

        class NullPropagatingTestClass
        {
            public int Field;
            public int Property { get; set; }

            public NullPropagatingTestClass()
            {
                Field = 6;
                Property = 7;
            }

            public int MethodNoParameters()
            {
                return 5;
            }                                          

            public int MethodTwoParameters(int a, int b)
            {
                return a + b;
            }
        }                                   
    }
}
