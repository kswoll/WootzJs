using System.Threading;

namespace System
{
    public class OperationCanceledException : SystemException
    {
        public CancellationToken CancellationToken { get; private set; }

        public OperationCanceledException(string message, CancellationToken cancellationToken) : base(message)
        {
            CancellationToken = cancellationToken;
        }

        public OperationCanceledException(string message, Exception innerException, CancellationToken cancellationToken) : base(message, innerException)
        {
            CancellationToken = cancellationToken;
        }

        public OperationCanceledException(string message) : base(message)
        {
        }

        public OperationCanceledException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public OperationCanceledException()
        {
        }

        public OperationCanceledException(CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
        }
    }
}