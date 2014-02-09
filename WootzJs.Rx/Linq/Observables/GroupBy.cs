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
using System.Reactive.Subjects;

namespace System.Reactive.Linq.Observables
{
    class GroupBy<TSource, TKey, TElement> : Producer<IGroupedObservable<TKey, TElement>>
    {
        private readonly IObservable<TSource> _source;
        private readonly Func<TSource, TKey> _keySelector;
        private readonly Func<TSource, TElement> _elementSelector;
        private readonly IEqualityComparer<TKey> _comparer;

        public GroupBy(IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            _source = source;
            _keySelector = keySelector;
            _elementSelector = elementSelector;
            _comparer = comparer;
        }

        private CompositeDisposable _groupDisposable;
        private RefCountDisposable _refCountDisposable;

        protected override IDisposable Run(IObserver<IGroupedObservable<TKey, TElement>> observer, IDisposable cancel, Action<IDisposable> setSink)
        {
            _groupDisposable = new CompositeDisposable();
            _refCountDisposable = new RefCountDisposable(_groupDisposable);

            var sink = new _(this, observer, cancel);
            setSink(sink);
            _groupDisposable.Add(_source.SubscribeSafe(sink));

            return _refCountDisposable;
        }

        class _ : Sink<IGroupedObservable<TKey, TElement>>, IObserver<TSource>
        {
            private readonly GroupBy<TSource, TKey, TElement> _parent;
            private readonly Dictionary<TKey, ISubject<TElement>> _map;

            public _(GroupBy<TSource, TKey, TElement> parent, IObserver<IGroupedObservable<TKey, TElement>> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _parent = parent;
                _map = new Dictionary<TKey, ISubject<TElement>>(_parent._comparer);
            }

            public void OnNext(TSource value)
            {
                TKey key;
                try
                {
                    key = _parent._keySelector(value);
                }
                catch (Exception exception)
                {
                    Error(exception);
                    return;
                }

                var fireNewMapEntry = false;
                ISubject<TElement> writer;
                try
                {
                    if (!_map.TryGetValue(key, out writer))
                    {
                        writer = new Subject<TElement>();
                        _map.Add(key, writer);
                        fireNewMapEntry = true;
                    }
                }
                catch (Exception exception)
                {
                    Error(exception);
                    return;
                }

                if (fireNewMapEntry)
                {
                    var group = new GroupedObservable<TKey, TElement>(key, writer, _parent._refCountDisposable);
                    _observer.OnNext(group);
                }

                TElement element;
                try
                {
                    element = _parent._elementSelector(value);
                }
                catch (Exception exception)
                {
                    Error(exception);
                    return;
                }

                writer.OnNext(element);
            }

            public void OnError(Exception error)
            {
                Error(error);
            }

            public void OnCompleted()
            {
                foreach (var w in _map.Values)
                    w.OnCompleted();

                _observer.OnCompleted();
                base.Dispose();
            }

            private void Error(Exception exception)
            {
                foreach (var w in _map.Values)
                    w.OnError(exception);

                _observer.OnError(exception);
                base.Dispose();
            }
        }
    }
}