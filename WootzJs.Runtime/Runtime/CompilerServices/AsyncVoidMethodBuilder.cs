namespace System.Runtime.CompilerServices
{
    public struct AsyncVoidMethodBuilder : IAsyncMethodBuilder
    {
        private AsyncMethodBuilderCore m_coreState;

        /// <summary>
        ///     Creates an instance of the <see cref="T:System.Runtime.CompilerServices.AsyncVoidMethodBuilder" /> class.
        /// </summary>
        /// <returns>
        ///     A new instance of the builder.
        /// </returns>
        public static AsyncVoidMethodBuilder Create()
        {
            var result = new AsyncVoidMethodBuilder();
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

        public void SetResult()
        {
        }

        public void SetException(Exception exception)
        {
            AsyncMethodBuilderCore.ThrowAsync(exception);
        }
    }
}