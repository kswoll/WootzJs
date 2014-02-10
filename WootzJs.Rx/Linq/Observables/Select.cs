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
    abstract class Select<TResult> : Producer<TResult>
    {
        public abstract IObservable<TResult2> Ω<TResult2>(Func<TResult, TResult2> selector);
    }

    class Select<TSource, TResult> : Select<TResult>
    {
        private readonly IObservable<TSource> _source;
        private readonly Func<TSource, TResult> _selector;
        private readonly Func<TSource, int, TResult> _selectorI;

        public Select(IObservable<TSource> source, Func<TSource, TResult> selector)
        {
            _source = source;
            _selector = selector;
        }

        public Select(IObservable<TSource> source, Func<TSource, int, TResult> selector)
        {
            _source = source;
            _selectorI = selector;
        }

        public override IObservable<TResult2> Ω<TResult2>(Func<TResult, TResult2> selector)
        {
            if (_selector != null)
                return new Select<TSource, TResult2>(_source, x => selector(_selector(x)));
            else
                return new Select<TResult, TResult2>(this, selector);
        }

        protected override IDisposable Run(IObserver<TResult> observer, IDisposable cancel, Action<IDisposable> setSink)
        {
            if (_selector != null)
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

        class _ : Sink<TResult>, IObserver<TSource>
        {
            private readonly Select<TSource, TResult> _parent;

            public _(Select<TSource, TResult> parent, IObserver<TResult> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _parent = parent;
            }

            public void OnNext(TSource value)
            {
                TResult result;
                try
                {
                    result = _parent._selector(value);
                }
                catch (Exception exception)
                {
                    _observer.OnError(exception);
                    base.Dispose();
                    return;
                }

                _observer.OnNext(result);
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

        class τ : Sink<TResult>, IObserver<TSource>
        {
            private readonly Select<TSource, TResult> _parent;
            private int _index;

            public τ(Select<TSource, TResult> parent, IObserver<TResult> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _parent = parent;
                _index = 0;
            }

            public void OnNext(TSource value)
            {
                TResult result;
                try
                {
                    result = _parent._selectorI(value, _index++);
                }
                catch (Exception exception)
                {
                    _observer.OnError(exception);
                    base.Dispose();
                    return;
                }

                _observer.OnNext(result);
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