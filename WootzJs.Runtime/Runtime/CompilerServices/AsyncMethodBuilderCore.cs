using System.Runtime.ExceptionServices;

namespace System.Runtime.CompilerServices
{
    internal struct AsyncMethodBuilderCore
    {
        internal Action m_defaultContextAction;
        internal IAsyncStateMachine m_stateMachine;

        internal void Start(IAsyncStateMachine stateMachine) 
        {
            if (stateMachine == null)
                throw new ArgumentNullException("stateMachine");
            stateMachine.MoveNext();
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            if (stateMachine == null)
                throw new ArgumentNullException("stateMachine");
            if (m_stateMachine != null)
                throw new InvalidOperationException("AsyncMethodBuilder_InstanceNotInitialized");
            m_stateMachine = stateMachine;
        }

        internal Action GetCompletionAction<TMethodBuilder, TStateMachine>(TMethodBuilder builder,
            TStateMachine stateMachine) where TMethodBuilder : IAsyncMethodBuilder
            where TStateMachine : IAsyncStateMachine
        {
            if (m_stateMachine == null)
            {
                m_stateMachine = stateMachine;
            }
            Action action = m_stateMachine.MoveNext;
            return action;
        }

        internal static void ThrowAsync(Exception exception)
        {
            ExceptionDispatchInfo exceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception);
            exceptionDispatchInfo.Throw();
        }
    }
}