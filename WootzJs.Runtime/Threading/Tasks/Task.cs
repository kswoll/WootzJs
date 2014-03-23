#region License

//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------

#endregion

using System.Collections.Generic;

namespace System.Threading.Tasks
{
    /// <summary>
    ///     Represents an asynchronous operation.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <see cref="Task" /> instances may be created in a variety of ways. The most common approach is by
    ///         using the Task type's <see cref="Factory" /> property to retrieve a
    ///         <see
    ///             cref="System.Threading.Tasks.TaskFactory" />
    ///         instance that can be used to create tasks for several
    ///         purposes. For example, to create a <see cref="Task" /> that runs an action, the factory's StartNew
    ///         method may be used:
    ///         <code> 
    ///  // C#
    ///  var t = Task.Factory.StartNew(() => DoAction());
    /// 
    ///  ' Visual Basic 
    ///  Dim t = Task.Factory.StartNew(Function() DoAction())
    ///  </code>
    ///     </para>
    ///     <para>
    ///         The <see cref="Task" /> class also provides constructors that initialize the Task but that do not
    ///         schedule it for execution. For performance reasons, TaskFactory's StartNew method should be the
    ///         preferred mechanism for creating and scheduling computational tasks, but for scenarios where creation
    ///         and scheduling must be separated, the constructors may be used, and the task's <see cref="Start()" />
    ///         method may then be used to schedule the task for execution at a later time.
    ///     </para>
    ///     <para>
    ///         All members of <see cref="Task" />, except for <see cref="Dispose()" />, are thread-safe
    ///         and may be used from multiple threads concurrently.
    ///     </para>
    ///     <para>
    ///         For operations that return values, the <see cref="System.Threading.Tasks.Task{TResult}" /> class
    ///         should be used.
    ///     </para>
    ///     <para>
    ///         For developers implementing custom debuggers, several internal and private members of Task may be
    ///         useful (these may change from release to release). The Int32 m_taskId field serves as the backing
    ///         store for the <see cref="Id" /> property, however accessing this field directly from a debugger may be
    ///         more efficient than accessing the same value through the property's getter method (the
    ///         s_taskIdCounter Int32 counter is used to retrieve the next available ID for a Task). Similarly, the
    ///         Int32 m_stateFlags field stores information about the current lifecycle stage of the Task,
    ///         information also accessible through the <see cref="Status" /> property. The m_action System.Object
    ///         field stores a reference to the Task's delegate, and the m_stateObject System.Object field stores the
    ///         async state passed to the Task by the developer. Finally, for debuggers that parse stack frames, the
    ///         InternalWait method serves a potential marker for when a Task is entering a wait operation.
    ///     </para>
    /// </remarks>
    public class Task : IDisposable
    {
        private const int OptionsMask = 0xFFFF; // signifies the Options portion of m_stateFlags 
        internal const int TASK_STATE_STARTED = 0x10000;
        internal const int TASK_STATE_DELEGATE_INVOKED = 0x20000;
        internal const int TASK_STATE_DISPOSED = 0x40000;
        internal const int TASK_STATE_EXCEPTIONOBSERVEDBYPARENT = 0x80000;
        internal const int TASK_STATE_CANCELLATIONACKNOWLEDGED = 0x100000;
        internal const int TASK_STATE_FAULTED = 0x200000;
        internal const int TASK_STATE_CANCELED = 0x400000;
        internal const int TASK_STATE_WAITING_ON_CHILDREN = 0x800000;
        internal const int TASK_STATE_RAN_TO_COMPLETION = 0x1000000;
        internal const int TASK_STATE_WAITINGFORACTIVATION = 0x2000000;
        internal const int TASK_STATE_COMPLETION_RESERVED = 0x4000000;
        internal const int TASK_STATE_THREAD_WAS_ABORTED = 0x8000000;
        internal readonly Task m_parent; // A task's parent, or null if parent-less.
        internal object m_action; // The body of the task.  Might be Action<object>, Action<TState> or Action.
//        private ManualResetEventSlim m_completionEvent; // Lazily created if waiting is required.
        internal ContingentProperties m_contingentProperties;
        internal int m_stateFlags;

