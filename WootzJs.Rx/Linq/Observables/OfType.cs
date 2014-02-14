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
    class OfType<TSource, TResult> : Producer<TResult>
    {
        private readonly IObservable<TSource> _source;

        public OfType(IObservable<TSource> source)
        {
            _source = source;
        }

        protected override IDisposable Run(IObserver<TResult> observer, IDisposable cancel, Action<IDisposable> setSink)
        {
            var sink = new _(observer, cancel);
            setSink(sink);
            return _source.SubscribeSafe(sink);
        }

        class _ : Sink<TResult>, IObserver<TSource>
        {
            public _(IObserver<TResult> observer, IDisposable cancel)
                : base(observer, cancel)
            {
            }

            public void OnNext(TSource value)
            {
                if (value is TResult)
                {
                    _observer.OnNext((TResult)(object)value);
                }
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