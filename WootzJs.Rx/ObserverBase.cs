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

using System.Threading;

namespace System.Reactive
{
    /// <summary>
    /// Abstract base class for implementations of the IObserver&lt;T&gt; interface.
    /// </summary>
    /// <remarks>This base class enforces the grammar of observers where OnError and OnCompleted are terminal messages.</remarks>
    /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
    public abstract class ObserverBase<T> : IObserver<T>, IDisposable
    {
        private int isStopped;

        /// <summary>
        /// Creates a new observer in a non-stopped state.
        /// </summary>
        protected ObserverBase()
        {
            isStopped = 0;
        }

        /// <summary>
        /// Notifies the observer of a new element in the sequence.
        /// </summary>
        /// <param name="value">Next element in the sequence.</param>
        public void OnNext(T value)
        {
            if (isStopped == 0)
                OnNextCore(value);
        }

        /// <summary>
        /// Implement this method to react to the receival of a new element in the sequence.
        /// </summary>
        /// <param name="value">Next element in the sequence.</param>
        /// <remarks>This method only gets called when the observer hasn't stopped yet.</remarks>
        protected abstract void OnNextCore(T value);

        /// <summary>
        /// Notifies the observer that an exception has occurred.
        /// </summary>
        /// <param name="error">The error that has occurred.</param>
        /// <exception cref="ArgumentNullException"><paramref name="error"/> is null.</exception>
        public void OnError(Exception error)
        {
            if (error == null)
                throw new ArgumentNullException("error");

            if (Interlocked.Exchange(ref isStopped, 1) == 0)
            {
                OnErrorCore(error);
            }
        }

        /// <summary>
        /// Implement this method to react to the occurrence of an exception.
        /// </summary>
        /// <param name="error">The error that has occurred.</param>
        /// <remarks>This method only gets called when the observer hasn't stopped yet, and causes the observer to stop.</remarks>
        protected abstract void OnErrorCore(Exception error);

        /// <summary>
        /// Notifies the observer of the end of the sequence.
        /// </summary>
        public void OnCompleted()
        {
            if (Interlocked.Exchange(ref isStopped, 1) == 0)
            {
                OnCompletedCore();
            }
        }

        /// <summary>
        /// Implement this method to react to the end of the sequence.
        /// </summary>
        /// <remarks>This method only gets called when the observer hasn't stopped yet, and causes the observer to stop.</remarks>
        protected abstract void OnCompletedCore();

        /// <summary>
        /// Disposes the observer, causing it to transition to the stopped state.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Core implementation of IDisposable.
        /// </summary>
        /// <param name="disposing">true if the Dispose call was triggered by the IDisposable.Dispose method; false if it was triggered by the finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                isStopped = 1;
            }
        }

        internal bool Fail(Exception error)
        {
            if (Interlocked.Exchange(ref isStopped, 1) == 0)
            {
                OnErrorCore(error);
                return true;
            }

            return false;
        }
    }
}