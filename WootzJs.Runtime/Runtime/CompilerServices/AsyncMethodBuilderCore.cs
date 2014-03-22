using System.Runtime.ExceptionServices;

namespace System.Runtime.CompilerServices
{
    internal class AsyncMethodBuilderCore
    {
        internal IAsyncStateMachine m_stateMachine;

        internal void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
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
            var moveNextRunner = new MoveNextRunner();
            Action action = moveNextRunner.Run;
            if (m_stateMachine == null)
            {
                builder.PreBoxInitialization();
                m_stateMachine = stateMachine;
                m_stateMachine.SetStateMachine(m_stateMachine);
            }
            moveNextRunner.m_stateMachine = m_stateMachine;
            return action;
        }

        internal static void ThrowAsync(Exception exception)
        {
            ExceptionDispatchInfo exceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception);
            exceptionDispatchInfo.Throw();
        }

        private sealed class MoveNextRunner
        {
            internal IAsyncStateMachine m_stateMachine;

            internal void Run()
            {
                m_stateMachine.MoveNext();
            }
        }
    }
}