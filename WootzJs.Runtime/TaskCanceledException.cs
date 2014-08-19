using System.Threading;

namespace System
{
    public class TaskCanceledException : OperationCanceledException
    {
        public TaskCanceledException(string message, CancellationToken cancellationToken) : base(message, cancellationToken)
        {
        }

        public TaskCanceledException(string message, Exception innerException, CancellationToken cancellationToken) : base(message, innerException, cancellationToken)
        {
        }

        public TaskCanceledException(string message) : base(message)
        {
        }

        public TaskCanceledException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public TaskCanceledException()
        {
        }

        public TaskCanceledException(CancellationToken cancellationToken) : base(cancellationToken)
        {
        }
    }
}