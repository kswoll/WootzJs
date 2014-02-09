namespace System.Reactive.Disposables
{
    /// <summary>
    /// Disposable resource with dipsosal state tracking.
    /// </summary>
    public interface ICancelable : IDisposable
    {
        /// <summary>
        /// Gets a value that indicates whether the object is disposed.
        /// </summary>
        bool IsDisposed { get; }
    }
}