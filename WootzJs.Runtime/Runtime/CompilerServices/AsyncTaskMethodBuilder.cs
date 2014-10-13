using System.Runtime.InteropServices;
using System.Runtime.WootzJs;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    ///     Represents a builder for asynchronous methods that return a task.
    /// </summary>
    public struct AsyncTaskMethodBuilder : IAsyncMethodBuilder
    {
        private AsyncTaskMethodBuilder<VoidTaskResult> m_builder;

        /// <summary>
        ///     Gets the task for this builder.
        /// </summary>
        /// <returns>
        ///     The task for this builder.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The builder is not initialized.</exception>
        public Task Task
        {
            get { return m_builder.Task; }
        }

        /// <summary>
        ///     Creates an instance of the <see cref="T:System.Runtime.CompilerServices.AsyncTaskMethodBuilder" /> class.
        /// </summary>
        /// <returns>
        ///     A new instance of the builder.
        /// </returns>
        public static AsyncTaskMethodBuilder Create()
        {
            var result = new AsyncTaskMethodBuilder();
            result.m_builder = AsyncTaskMethodBuilder<VoidTaskResult>.Create();
            return result;
        }

        /// <summary>
        ///     Begins running the builder with the associated state machine.
        /// </summary>
        /// <param name="stateMachine">The state machine instance, passed by reference.</param>
        /// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="stateMachine" /> is null.</exception>
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            TrueStart(stateMachine);
        }

        public void TrueStart(IAsyncStateMachine stateMachine)
        {
            m_builder.Start(ref stateMachine);
        }


        /// <summary>
        ///     Associates the builder with the specified state machine.
        /// </summary>
        /// <param name="stateMachine">The state machine instance to associate with the builder.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="stateMachine" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The state machine was previously set.</exception>
        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            m_builder.SetStateMachine(stateMachine);
        }

        /// <summary>
        ///     Schedules the state machine to proceed to the next action when the specified awaiter completes.
        /// </summary>
        /// <param name="awaiter">The awaiter.</param>
        /// <param name="stateMachine">The state machine.</param>
        /// <typeparam name="TAwaiter">The type of the awaiter.</typeparam>
        /// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(TAwaiter awaiter, TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            m_builder.AwaitOnCompleted(awaiter, stateMachine);
        }

        /// <summary>
        ///     Marks the task as successfully completed.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The task has already completed.-or-The builder is not initialized.</exception>
        public void SetResult()
        {
            m_builder.SetResult(new VoidTaskResult());
        }

        /// <summary>
        ///     Marks the task as failed and binds the specified exception to the task.
        /// </summary>
        /// <param name="exception">The exception to bind to the task.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="exception" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The task has already completed.-or-The builder is not initialized.</exception>
        public void SetException(Exception exception)
        {
            m_builder.SetException(exception);
        }

        /// <summary>
        ///     Schedules the state machine to proceed to the next action when the specified awaiter completes.
        /// </summary>
        /// <param name="awaiter">The awaiter.</param>
        /// <param name="stateMachine">The state machine.</param>
        /// <typeparam name="TAwaiter">The type of the awaiter.</typeparam>
        /// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            m_builder.AwaitOnCompleted(awaiter, stateMachine);
        }

        /// <summary>
        ///     Schedules the state machine to proceed to the next action when the specified awaiter completes. This method can be
        ///     called from partially trusted code.
        /// </summary>
        /// <param name="awaiter">The awaiter.</param>
        /// <param name="stateMachine">The state machine.</param>
        /// <typeparam name="TAwaiter">The type of the awaiter.</typeparam>
        /// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            m_builder.AwaitOnCompleted(awaiter, stateMachine);
        }
    }

    /// <summary>
    ///     Represents a builder for asynchronous methods that return a task and provides a parameter for the result.
    /// </summary>
    /// <typeparam name="TResult">The result to use to complete the task.</typeparam>
    public struct AsyncTaskMethodBuilder<TResult> : IAsyncMethodBuilder
    {
        private AsyncMethodBuilderCore m_coreState;
        private Task<TResult> m_task;

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

        /// <summary>
        ///     Creates an instance of the <see cref="T:System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1" /> class.
        /// </summary>
        /// <returns>
        ///     A new instance of the builder.
        /// </returns>
        public static AsyncTaskMethodBuilder<TResult> Create()
        {
            var result = new AsyncTaskMethodBuilder<TResult>();
            result.m_coreState = new AsyncMethodBuilderCore();
            return result;
        }

        /// <summary>
        ///     Begins running the builder with the associated state machine.
        /// </summary>
        /// <param name="stateMachine">The state machine instance, passed by reference.</param>
        /// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="stateMachine" /> is null.</exception>
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            TrueStart(stateMachine);
        }

        public void TrueStart(IAsyncStateMachine stateMachine) 
        {
            m_coreState.Start(stateMachine);
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
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(TAwaiter awaiter, TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            try
            {
                Action completionAction = m_coreState.GetCompletionAction(this, stateMachine);
                awaiter.OnCompleted(completionAction);
            }
            catch (Exception ex)
            {
                AsyncMethodBuilderCore.ThrowAsync(ex);
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
                throw new InvalidOperationException("TaskT_TransitionToFinal_AlreadyCompleted");
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
            if (exception.As<JsObject>().member("GetType") == null)
                exception = new JsException(exception.As<JsError>());

            Task<TResult> task = Task;
            var canceledException = exception as OperationCanceledException;
            if (
                !(canceledException != null
                    ? task.TrySetCanceled(canceledException.CancellationToken, canceledException)
                    : task.TrySetException(exception)))
                throw (canceledException ?? exception);
        }

        private Task<TResult> GetTaskForResult(TResult result)
        {
            return new Task<TResult>(result);
        }

        /// <summary>
        ///     Schedules the state machine to proceed to the next action when the specified awaiter completes.
        /// </summary>
        /// <param name="awaiter">The awaiter.</param>
        /// <param name="stateMachine">The state machine.</param>
        /// <typeparam name="TAwaiter">The type of the awaiter.</typeparam>
        /// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            try
            {
                Action completionAction = m_coreState.GetCompletionAction(this, stateMachine);
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
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            try
            {
                Action completionAction = m_coreState.GetCompletionAction(this, stateMachine);
                awaiter.UnsafeOnCompleted(completionAction);
            }
            catch (Exception ex)
            {
                AsyncMethodBuilderCore.ThrowAsync(ex);
            }
        }
    }
}