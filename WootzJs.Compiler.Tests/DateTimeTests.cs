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
    [TestFixture]
    public class DateTimeTests
    {
        [Test]
        public void CreateDate()
        {
            var date = new DateTime(2014, 1, 2, 15, 3, 5, 30);
            date.Year.AssertEquals(2014);
            date.Month.AssertEquals(1);
            date.Day.AssertEquals(2);
            date.Hour.AssertEquals(15);
            date.Minute.AssertEquals(3);
            date.Second.AssertEquals(5);
            date.Millisecond.AssertEquals(30);
        }

        [Test]
        public void AddMilliseconds()
        {
            var originalDate = new DateTime(2012, 1, 1, 0, 0, 0, 995);
            var newDate = originalDate.AddMilliseconds(10);
            
            newDate.Second.AssertEquals(1);
            newDate.Millisecond.AssertEquals(5);
        }

        [Test]
        public void AddSeconds()
        {
            var originalDate = new DateTime(2012, 1, 1, 0, 0, 55, 0);
            var newDate = originalDate.AddSeconds(10);
            
            newDate.Minute.AssertEquals(1);
            newDate.Second.AssertEquals(5);            
        }

        [Test]
        public void AddMinutes()
        {
            var originalDate = new DateTime(2012, 1, 1, 0, 55, 0, 0);
            var newDate = originalDate.AddMinutes(10);
            
            newDate.Hour.AssertEquals(1);
            newDate.Minute.AssertEquals(5);            
        }

        [Test]
        public void AddHours()
        {
            var originalDate = new DateTime(2012, 1, 1, 23, 0, 0, 0);
            var newDate = originalDate.AddHours(2);
            
            newDate.Hour.AssertEquals(1);
            newDate.Day.AssertEquals(2);            
        }

        [Test]
        public void AddDays()
        {
            var originalDate = new DateTime(2012, 1, 31, 0, 0, 0, 0);
            var newDate = originalDate.AddDays(1);
            
            newDate.Day.AssertEquals(1);
            newDate.Month.AssertEquals(2);            
        }

        [Test]
        public void AddMonths()
        {
            var originalDate = new DateTime(2012, 12, 1, 0, 0, 0, 0);
            var newDate = originalDate.AddMonths(1);
            
            newDate.Month.AssertEquals(1);
            newDate.Year.AssertEquals(2013);                        
        }

        [Test]
        public void AddYears()
        {
            var originalDate = new DateTime(2012, 1, 1, 0, 0, 0, 0);
            var newDate = originalDate.AddYears(1);
            
            newDate.Year.AssertEquals(2013);
        }
    }
}