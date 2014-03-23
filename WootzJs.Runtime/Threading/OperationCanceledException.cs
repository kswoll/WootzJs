namespace System.Threading
{
    public class OperationCanceledException : Exception
    {
        private CancellationToken token;

        public OperationCanceledException(CancellationToken token)
        {
            this.token = token;
        }

        public OperationCanceledException(CancellationToken token, string message) : base(message)
        {
            this.token = token;
        }

        public OperationCanceledException(CancellationToken token, string message, Exception innerException) : base(message, innerException)
        {
            this.token = token;
        }

        public CancellationToken CancellationToken
        {
            get { return token; }
        }
    }
}