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
    class SumDouble : Producer<double>
    {
        private readonly IObservable<double> _source;

        public SumDouble(IObservable<double> source)
        {
            _source = source;
        }

        protected override IDisposable Run(IObserver<double> observer, IDisposable cancel, Action<IDisposable> setSink)
        {
            var sink = new _(observer, cancel);
            setSink(sink);
            return _source.SubscribeSafe(sink);
        }

        class _ : Sink<double>, IObserver<double>
        {
            private double _sum;

            public _(IObserver<double> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _sum = 0.0;
            }

            public void OnNext(double value)
            {
                _sum += value;
            }

            public void OnError(Exception error)
            {
                _observer.OnError(error);
                base.Dispose();
            }

            public void OnCompleted()
            {
                _observer.OnNext(_sum);
                _observer.OnCompleted();
                base.Dispose();
            }
        }
    }

    class SumSingle : Producer<float>
    {
        private readonly IObservable<float> _source;

        public SumSingle(IObservable<float> source)
        {
            _source = source;
        }

        protected override IDisposable Run(IObserver<float> observer, IDisposable cancel, Action<IDisposable> setSink)
        {
            var sink = new _(observer, cancel);
            setSink(sink);
            return _source.SubscribeSafe(sink);
        }

        class _ : Sink<float>, IObserver<float>
        {
            private double _sum; // This is what LINQ to Objects does!

            public _(IObserver<float> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _sum = 0.0; // This is what LINQ to Objects does!
            }

            public void OnNext(float value)
            {
                _sum += value; // This is what LINQ to Objects does!
            }

            public void OnError(Exception error)
            {
                _observer.OnError(error);
                base.Dispose();
            }

            public void OnCompleted()
            {
                _observer.OnNext((float)_sum); // This is what LINQ to Objects does!
                _observer.OnCompleted();
                base.Dispose();
            }
        }
    }

    class SumInt32 : Producer<int>
    {
        private readonly IObservable<int> _source;

        public SumInt32(IObservable<int> source)
        {
            _source = source;
        }

        protected override IDisposable Run(IObserver<int> observer, IDisposable cancel, Action<IDisposable> setSink)
        {
            var sink = new _(observer, cancel);
            setSink(sink);
            return _source.SubscribeSafe(sink);
        }

        class _ : Sink<int>, IObserver<int>
        {
            private int _sum;

            public _(IObserver<int> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _sum = 0;
            }

            public void OnNext(int value)
            {
                _sum += value;
            }

            public void OnError(Exception error)
            {
                _observer.OnError(error);
                base.Dispose();
            }

            public void OnCompleted()
            {
                _observer.OnNext(_sum);
                _observer.OnCompleted();
                base.Dispose();
            }
        }
    }

    class SumInt64 : Producer<long>
    {
        private readonly IObservable<long> _source;

        public SumInt64(IObservable<long> source)
        {
            _source = source;
        }

        protected override IDisposable Run(IObserver<long> observer, IDisposable cancel, Action<IDisposable> setSink)
        {
            var sink = new _(observer, cancel);
            setSink(sink);
            return _source.SubscribeSafe(sink);
        }

        class _ : Sink<long>, IObserver<long>
        {
            private long _sum;

            public _(IObserver<long> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _sum = 0L;
            }

            public void OnNext(long value)
            {
                _sum += value;
            }

            public void OnError(Exception error)
            {
                _observer.OnError(error);
                base.Dispose();
            }

            public void OnCompleted()
            {
                _observer.OnNext(_sum);
                _observer.OnCompleted();
                base.Dispose();
            }
        }
    }

    class SumDoubleNullable : Producer<double?>
    {
        private readonly IObservable<double?> _source;

        public SumDoubleNullable(IObservable<double?> source)
        {
            _source = source;
        }

        protected override IDisposable Run(IObserver<double?> observer, IDisposable cancel, Action<IDisposable> setSink)
        {
            var sink = new _(observer, cancel);
            setSink(sink);
            return _source.SubscribeSafe(sink);
        }

        class _ : Sink<double?>, IObserver<double?>
        {
            private double _sum;

            public _(IObserver<double?> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _sum = 0.0;
            }

            public void OnNext(double? value)
            {
                if (value != null)
                    _sum += value.Value;
            }

            public void OnError(Exception error)
            {
                _observer.OnError(error);
                base.Dispose();
            }

            public void OnCompleted()
            {
                _observer.OnNext(_sum);
                _observer.OnCompleted();
                base.Dispose();
            }
        }
    }

    class SumSingleNullable : Producer<float?>
    {
        private readonly IObservable<float?> _source;

        public SumSingleNullable(IObservable<float?> source)
        {
            _source = source;
        }

        protected override IDisposable Run(IObserver<float?> observer, IDisposable cancel, Action<IDisposable> setSink)
        {
            var sink = new _(observer, cancel);
            setSink(sink);
            return _source.SubscribeSafe(sink);
        }

        class _ : Sink<float?>, IObserver<float?>
        {
            private double _sum; // This is what LINQ to Objects does!

            public _(IObserver<float?> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _sum = 0.0; // This is what LINQ to Objects does!
            }

            public void OnNext(float? value)
            {
                if (value != null)
                    _sum += value.Value; // This is what LINQ to Objects does!
            }

            public void OnError(Exception error)
            {
                _observer.OnError(error);
                base.Dispose();
            }

            public void OnCompleted()
            {
                _observer.OnNext((float)_sum); // This is what LINQ to Objects does!
                _observer.OnCompleted();
                base.Dispose();
            }
        }
    }

    class SumInt32Nullable : Producer<int?>
    {
        private readonly IObservable<int?> _source;

        public SumInt32Nullable(IObservable<int?> source)
        {
            _source = source;
        }

        protected override IDisposable Run(IObserver<int?> observer, IDisposable cancel, Action<IDisposable> setSink)
        {
            var sink = new _(observer, cancel);
            setSink(sink);
            return _source.SubscribeSafe(sink);
        }

        class _ : Sink<int?>, IObserver<int?>
        {
            private int _sum;

            public _(IObserver<int?> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _sum = 0;
            }

            public void OnNext(int? value)
            {
                if (value != null)
                    _sum += value.Value;
            }

            public void OnError(Exception error)
            {
                _observer.OnError(error);
                base.Dispose();
            }

            public void OnCompleted()
            {
                _observer.OnNext(_sum);
                _observer.OnCompleted();
                base.Dispose();
            }
        }
    }

    class SumInt64Nullable : Producer<long?>
    {
        private readonly IObservable<long?> _source;

        public SumInt64Nullable(IObservable<long?> source)
        {
            _source = source;
        }

        protected override IDisposable Run(IObserver<long?> observer, IDisposable cancel, Action<IDisposable> setSink)
        {
            var sink = new _(observer, cancel);
            setSink(sink);
            return _source.SubscribeSafe(sink);
        }

        class _ : Sink<long?>, IObserver<long?>
        {
            private long _sum;

            public _(IObserver<long?> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                _sum = 0L;
            }

            public void OnNext(long? value)
            {
                if (value != null)
                    _sum += value.Value;
            }

            public void OnError(Exception error)
            {
                _observer.OnError(error);
                base.Dispose();
            }

            public void OnCompleted()
            {
                _observer.OnNext(_sum);
                _observer.OnCompleted();
                base.Dispose();
            }
        }
    }
}