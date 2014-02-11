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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace WootzJs.Rx.Tests.Subjects
{
    [TestFixture]
    public class SubjectTest
    {
        [Test]
        public void OnNext()
        {
            var subject = new Subject<TestEvent>();
            bool flagged = false;
            subject.Subscribe(x => flagged = true);
            subject.OnNext(new TestEvent());
            QUnit.IsTrue(flagged);
        }

        [Test]
        public void Where()
        {
            var subject = new Subject<TestEvent>();
            int counter = 0;
            subject
                .Where(x => x.Key == "one")
                .Subscribe(x => counter++);
            subject.OnNext(new TestEvent { Key = "zero" });
            subject.OnNext(new TestEvent { Key = "one" });
            subject.OnNext(new TestEvent { Key = "two" });
            QUnit.AreEqual(counter, 1);
        }

        [Test]
        public void Select()
        {
            var subject = new Subject<TestEvent>();
            int counter = 0;
            subject
                .Select(x => x.Key)
                .Subscribe(x => counter += x.Length);
            subject.OnNext(new TestEvent { Key = "zero" });
            subject.OnNext(new TestEvent { Key = "one" });
            subject.OnNext(new TestEvent { Key = "two" });
            QUnit.AreEqual(counter, 10);
        }

        [Test]
        public void SelectMany()
        {
            var subject = new Subject<TestEvent>();
            int counter = 0;
            subject
                .SelectMany(x => x.Ints)
                .Subscribe(x => counter += x);
            subject.OnNext(new TestEvent { Ints = new[] { 1, 2 } });
            subject.OnNext(new TestEvent { Ints = new[] { 3, 4 } });
            QUnit.AreEqual(counter, 10);
        }

        [Test]
        public void GroupBy()
        { 
            var subject = new Subject<TestEvent>();
            int one = 0;
            int two = 0;
            var group = subject.GroupBy(x => x.Key);

            group.Where(x => x.Key == "one").SelectMany(x => x).Subscribe(x => one += x.Value);
            group.Where(x => x.Key == "two").SelectMany(x => x).Subscribe(x => two += x.Value);
            subject.OnNext(new TestEvent { Key = "one", Value = 1 });
            subject.OnNext(new TestEvent { Key = "one", Value = 5 });
            subject.OnNext(new TestEvent { Key = "two", Value = 8 });
            QUnit.AreEqual(one, 6);
            QUnit.AreEqual(two, 8);
        }

        public class TestEvent
        {
            public string Key { get; set; }
            public int Value { get; set; }
            public int[] Ints { get; set; }
        }
    }
}