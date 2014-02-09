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

namespace System.Reactive.Linq
{
    public class Observable
    {
        public virtual IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return GroupBy_<TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default);
        }

        public virtual IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return GroupBy_<TSource, TKey, TSource>(source, keySelector, x => x, comparer);
        }

        public virtual IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(IObservable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return GroupBy_<TSource, TKey, TSource>(source, keySelector, x => x, EqualityComparer<TKey>.Default);
        }

        public virtual IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return GroupBy_<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer);
        }

        private static IObservable<IGroupedObservable<TKey, TElement>> GroupBy_<TSource, TKey, TElement>(IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return new GroupBy<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer);
        }
    }
}