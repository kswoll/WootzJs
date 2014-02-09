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
    /// Base class for implementation of query operators, providing a lightweight sink that can be disposed to mute the outgoing observer.
    /// </summary>
    /// <typeparam name="TSource">Type of the resulting sequence's elements.</typeparam>
    /// <remarks>Implementations of sinks are responsible to enforce the message grammar on the associated observer. Upon sending a terminal message, a pairing Dispose call should be made to trigger cancellation of related resources and to mute the outgoing observer.</remarks>
    internal abstract class Sink<TSource> : IDisposable
    {
        protected internal volatile IObserver<TSource> _observer;
        private IDisposable _cancel;

        protected Sink(IObserver<TSource> observer, IDisposable cancel)
        {
            _observer = observer;
            _cancel = cancel;
        }

        public virtual void Dispose()
        {
            _observer = NopObserver<TSource>.Instance;

            var cancel = Interlocked.Exchange(ref _cancel, null);
            if (cancel != null)
            {
                cancel.Dispose();
            }
        }

        public IObserver<TSource> GetForwarder()
        {
            return new _(this);
        }

        class _ : IObserver<TSource>
        {
            private readonly Sink<TSource> _forward;

            public _(Sink<TSource> forward)
            {
                _forward = forward;
            }

            public void OnNext(TSource value)
            {
                _forward._observer.OnNext(value);
            }

            public void OnError(Exception error)
            {
                _forward._observer.OnError(error);
                _forward.Dispose();
            }

            public void OnCompleted()
            {
                _forward._observer.OnCompleted();
                _forward.Dispose();
            }
        }
    }
}