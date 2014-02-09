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
using System.Reactive.Disposables;

namespace System.Reactive.Subjects
{
    /// <summary>
    /// Represents an object that is both an observable sequence as well as an observer.
    /// Each notification is broadcasted to all subscribed observers.
    /// </summary>
    /// <typeparam name="T">The type of the elements processed by the subject.</typeparam>
    public sealed class Subject<T> : ISubject<T>, IDisposable
    {
        private IObserver<T> _observer;

        /// <summary>
        /// Creates a subject.
        /// </summary>
        public Subject()
        {
            _observer = NopObserver<T>.Instance;
        }

        /// <summary>
        /// Notifies all subscribed observers about the end of the sequence.
        /// </summary>
        public void OnCompleted()
        {
            IObserver<T> oldObserver;
            var newObserver = DoneObserver<T>.Completed;

            do
            {
                oldObserver = _observer;

                if (oldObserver == DisposedObserver<T>.Instance || oldObserver is DoneObserver<T>)
                    break;
#pragma warning disable 0420
            } while (Interlocked.CompareExchange(ref _observer, newObserver, oldObserver) != oldObserver);
#pragma warning restore 0420

            oldObserver.OnCompleted();
        }

        /// <summary>
        /// Notifies all subscribed observers about the specified exception.
        /// </summary>
        /// <param name="error">The exception to send to all currently subscribed observers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="error"/> is null.</exception>
        public void OnError(Exception error)
        {
            if (error == null)
                throw new ArgumentNullException("error");

            IObserver<T> oldObserver;
            var newObserver = new DoneObserver<T> { Exception = error };

            do
            {
                oldObserver = _observer;

                if (oldObserver == DisposedObserver<T>.Instance || oldObserver is DoneObserver<T>)
                    break;
#pragma warning disable 0420
            } while (Interlocked.CompareExchange(ref _observer, newObserver, oldObserver) != oldObserver);
#pragma warning restore 0420

            oldObserver.OnError(error);
        }

        /// <summary>
        /// Notifies all subscribed observers about the arrival of the specified element in the sequence.
        /// </summary>
        /// <param name="value">The value to send to all currently subscribed observers.</param>
        public void OnNext(T value)
        {
            _observer.OnNext(value);
        }

        /// <summary>
        /// Subscribes an observer to the subject.
        /// </summary>
        /// <param name="observer">Observer to subscribe to the subject.</param>
        /// <returns>Disposable object that can be used to unsubscribe the observer from the subject.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="observer"/> is null.</exception>
        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (observer == null)
                throw new ArgumentNullException("observer");

            IObserver<T> oldObserver;
            IObserver<T> newObserver;

            do
            {
                oldObserver = _observer;

                if (oldObserver == DisposedObserver<T>.Instance)
                {
                    throw new ObjectDisposedException("");
                }

                if (oldObserver == DoneObserver<T>.Completed)
                {
                    observer.OnCompleted();
                    return Disposable.Empty;
                }

                var done = oldObserver as DoneObserver<T>;
                if (done != null)
                {
                    observer.OnError(done.Exception);
                    return Disposable.Empty;
                }

                if (oldObserver == NopObserver<T>.Instance)
                {
                    newObserver = observer;
                }
                else
                {
                    var obs = oldObserver as Observer<T>;
                    if (obs != null)
                    {
                        newObserver = obs.Add(observer);
                    }
                    else
                    {
                        newObserver = new Observer<T>(new ImmutableList<IObserver<T>>(new[] { oldObserver, observer }));
                    }
                }
#pragma warning disable 0420
            } while (Interlocked.CompareExchange(ref _observer, newObserver, oldObserver) != oldObserver);
#pragma warning restore 0420

            return new Subscription(this, observer);
        }

        class Subscription : IDisposable
        {
            private Subject<T> _subject;
            private IObserver<T> _observer;

            public Subscription(Subject<T> subject, IObserver<T> observer)
            {
                _subject = subject;
                _observer = observer;
            }

            public void Dispose()
            {
                var observer = Interlocked.Exchange(ref _observer, null);
                if (observer == null)
                    return;

                _subject.Unsubscribe(observer);
                _subject = null;
            }
        }

        private void Unsubscribe(IObserver<T> observer)
        {
            IObserver<T> oldObserver;
            IObserver<T> newObserver;

            do
            {
                oldObserver = _observer;

                if (oldObserver == DisposedObserver<T>.Instance || oldObserver is DoneObserver<T>)
                    return;

                var obs = oldObserver as Observer<T>;
                if (obs != null)
                {
                    newObserver = obs.Remove(observer);
                }
                else
                {
                    if (oldObserver != observer)
                        return;

                    newObserver = NopObserver<T>.Instance;
                }
#pragma warning disable 0420
            } while (Interlocked.CompareExchange(ref _observer, newObserver, oldObserver) != oldObserver);
#pragma warning restore 0420
        }

        /// <summary>
        /// Releases all resources used by the current instance of the <see cref="System.Reactive.Subjects.Subject&lt;T&gt;"/> class and unsubscribes all observers.
        /// </summary>
        public void Dispose()
        {
            _observer = DisposedObserver<T>.Instance;
        }
    }
}