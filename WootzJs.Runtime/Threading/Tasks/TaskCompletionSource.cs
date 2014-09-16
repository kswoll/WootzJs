using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace System.Threading.Tasks
{
    public class TaskCompletionSource<TResult>
    {
        private readonly Task<TResult> m_task;

        /// <summary>
        /// Creates a <see cref="T:System.Threading.Tasks.TaskCompletionSource`1" />.
        /// </summary>
        public TaskCompletionSource()
        {
            m_task = new Task<TResult>();
        }

        /// <summary>
        /// Gets the <see cref="T:System.Threading.Tasks.Task`1" /> created by this
        /// <see cref="T:System.Threading.Tasks.TaskCompletionSource`1" />.
        /// </summary>
        /// <returns>
        /// Returns the <see cref="T:System.Threading.Tasks.Task`1" /> created by this
        /// <see cref="T:System.Threading.Tasks.TaskCompletionSource`1" />.
        /// </returns>
        public Task<TResult> Task
        {
            get { return m_task; }
        }

        /// <summary>
        /// Attempts to transition the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" /> state.
        /// </summary>
        /// <returns>
        /// True if the operation was successful; otherwise, false.
        /// </returns>
        /// <param name="exception">The exception to bind to this <see cref="T:System.Threading.Tasks.Task`1" />.</param>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The
        /// <see cref="P:System.Threading.Tasks.TaskCompletionSource`1.Task" /> was disposed.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="exception" /> argument is null.</exception>
        public bool TrySetException(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");
            return m_task.TrySetException(exception);
        }

        /// <summary>
        /// Attempts to transition the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" /> state.
        /// </summary>
        /// <returns>
        /// True if the operation was successful; otherwise, false.
        /// </returns>
        /// <param name="exceptions">The collection of exceptions to bind to this <see cref="T:System.Threading.Tasks.Task`1" />.</param>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The
        /// <see cref="P:System.Threading.Tasks.TaskCompletionSource`1.Task" /> was disposed.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="exceptions" /> argument is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        /// There are one or more null elements in <paramref name="exceptions" />
        /// .-or-The <paramref name="exceptions" /> collection is empty.
        /// </exception>
        public bool TrySetException(IEnumerable<Exception> exceptions)
        {
            if (exceptions == null)
                throw new ArgumentNullException("exceptions");
            var list = new List<Exception>();
            foreach (Exception exception in exceptions)
            {
                if (exception == null)
                    throw new ArgumentException("exception");
                list.Add(exception);
            }
            if (list.Count == 0)
                throw new ArgumentException("exceptions");
            return m_task.TrySetException(list.Single());
        }

/*
        internal bool TrySetException(IEnumerable<ExceptionDispatchInfo> exceptions)
        {
            return m_task.TrySetException(exceptions.First());
        }
*/

        /// <summary>
        /// Transitions the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" /> state.
        /// </summary>
        /// <param name="exception">The exception to bind to this <see cref="T:System.Threading.Tasks.Task`1" />.</param>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The
        /// <see cref="P:System.Threading.Tasks.TaskCompletionSource`1.Task" /> was disposed.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="exception" /> argument is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">
        /// The underlying <see cref="T:System.Threading.Tasks.Task`1" /> is
        /// already in one of the three final states: <see cref="F:System.Threading.Tasks.TaskStatus.RanToCompletion" />,
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" />, or
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" />.
        /// </exception>
        public void SetException(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");
            if (!TrySetException(exception))
                throw new InvalidOperationException("TaskT_TransitionToFinal_AlreadyCompleted");
        }

        /// <summary>
        /// Transitions the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" /> state.
        /// </summary>
        /// <param name="exceptions">The collection of exceptions to bind to this <see cref="T:System.Threading.Tasks.Task`1" />.</param>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The
        /// <see cref="P:System.Threading.Tasks.TaskCompletionSource`1.Task" /> was disposed.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="exceptions" /> argument is null.</exception>
        /// <exception cref="T:System.ArgumentException">There are one or more null elements in <paramref name="exceptions" />.</exception>
        /// <exception cref="T:System.InvalidOperationException">
        /// The underlying <see cref="T:System.Threading.Tasks.Task`1" /> is
        /// already in one of the three final states: <see cref="F:System.Threading.Tasks.TaskStatus.RanToCompletion" />,
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" />, or
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" />.
        /// </exception>
        public void SetException(IEnumerable<Exception> exceptions)
        {
            if (!TrySetException(exceptions))
                throw new InvalidOperationException("TaskT_TransitionToFinal_AlreadyCompleted");
        }

        /// <summary>
        /// Attempts to transition the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the
        /// <see cref="F:System.Threading.Tasks.TaskStatus.RanToCompletion" /> state.
        /// </summary>
        /// <returns>
        /// True if the operation was successful; otherwise, false.
        /// </returns>
        /// <param name="result">The result value to bind to this <see cref="T:System.Threading.Tasks.Task`1" />.</param>
        public bool TrySetResult(TResult result)
        {
            return m_task.TrySetResult(result);
        }

        /// <summary>
        /// Transitions the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the
        /// <see cref="F:System.Threading.Tasks.TaskStatus.RanToCompletion" /> state.
        /// </summary>
        /// <param name="result">The result value to bind to this <see cref="T:System.Threading.Tasks.Task`1" />.</param>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The
        /// <see cref="P:System.Threading.Tasks.TaskCompletionSource`1.Task" /> was disposed.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException">
        /// The underlying <see cref="T:System.Threading.Tasks.Task`1" /> is
        /// already in one of the three final states: <see cref="F:System.Threading.Tasks.TaskStatus.RanToCompletion" />,
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" />, or
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" />.
        /// </exception>
        public void SetResult(TResult result)
        {
            if (!TrySetResult(result))
                throw new InvalidOperationException("TaskT_TransitionToFinal_AlreadyCompleted");
        }

        /// <summary>
        /// Attempts to transition the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" /> state.
        /// </summary>
        /// <returns>
        /// True if the operation was successful; false if the operation was unsuccessful or the object has already been
        /// disposed.
        /// </returns>
        public bool TrySetCanceled()
        {
            return TrySetCanceled(new CancellationToken());
        }

        internal bool TrySetCanceled(CancellationToken tokenToRecord)
        {
            return m_task.TrySetCanceled(tokenToRecord);
        }

        /// <summary>
        /// Transitions the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" /> state.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">
        /// The underlying <see cref="T:System.Threading.Tasks.Task`1" /> is
        /// already in one of the three final states: <see cref="F:System.Threading.Tasks.TaskStatus.RanToCompletion" />,
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" />, or
        /// <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" />, or if the underlying
        /// <see cref="T:System.Threading.Tasks.Task`1" /> has already been disposed.
        /// </exception>
        public void SetCanceled()
        {
            if (!TrySetCanceled())
                throw new InvalidOperationException("TaskT_TransitionToFinal_AlreadyCompleted");
        }
    }
}