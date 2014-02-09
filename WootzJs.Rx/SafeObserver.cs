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

namespace System.Reactive
{
    //
    // See AutoDetachObserver.cs for more information on the safeguarding requirement and
    // its implementation aspects.
    //

    class SafeObserver<TSource> : IObserver<TSource>
    {
        private readonly IObserver<TSource> _observer;
        private readonly IDisposable _disposable;

        public static IObserver<TSource> Create(IObserver<TSource> observer, IDisposable disposable)
        {
            var a = observer as AnonymousObserver<TSource>;
            if (a != null)
                return a.MakeSafe(disposable);
            else
                return new SafeObserver<TSource>(observer, disposable);
        }

        private SafeObserver(IObserver<TSource> observer, IDisposable disposable)
        {
            _observer = observer;
            _disposable = disposable;
        }

        public void OnNext(TSource value)
        {
            var __noError = false;
            try
            {
                _observer.OnNext(value);
                __noError = true;
            }
            finally
            {
                if (!__noError)
                    _disposable.Dispose();
            }
        }

        public void OnError(Exception error)
        {
            try
            {
                _observer.OnError(error);
            }
            finally
            {
                _disposable.Dispose();
            }
        }

        public void OnCompleted()
        {
            try
            {
                _observer.OnCompleted();
            }
            finally
            {
                _disposable.Dispose();
            }
        }
    }
}