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
    internal class NopObserver<T> : IObserver<T>
    {
        public static readonly IObserver<T> Instance = new NopObserver<T>();

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(T value)
        {
        }
    }

    internal class DoneObserver<T> : IObserver<T>
    {
        public static readonly IObserver<T> Completed = new DoneObserver<T>();

        public Exception Exception { get; set; }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(T value)
        {
        }
    }

    internal class DisposedObserver<T> : IObserver<T>
    {
        public static readonly IObserver<T> Instance = new DisposedObserver<T>();

        public void OnCompleted()
        {
            throw new ObjectDisposedException("");
        }

        public void OnError(Exception error)
        {
            throw new ObjectDisposedException("");
        }

        public void OnNext(T value)
        {
            throw new ObjectDisposedException("");
        }
    }

    internal class Observer<T> : IObserver<T>
    {
        private readonly ImmutableList<IObserver<T>> _observers;

        public Observer(ImmutableList<IObserver<T>> observers)
        {
            _observers = observers;
        }

        public void OnCompleted()
        {
            foreach (var observer in _observers.Data)
                observer.OnCompleted();
        }

        public void OnError(Exception error)
        {
            foreach (var observer in _observers.Data)
                observer.OnError(error);
        }

        public void OnNext(T value)
        {
            foreach (var observer in _observers.Data)
                observer.OnNext(value);
        }

        internal IObserver<T> Add(IObserver<T> observer)
        {
            return new Observer<T>(_observers.Add(observer));
        }

        internal IObserver<T> Remove(IObserver<T> observer)
        {
            var i = Array.IndexOf(_observers.Data, observer);
            if (i < 0)
                return this;

            if (_observers.Data.Length == 2)
            {
                return _observers.Data[1 - i];
            }
            else
            {
                return new Observer<T>(_observers.Remove(observer));
            }
        }
    }
}