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

using System.Reactive.Disposables;

namespace System.Reactive
{
    /// <summary>
    /// Base class for implementation of query operators, providing performance benefits over the use of Observable.Create.
    /// </summary>
    /// <typeparam name="TSource">Type of the resulting sequence's elements.</typeparam>
    internal abstract class Producer<TSource> : IObservable<TSource>
    {
        /// <summary>
        /// Publicly visible Subscribe method.
        /// </summary>
        /// <param name="observer">Observer to send notifications on. The implementation of a producer must ensure the correct message grammar on the observer.</param>
        /// <returns>IDisposable to cancel the subscription. This causes the underlying sink to be notified of unsubscription, causing it to prevent further messages from being sent to the observer.</returns>
        public IDisposable Subscribe(IObserver<TSource> observer)
        {
            if (observer == null)
                throw new ArgumentNullException("observer");

            return SubscribeRaw(observer, true);
        }

        internal IDisposable SubscribeRaw(IObserver<TSource> observer, bool enableSafeguard)
        {
            var state = new State();
            state.observer = observer;
            state.sink = new SingleAssignmentDisposable();
            state.subscription = new SingleAssignmentDisposable();

            var d = new CompositeDisposable(2) { state.sink, state.subscription };

            //
            // See AutoDetachObserver.cs for more information on the safeguarding requirement and
            // its implementation aspects.
            //
            if (enableSafeguard)
            {
                state.observer = SafeObserver<TSource>.Create(state.observer, d);
            }

            state.subscription.Disposable = Run(state.observer, state.subscription, state.Assign);
            return d;
        }

        class State
        {
            public SingleAssignmentDisposable sink;
            public SingleAssignmentDisposable subscription;
            public IObserver<TSource> observer;

            public void Assign(IDisposable s)
            {
                sink.Disposable = s;
            }
        }

        /// <summary>
        /// Core implementation of the query operator, called upon a new subscription to the producer object.
        /// </summary>
        /// <param name="observer">Observer to send notifications on. The implementation of a producer must ensure the correct message grammar on the observer.</param>
        /// <param name="cancel">The subscription disposable object returned from the Run call, passed in such that it can be forwarded to the sink, allowing it to dispose the subscription upon sending a final message (or prematurely for other reasons).</param>
        /// <param name="setSink">Callback to communicate the sink object to the subscriber, allowing consumers to tunnel a Dispose call into the sink, which can stop the processing.</param>
        /// <returns>Disposable representing all the resources and/or subscriptions the operator uses to process events.</returns>
        /// <remarks>The <paramref name="observer">observer</paramref> passed in to this method is not protected using auto-detach behavior upon an OnError or OnCompleted call. The implementation must ensure proper resource disposal and enforce the message grammar.</remarks>
        protected abstract IDisposable Run(IObserver<TSource> observer, IDisposable cancel, Action<IDisposable> setSink);
    }
}