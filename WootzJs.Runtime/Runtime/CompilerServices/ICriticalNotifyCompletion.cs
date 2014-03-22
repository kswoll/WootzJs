namespace System.Runtime.CompilerServices
{
    /// <summary>
    ///     Represents an awaiter that schedules continuations when an await operation completes.
    /// </summary>
    public interface ICriticalNotifyCompletion : INotifyCompletion
    {
        /// <summary>
        ///     Schedules the continuation action that's invoked when the instance completes.
        /// </summary>
        /// <param name="continuation">The action to invoke when the operation completes.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     The <paramref name="continuation" /> argument is null (Nothing in
        ///     Visual Basic).
        /// </exception>
        void UnsafeOnCompleted(Action continuation);
    }
}