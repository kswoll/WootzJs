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
    /// Represents a disposable resource that only disposes its underlying disposable resource when all <see cref="GetDisposable">dependent disposable objects</see> have been disposed.
    /// </summary>
    public sealed class RefCountDisposable : ICancelable
    {
        private IDisposable _disposable;
        private bool _isPrimaryDisposed;
        private int _count;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Reactive.Disposables.RefCountDisposable"/> class with the specified disposable.
        /// </summary>
        /// <param name="disposable">Underlying disposable.</param>
        /// <exception cref="ArgumentNullException"><paramref name="disposable"/> is null.</exception>
        public RefCountDisposable(IDisposable disposable)
        {
            if (disposable == null)
                throw new ArgumentNullException("disposable");

            _disposable = disposable;
            _isPrimaryDisposed = false;
            _count = 0;
        }

        /// <summary>
        /// Gets a value that indicates whether the object is disposed.
        /// </summary>
        public bool IsDisposed
        {
            get { return _disposable == null; }
        }

        /// <summary>
        /// Returns a dependent disposable that when disposed decreases the refcount on the underlying disposable.
        /// </summary>
        /// <returns>A dependent disposable contributing to the reference count that manages the underlying disposable's lifetime.</returns>
        public IDisposable GetDisposable()
        {
            if (_disposable == null)
            {
                return Disposable.Empty;
            }
            else
            {
                _count++;
                return new InnerDisposable(this);
            }
        }

        /// <summary>
        /// Disposes the underlying disposable only when all dependent disposables have been disposed.
        /// </summary>
        public void Dispose()
        {
            var disposable = default(IDisposable);
            if (_disposable != null)
            {
                if (!_isPrimaryDisposed)
                {
                    _isPrimaryDisposed = true;

                    if (_count == 0)
                    {
                        disposable = _disposable;
                        _disposable = null;
                    }
                }
            }

            if (disposable != null)
                disposable.Dispose();
        }

        private void Release()
        {
            var disposable = default(IDisposable);
            if (_disposable != null)
            {
                _count--;

                Diagnostics.Debug.Assert(_count >= 0);

                if (_isPrimaryDisposed)
                {
                    if (_count == 0)
                    {
                        disposable = _disposable;
                        _disposable = null;
                    }
                }
            }

            if (disposable != null)
                disposable.Dispose();
        }

        sealed class InnerDisposable : IDisposable
        {
            private RefCountDisposable _parent;

            public InnerDisposable(RefCountDisposable parent)
            {
                _parent = parent;
            }

            public void Dispose()
            {
                var parent = Interlocked.Exchange(ref _parent, null);
                if (parent != null)
                    parent.Release();
            }
        }
    }
}