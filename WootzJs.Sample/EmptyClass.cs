using System;
using System.Collections.Generic;
using System.Linq;

namespace WootzJs.Sample
{
    public class EmptyClass
    {
        private string MyObject { get; set; }

        private string foo;

        public string Foo
        {
            get
            {
                Func<IEnumerable<string>, Func<string, bool>, IEnumerable<string>> s = System.Linq.Enumerable.Where;
                return foo;
            }
            set { foo = value; }
        }
    }
}
