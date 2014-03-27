namespace System.Runtime.CompilerServices
{
    public interface IAsyncStateMachine
    {
        /// <summary>
        ///     Moves the state machine to its next state.
        /// </summary>
        void MoveNext();

        /// <summary>
        ///     Configures the state machine with a heap-allocated replica.
        /// </summary>
        /// <param name="stateMachine">The heap-allocated replica.</param>
        void SetStateMachine(IAsyncStateMachine stateMachine);
    }
}