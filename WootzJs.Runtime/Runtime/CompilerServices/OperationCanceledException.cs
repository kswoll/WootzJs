using System.Runtime.WootzJs;
using System.Threading;

namespace System.Runtime.CompilerServices
{
    [Js(Preserve = true)]
    public class OperationCanceledException : Exception
    {
        public CancellationToken CancellationToken { get; set; }
    }
}