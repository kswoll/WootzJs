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

namespace System.Threading
{
    public class Task
    {
        /// <summary>
        /// Creates a continuation that executes asynchronously when the target <see cref="T:System.Threading.Tasks.Task"/> completes.
        /// </summary>
        /// 
        /// <returns>
        /// A new continuation <see cref="T:System.Threading.Tasks.Task"/>.
        /// </returns>
        /// <param name="continuationAction">An action to run when the <see cref="T:System.Threading.Tasks.Task"/> completes. When run, the delegate will be passed the completed task as an argument.</param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.CancellationTokenSource"/> that created <paramref name="cancellationToken"/> has already been disposed.</exception><exception cref="T:System.ArgumentNullException">The <paramref name="continuationAction"/> argument is null.</exception>
        public Task ContinueWith(Action<Task> continuationAction)
        {
            StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
            return this.ContinueWith(continuationAction, TaskScheduler.Current, new CancellationToken(), TaskContinuationOptions.None, ref stackMark);
        }
    }
}