        /// <summary>
        ///     Gets whether this <see cref="Task">Task</see> has completed.
        /// </summary>
        /// <remarks>
        ///     <see cref="IsCompleted" /> will return true when the Task is in one of the three
        ///     final states: <see cref="System.Threading.Tasks.TaskStatus.RanToCompletion">RanToCompletion</see>,
        ///     <see cref="System.Threading.Tasks.TaskStatus.Faulted">Faulted</see>, or
        ///     <see cref="System.Threading.Tasks.TaskStatus.Canceled">Canceled</see>.
        /// </remarks>
        public bool IsCompleted
        {
            get
            {
                return ((m_stateFlags & (TASK_STATE_CANCELED | TASK_STATE_FAULTED | TASK_STATE_RAN_TO_COMPLETION)) != 0);
            }
        }

        /// <summary> 
        /// Adds an exception to the list of exceptions this task has thrown.
        /// </summary> 
        /// <param name="exceptionObject">An object representing either an Exception or a collection of Exceptions.</param> 
        internal void AddException(object exceptionObject)
        { 
            //
            // WARNING: A great deal of care went into insuring that
            // AddException() and GetExceptions() are never called
            // simultaneously.  See comment at start of GetExceptions(). 
            //
 
            // Lazily initialize the list, ensuring only one thread wins. 
            LazyInitializer.EnsureInitialized<ContingentProperties>(ref m_contingentProperties, s_contingentPropertyCreator);
            if (m_contingentProperties.m_exceptionsHolder == null) 
            {
                TaskExceptionHolder holder = new TaskExceptionHolder(this);
                if (Interlocked.CompareExchange(
                    ref m_contingentProperties.m_exceptionsHolder, holder, null) != null) 
                {
                    // If we lost the ----, suppress finalization. 
                    holder.MarkAsHandled(false); 
                }
            } 

            // Figure this out before your enter the lock.
            m_contingentProperties.m_exceptionsHolder.Add(exceptionObject);
        }

        /// <summary>
        ///     Gets whether the <see cref="Task" /> completed due to an unhandled exception.
        /// </summary>
        /// <remarks>
        ///     If <see cref="IsFaulted" /> is true, the Task's <see cref="Status" /> will be equal to
        ///     <see cref="System.Threading.Tasks.TaskStatus.Faulted">TaskStatus.Faulted</see>, and its
        ///     <see cref="Exception" /> property will be non-null.
        /// </remarks>
        public bool IsFaulted
        {
            get
            {
                // Faulted is "king" -- if that bit is present (regardless of other bits), we are faulted.
                return ((m_stateFlags & TASK_STATE_FAULTED) != 0);
            }
        }

        /// <summary>
        ///     Checks whether the TASK_STATE_EXCEPTIONOBSERVEDBYPARENT status flag is set,
        ///     This will only be used by the implicit wait to prevent double throws
        /// </summary>
        internal bool IsExceptionObservedByParent
        {
            get { return (m_stateFlags & TASK_STATE_EXCEPTIONOBSERVEDBYPARENT) != 0; }
        }

        /// <summary>
        ///     Disposes the <see cref="Task" />, releasing all of its unmanaged resources.
        /// </summary>
        /// <remarks>
        ///     Unlike most of the members of <see cref="Task" />, this method is not thread-safe.
        ///     Also, <see cref="Dispose()" /> may only be called on a <see cref="Task" /> that is in one of
        ///     the final states: <see cref="System.Threading.Tasks.TaskStatus.RanToCompletion">RanToCompletion</see>,
        ///     <see cref="System.Threading.Tasks.TaskStatus.Faulted">Faulted</see>, or
        ///     <see cref="System.Threading.Tasks.TaskStatus.Canceled">Canceled</see>.
        /// </remarks>
        /// <exception cref="T:System.InvalidOperationException">
        ///     The exception that is thrown if the <see cref="Task" /> is not in
        ///     one of the final states: <see cref="System.Threading.Tasks.TaskStatus.RanToCompletion">RanToCompletion</see>,
        ///     <see cref="System.Threading.Tasks.TaskStatus.Faulted">Faulted</see>, or
        ///     <see cref="System.Threading.Tasks.TaskStatus.Canceled">Canceled</see>.
        /// </exception>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        ///     Creates a continuation that executes asynchronously when the target <see cref="T:System.Threading.Tasks.Task" />
        ///     completes.
        /// </summary>
        /// <returns>
        ///     A new continuation <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        /// <param name="continuationAction">
        ///     An action to run when the <see cref="T:System.Threading.Tasks.Task" /> completes. When
        ///     run, the delegate will be passed the completed task as an argument.
        /// </param>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     The <see cref="T:System.Threading.CancellationTokenSource" /> that
        ///     created <paramref name="cancellationToken" /> has already been disposed.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="continuationAction" /> argument is null.</exception>
        public Task ContinueWith(Action<Task> continuationAction)
        {
            return null;
//            StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
//            return this.ContinueWith(continuationAction, TaskScheduler.Current, new CancellationToken(), TaskContinuationOptions.None, ref stackMark);
        }

