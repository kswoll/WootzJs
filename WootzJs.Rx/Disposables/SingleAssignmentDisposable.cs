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
    /// Represents a disposable resource which only allows a single assignment of its underlying disposable resource.
    /// If an underlying disposable resource has already been set, future attempts to set the underlying disposable resource will throw an <see cref="T:System.InvalidOperationException"/>.
    /// </summary>
    public sealed class SingleAssignmentDisposable : ICancelable
    {
        private IDisposable _current;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Reactive.Disposables.SingleAssignmentDisposable"/> class.
        /// </summary>
        public SingleAssignmentDisposable()
        {
        }

        /// <summary>
        /// Gets a value that indicates whether the object is disposed.
        /// </summary>
        public bool IsDisposed
        {
            get
            {
                // We use a sentinel value to indicate we've been disposed. This sentinel never leaks
                // to the outside world (see the Disposable property getter), so no-one can ever assign
                // this value to us manually.
                return _current == BooleanDisposable.True;
            }
        }

        /// <summary>
        /// Gets or sets the underlying disposable. After disposal, the result of getting this property is undefined.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the SingleAssignmentDisposable has already been assigned to.</exception>
        public IDisposable Disposable
        {
            get
            {
                var current = _current;

                if (current == BooleanDisposable.True)
                    return DefaultDisposable.Instance; // Don't leak the sentinel value.

                return current;
            }

            set
            {
#pragma warning disable 0420
                var old = Interlocked.CompareExchange(ref _current, value, null);
#pragma warning restore 0420
                if (old == null)
                    return;

                if (old != BooleanDisposable.True)
                    throw new InvalidOperationException("DISPOSABLE_ALREADY_ASSIGNED");

                if (value != null)
                    value.Dispose();
            }
        }

        /// <summary>
        /// Disposes the underlying disposable.
        /// </summary>
        public void Dispose()
        {
            var old = Interlocked.Exchange(ref _current, BooleanDisposable.True);
            if (old != null)
                old.Dispose();
        }
    }
}