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

namespace System.Reactive.Disposables
{
    /// <summary>
    /// Represents a disposable resource that can be checked for disposal status.
    /// </summary>
    public sealed class BooleanDisposable : ICancelable
    {
        // Keep internal! This is used as sentinel in other IDisposable implementations to detect disposal and
        // should never be exposed to user code in order to prevent users from swapping in the sentinel. Have
        // a look at the code in e.g. SingleAssignmentDisposable for usage patterns.
        internal static readonly BooleanDisposable True = new BooleanDisposable(true);

        private volatile bool _isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Reactive.Disposables.BooleanDisposable"/> class.
        /// </summary>
        public BooleanDisposable()
        {
        }

        private BooleanDisposable(bool isDisposed)
        {
            _isDisposed = isDisposed;
        }

        /// <summary>
        /// Gets a value that indicates whether the object is disposed.
        /// </summary>
        public bool IsDisposed
        {
            get { return _isDisposed; }
        }

        /// <summary>
        /// Sets the status to disposed, which can be observer through the <see cref="IsDisposed"/> property.
        /// </summary>
        public void Dispose()
        {
            _isDisposed = true;
        }
    }
}