        /// <summary>
        ///     Disposes the <see cref="Task" />, releasing all of its unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        ///     A Boolean value that indicates whether this method is being called due to a call to
        ///     <see
        ///         cref="Dispose()" />
        ///     .
        /// </param>
        /// <remarks>
        ///     Unlike most of the members of <see cref="Task" />, this method is not thread-safe.
        /// </remarks>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Task must be completed to dispose
                if (!IsCompleted)
                {
                    throw new InvalidOperationException("Task_Dispose_NotCompleted");
                }

/*
                var tmp = m_completionEvent; // make a copy to protect against racing Disposes. 

                // Dispose of the underlying completion event
                if (tmp != null)
                {
                    // In the unlikely event that our completion event is inflated but not yet signaled,
                    // go ahead and signal the event.  If you dispose of an unsignaled MRES, then any waiters 
                    // will deadlock; an ensuing Set() will not wake them up.  In the event of an AppDomainUnload, 
                    // there is no guarantee that anyone else is going to signal the event, and it does no harm to
                    // call Set() twice on m_completionEvent. 
                    if (!tmp.IsSet) tmp.Set();

                    tmp.Dispose();
                    m_completionEvent = null;
                }
*/
            }

            // We OR the flags to indicate the object has been disposed.  This is not 
            // thread-safe -- trying to dispose while a task is running can lead to corruption.
            // Do this regardless of the value of "disposing".
            m_stateFlags |= TASK_STATE_DISPOSED;
        }

        // Atomically OR-in newBits to m_stateFlags, while making sure that 
        // no illegalBits are set.  Returns true on success, false on failure.
        internal bool AtomicStateUpdate(int newBits, int illegalBits)
        {
            int oldFlags = 0;
            return AtomicStateUpdate(newBits, illegalBits, ref oldFlags);
        }

        internal bool AtomicStateUpdate(int newBits, int illegalBits, ref int oldFlags)
        {
            oldFlags = m_stateFlags;
            if ((oldFlags & illegalBits) != 0) return false;
            m_stateFlags = oldFlags | newBits;
            return true;
        }

        /// <summary>
        ///     Final stage of the task completion code path. Notifies the parent (if any) that another of its childre are done,
        ///     and runs continuations.
        ///     This function is only separated out from FinishStageTwo because these two operations are also needed to be called
        ///     from CancellationCleanupLogic()
        /// </summary>
        private void FinishStageThree()
        {
            // Notify parent if this was an attached task
            if (m_parent != null
                && (((TaskCreationOptions) (m_stateFlags & OptionsMask)) & TaskCreationOptions.AttachedToParent) != 0)
            {
                m_parent.ProcessChildCompletion(this);
            }

            // Activate continuations (if any).
            FinishContinuations();

            // Need this to bound the memory usage on long/infinite continuation chains
            m_action = null;
        }

        // Atomically mark a Task as started while making sure that it is not canceled.
        internal bool MarkStarted()
        {
            return AtomicStateUpdate(TASK_STATE_STARTED, TASK_STATE_CANCELED | TASK_STATE_STARTED);
        }

        /// <summary>
        ///     Runs all of the continuations, as appropriate.
        /// </summary>
        private void FinishContinuations()
        {
            // Grab the list of continuations, and lock it to contend with concurrent adds.
            // At this point, IsCompleted == true, so those adding will either come before 
            // that and add a continuation under the lock (serializing before this), so we
            // will run it; or they will attempt to acquire the lock, get it, and then see the 
            // task is completed (serializing after this), and run it on their own. 
            List<TaskContinuation> continuations = (m_contingentProperties == null)
                ? null
                : m_contingentProperties.m_continuations;
            if (continuations != null)
            {
                lock (m_contingentProperties)
                {
                    // Ensure that all concurrent adds have completed. 
                }

                // skip synchronous execution of continuations if this tasks thread was aborted 
                bool bCanInlineContinuations = true;

                // Records earliest index of synchronous continuation.
                // A value of -1 means that no synchronous continuations were found.
                int firstSynchronousContinuation = -1;

                // Fire the asynchronous continuations first ... 
                // Go back-to-front to make the "firstSynchronousContinuation" logic simpler. 
                for (int i = continuations.Count - 1; i >= 0; i--)
                {
                    TaskContinuation tc = continuations[i];
                    // ContinuationActions, which execute synchronously, have a null scheduler
                    // Synchronous continuation tasks will have the ExecuteSynchronously option
                    firstSynchronousContinuation = i;
                }

                // ... and then fire the synchronous continuations (if there are any)
                if (firstSynchronousContinuation > -1)
                {
                    for (int i = firstSynchronousContinuation; i < continuations.Count; i++)
                    {
                        TaskContinuation tc = continuations[i];
                        // ContinuationActions, which execute synchronously, have a null scheduler
                        // Synchronous continuation tasks will have the ExecuteSynchronously option 
                        tc.Run(this, bCanInlineContinuations);
                    }
                }

                // Don't keep references to "spent" continuations 
                m_contingentProperties.m_continuations = null;
            }
        }

        /// <summary>
        ///     FinishStageTwo is to be executed as soon as we known there are no more children to complete.
        ///     It can happen i) either on the thread that originally executed this task (if no children were spawned, or they all
        ///     completed by the time this task's delegate quit)
        ///     ii) or on the thread that executed the last child.
        /// </summary>
        internal void FinishStageTwo()
        {
            AddExceptionsFromChildren();

            // At this point, the task is done executing and waiting for its children,
            // we can transition our task to a completion state.
            int completionState;
            if (ExceptionRecorded)
            {
                completionState = TASK_STATE_FAULTED;
            }
            else if (IsCancellationRequested && IsCancellationAcknowledged)
            {
                // We transition into the TASK_STATE_CANCELED final state if the task's CT was signalled for cancellation,
                // and the user delegate acknowledged the cancellation request by throwing an OCE,
                // and the task hasn't otherwise transitioned into faulted state. (TASK_STATE_FAULTED trumps TASK_STATE_CANCELED) 
                //
                // If the task threw an OCE without cancellation being requestsed (while the CT not being in signaled state), 
                // then we regard it as a regular exception 

                completionState = TASK_STATE_CANCELED;
            }
            else
            {
                completionState = TASK_STATE_RAN_TO_COMPLETION;
            }

            // Use Interlocked.Exchange() to effect a memory fence, preventing 
            // any SetCompleted() (or later) instructions from sneak back before it.
            Interlocked.Exchange(ref m_stateFlags, m_stateFlags | completionState);

            // Set the completion event if it's been lazy allocated.
            SetCompleted();

            // if we made a cancellation registration, it's now unnecessary.
            DeregisterCancellationCallback();

            // ready to run continuations and notify parent.
            FinishStageThree();
        }

        /// <summary>
        ///     Checks if we registered a CT callback during construction, and deregisters it.
        ///     This should be called when we know the registration isn't useful anymore. Specifically from Finish() if the task
        ///     has completed
        ///     successfully or with an exception.
        /// </summary>
        internal void DeregisterCancellationCallback()
        {
            if (m_contingentProperties != null &&
                m_contingentProperties.m_cancellationRegistration != null)
            {
                // Harden against ODEs thrown from disposing of the CTR.
                // Since the task has already been put into a final state by the time this
                // is called, all we can do here is suppress the exception.
                try
                {
                    m_contingentProperties.m_cancellationRegistration.Value.Dispose();
                }
                catch (ObjectDisposedException)
                {
                }

                m_contingentProperties.m_cancellationRegistration = null;
            }
        }

        /// <summary>
        ///     Sets the internal completion event.
        /// </summary>
        private void SetCompleted()
        {
/*
            ManualResetEventSlim mres = m_completionEvent;
            if (mres != null) 
            {
                mres.Set(); 
            } 
*/
        }

        /// <summary>
        ///     This is called by children of this task when they are completed.
        /// </summary>
        internal void ProcessChildCompletion(Task childTask)
        {
            // if the child threw and we haven't observed it we need to save it for future reference
            if (childTask.IsFaulted && !childTask.IsExceptionObservedByParent)
            {
                // Lazily initialize the child exception list
                if (m_contingentProperties.m_exceptionalChildren == null)
                {
                    Interlocked.CompareExchange(ref m_contingentProperties.m_exceptionalChildren, new List<Task>(), null);
                }

                // In rare situations involving AppDomainUnload, it's possible (though unlikely) for FinishStageTwo() to be called
                // multiple times for the same task.  In that case, AddExceptionsFromChildren() could be nulling m_exceptionalChildren 
                // out at the same time that we're processing it, resulting in a NullReferenceException here.  We'll protect 
                // ourselves by caching m_exceptionChildren in a local variable.
                List<Task> tmp = m_contingentProperties.m_exceptionalChildren;
                if (tmp != null)
                {
                    lock (tmp)
                    {
                        tmp.Add(childTask);
                    }
                }
            }

            if (--m_contingentProperties.m_completionCountdown == 0)
            {
                // This call came from the final child to complete, and apparently we have previously given up this task's right to complete itself. 
                // So we need to invoke the final finish stage.

                FinishStageTwo();
            }
        }

        internal class ContingentProperties
        {
            public Shared<CancellationTokenRegistration> m_cancellationRegistration;
            public CancellationToken m_cancellationToken;
            internal volatile int m_completionCountdown = 1; // # of active children + 1 (for this task itself). 
            // Used for ensuring all children are done before this task can complete
            // The extra count helps prevent the ---- for executing the final state transition 
            // (i.e. whether the last child or this task itself should call FinishStageTwo()) 

//            public TaskExceptionHolder m_exceptionsHolder; // Tracks exceptions, if any have occurred 

            // but haven't yet been waited on by the parent, lazily initialized.

            public List<TaskContinuation> m_continuations;
                // A list of tasks or actions to be started upon completion, lazily initialized.

            public List<Task> m_exceptionalChildren;
                // A list of child tasks that threw an exception (TCEs don't count),

            public volatile int m_internalCancellationRequested;
                // We keep canceled in its own field because threads legally ---- to set it.

            internal void SetCompleted()
            {
/*
                ManualResetEventSlim manualResetEventSlim = this.m_completionEvent;
                if (manualResetEventSlim == null)
                    return;
                manualResetEventSlim.Set();
*/
            }
        }
    }

    public class Task<TResult> : Task
    {
        internal TResult m_result;

        internal bool TrySetResult(TResult result)
        {
            if (this.IsCompleted || !this.AtomicStateUpdate(67108864, 90177536))
                return false;
            m_result = result;
            Interlocked.Exchange(ref this.m_stateFlags, this.m_stateFlags | 16777216);
            Task.ContingentProperties contingentProperties = this.m_contingentProperties;
            if (contingentProperties != null)
                contingentProperties.SetCompleted();
            this.FinishStageThree();
            return true;
        }

        internal bool TrySetException(object exceptionObject)
        {
            bool flag = false;
            this.EnsureContingentPropertiesInitialized(true);
            if (this.AtomicStateUpdate(67108864, 90177536))
            {
                this.AddException(exceptionObject);
                this.Finish(false);
                flag = true;
            }
            return flag;
        }

        internal bool TrySetCanceled(CancellationToken tokenToRecord)
        {
            return TrySetCanceled(tokenToRecord, null);
        }

        internal bool TrySetCanceled(CancellationToken tokenToRecord, object cancellationException)
        {
            bool flag = false;
            if (this.AtomicStateUpdate(67108864, 90177536))
            {
                this.RecordInternalCancellationRequest(tokenToRecord, cancellationException);
                this.CancellationCleanupLogic();
                flag = true;
            }
            return flag;
        }
    }

    internal class Shared<T>
    {
        internal T Value;

        internal Shared(T value)
        {
            Value = value;
        }
    }
}