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
using System.Runtime.CompilerServices;
using System.Runtime.WootzJs;

namespace System.Threading.Tasks
{
    public class Task
    {
        protected bool isCompleted;
        protected bool isFaulted;
        protected Action m_continuationObject;
        private Exception exception;

        public bool IsCompleted
        {
            get { return isCompleted; }
        }

        public bool IsFaulted
        {
            get { return isFaulted; }
        }

        public static Task<TResult> FromResult<TResult>(TResult result)
        {
            return new Task<TResult>(result);
        }

        /// <summary>
        ///     Gets an awaiter used to await this <see cref="T:System.Threading.Tasks.Task" />.
        /// </summary>
        /// <returns>
        ///     An awaiter instance.
        /// </returns>
        public TaskAwaiter GetAwaiter()
        {
            return new TaskAwaiter(this);
        }

        public static Task Delay(int millisecondsDelay)
        {
            return Delay(millisecondsDelay, new CancellationToken());
        }

        public static Task Delay(int millisecondsDelay, CancellationToken cancellationToken)
        {
            var completionSource = new TaskCompletionSource<object>();
            var token = Jsni.setTimeout(
                () =>
                {
                    completionSource.SetResult(null);
                }, 
                millisecondsDelay);
            cancellationToken.Register(() =>
            {
                Jsni.clearTimeout(token);
                completionSource.TrySetCanceled(cancellationToken);
            });
            return completionSource.Task;
        }

        internal void SetContinuationForAwait(Action continuationAction)
        {
            if (IsCompleted)
                return;
            if (m_continuationObject != null)
                throw new Exception("Cannot add more than one continuation to a task");

            m_continuationObject = continuationAction;
        }

        internal void Finish()
        {
            isCompleted = true;
            if (m_continuationObject != null)
                m_continuationObject();
            else if (IsFaulted)
                ThrowIfExceptional(true);
        }

        public Task<TResult> ContinueWith<TResult>(Func<Task, TResult> continuationFunction) 
        { 
            if (isCompleted)
                return FromResult(continuationFunction(this));
            else if (m_continuationObject == null)
            {
                var result = new Task<TResult>();
                m_continuationObject = () => result.TrySetResult(continuationFunction(this));
                return result;
            }
            else
            {
                var result = new Task<TResult>();
                var oldContinuation = m_continuationObject;
                m_continuationObject = () =>
                {
                    oldContinuation();
                    result.TrySetResult(continuationFunction(this));
                };
                return result;
            }
        }

        public Task ContinueWith(Action<Task> continuationAction) 
        {
            if (isCompleted)
                continuationAction(this);
            else if (m_continuationObject == null)
                m_continuationObject = () => continuationAction(this);
            else
            {
                var oldContinuation = m_continuationObject;
                m_continuationObject = () =>
                {
                    oldContinuation();
                    continuationAction(this);
                };
            }
            return this;
        }

        internal void ThrowIfExceptional(bool includeTaskCanceledExceptions)
        { 
            Exception exception = GetExceptions(includeTaskCanceledExceptions); 
            if (exception != null)
            {
                throw exception; 
            }
        } 

        private Exception GetExceptions(bool includeTaskCanceledExceptions)
        {
            return exception;
        } 

        internal bool TrySetException(Exception exceptionObject)
        {
            bool flag = false;
            if (!IsCompleted)
            {
                exception = (Exception)exceptionObject;
                isFaulted = true;
                this.Finish();
                flag = true;
            }
            return flag;
        }

        internal bool TrySetCanceled(CancellationToken tokenToRecord)
        {
            return TrySetCanceled(tokenToRecord, new TaskCanceledException());
        }

        internal bool TrySetCanceled(CancellationToken tokenToRecord, object cancellationException)
        {
            bool flag = false;
            if (!IsCompleted)
            {
                TrySetException((Exception)cancellationException);
                flag = true;
            }
            return flag;
        }
    }

    public class Task<TResult> : Task
    {
        internal TResult m_result;

        public Task()
        {
        }

        public Task(TResult mResult)
        {
            m_result = mResult;
            isCompleted = true;
        }

        internal bool TrySetResult(TResult result)
        {
            if (IsCompleted)
                return false;
            m_result = result;
            Finish();
            return true;
        }

        /// <summary>
        ///     Gets an awaiter used to await this <see cref="T:System.Threading.Tasks.Task`1" />.
        /// </summary>
        /// <returns>
        ///     An awaiter instance.
        /// </returns>
        public new TaskAwaiter<TResult> GetAwaiter()
        {
            return new TaskAwaiter<TResult>(this);
        }

        /// <summary>
        /// Creates a continuation that executes asynchronously when the target <see cref="T:System.Threading.Tasks.Task`1"/> completes.
        /// </summary>
        /// 
        /// <returns>
        /// A new continuation <see cref="T:System.Threading.Tasks.Task"/>.
        /// </returns>
        /// <param name="continuationAction">An action to run when the <see cref="T:System.Threading.Tasks.Task`1"/> completes. When run, the delegate will be passed the completed task as an argument.</param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Tasks.Task`1"/> has been disposed.</exception><exception cref="T:System.ArgumentNullException">The <paramref name="continuationAction"/> argument is null.</exception>
        public Task ContinueWith(Action<Task<TResult>> continuationAction)
        {
            return base.ContinueWith(task => continuationAction(this));
        }

        /// <summary>
        /// Creates a continuation that executes asynchronously when the target <see cref="T:System.Threading.Tasks.Task`1"/> completes.
        /// </summary>
        /// 
        /// <returns>
        /// A new continuation <see cref="T:System.Threading.Tasks.Task`1"/>.
        /// </returns>
        /// <param name="continuationFunction">A function to run when the <see cref="T:System.Threading.Tasks.Task`1"/> completes. When run, the delegate will be passed the completed task as an argument.</param><typeparam name="TNewResult">The type of the result produced by the continuation.</typeparam><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Tasks.Task`1"/> has been disposed.</exception><exception cref="T:System.ArgumentNullException">The <paramref name="continuationFunction"/> argument is null.</exception>
        public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction)
        {
            var task = new Task<TNewResult>();
            if (IsCompleted)
                task.TrySetResult(continuationFunction(this));
            else if (m_continuationObject == null)
                m_continuationObject = () => task.TrySetResult(continuationFunction(this));
            else
            {
                var oldContinuation = m_continuationObject;
                m_continuationObject = () =>
                {
                    oldContinuation();
                    task.TrySetResult(continuationFunction(this));
                };
            }
            return task;
        }

        public TResult Result
        {
            get { return m_result; }
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