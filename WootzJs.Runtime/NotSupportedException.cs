namespace System
{
    public class NotSupportedException : Exception
    {
        public NotSupportedException()
        {
        }

        public NotSupportedException(string message) : base(message)
        {
        }

        public NotSupportedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}