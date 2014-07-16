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
using System.Runtime.WootzJs;
using System.Threading.Tasks;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class AsyncTests : TestFixture
    {
        private bool basicTestAsync;
        private bool basicTestTaskAsync;

        [Test]
        public void BasicTest()
        {
            BasicTestAsync();
            AssertTrue(basicTestAsync);
        }

        async void BasicTestAsync()
        {
            basicTestAsync = true;
        }

        [Test]
        public void BasicTestTask()
        {
            BasicTestTaskAsync();
            AssertTrue(basicTestTaskAsync);
        }

        async Task BasicTestTaskAsync()
        {
            basicTestTaskAsync = true;
        }

        [Test]
        public async Task BasicTestTaskT()
        {
//            await BasicTestTaskAsync();
            var value = await BasicTestTaskTAsync();
            AssertEquals(value, 5);
        }

        async Task<int> BasicTestTaskTAsync()
        {
            return 5;
        }

        [Test]
        public async Task TrueAsyncTestTaskT()
        {
            var taskCompletionSource = new TaskCompletionSource<int>();
            Jsni.setTimeout(() => taskCompletionSource.SetResult(4), 0);
            var value = await taskCompletionSource.Task;
            AssertEquals(value, 4);
        }

        [Test]
        public async void IfStatementTrue()
        {
            int i = 5;
            if (true)
            {
                i = 6;
            }
            AssertEquals(i, 6);
        }

        [Test]
        public async void IfStatementFalse()
        {
            int i = 5;
            if (false)
            {
                i = 6;
            }
            AssertEquals(i, 5);
        }

        [Test]
        public async void IfElseTrue()
        {
            int i = 5;
            if (true) 
                i = 6;
            else 
                i = 7;

            AssertEquals(i, 6);
        }

        [Test]
        public async void IfElseFalse()
        {
            int i = 5;
            if (false) 
                i = 6;
            else 
                i = 7;

            AssertEquals(i, 7);
        }

        [Test]
        public async void WhileLoop()
        {
            var i = 0;
            while (i < 5)
            {
                i++;
            }
            AssertEquals(i, 5);
        }

        [Test]
        public async void ForLoop()
        {
            var x = 0;
            for (var i = 0; i < 5; i++)
            {
                x++;
            }
            AssertEquals(x, 5);
        }

        [Test]
        public async void ForeachLoop()
        {
            var items = new[] { "1", "2", "3" };
            var s = "";
            foreach (var item in items)
            {
                s += item;
            }
            AssertEquals(s, "123");
        }

        [Test]
        public async void TryCatch()
        {
            bool flag = false;

            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                flag = true;
            }
            AssertTrue(flag);
        }

        [Test]
        public async Task TryCatchTrueAsync()
        {
            var taskCompletionSource = new TaskCompletionSource<int>();
            Jsni.setTimeout(() => taskCompletionSource.SetResult(4), 0);

            bool flag = false;

            try
            {
                await taskCompletionSource.Task;
                throw new Exception();
            }
            catch (Exception ex)
            {
                flag = true;
            }
            AssertTrue(flag);
        }

        [Test]
        public async Task TryFinally()
        {
            var flag = false;
            try
            {
            }
            finally
            {
                flag = true;
            }
            AssertTrue(flag);
        }

        [Test]
        public async Task TryFinallyThrowsException()
        {
            var flag = false;
            try
            {
                try
                {
                    throw new Exception();
                }
                finally
                {
                    flag = true;
                }
                AssertTrue(false);
            }
            catch (Exception e)
            {
                AssertTrue(true);
            }
            AssertTrue(flag);
        }

        [Test]
        public async Task Switch()
        {
            string value = null;
            string expression = "foo";
            switch (expression)
            {
                case "bar":
                    value = "abar";
                    break;
                case "foo":
                    value = "afoo";
                    break;
            }
            AssertEquals(value, "afoo");
        }

        [Test]
        public async Task BreakForLoop()
        {
            var counter = 0;
            for (var i = 0; i < 10; i++)
            {
                counter++;
                if (i == 1)
                    break;
            }
            AssertEquals(counter, 2);
        }

        [Test]
        public async Task ContinueForLoop()
        {
            var counter = 0;
            for (var i = 0; i < 10; i++)
            {
                if (i % 2 == 1)
                    continue;
                counter++;
            }
            AssertEquals(counter, 5);
        }
        
        [Test]
        public async Task UsingDeclare()
        {
            TestDisposable disposed;
            using (var disposable = new TestDisposable())
            {
                disposed = disposable;
            }
            AssertTrue(disposed.Disposed);
        }
        
        [Test]
        public async Task UsingDeclareWithException()
        {
            TestDisposable disposed = null;
            try
            {
                using (var disposable = new TestDisposable())
                {
                    disposed = disposable;
                    throw new Exception();
                }                
                AssertTrue(false);
            }
            catch (Exception ex) 
            {
                AssertTrue(true);
            }
            AssertTrue(disposed.Disposed);
        }

        class TestDisposable : IDisposable
        {
            private bool disposed;

            public void Dispose()
            {
                disposed = true;
            }

            public bool Disposed
            {
                get { return disposed; }
            }
        }
    }
}