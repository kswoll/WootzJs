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

namespace System.Reactive.Linq.Observables
{
    class Where<TSource> : Producer<TSource>
    {
        private readonly IObservable<TSource> _source;
        private readonly Func<TSource, bool> _predicate;
        private readonly Func<TSource, int, bool> _predicateI;

        public Where(IObservable<TSource> source, Func<TSource, bool> predicate)
        {
            _source = source;
            _predicate = predicate;
        }

        public Where(IObservable<TSource> source, Func<TSource, int, bool> predicate)
        {
            _source = source;
            _predicateI = predicate;
        }

        public IObservable<TSource> Ω(Func<TSource, bool> predicate)
        {
            if (_predicate != null)
                return new Where<TSource>(_source, x => _predicate(x) && predicate(x));
            else
                return new Where<TSource>(this, predicate);
        }

        protected override IDisposable Run(IObserver<TSource> observer, IDisposable cancel, Action<IDisposable> setSink)
        {
            if (_predicate != null)
            {
                var sink = new _(this, observer, cancel);
                setSink(sink);
                return _source.SubscribeSafe(sink);
            }
            else
            {
                var sink = new τ(this, observer, cancel);
                setSink(sink);
                return _source.SubscribeSafe(sink);
            }
        }

        class _ : Sink<TSource>, IObserver<TSource>
        {
            private readonly Where<TSource> _parent;

            public _(Where<TSource> parent, IObserver<TSource> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _parent = parent;
            }

            public void OnNext(TSource value)
            {
                bool shouldRun;
                try
                {
                    shouldRun = _parent._predicate(value);
                }
                catch (Exception exception)
                {
                    _observer.OnError(exception);
                    base.Dispose();
                    return;
                }

                if (shouldRun)
                    _observer.OnNext(value);
            }

            public void OnError(Exception error)
            {
                _observer.OnError(error);
                base.Dispose();
            }

            public void OnCompleted()
            {
                _observer.OnCompleted();
                base.Dispose();
            }
        }

        class τ : Sink<TSource>, IObserver<TSource>
        {
            private readonly Where<TSource> _parent;
            private int _index;

            public τ(Where<TSource> parent, IObserver<TSource> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _parent = parent;
                _index = 0;
            }

            public void OnNext(TSource value)
            {
                bool shouldRun;
                try
                {
                    shouldRun = _parent._predicateI(value, _index++);
                }
                catch (Exception exception)
                {
                    _observer.OnError(exception);
                    base.Dispose();
                    return;
                }

                if (shouldRun)
                    _observer.OnNext(value);
            }

            public void OnError(Exception error)
            {
                _observer.OnError(error);
                base.Dispose();
            }

            public void OnCompleted()
            {
                _observer.OnCompleted();
                base.Dispose();
            }
        }
    }
}