using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace WootzJs.Testing
{
    public class TestFixture
    {
        private Dictionary<string, UnitTest> tests = new Dictionary<string, UnitTest>();

        public TestFixture()
        {
            foreach (var method in GetType().GetMethods())
            {
                if (method.IsDefined(typeof(TestAttribute), false))
                {
                    tests[method.Name] = new UnitTest();
                }
            }
        }

//        public static UnitTest CurrentTest
//        {
//            get { return currentTest; }
//            internal set { currentTest = value; }
//        }

        public void AssertEquals(object actual, object expected, [CallerMemberName]string callerMemberName = null)
        {
            bool equal = actual == expected;
/*
            if (actual == null && expected != null || actual != null && expected == null)
                equal = false;
            else if (actual == null)
                equal = true;
            else if (actual is bool && expected is bool)
                equal = (bool)actual == (bool)expected;
            else
                equal = actual.Equals(expected);
*/
                
            var currentTest = tests[callerMemberName];
            if (!equal)
            {
                var exception = new AssertionException("Expected: " + expected + ", Found: " + actual);
                currentTest.Assertions.Add(new Assertion(AssertionStatus.Failed, exception.Message));
                throw exception;
            }
            else
            {
                currentTest.Assertions.Add(new Assertion());
            }
        }

        public void AssertTrue(bool actual, [CallerMemberName]string callerMemberName = null)
        {
            var currentTest = tests[callerMemberName];
            if (!actual)
            {
                var exception = new AssertionException("Expected true");
                currentTest.Assertions.Add(new Assertion(AssertionStatus.Failed, exception.Message));
                throw exception;
            }
            else
            {
                currentTest.Assertions.Add(new Assertion());
            }
        }
    }
}