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

namespace System.Reactive.Disposables
{
    /// <summary>
    /// Represents an Action-based disposable.
    /// </summary>
    internal sealed class AnonymousDisposable : ICancelable
    {
        private Action _dispose;

        /// <summary>
        /// Constructs a new disposable with the given action used for disposal.
        /// </summary>
        /// <param name="dispose">Disposal action which will be run upon calling Dispose.</param>
        public AnonymousDisposable(Action dispose)
        {
            Diagnostics.Debug.Assert(dispose != null);

            _dispose = dispose;
        }

        /// <summary>
        /// Gets a value that indicates whether the object is disposed.
        /// </summary>
        public bool IsDisposed
        {
            get { return _dispose == null; }
        }

        /// <summary>
        /// Calls the disposal action if and only if the current instance hasn't been disposed yet.
        /// </summary>
        public void Dispose()
        {
            var dispose = Interlocked.Exchange(ref _dispose, null);
            if (dispose != null)
            {
                dispose();
            }
        }
    }
}