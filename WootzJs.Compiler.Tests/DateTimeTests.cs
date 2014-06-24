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
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class DateTimeTests : TestFixture
    {
        [Test]
        public void CreateDate()
        {
            var date = new DateTime(2014, 1, 2, 15, 3, 5, 30);
            AssertEquals(date.Year, 2014);
            AssertEquals(date.Month, 1);
            AssertEquals(date.Day, 2);
            AssertEquals(date.Hour, 15);
            AssertEquals(date.Minute, 3);
            AssertEquals(date.Second, 5);
            AssertEquals(date.Millisecond, 30);
        }

        [Test]
        public void AddMilliseconds()
        {
            var originalDate = new DateTime(2012, 1, 1, 0, 0, 0, 995);
            var newDate = originalDate.AddMilliseconds(10);
            
            AssertEquals(newDate.Second, 1);
            AssertEquals(newDate.Millisecond, 5);
        }

        [Test]
        public void AddSeconds()
        {
            var originalDate = new DateTime(2012, 1, 1, 0, 0, 55, 0);
            var newDate = originalDate.AddSeconds(10);
            
            AssertEquals(newDate.Minute, 1);
            AssertEquals(newDate.Second, 5);            
        }

        [Test]
        public void AddMinutes()
        {
            var originalDate = new DateTime(2012, 1, 1, 0, 55, 0, 0);
            var newDate = originalDate.AddMinutes(10);
            
            AssertEquals(newDate.Hour, 1);
            AssertEquals(newDate.Minute, 5);            
        }

        [Test]
        public void AddHours()
        {
            var originalDate = new DateTime(2012, 1, 1, 23, 0, 0, 0);
            var newDate = originalDate.AddHours(2);
            
            AssertEquals(newDate.Hour, 1);
            AssertEquals(newDate.Day, 2);            
        }

        [Test]
        public void AddDays()
        {
            var originalDate = new DateTime(2012, 1, 31, 0, 0, 0, 0);
            var newDate = originalDate.AddDays(1);
            
            AssertEquals(newDate.Day, 1);
            AssertEquals(newDate.Month, 2);            
        }

        [Test]
        public void AddMonths()
        {
            var originalDate = new DateTime(2012, 12, 1, 0, 0, 0, 0);
            var newDate = originalDate.AddMonths(1);
            
            AssertEquals(newDate.Month, 1);
            AssertEquals(newDate.Year, 2013);                        
        }

        [Test]
        public void AddYears()
        {
            var originalDate = new DateTime(2012, 1, 1, 0, 0, 0, 0);
            var newDate = originalDate.AddYears(1);
            
            AssertEquals(newDate.Year, 2013);
        }
    }
}