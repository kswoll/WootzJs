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

namespace System.Threading.Tasks
{
    public class Task
    {
        private bool isCompleted;
        private Action m_continuationObject;

        public bool IsCompleted
        {
            get { return isCompleted; }
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
        }
    }

    public class Task<TResult> : Task
    {
        private List<Exception> exceptions;
        internal TResult m_result;

        public Task()
        {
        }

        public Task(TResult mResult)
        {
            m_result = mResult;
        }

        internal bool TrySetException(object exceptionObject)
        {
            bool flag = false;
            if (!IsCompleted)
            {
                exceptions = exceptions ?? new List<Exception>();
                exceptions.Add(exceptionObject);
                this.Finish();
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
            if (!IsCompleted)
            {
                flag = true;
            }
            return flag;
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