using System;

namespace WootzJs.Testing
{
    public class Assertion
    {
        public AssertionStatus Status { get; set; } 
        public string Message { get; set; }
        public Exception Error { get; set; }

        public Assertion()
        {
            Status = AssertionStatus.Passed;
        }

        public Assertion(AssertionStatus status, string message)
        {
            Status = status;
            Message = message;
        }

        public Assertion(Exception error)
        {
            Status = AssertionStatus.Errored;
            Message = error.ToString();
            Error = error;
        }
    }
}