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
    //
    // See AutoDetachObserver.cs for more information on the safeguarding requirement and
    // its implementation aspects.
    //

    /// <summary>
    /// This class fuses logic from ObserverBase, AnonymousObserver, and SafeObserver into one class. When an observer
    /// needs to be safeguarded, an instance of this type can be created by SafeObserver.Create when it detects its
    /// input is an AnonymousObserver, which is commonly used by end users when using the Subscribe extension methods
    /// that accept delegates for the On* handlers. By doing the fusion, we make the call stack depth shorter which
    /// helps debugging and some performance.
    /// </summary>
    class AnonymousSafeObserver<T> : IObserver<T>
    {
        private readonly Action<T> _onNext;
        private readonly Action<Exception> _onError;
        private readonly Action _onCompleted;
        private readonly IDisposable _disposable;

        private int isStopped;

        public AnonymousSafeObserver(Action<T> onNext, Action<Exception> onError, Action onCompleted, IDisposable disposable)
        {
            _onNext = onNext;
            _onError = onError;
            _onCompleted = onCompleted;
            _disposable = disposable;
        }

        public void OnNext(T value)
        {
            if (isStopped == 0)
            {
                var __noError = false;
                try
                {
                    _onNext(value);
                    __noError = true;
                }
                finally
                {
                    if (!__noError)
                        _disposable.Dispose();
                }
            }
        }

        public void OnError(Exception error)
        {
            if (Interlocked.Exchange(ref isStopped, 1) == 0)
            {
                try
                {
                    _onError(error);
                }
                finally
                {
                    _disposable.Dispose();
                }
            }
        }

        public void OnCompleted()
        {
            if (Interlocked.Exchange(ref isStopped, 1) == 0)
            {
                try
                {
                    _onCompleted();
                }
                finally
                {
                    _disposable.Dispose();
                }
            }
        }
    }
}