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
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class TryTests
    {
        [Test]
        public void ExceptionCaught()
        {
            try
            {
                throw new Exception();
                Assert.AssertTrue(false);
            }
            catch (Exception e)
            {
                Assert.AssertTrue(true);
            }
        }
         
        [Test]
        public void FinallyExecuted()
        {
            bool success = false;
            try
            {
                try
                {
                    throw new Exception();
                }
                finally
                {
                    success = true;
                }
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch (Exception e)
            {
            }
            Assert.AssertTrue(success);
        }
         
        [Test]
        public void NakedCatchClause()
        {
            try
            {
                throw new Exception();
                Assert.AssertTrue(false);
            }
            catch 
            {
                Assert.AssertTrue(true);
            }
        }
/*
         
        [Js(Inline = true)]
        public void MultipleCatchClauses()
        {
            QUnit.RunTest("TryTests.MultipleCatchClauses", () =>
            {
                try
                {
                    throw new Exception();
                    QUnit.IsTrue(false);
                }
                catch 
                {
                    QUnit.IsTrue(true);
                }
           });
        }
*/
    }
}
