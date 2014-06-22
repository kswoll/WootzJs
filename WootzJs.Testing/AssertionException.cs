using System;

namespace WootzJs.Testing
{
    public class AssertionException : Exception
    {
        private UnitTest test;

        public AssertionException(UnitTest test)
        {
            this.test = test;
            Init();
        }

        public AssertionException(UnitTest test, string message) : base(message)
        {
            this.test = test;
            Init();
        }

        public AssertionException(UnitTest test, string message, Exception innerException) : base(message, innerException)
        {
            this.test = test;
            Init();
        }

        private void Init()
        {
            test.Assertions.Add(new Assertion(AssertionStatus.Failed, Message));
        }
    }
}