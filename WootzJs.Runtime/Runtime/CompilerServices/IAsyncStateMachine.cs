namespace System.Runtime.CompilerServices
{
    public interface IAsyncStateMachine
    {
        /// <summary>
        ///     Moves the state machine to its next state.
        /// </summary>
        void MoveNext();

        /// <summary>
        ///     Never invoked.  This method exists because C# requires it to.
        /// </summary>
        void SetStateMachine(IAsyncStateMachine stateMachine);
    }
}