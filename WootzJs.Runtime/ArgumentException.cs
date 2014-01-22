namespace System
{
    public class ArgumentException : Exception
    {
        public ArgumentException()
        {
        }

        public ArgumentException(string message) : base(message)
        {
        }

        public ArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}