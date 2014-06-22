using System.Collections.Generic;
using System.Reflection;

namespace WootzJs.Testing
{
    public class UnitTest
    {
        public object Instance { get; set; } 
        public MethodInfo Method { get; set; }

        public List<Assertion> Assertions { get; set; }

        public UnitTest()
        {
            Assertions = new List<Assertion>();
        }
    }
}