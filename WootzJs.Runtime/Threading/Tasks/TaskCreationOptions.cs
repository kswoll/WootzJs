namespace System.Threading.Tasks
{
    /// <summary>
    ///     Specifies flags that control optional behavior for the creation and execution of tasks.
    /// </summary>
    [Flags]
    public enum TaskCreationOptions
    {
        None = 0,
        PreferFairness = 1,
        LongRunning = 2,
        AttachedToParent = 4,
        DenyChildAttach = 8,
        HideScheduler = 16,
    }
}