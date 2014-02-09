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
    /// <summary>
    /// Abstract base class for implementations of the IObservable&lt;T&gt; interface.
    /// </summary>
    /// <remarks>
    /// If you don't need a named type to create an observable sequence (i.e. you rather need
    /// an instance rather than a reusable type), use the Observable.Create method to create
    /// an observable sequence with specified subscription behavior.
    /// </remarks>
    /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
    public abstract class ObservableBase<T> : IObservable<T>
    {
        /// <summary>
        /// Subscribes the given observer to the observable sequence.
        /// </summary>
        /// <param name="observer">Observer that will receive notifications from the observable sequence.</param>
        /// <returns>Disposable object representing an observer's subscription to the observable sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="observer"/> is null.</exception>
        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (observer == null)
                throw new ArgumentNullException("observer");

            var autoDetachObserver = new AutoDetachObserver<T>(observer);
            
            try
            {
                autoDetachObserver.Disposable = SubscribeCore(autoDetachObserver);
            }
            catch (Exception exception)
            {
                //
                // This can happen when there's a synchronous callback to OnError in the
                // implementation of SubscribeCore, which also throws. So, we're seeing
                // an exception being thrown from a handler.
                //
                // For compat with v1.x, we rethrow the exception in this case, keeping
                // in mind this should be rare but if it happens, something's totally
                // screwed up.
                //
                if (!autoDetachObserver.Fail(exception))
                    throw;
            }

            return autoDetachObserver;
        }

        /// <summary>
        /// Implement this method with the core subscription logic for the observable sequence.
        /// </summary>
        /// <param name="observer">Observer to send notifications to.</param>
        /// <returns>Disposable object representing an observer's subscription to the observable sequence.</returns>
        protected abstract IDisposable SubscribeCore(IObserver<T> observer);
    }
}