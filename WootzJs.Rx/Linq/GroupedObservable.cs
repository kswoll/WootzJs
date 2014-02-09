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

using System.Reactive.Disposables;

namespace System.Reactive.Linq
{
    class GroupedObservable<TKey, TElement> : ObservableBase<TElement>, IGroupedObservable<TKey, TElement>
    {
        private readonly TKey _key;
        private readonly IObservable<TElement> _subject;
        private readonly RefCountDisposable _refCount;

        public GroupedObservable(TKey key, ISubject<TElement> subject, RefCountDisposable refCount)
        {
            _key = key;
            _subject = subject;
            _refCount = refCount;
        }

        public GroupedObservable(TKey key, ISubject<TElement> subject)
        {
            _key = key;
            _subject = subject;
        }

        public TKey Key
        {
            get { return _key; }
        }

        protected override IDisposable SubscribeCore(IObserver<TElement> observer)
        {
            if (_refCount != null)
            {
                //
                // [OK] Use of unsafe Subscribe: called on a known subject implementation.
                //
                var release = _refCount.GetDisposable();
                var subscription = _subject.Subscribe/*Unsafe*/(observer);
                return new CompositeDisposable(release, subscription);
            }
            else
            {
                //
                // [OK] Use of unsafe Subscribe: called on a known subject implementation.
                //
                return _subject.Subscribe/*Unsafe*/(observer);
            }
        }
    }
}