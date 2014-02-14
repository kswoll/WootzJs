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

using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq.Observables;

namespace System.Reactive.Linq
{
    public static class Observable
    {
        public static IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return GroupBy_(source, keySelector, elementSelector, EqualityComparer<TKey>.Default);
        }

        public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return GroupBy_(source, keySelector, x => x, comparer);
        }

        public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return GroupBy_(source, keySelector, x => x, EqualityComparer<TKey>.Default);
        }

        public static IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return GroupBy_(source, keySelector, elementSelector, comparer);
        }

        private static IObservable<IGroupedObservable<TKey, TElement>> GroupBy_<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return new GroupBy<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer);
        }

        /// <summary>
        /// Subscribes to the specified source, re-routing synchronous exceptions during invocation of the Subscribe method to the observer's OnError channel.
        /// This method is typically used when writing query operators.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
        /// <param name="source">Observable sequence to subscribe to.</param>
        /// <param name="observer">Observer that will be passed to the observable sequence, and that will be used for exception propagation.</param>
        /// <returns>IDisposable object used to unsubscribe from the observable sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="observer"/> is null.</exception>
        public static IDisposable SubscribeSafe<T>(this IObservable<T> source, IObserver<T> observer)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (observer == null)
                throw new ArgumentNullException("observer");

            //
            // The following types are white-listed and should not exhibit exceptional behavior
            // for regular operation circumstances.
            //
            if (source is ObservableBase<T>)
                return source.Subscribe(observer);

            var producer = source as Producer<T>;
            if (producer != null)
                return producer.SubscribeRaw(observer, false);

            var d = Disposable.Empty;

            try
            {
                d = source.Subscribe(observer);
            }
            catch (Exception exception)
            {
                //
                // The effect of redirecting the exception to the OnError channel is automatic
                // clean-up of query operator state for a large number of cases. For example,
                // consider a binary and temporal query operator with the following Subscribe
                // behavior (implemented using the Producer pattern with a Run method):
                //
                //   public IDisposable Run(...)
                //   {
                //       var tm = _scheduler.Schedule(_due, Tick);
                //
                //       var df = _fst.SubscribeSafe(new FstObserver(this, ...));
                //       var ds = _snd.SubscribeSafe(new SndObserver(this, ...)); // <-- fails
                //
                //       return new CompositeDisposable(tm, df, ds);
                //   }
                //
                // If the second subscription fails, we're not leaving the first subscription
                // or the scheduled job hanging around. Instead, the OnError propagation to
                // the SndObserver should take care of a Dispose call to the observer's parent
                // object. The handshake between Producer and Sink objects will ultimately
                // cause disposal of the CompositeDisposable that's returned from the method.
                //
                observer.OnError(exception);
            }

            return d;
        }

        public static IObservable<TSource> Where<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
        {
            var where = source as Where<TSource>;
            if (where != null)
                return where.Ω(predicate);

            return new Where<TSource>(source, predicate);
        }

        public static IObservable<TSource> Where<TSource>(this IObservable<TSource> source, Func<TSource, int, bool> predicate)
        {
            return new Where<TSource>(source, predicate);
        }

        public static IObservable<TResult> Select<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector)
        {
            var select = source as Select<TSource>;
            if (select != null)
                return select.Ω(selector);

            return new Select<TSource, TResult>(source, selector);
        }

        public static IObservable<TResult> Select<TSource, TResult>(this IObservable<TSource> source, Func<TSource, int, TResult> selector)
        {
            return new Select<TSource, TResult>(source, selector);
        }

        public static IObservable<TOther> SelectMany<TSource, TOther>(this IObservable<TSource> source, IObservable<TOther> other)
        {
            return SelectMany_(source, _ => other);
        }

        public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TResult>> selector)
        {
            return SelectMany_(source, selector);
        }

        public static IObservable<TResult> SelectMany<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            return SelectMany_(source, collectionSelector, resultSelector);
        }

        private static IObservable<TResult> SelectMany_<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TResult>> selector)
        {
            return new SelectMany<TSource, TResult>(source, selector);
        }

        private static IObservable<TResult> SelectMany_<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            return new SelectMany<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
        }

        public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IObservable<TResult>> onNext, Func<Exception, IObservable<TResult>> onError, Func<IObservable<TResult>> onCompleted)
        {
            return new SelectMany<TSource, TResult>(source, onNext, onError, onCompleted);
        }

        public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            return new SelectMany<TSource, TResult>(source, selector);
        }

        public static IObservable<TResult> SelectMany<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            return SelectMany_(source, collectionSelector, resultSelector);
        }

        private static IObservable<TResult> SelectMany_<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            return new SelectMany<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
        }

        public static IObservable<double> Sum(this IObservable<double> source)
        {
            return new SumDouble(source);
        }

        public static IObservable<float> Sum(IObservable<float> source)
        {
            return new SumSingle(source);
        }

        public static IObservable<int> Sum(IObservable<int> source)
        {
            return new SumInt32(source);
        }

        public static IObservable<long> Sum(IObservable<long> source)
        {
            return new SumInt64(source);
        }

        public static IObservable<double?> Sum(IObservable<double?> source)
        {
            return new SumDoubleNullable(source);
        }

        public static IObservable<float?> Sum(IObservable<float?> source)
        {
            return new SumSingleNullable(source);
        }

        public static IObservable<int?> Sum(IObservable<int?> source)
        {
            return new SumInt32Nullable(source);
        }

        public static IObservable<long?> Sum(IObservable<long?> source)
        {
            return new SumInt64Nullable(source);
        }

        public static IObservable<double> Sum<TSource>(IObservable<TSource> source, Func<TSource, double> selector)
        {
            return Sum(Select(source, selector));
        }

        public static IObservable<float> Sum<TSource>(IObservable<TSource> source, Func<TSource, float> selector)
        {
            return Sum(Select(source, selector));
        }

        public static IObservable<int> Sum<TSource>(IObservable<TSource> source, Func<TSource, int> selector)
        {
            return Sum(Select(source, selector));
        }

        public static IObservable<long> Sum<TSource>(IObservable<TSource> source, Func<TSource, long> selector)
        {
            return Sum(Select(source, selector));
        }

        public static IObservable<double?> Sum<TSource>(IObservable<TSource> source, Func<TSource, double?> selector)
        {
            return Sum(Select(source, selector));
        }

        public static IObservable<float?> Sum<TSource>(IObservable<TSource> source, Func<TSource, float?> selector)
        {
            return Sum(Select(source, selector));
        }

        public static IObservable<int?> Sum<TSource>(IObservable<TSource> source, Func<TSource, int?> selector)
        {
            return Sum(Select(source, selector));
        }

        public static IObservable<long?> Sum<TSource>(IObservable<TSource> source, Func<TSource, long?> selector)
        {
            return Sum(Select(source, selector));
        }

        /// <summary>
        /// Subscribes to the observable sequence without specifying any handlers.
        /// This method can be used to evaluate the observable sequence for its side-effects only.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
        /// <param name="source">Observable sequence to subscribe to.</param>
        /// <returns>IDisposable object used to unsubscribe from the observable sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static IDisposable Subscribe<T>(this IObservable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            //
            // [OK] Use of unsafe Subscribe: non-pretentious constructor for an observer; this overload is not to be used internally.
            //
            return source.Subscribe/*Unsafe*/(new AnonymousObserver<T>(Stubs<T>.Ignore, Stubs.Throw, Stubs.Nop));
        }

        /// <summary>
        /// Subscribes an element handler to an observable sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
        /// <param name="source">Observable sequence to subscribe to.</param>
        /// <param name="onNext">Action to invoke for each element in the observable sequence.</param>
        /// <returns>IDisposable object used to unsubscribe from the observable sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="onNext"/> is null.</exception>
        public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (onNext == null)
                throw new ArgumentNullException("onNext");

            //
            // [OK] Use of unsafe Subscribe: non-pretentious constructor for an observer; this overload is not to be used internally.
            //
            return source.Subscribe/*Unsafe*/(new AnonymousObserver<T>(onNext, Stubs.Throw, Stubs.Nop));
        }

        /// <summary>
        /// Subscribes an element handler and an exception handler to an observable sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
        /// <param name="source">Observable sequence to subscribe to.</param>
        /// <param name="onNext">Action to invoke for each element in the observable sequence.</param>
        /// <param name="onError">Action to invoke upon exceptional termination of the observable sequence.</param>
        /// <returns>IDisposable object used to unsubscribe from the observable sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="onNext"/> or <paramref name="onError"/> is null.</exception>
        public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (onNext == null)
                throw new ArgumentNullException("onNext");
            if (onError == null)
                throw new ArgumentNullException("onError");

            //
            // [OK] Use of unsafe Subscribe: non-pretentious constructor for an observer; this overload is not to be used internally.
            //
            return source.Subscribe/*Unsafe*/(new AnonymousObserver<T>(onNext, onError, Stubs.Nop));
        }

        /// <summary>
        /// Subscribes an element handler and a completion handler to an observable sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
        /// <param name="source">Observable sequence to subscribe to.</param>
        /// <param name="onNext">Action to invoke for each element in the observable sequence.</param>
        /// <param name="onCompleted">Action to invoke upon graceful termination of the observable sequence.</param>
        /// <returns>IDisposable object used to unsubscribe from the observable sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="onNext"/> or <paramref name="onCompleted"/> is null.</exception>
        public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action onCompleted)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (onNext == null)
                throw new ArgumentNullException("onNext");
            if (onCompleted == null)
                throw new ArgumentNullException("onCompleted");

            //
            // [OK] Use of unsafe Subscribe: non-pretentious constructor for an observer; this overload is not to be used internally.
            //
            return source.Subscribe/*Unsafe*/(new AnonymousObserver<T>(onNext, Stubs.Throw, onCompleted));
        }

        /// <summary>
        /// Subscribes an element handler, an exception handler, and a completion handler to an observable sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
        /// <param name="source">Observable sequence to subscribe to.</param>
        /// <param name="onNext">Action to invoke for each element in the observable sequence.</param>
        /// <param name="onError">Action to invoke upon exceptional termination of the observable sequence.</param>
        /// <param name="onCompleted">Action to invoke upon graceful termination of the observable sequence.</param>
        /// <returns>IDisposable object used to unsubscribe from the observable sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="onNext"/> or <paramref name="onError"/> or <paramref name="onCompleted"/> is null.</exception>
        public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError, Action onCompleted)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (onNext == null)
                throw new ArgumentNullException("onNext");
            if (onError == null)
                throw new ArgumentNullException("onError");
            if (onCompleted == null)
                throw new ArgumentNullException("onCompleted");

            //
            // [OK] Use of unsafe Subscribe: non-pretentious constructor for an observer; this overload is not to be used internally.
            //
            return source.Subscribe/*Unsafe*/(new AnonymousObserver<T>(onNext, onError, onCompleted));
        }

        /// <summary>
        /// Filters the elements of an observable sequence based on the specified type.
        /// </summary>
        /// <typeparam name="TResult">The type to filter the elements in the source sequence on.</typeparam>
        /// <param name="source">The observable sequence that contains the elements to be filtered.</param>
        /// <returns>An observable sequence that contains elements from the input sequence of type TResult.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static IObservable<TResult> OfType<TResult>(this IObservable<object> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return new OfType<object, TResult>(source);
        }
    }
}