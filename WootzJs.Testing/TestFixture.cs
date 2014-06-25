using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WootzJs.Testing
{
    public class TestFixture
    {
        private UnitTest unitTest;

        public void SetUnitTest(UnitTest unitTest)
        {
            this.unitTest = unitTest;
        }

        private UnitTest GetTest(string name)
        {
            return unitTest;
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
                
            var currentTest = GetTest(callerMemberName);
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
            var currentTest = GetTest(callerMemberName);
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