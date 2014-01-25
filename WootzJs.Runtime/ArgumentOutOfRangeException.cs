namespace System
{
    public class ArgumentOutOfRangeException : Exception
    {
        public ArgumentOutOfRangeException()
        {
        }

        public ArgumentOutOfRangeException(string message) : base(message)
        {
        }

        public ArgumentOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}