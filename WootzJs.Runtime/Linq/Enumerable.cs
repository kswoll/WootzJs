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

using System.Collections;
using System.Collections.Generic;
using System.Runtime.WootzJs;

namespace System.Linq
{
    [DependsOn(Type = typeof (YieldIterator<>))]
    public static class Enumerable
    {
        /// <summary>
        /// Applies an accumulator function over a sequence.
        /// </summary>
        /// 
        /// <returns>
        /// The final accumulator value.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> to aggregate over.</param><param name="func">An accumulator function to be invoked on each element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="func"/> is null.</exception><exception cref="T:System.InvalidOperationException"><paramref name="source"/> contains no elements.</exception>
        public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (func == null)
                throw new ArgumentNullException("func");

            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    throw new InvalidOperationException("No elements");
                TSource current = enumerator.Current;
                while (enumerator.MoveNext())
                    current = func(current, enumerator.Current);
                return current;
            }
        }

        /// <summary>
        /// Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value.
        /// </summary>
        /// 
        /// <returns>
        /// The final accumulator value.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> to aggregate over.</param><param name="seed">The initial accumulator value.</param><param name="func">An accumulator function to be invoked on each element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TAccumulate">The type of the accumulator value.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="func"/> is null.</exception>
        public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (func == null)
                throw new ArgumentNullException("func");
            TAccumulate accumulate = seed;
            foreach (TSource current in source)
                accumulate = func(accumulate, current);
            return accumulate;
        }

        /// <summary>
        /// Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value, and the specified function is used to select the result value.
        /// </summary>
        /// 
        /// <returns>
        /// The transformed final accumulator value.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> to aggregate over.</param><param name="seed">The initial accumulator value.</param><param name="func">An accumulator function to be invoked on each element.</param><param name="resultSelector">A function to transform the final accumulator value into the result value.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TAccumulate">The type of the accumulator value.</typeparam><typeparam name="TResult">The type of the resulting value.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="func"/> or <paramref name="resultSelector"/> is null.</exception>
        public static TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (func == null)
                throw new ArgumentNullException("func");
            if (resultSelector == null)
                throw new ArgumentNullException("resultSelector");
            TAccumulate accumulate = seed;
            foreach (TSource current in source)
                accumulate = func(accumulate, current);
            return resultSelector(accumulate);
        }

        /// <summary>
        /// Determines whether all elements of a sequence satisfy a condition.
        /// </summary>
        /// 
        /// <returns>
        /// true if every element of the source sequence passes the test in the specified predicate, or if the sequence is empty; otherwise, false.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains the elements to apply the predicate to.</param><param name="predicate">A function to test each element for a condition.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            foreach (TSource current in source)
            {
                if (!predicate(current))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains elements from the input sequence that satisfy the condition.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> to filter.</param><param name="predicate">A function to test each element for a condition.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate. Each element's index is used in the logic 
        /// of the predicate function.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains elements from the 
        /// input sequence that satisfy the condition.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> to filter.</param>
        /// <param name="predicate">A function to test each source element for a condition; the second parameter of the 
        /// function represents the index of the source element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> 
        /// is null.</exception>
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            int index = 0;
            foreach (var item in source)
            {
                if (predicate(item, index))
                    yield return item;
                index++;
            }
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.Where(predicate).First();
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.Where(predicate).FirstOrDefault();
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            return source.FirstOrDefault(() => { throw new InvalidOperationException("Sequence contains no elements"); });
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return source.FirstOrDefault(() => default(TSource));
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource> defaultValue)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
                return defaultValue();
            var result = enumerator.Current;
            enumerator.Dispose();
            return result;
        }

        public static TSource Last<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.Where(predicate).Last();
        }

        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.Where(predicate).LastOrDefault();
        }

        public static TSource Last<TSource>(this IEnumerable<TSource> source)
        {
            return source.LastOrDefault(() => { throw new InvalidOperationException("Sequence contains no elements"); });
        }

        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return source.LastOrDefault(() => default(TSource));
        }

        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource> defaultValue)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
                return defaultValue();

            var lastValue = enumerator.Current;
            while (enumerator.MoveNext())
                lastValue = enumerator.Current;
            enumerator.Dispose();
            return lastValue;
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.Where(predicate).Single();
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.Where(predicate).SingleOrDefault();
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source)
        {
            return source.SingleOrDefault(() => { throw new InvalidOperationException("Sequence contains no elements"); });
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return source.SingleOrDefault(() => default(TSource));
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource> defaultValue)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
                return defaultValue();
            var result = enumerator.Current;
            if (enumerator.MoveNext())
                throw new InvalidOperationException("Sequence contains more than one element");
            enumerator.Dispose();
            return result;
        }

        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            var result = new TSource[0].As<JsArray>();
            foreach (var item in source)
                result.push(item.As<JsObject>());
            return result.As<TSource[]>();
        }

        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            var list = new List<TSource>();
            foreach (var item in source)
                list.Add(item);
            return list;
        }

        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements are the result of 
        /// invoking the transform function on each element of <paramref name="source"/>.
        /// </returns>
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> 
        /// is null.</exception>
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
                yield return selector(item);
        }

        /// <summary>
        /// Projects each element of a sequence into a new form by incorporating the element's index.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements are the result of invoking the transform function on each element of <paramref name="source"/>.
        /// </returns>
        /// <param name="source">A sequence of values to invoke a transform function on.</param><param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> is null.</exception>
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            var index = 0;
            foreach (var item in source)
            {
                yield return selector(item, index);
                index++;
            }
        }

        /// <summary>
        /// Projects each element of a sequence to an <see cref="T:System.Collections.Generic.IEnumerable`1"/> 
        /// and flattens the resulting sequences into one sequence.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements are the result of invoking the 
        /// one-to-many transform function on each element of the input sequence.
        /// </returns>
        /// <param name="source">A sequence of values to project.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">The type of the elements of the sequence returned by 
        /// <paramref name="selector"/>.</typeparam><exception cref="T:System.ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="selector"/> is null.</exception>
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var item in source)
            {
                foreach (var subitem in selector(item))
                {
                    yield return subitem;
                }
            }
        }

        /// <summary>
        /// Projects each element of a sequence to an <see cref="T:System.Collections.Generic.IEnumerable`1"/>, and flattens the resulting sequences into one sequence. The index of each source element is used in the projected form of that element.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements are the result of invoking the one-to-many transform function on each element of an input sequence.
        /// </returns>
        /// <param name="source">A sequence of values to project.</param><param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TResult">The type of the elements of the sequence returned by <paramref name="selector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> is null.</exception>
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
        {
            if (source == null)
                new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            var index = 0;
            foreach (var item in source)
            {
                foreach (var subitem in selector(item, index))
                {
                    yield return subitem;
                }
                index++;
            }
        }

        /// <summary>
        /// Projects each element of a sequence to an <see cref="T:System.Collections.Generic.IEnumerable`1"/>, flattens the resulting sequences into one sequence, and invokes a result selector function on each element therein. The index of each source element is used in the intermediate projected form of that element.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements are the result of invoking the one-to-many transform function <paramref name="collectionSelector"/> on each element of <paramref name="source"/> and then mapping each of those sequence elements and their corresponding source element to a result element.
        /// </returns>
        /// <param name="source">A sequence of values to project.</param><param name="collectionSelector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param><param name="resultSelector">A transform function to apply to each element of the intermediate sequence.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TCollection">The type of the intermediate elements collected by <paramref name="collectionSelector"/>.</typeparam><typeparam name="TResult">The type of the elements of the resulting sequence.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="collectionSelector"/> or <paramref name="resultSelector"/> is null.</exception>
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (collectionSelector == null)
                throw new ArgumentNullException("collectionSelector");
            if (resultSelector == null)
                throw new ArgumentNullException("resultSelector");

            var index = 0;
            foreach (var item in source)
            {
                foreach (var subitem in collectionSelector(item, index))
                {
                    yield return resultSelector(item, subitem);
                }
                index++;
            }
        }

        /// <summary>
        /// Projects each element of a sequence to an <see cref="T:System.Collections.Generic.IEnumerable`1"/>, flattens the resulting sequences into one sequence, and invokes a result selector function on each element therein.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements are the result of invoking the one-to-many transform function <paramref name="collectionSelector"/> on each element of <paramref name="source"/> and then mapping each of those sequence elements and their corresponding source element to a result element.
        /// </returns>
        /// <param name="source">A sequence of values to project.</param><param name="collectionSelector">A transform function to apply to each element of the input sequence.</param><param name="resultSelector">A transform function to apply to each element of the intermediate sequence.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TCollection">The type of the intermediate elements collected by <paramref name="collectionSelector"/>.</typeparam><typeparam name="TResult">The type of the elements of the resulting sequence.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="collectionSelector"/> or <paramref name="resultSelector"/> is null.</exception>
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (collectionSelector == null)
                throw new ArgumentNullException("collectionSelector");
            if (resultSelector == null)
                throw new ArgumentNullException("resultSelector");

            foreach (var item in source)
            {
                foreach (var subitem in collectionSelector(item))
                {
                    yield return resultSelector(item, subitem);
                }
            }
        }

        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains the specified number of elements from the start of the input sequence.
        /// </returns>
        /// <param name="source">The sequence to return elements from.</param><param name="count">The number of elements to return.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int index = 0;
            foreach (var item in source)
            {
                if (index >= count)
                    break;
                yield return item;
                index++;
            }
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains the elements from the input sequence that occur before the element at which the test no longer passes.
        /// </returns>
        /// <param name="source">A sequence to return elements from.</param><param name="predicate">A function to test each element for a condition.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
        public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            foreach (var item in source)
            {
                if (!predicate(item))
                    break;
                yield return item;
            }
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains elements from the input sequence that occur before the element at which the test no longer passes.
        /// </returns>
        /// <param name="source">The sequence to return elements from.</param><param name="predicate">A function to test each source element for a condition; the second parameter of the function represents the index of the source element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
        public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var index = 0;
            foreach (var item in source)
            {
                if (!predicate(item, index))
                    break;
                yield return item;
                index++;
            }
        }

        /// <summary>
        /// Bypasses a specified number of elements in a sequence and then returns the remaining elements.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains the elements that occur after the specified index in the input sequence.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> to return elements from.</param><param name="count">The number of elements to skip before returning the remaining elements.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int index = -1;
            foreach (var item in source)
            {
                index++;
                if (index < count)
                    continue;
                yield return item;
            }
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains the elements from the input sequence starting at the first element in the linear series that does not pass the test specified by <paramref name="predicate"/>.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> to return elements from.</param><param name="predicate">A function to test each element for a condition.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
        public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            foreach (var item in source)
            {
                if (predicate(item))
                    continue;
                yield return item;
            }
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains the elements from the input sequence starting at the first element in the linear series that does not pass the test specified by <paramref name="predicate"/>.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> to return elements from.</param><param name="predicate">A function to test each source element for a condition; the second parameter of the function represents the index of the source element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
        public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            int index = -1;
            foreach (var item in source)
            {
                index++;
                if (predicate(item, index))
                    continue;
                yield return item;
            }
        }

        /// <summary>
        /// Correlates the elements of two sequences based on matching keys. The default equality comparer 
        /// is used to compare keys.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that has elements of type 
        /// <paramref name="TResult"/> that are obtained by performing an inner join on two sequences.
        /// </returns>
        /// <param name="outer">The first sequence to join.</param>
        /// <param name="inner">The sequence to join to the first sequence.</param>
        /// <param name="outerKeySelector">A function to extract the join key from each element of the first 
        /// sequence.</param>
        /// <param name="innerKeySelector">A function to extract the join key from each element of the second 
        /// sequence.</param>
        /// <param name="resultSelector">A function to create a result element from two matching elements.</param>
        /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
        /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
        /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
        /// <typeparam name="TResult">The type of the result elements.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="outer"/> or <paramref name="inner"/> or 
        /// <paramref name="outerKeySelector"/> or <paramref name="innerKeySelector"/> or 
        /// <paramref name="resultSelector"/> is null.</exception>
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            var outers = outer.ToArray();
            if (outer == null)
                throw new ArgumentNullException("outer");
            if (inner == null)
                throw new ArgumentNullException("inner");
            if (outerKeySelector == null)
                throw new ArgumentNullException("outerKeySelector");
            if (innerKeySelector == null)
                throw new ArgumentNullException("innerKeySelector");
            if (resultSelector == null)
                throw new ArgumentNullException("resultSelector");

            var dictionary = new Dictionary<TKey, Tuple<List<TOuter>, List<TInner>>>();
            foreach (var item in outers)
            {
                var key = outerKeySelector(item);
                Tuple<List<TOuter>, List<TInner>> lists;
                if (!dictionary.TryGetValue(key, out lists))
                {
                    lists = new Tuple<List<TOuter>, List<TInner>>(new List<TOuter>(), new List<TInner>());
                    dictionary[key] = lists;
                }
                lists.Item1.Add(item);
            }
            foreach (var item in inner)
            {
                var key = innerKeySelector(item);
                Tuple<List<TOuter>, List<TInner>> lists;
                if (!dictionary.TryGetValue(key, out lists))
                    continue;
                lists.Item2.Add(item);
            }
            foreach (var outerItem in outers)
            {
                var key = outerKeySelector(outerItem);
                var set = dictionary[key];
                foreach (var innerItem in set.Item2)
                {
                    yield return resultSelector(outerItem, innerItem);
                }
            }
        }


        public static bool Any<TSource>(this IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();
            var result = enumerator.MoveNext();
            enumerator.Dispose();
            return result;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.Where(predicate).Any();
        }

        public static TSource Max<TSource>(this IEnumerable<TSource> source)
        {
            TSource current = default(TSource);
            foreach (var item in source)
            {
                if (item == null)
                    continue;
                if (current == null)
                {
                    current = item;
                    continue;
                }

                var comparable = item as IComparable;
                if (comparable.CompareTo(current) > 0)
                    current = item;
            }
            return current;
        }

        public static TSource Min<TSource>(this IEnumerable<TSource> source)
        {
            TSource current = default(TSource);
            foreach (var item in source)
            {
                if (item == null)
                    continue;
                if (current == null)
                {
                    current = item;
                    continue;
                }

                var comparable = item as IComparable;
                if (comparable.CompareTo(current) < 0)
                    current = item;
            }
            return current;
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, IEnumerable<T> other)
        {
            foreach (var item in source)
                yield return item;
            foreach (var item in other)
                yield return item;
        }

        /// <summary>
        /// Produces the set difference of two sequences by using the default equality comparer to compare values.
        /// </summary>
        /// 
        /// <returns>
        /// A sequence that contains the set difference of the elements of two sequences.
        /// </returns>
        /// <param name="first">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements that are not also in <paramref name="second"/> will be returned.</param><param name="second">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence.</param><typeparam name="TSource">The type of the elements of the input sequences.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="first"/> or <paramref name="second"/> is null.</exception>
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null)
                throw new ArgumentNullException("first");
            if (second == null)
                throw new ArgumentNullException("second");

            var set = new HashSet<TSource>(second);
            foreach (var item in first)
            {
                if (!set.Contains(item))
                    yield return item;
            }
        }

        /// <summary>
        /// Computes the sum of a sequence of <see cref="T:System.Int32"/> values.
        /// </summary>
        /// 
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <param name="source">A sequence of <see cref="T:System.Int32"/> values to calculate the sum of.</param><exception cref="T:System.ArgumentNullException"><paramref name="source"/> is null.</exception><exception cref="T:System.OverflowException">The sum is larger than <see cref="F:System.Int32.MaxValue"/>.</exception>
        public static int Sum(this IEnumerable<int> source)
        {
            return source.As<IEnumerable<int?>>().Sum().As<int>();
        }

        /// <summary>
        /// Computes the sum of a sequence of nullable <see cref="T:System.Int32"/> values.
        /// </summary>
        /// 
        /// <returns>
        /// The sum of the values in the sequence.
        /// </returns>
        /// <param name="source">A sequence of nullable <see cref="T:System.Int32"/> values to calculate the sum of.</param><exception cref="T:System.ArgumentNullException"><paramref name="source"/> is null.</exception><exception cref="T:System.OverflowException">The sum is larger than <see cref="F:System.Int32.MaxValue"/>.</exception>
        public static int? Sum(this IEnumerable<int?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            int num = 0;
            foreach (int? nullable in source)
            {
                if (nullable.HasValue)
                    num += nullable.GetValueOrDefault();
            }
            return num;
        }

        /// <summary>
        /// Computes the sum of the sequence of <see cref="T:System.Int32"/> values that are obtained by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// 
        /// <returns>
        /// The sum of the projected values.
        /// </returns>
        /// <param name="source">A sequence of values that are used to calculate a sum.</param><param name="selector">A transform function to apply to each element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> is null.</exception><exception cref="T:System.OverflowException">The sum is larger than <see cref="F:System.Int32.MaxValue"/>.</exception>
        public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            return source.Select(selector).Sum();
        }

        /// <summary>
        /// Generates a sequence that contains one repeated value.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains a repeated value.
        /// </returns>
        /// <param name="element">The value to be repeated.</param><param name="count">The number of times to repeat the value in the generated sequence.</param><typeparam name="TResult">The type of the value to be repeated in the result sequence.</typeparam><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count"/> is less than 0.</exception>
        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            else
            {
                for (var i = 0; i < count; i++)
                    yield return element;
            }
        }

        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
        {
            var stack = new Stack<TSource>();
            foreach (var item in source)
                stack.Push(item);
            return stack;
        }

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            return source.ToDictionary<TSource, TKey, TSource>(keySelector, x => x);
        }

        public static Dictionary<TKey, TValue> ToDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector)
        {
            var dictionary = new Dictionary<TKey, TValue>();
            foreach (var item in source)
            {
                var key = keySelector(item);
                var value = valueSelector(item);
                dictionary[key] = value;
            }
            return dictionary;
        }

        public static bool SequenceEqual<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other)
        {
            var sourceEnumerator = source.GetEnumerator();
            var otherEnumerator = other.GetEnumerator();

            while (sourceEnumerator.MoveNext() && otherEnumerator.MoveNext())
            {
                var sourceItem = sourceEnumerator.Current;
                var otherItem = otherEnumerator.Current;
                if (!EqualityComparer<TSource>.Default.Equals(sourceItem, otherItem))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Casts the elements of an <see cref="T:System.Collections.IEnumerable"/> to the specified type.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains each element of the source sequence cast to the specified type.
        /// </returns>
        /// <param name="source">The <see cref="T:System.Collections.IEnumerable"/> that contains the elements to be cast to type <paramref name="TResult"/>.</param><typeparam name="TResult">The type to cast the elements of <paramref name="source"/> to.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> is null.</exception><exception cref="T:System.InvalidCastException">An element in the sequence cannot be cast to type <paramref name="TResult"/>.</exception>
        public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            foreach (var item in source)
            {
                yield return (TResult)item;
            }
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order according to a key.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Linq.IOrderedEnumerable`1"/> whose elements are sorted according to a key.
        /// </returns>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source"/> or 
        /// <paramref name="keySelector"/> is null.</exception>
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            return OrderedEnumerable<TSource>.Create(source, keySelector, Comparer<TKey>.Default, false);
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order by using a specified comparer.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Linq.IOrderedEnumerable`1"/> whose elements are sorted according to a key.
        /// </returns>
        /// <param name="source">A sequence of values to order.</param><param name="keySelector">A function to extract a key from an element.</param><param name="comparer">An <see cref="T:System.Collections.Generic.IComparer`1"/> to compare keys.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return OrderedEnumerable<TSource>.Create(source, keySelector, comparer, false);
        }

        /// <summary>
        /// Sorts the elements of a sequence in descending order according to a key.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Linq.IOrderedEnumerable`1"/> whose elements are sorted in descending order according to a key.
        /// </returns>
        /// <param name="source">A sequence of values to order.</param><param name="keySelector">A function to extract a key from an element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return OrderedEnumerable<TSource>.Create(source, keySelector, Comparer<TKey>.Default, true);
        }

        /// <summary>
        /// Sorts the elements of a sequence in descending order by using a specified comparer.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Linq.IOrderedEnumerable`1"/> whose elements are sorted in descending order according to a key.
        /// </returns>
        /// <param name="source">A sequence of values to order.</param><param name="keySelector">A function to extract a key from an element.</param><param name="comparer">An <see cref="T:System.Collections.Generic.IComparer`1"/> to compare keys.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return OrderedEnumerable<TSource>.Create(source, keySelector, comparer, true);
        }

        /// <summary>
        /// Performs a subsequent ordering of the elements in a sequence in ascending order according to a key.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Linq.IOrderedEnumerable`1"/> whose elements are sorted according to a key.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Linq.IOrderedEnumerable`1"/> that contains elements to sort.</param><param name="keySelector">A function to extract a key from each element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            else
                return source.CreateOrderedEnumerable(keySelector, Comparer<TKey>.Default, false);
        }

        /// <summary>
        /// Performs a subsequent ordering of the elements in a sequence in ascending order by using a specified comparer.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Linq.IOrderedEnumerable`1"/> whose elements are sorted according to a key.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Linq.IOrderedEnumerable`1"/> that contains elements to sort.</param><param name="keySelector">A function to extract a key from each element.</param><param name="comparer">An <see cref="T:System.Collections.Generic.IComparer`1"/> to compare keys.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            else
                return source.CreateOrderedEnumerable(keySelector, comparer, false);
        }

        /// <summary>
        /// Performs a subsequent ordering of the elements in a sequence in descending order, according to a key.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Linq.IOrderedEnumerable`1"/> whose elements are sorted in descending order according to a key.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Linq.IOrderedEnumerable`1"/> that contains elements to sort.</param><param name="keySelector">A function to extract a key from each element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            else
                return source.CreateOrderedEnumerable(keySelector, Comparer<TKey>.Default, true);
        }

        /// <summary>
        /// Performs a subsequent ordering of the elements in a sequence in descending order by using a specified comparer.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Linq.IOrderedEnumerable`1"/> whose elements are sorted in descending order according to a key.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Linq.IOrderedEnumerable`1"/> that contains elements to sort.</param><param name="keySelector">A function to extract a key from each element.</param><param name="comparer">An <see cref="T:System.Collections.Generic.IComparer`1"/> to compare keys.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            else
                return source.CreateOrderedEnumerable(keySelector, comparer, true);
        }

        public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source)
        {
            foreach (var item in source)
            {
                if (item is TResult)
                    yield return (TResult)item;
            }
        }

        /// <summary>
        /// Returns an empty <see cref="T:System.Collections.Generic.IEnumerable`1"/> that has the 
        /// specified type argument.
        /// </summary>
        /// 
        /// <returns>
        /// An empty <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose type argument is 
        /// <paramref name="TResult"/>.
        /// </returns>
        /// <typeparam name="TResult">The type to assign to the type parameter of the returned generic 
        /// <see cref="T:System.Collections.Generic.IEnumerable`1"/>.</typeparam>
        public static IEnumerable<TResult> Empty<TResult>()
        {
            yield break;
        }

        /// <summary>
        /// Returns the elements of the specified sequence or the type parameter's default value in a singleton collection if the sequence is empty.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> object that contains the default value for the <paramref name="TSource"/> type if <paramref name="source"/> is empty; otherwise, <paramref name="source"/>.
        /// </returns>
        /// <param name="source">The sequence to return a default value for if it is empty.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return DefaultIfEmpty(source, default(TSource));
        }

        /// <summary>
        /// Returns the elements of the specified sequence or the specified value in a singleton collection if the sequence is empty.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains <paramref name="defaultValue"/> if <paramref name="source"/> is empty; otherwise, <paramref name="source"/>.
        /// </returns>
        /// <param name="source">The sequence to return the specified value for if it is empty.</param><param name="defaultValue">The value to return if the sequence is empty.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            bool isEmpty = true;
            foreach (var item in source)
            {
                isEmpty = false;
                yield return item;
            }
            if (isEmpty)
            {
                yield return defaultValue;
            }
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function.
        /// </summary>
        /// 
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; in C# or IEnumerable(Of IGrouping(Of TKey, TSource)) in Visual Basic where each <see cref="T:System.Linq.IGrouping`2"/> object contains a sequence of objects and a key.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements to group.</param><param name="keySelector">A function to extract the key for each element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.GroupBy(keySelector, IdentityFunction<TSource>.Default,
                GroupingCreator<TKey, TSource>.Create, EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and compares the keys by using a specified comparer.
        /// </summary>
        /// 
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; in C# or IEnumerable(Of IGrouping(Of TKey, TSource)) in Visual Basic where each <see cref="T:System.Linq.IGrouping`2"/> object contains a collection of objects and a key.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements to group.</param><param name="keySelector">A function to extract the key for each element.</param><param name="comparer">An <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> to compare keys.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer)
        {
            return source.GroupBy(keySelector, IdentityFunction<TSource>.Default,
                GroupingCreator<TKey, TSource>.Create, comparer);
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and projects the elements for each group by using a specified function.
        /// </summary>
        /// 
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TElement&gt;&gt; in C# or IEnumerable(Of IGrouping(Of TKey, TElement)) in Visual Basic where each <see cref="T:System.Linq.IGrouping`2"/> object contains a collection of objects of type <paramref name="TElement"/> and a key.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements to group.</param><param name="keySelector">A function to extract the key for each element.</param><param name="elementSelector">A function to map each source element to an element in the <see cref="T:System.Linq.IGrouping`2"/>.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><typeparam name="TElement">The type of the elements in the <see cref="T:System.Linq.IGrouping`2"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null.</exception>
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            return source.GroupBy(
                keySelector,
                elementSelector,
                GroupingCreator<TKey, TElement>.Create,
                EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// Groups the elements of a sequence according to a key selector function. The keys are compared by using a comparer and each group's elements are projected by using a specified function.
        /// </summary>
        /// 
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TElement&gt;&gt; in C# or IEnumerable(Of IGrouping(Of TKey, TElement)) in Visual Basic where each <see cref="T:System.Linq.IGrouping`2"/> object contains a collection of objects of type <paramref name="TElement"/> and a key.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements to group.</param><param name="keySelector">A function to extract the key for each element.</param><param name="elementSelector">A function to map each source element to an element in an <see cref="T:System.Linq.IGrouping`2"/>.</param><param name="comparer">An <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> to compare keys.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><typeparam name="TElement">The type of the elements in the <see cref="T:System.Linq.IGrouping`2"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null.</exception>
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return source.GroupBy(keySelector, elementSelector,
                GroupingCreator<TKey, TElement>.Create,
                EqualityComparer<TKey>.Default);
        }

        private static class GroupingCreator<TKey, TElement>
        {
            public static IGrouping<TKey, TElement> Create(TKey key, IEnumerable<TElement> elements)
            {
                return new Grouping<TKey, TElement>(key, elements);
            }
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and creates a result value from each group and its key.
        /// </summary>
        /// 
        /// <returns>
        /// A collection of elements of type <paramref name="TResult"/> where each element represents a projection over a group and its key.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements to group.</param><param name="keySelector">A function to extract the key for each element.</param><param name="resultSelector">A function to create a result value from each group.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><typeparam name="TResult">The type of the result value returned by <paramref name="resultSelector"/>.</typeparam>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
        {
            return source.GroupBy(keySelector, IdentityFunction<TSource>.Default, resultSelector, EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and creates a result value from each group and its key. The elements of each group are projected by using a specified function.
        /// </summary>
        /// 
        /// <returns>
        /// A collection of elements of type <paramref name="TResult"/> where each element represents a projection over a group and its key.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements to group.</param><param name="keySelector">A function to extract the key for each element.</param><param name="elementSelector">A function to map each source element to an element in an <see cref="T:System.Linq.IGrouping`2"/>.</param><param name="resultSelector">A function to create a result value from each group.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><typeparam name="TElement">The type of the elements in each <see cref="T:System.Linq.IGrouping`2"/>.</typeparam><typeparam name="TResult">The type of the result value returned by <paramref name="resultSelector"/>.</typeparam>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
        {
            return source.GroupBy(keySelector, elementSelector, resultSelector, EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and creates a result value from each group and its key. The keys are compared by using a specified comparer.
        /// </summary>
        /// 
        /// <returns>
        /// A collection of elements of type <paramref name="TResult"/> where each element represents a projection over a group and its key.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements to group.</param><param name="keySelector">A function to extract the key for each element.</param><param name="resultSelector">A function to create a result value from each group.</param><param name="comparer">An <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> to compare keys with.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><typeparam name="TResult">The type of the result value returned by <paramref name="resultSelector"/>.</typeparam>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            return source.GroupBy(keySelector, IdentityFunction<TSource>.Default, resultSelector,
                comparer);
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and creates a result value from each group and its key. Key values are compared by using a specified comparer, and the elements of each group are projected by using a specified function.
        /// </summary>
        /// 
        /// <returns>
        /// A collection of elements of type <paramref name="TResult"/> where each element represents a projection over a group and its key.
        /// </returns>
        /// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> whose elements to group.</param><param name="keySelector">A function to extract the key for each element.</param><param name="elementSelector">A function to map each source element to an element in an <see cref="T:System.Linq.IGrouping`2"/>.</param><param name="resultSelector">A function to create a result value from each group.</param><param name="comparer">An <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> to compare keys with.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><typeparam name="TElement">The type of the elements in each <see cref="T:System.Linq.IGrouping`2"/>.</typeparam><typeparam name="TResult">The type of the result value returned by <paramref name="resultSelector"/>.</typeparam>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            var dictionary = new Dictionary<TKey, List<TElement>>(comparer);
            foreach (var item in source)
            {
                var key = keySelector(item);
                List<TElement> list;
                if (!dictionary.TryGetValue(key, out list))
                {
                    list = new List<TElement>();
                    dictionary[key] = list;
                }
                list.Add(item);
            }
            foreach (var item in dictionary)
            {
                var result = resultSelector(item.Key, item.Value);
                yield return result;
            }
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Lookup`2"/> from an <see cref="T:System.Collections.Generic.IEnumerable`1"/> according to a specified key selector function.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Lookup`2"/> that contains keys and values.
        /// </returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1"/> to create a <see cref="T:System.Linq.Lookup`2"/> from.</param><param name="keySelector">A function to extract a key from each element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return new Lookup<TKey, TSource>(source.GroupBy(keySelector));
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Lookup`2"/> from an <see cref="T:System.Collections.Generic.IEnumerable`1"/> according to a specified key selector function and key comparer.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Lookup`2"/> that contains keys and values.
        /// </returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1"/> to create a <see cref="T:System.Linq.Lookup`2"/> from.</param><param name="keySelector">A function to extract a key from each element.</param><param name="comparer">An <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> to compare keys.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return new Lookup<TKey, TSource>(source.GroupBy(keySelector, GroupingCreator<TKey, TSource>.Create, comparer));
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Lookup`2"/> from an <see cref="T:System.Collections.Generic.IEnumerable`1"/> according to specified key selector and element selector functions.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Lookup`2"/> that contains values of type <paramref name="TElement"/> selected from the input sequence.
        /// </returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1"/> to create a <see cref="T:System.Linq.Lookup`2"/> from.</param><param name="keySelector">A function to extract a key from each element.</param><param name="elementSelector">A transform function to produce a result element value from each element.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><typeparam name="TElement">The type of the value returned by <paramref name="elementSelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null.</exception>
        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return new Lookup<TKey, TElement>(source.GroupBy(keySelector, elementSelector));
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Lookup`2"/> from an <see cref="T:System.Collections.Generic.IEnumerable`1"/> according to a specified key selector function, a comparer and an element selector function.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Lookup`2"/> that contains values of type <paramref name="TElement"/> selected from the input sequence.
        /// </returns>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1"/> to create a <see cref="T:System.Linq.Lookup`2"/> from.</param><param name="keySelector">A function to extract a key from each element.</param><param name="elementSelector">A transform function to produce a result element value from each element.</param><param name="comparer">An <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> to compare keys.</param><typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam><typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam><typeparam name="TElement">The type of the value returned by <paramref name="elementSelector"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null.</exception>
        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, 
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return new Lookup<TKey, TElement>(source.GroupBy(keySelector, elementSelector, comparer));
        }
    }
}