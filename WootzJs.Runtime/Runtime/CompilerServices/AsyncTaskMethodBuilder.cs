using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    ///     Represents a builder for asynchronous methods that return a task and provides a parameter for the result.
    /// </summary>
    /// <typeparam name="TResult">The result to use to complete the task.</typeparam>
    public struct AsyncTaskMethodBuilder<TResult> : IAsyncMethodBuilder
    {
//        internal static readonly Task<TResult> s_defaultResultTask =
//            AsyncTaskCache.CreateCacheableTask<TResult>(default (TResult));

        private AsyncMethodBuilderCore m_coreState;
        private Task<TResult> m_task;

        static AsyncTaskMethodBuilder()
        {
        }

        /// <summary>
        ///     Gets the task for this builder.
        /// </summary>
        /// <returns>
        ///     The task for this builder.
        /// </returns>
        public Task<TResult> Task
        {
            get
            {
                Task<TResult> task = m_task;
                if (task == null)
                    m_task = task = new Task<TResult>();
                return task;
            }
        }

        void IAsyncMethodBuilder.PreBoxInitialization()
        {
            Task<TResult> task = Task;
        }

        /// <summary>
        ///     Creates an instance of the <see cref="T:System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1" /> class.
        /// </summary>
        /// <returns>
        ///     A new instance of the builder.
        /// </returns>
        public static AsyncTaskMethodBuilder<TResult> Create()
        {
            return new AsyncTaskMethodBuilder<TResult>();
        }

        /// <summary>
        ///     Begins running the builder with the associated state machine.
        /// </summary>
        /// <param name="stateMachine">The state machine instance, passed by reference.</param>
        /// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="stateMachine" /> is null.</exception>
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            m_coreState.Start(ref stateMachine);
        }

        /// <summary>
        ///     Associates the builder with the specified state machine.
        /// </summary>
        /// <param name="stateMachine">The state machine instance to associate with the builder.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="stateMachine" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The state machine was previously set.</exception>
        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            m_coreState.SetStateMachine(stateMachine);
        }

        /// <summary>
        ///     Schedules the state machine to proceed to the next action when the specified awaiter completes.
        /// </summary>
        /// <param name="awaiter">The awaiter.</param>
        /// <param name="stateMachine">The state machine.</param>
        /// <typeparam name="TAwaiter">The type of the awaiter.</typeparam>
        /// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            try
            {
                Action completionAction =
                    m_coreState.GetCompletionAction(this, stateMachine);
                awaiter.OnCompleted(completionAction);
            }
            catch (Exception ex)
            {
                AsyncMethodBuilderCore.ThrowAsync(ex);
            }
        }

        /// <summary>
        ///     Schedules the state machine to proceed to the next action when the specified awaiter completes. This method can be
        ///     called from partially trusted code.
        /// </summary>
        /// <param name="awaiter">The awaiter.</param>
        /// <param name="stateMachine">The state machine.</param>
        /// <typeparam name="TAwaiter">The type of the awaiter.</typeparam>
        /// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            try
            {
                Action completionAction =
                    m_coreState.GetCompletionAction(this, stateMachine);
                awaiter.UnsafeOnCompleted(completionAction);
            }
            catch (Exception ex)
            {
                AsyncMethodBuilderCore.ThrowAsync(ex, null);
            }
        }

        /// <summary>
        ///     Marks the task as successfully completed.
        /// </summary>
        /// <param name="result">The result to use to complete the task.</param>
        /// <exception cref="T:System.InvalidOperationException">The task has already completed.</exception>
        public void SetResult(TResult result)
        {
            Task<TResult> task = m_task;
            if (task == null)
                m_task = GetTaskForResult(result);
            else if (!task.TrySetResult(result))
                throw new InvalidOperationException(
                    "TaskT_TransitionToFinal_AlreadyCompleted");
        }

        internal void SetResult(Task<TResult> completedTask)
        {
            if (m_task == null)
                m_task = completedTask;
            else
                SetResult(default (TResult));
        }

        /// <summary>
        ///     Marks the task as failed and binds the specified exception to the task.
        /// </summary>
        /// <param name="exception">The exception to bind to the task.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="exception" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The task has already completed.</exception>
        public void SetException(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");
            Task<TResult> task = Task;
            var canceledException = exception as OperationCanceledException;
            if (
                !(canceledException != null
                    ? task.TrySetCanceled(canceledException.CancellationToken, (object) canceledException)
                    : task.TrySetException((object) exception)))
                throw new InvalidOperationException(
                    "TaskT_TransitionToFinal_AlreadyCompleted");
        }

        internal void SetNotificationForWaitCompletion(bool enabled)
        {
            Task.SetNotificationForWaitCompletion(enabled);
        }

/*
        private Task<TResult> GetTaskForResult(TResult result)
        {
            if (default (TResult) != null)
            {
                if (typeof (TResult) == typeof (bool))
                    return
                        JitHelpers.UnsafeCast<Task<TResult>>((bool) (object) result
                            ? (object) AsyncTaskCache.TrueTask
                            : (object) AsyncTaskCache.FalseTask);
                if (typeof (TResult) == typeof (int))
                {
                    var num = (int) (object) result;
                    if (num < 9 && num >= -1)
                        return JitHelpers.UnsafeCast<Task<TResult>>((object) AsyncTaskCache.Int32Tasks[num - -1]);
                }
                else if (typeof (TResult) == typeof (uint) && (int) (uint) (object) result == 0 ||
                         typeof (TResult) == typeof (byte) && (byte) (object) result == 0 ||
                         (typeof (TResult) == typeof (sbyte) && (sbyte) (object) result == 0 ||
                          typeof (TResult) == typeof (char) && (char) (object) result == 0) ||
                         (typeof (TResult) == typeof (Decimal) && new Decimal(0) == (Decimal) (object) result ||
                          typeof (TResult) == typeof (long) && 0L == (long) (object) result ||
                          (typeof (TResult) == typeof (ulong) && 0L == (long) (ulong) (object) result ||
                           typeof (TResult) == typeof (short) && (short) (object) result == 0)) ||
                         typeof (TResult) == typeof (ushort) && (ushort) (object) result == 0 ||
                         typeof (TResult) == typeof (IntPtr) && new IntPtr() == (IntPtr) (object) result ||
                         typeof (TResult) == typeof (UIntPtr) && new UIntPtr() == (UIntPtr) (object) result)
                    return s_defaultResultTask;
            }
            else if (result == null)
                return s_defaultResultTask;
            return new Task<TResult>(result);
        }
*/
    }
}