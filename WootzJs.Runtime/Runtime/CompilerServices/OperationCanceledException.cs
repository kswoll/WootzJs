using System.Threading;

namespace System.Runtime.CompilerServices
{
    public class OperationCanceledException : Exception
    {
        public CancellationToken CancellationToken { get; set; }
    }
}