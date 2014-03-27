using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    ///     Provides an object that waits for the completion of an asynchronous task.
    /// </summary>
    public struct TaskAwaiter : ICriticalNotifyCompletion, INotifyCompletion
    {
        private readonly Task m_task;

        internal TaskAwaiter(Task task)
        {
            m_task = task;
        }

        public bool IsCompleted
        {
            get { return m_task.IsCompleted; }
        }

        public void OnCompleted(Action continuation)
        {
            m_task.SetContinuationForAwait(continuation);
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            m_task.SetContinuationForAwait(continuation);
        }

        public void GetResult()
        {
        }
    }

    public struct TaskAwaiter<TResult> : ICriticalNotifyCompletion, INotifyCompletion
    {
        private readonly Task<TResult> m_task;

        public TaskAwaiter(Task<TResult> mTask)
        {
            m_task = mTask;
        }

        public bool IsCompleted
        {
            get { return m_task.IsCompleted; }
        }

        public void OnCompleted(Action continuation)
        {
            m_task.SetContinuationForAwait(continuation);
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            m_task.SetContinuationForAwait(continuation);
        }

        public TResult GetResult()
        {
            return this.m_task.m_result;
        }
    }
}