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

        [Test]
        public void SingleDigitMonth()
        {
            var time = new DateTime(2014, 1, 1);
            var s = time.ToString("M");
            AssertEquals(s, "1");
        }

        [Test]
        public void ParseSingleDigitMonth()
        {
            var s = "1";
            var time = DateTime.ParseExact(s, "M");
            AssertEquals(time, new DateTime(0, 1, 0));
        }

        [Test]
        public void SingleDigitMonthWithTwoDigits()
        {
            var time = new DateTime(2014, 12, 1);
            var s = time.ToString("M");
            AssertEquals(s, "12");
        }

        [Test]
        public void ParseSingleDigitMonthWithTwoDigits()
        {
            var s = "12";
            var time = DateTime.ParseExact(s, "M");
            AssertEquals(time, new DateTime(0, 12, 0));
        }

        [Test]
        public void TwoDigitMonth()
        {
            var time = new DateTime(2014, 1, 1);
            var s = time.ToString("MM");
            AssertEquals(s, "01");
        }

        [Test]
        public void ParseTwoDigitMonth()
        {
            var s = "01";
            var time = DateTime.ParseExact(s, "MM");
            AssertEquals(time, new DateTime(0, 1, 0));
        }

        [Test]
        public void TwoDigitMonthWithTwoDigits()
        {
            var time = new DateTime(2014, 12, 1);
            var s = time.ToString("MM");
            AssertEquals(s, "12");
        }

        [Test]
        public void ParseTwoDigitMonthWithTwoDigits()
        {
            var s = "12";
            var time = DateTime.ParseExact(s, "MM");
            AssertEquals(time, new DateTime(0, 12, 0));
        }

        [Test]
        public void SingleDigitDay()
        {
            var time = new DateTime(2014, 12, 3);
            var s = time.ToString("d");
            AssertEquals(s, "3");
        }

        [Test]
        public void ParseSingleDigitDay()
        {
            var s = "3";
            var time = DateTime.ParseExact(s, "d");
            AssertEquals(time, new DateTime(0, 0, 3));
        }

        [Test]
        public void SingleDigitDayTwoDigit()
        {
            var time = new DateTime(2014, 12, 29);
            var s = time.ToString("d");
            AssertEquals(s, "29");
        }

        [Test]
        public void ParseSingleDigitDayTwoDigit()
        {
            var s = "29";
            var time = DateTime.ParseExact(s, "d");
            AssertEquals(time, new DateTime(0, 0, 29));
        }

        [Test]
        public void TwoDigitDay()
        {
            var time = new DateTime(2014, 12, 3);
            var s = time.ToString("dd");
            AssertEquals(s, "03");
        }

        [Test]
        public void ParseTwoDigitDay()
        {
            var s = "03";
            var time = DateTime.ParseExact(s, "dd");
            AssertEquals(time, new DateTime(0, 0, 3));
        }

        [Test]
        public void TwoDigitDayTwoDigit()
        {
            var time = new DateTime(2014, 12, 29);
            var s = time.ToString("dd");
            AssertEquals(s, "29");
        }

        [Test]
        public void ParseTwoDigitDayTwoDigit()
        {
            var s = "29";
            var time = DateTime.ParseExact(s, "dd");
            AssertEquals(time, new DateTime(0, 0, 29));
        }

        [Test]
        public void SingleDigitYear()
        {
            var time = new DateTime(2003, 12, 3);
            var s = time.ToString("y");
            AssertEquals(s, "3");
        }

        [Test]
        public void ParseSingleDigitYear()
        {
            var s = "3";
            var time = DateTime.ParseExact(s, "y");
            AssertEquals(time, new DateTime(2003, 0, 0));
        }

        [Test]
        public void SingleDigitYearTwoDigit()
        {
            var time = new DateTime(2014, 12, 29);
            var s = time.ToString("y");
            AssertEquals(s, "14");
        }

        [Test]
        public void ParseSingleDigitYearTwoDigit()
        {
            var s = "14";
            var time = DateTime.ParseExact(s, "y");
            AssertEquals(time, new DateTime(2014, 0, 0));
        }

        [Test]
        public void ParseTwoDigitYear()
        {
            var s = "03";
            var time = DateTime.ParseExact(s, "yy");
            AssertEquals(time, new DateTime(2003, 0, 0));
        }

        [Test]
        public void TwoDigitYearTwoDigit()
        {
            var time = new DateTime(2014, 12, 29);
            var s = time.ToString("yy");
            AssertEquals(s, "14");
        }

        [Test]
        public void ParseTwoDigitYearTwoDigit()
        {
            var s = "14";
            var time = DateTime.ParseExact(s, "yy");
            AssertEquals(time, new DateTime(2014, 0, 0));
        }

        [Test]
        public void FourDigitYear()
        {
            var time = new DateTime(2003, 12, 3);
            var s = time.ToString("yyyy");
            AssertEquals(s, "2003");
        }

        [Test]
        public void ParseFourDigitYear()
        {
            var s = "2003";
            var time = DateTime.ParseExact(s, "yyyy");
            AssertEquals(time, new DateTime(2003, 0, 0));
        }

        [Test]
        public void SingleDigitHour()
        {
            var time = new DateTime(2014, 12, 3, 17, 3, 10);
            var s = time.ToString("h");
            AssertEquals(s, "5");
        }

        [Test]
        public void ParseSingleDigitHour()
        {
            var s = "5";
            var time = DateTime.ParseExact(s, "h");
            AssertEquals(time, new DateTime(0, 0, 0, 5, 0, 0));
        }

        [Test]
        public void SingleDigitHourTwoDigit()
        {
            var time = new DateTime(2014, 12, 3, 22, 3, 10);
            var s = time.ToString("h");
            AssertEquals(s, "10");
        }

        [Test]
        public void ParseSingleDigitHourTwoDigit()
        {
            var s = "10";
            var time = DateTime.ParseExact(s, "h");
            AssertEquals(time, new DateTime(0, 0, 0, 10, 0, 0));
        }

        [Test]
        public void TwoDigitHour()
        {
            var time = new DateTime(2014, 12, 3, 17, 3, 10);
            var s = time.ToString("hh");
            AssertEquals(s, "05");
        }

        [Test]
        public void ParseTwoDigitHour()
        {
            var s = "05";
            var time = DateTime.ParseExact(s, "hh");
            AssertEquals(time, new DateTime(0, 0, 0, 5, 0, 0));
        }

        [Test]
        public void TwoDigitHourTwoDigit()
        {
            var time = new DateTime(2014, 12, 3, 22, 3, 10);
            var s = time.ToString("hh");
            AssertEquals(s, "10");
        }

        [Test]
        public void ParseTwoDigitHourTwoDigit()
        {
            var s = "10";
            var time = DateTime.ParseExact(s, "hh");
            AssertEquals(time, new DateTime(0, 0, 0, 10, 0, 0));
        }

        [Test]
        public void SingleDigitMinute()
        {
            var time = new DateTime(2014, 12, 3, 17, 3, 10);
            var s = time.ToString("m");
            AssertEquals(s, "3");
        }

        [Test]
        public void ParseSingleDigitMinute()
        {
            var s = "3";
            var time = DateTime.ParseExact(s, "m");
            AssertEquals(time, new DateTime(0, 0, 0, 0, 3, 0));
        }

        [Test]
        public void SingleDigitMinuteTwoDigit()
        {
            var time = new DateTime(2014, 12, 3, 22, 13, 10);
            var s = time.ToString("m");
            AssertEquals(s, "13");
        }

        [Test]
        public void ParseSingleDigitMinuteTwoDigit()
        {
            var s = "13";
            var time = DateTime.ParseExact(s, "m");
            AssertEquals(time, new DateTime(0, 0, 0, 0, 13, 0));
        }

        [Test]
        public void TwoDigitMinute()
        {
            var time = new DateTime(2014, 12, 3, 17, 3, 10);
            var s = time.ToString("mm");
            AssertEquals(s, "03");
        }

        [Test]
        public void ParseTwoDigitMinute()
        {
            var s = "03";
            var time = DateTime.ParseExact(s, "mm");
            AssertEquals(time, new DateTime(0, 0, 0, 0, 3, 0));
        }

        [Test]
        public void TwoDigitMinuteTwoDigit()
        {
            var time = new DateTime(2014, 12, 3, 22, 13, 10);
            var s = time.ToString("mm");
            AssertEquals(s, "13");
        }

        [Test]
        public void ParseTwoDigitMinuteTwoDigit()
        {
            var s = "13";
            var time = DateTime.ParseExact(s, "mm");
            AssertEquals(time, new DateTime(0, 0, 0, 0, 13, 0));
        }

        [Test]
        public void SingleDigitSecond()
        {
            var time = new DateTime(2014, 12, 3, 17, 3, 4);
            var s = time.ToString("s");
            AssertEquals(s, "4");
        }

        [Test]
        public void ParseSingleDigitSecond()
        {
            var s = "4";
            var time = DateTime.ParseExact(s, "s");
            AssertEquals(time, new DateTime(0, 0, 0, 0, 0, 4));
        }

        [Test]
        public void SingleDigitSecondTwoDigit()
        {
            var time = new DateTime(2014, 12, 3, 22, 13, 14);
            var s = time.ToString("s");
            AssertEquals(s, "14");
        }

        [Test]
        public void ParseSingleDigitSecondTwoDigit()
        {
            var s = "14";
            var time = DateTime.ParseExact(s, "s");
            AssertEquals(time, new DateTime(0, 0, 0, 0, 0, 14));
        }

        [Test]
        public void TwoDigitSecond()
        {
            var time = new DateTime(2014, 12, 3, 17, 3, 4);
            var s = time.ToString("ss");
            AssertEquals(s, "04");
        }

        [Test]
        public void ParseTwoDigitSecond()
        {
            var s = "04";
            var time = DateTime.ParseExact(s, "ss");
            AssertEquals(time, new DateTime(0, 0, 0, 0, 0, 4));
        }

        [Test]
        public void TwoDigitSecondTwoDigit()
        {
            var time = new DateTime(2014, 12, 3, 22, 13, 14);
            var s = time.ToString("ss");
            AssertEquals(s, "14");
        }

        [Test]
        public void ParseTwoDigitSecondTwoDigit()
        {
            var s = "14";
            var time = DateTime.ParseExact(s, "ss");
            AssertEquals(time, new DateTime(0, 0, 0, 0, 0, 14));
        }

        [Test]
        public void TenthSecond()
        {
            var time = new DateTime(2014, 12, 3, 17, 3, 4, 342);
            var s = time.ToString("f");
            AssertEquals(s, "3");
        }

        [Test]
        public void ParseTenthSecond()
        {
            var s = "3";
            var time = DateTime.ParseExact(s, "f");
            AssertEquals(time, new DateTime(0, 0, 0, 0, 0, 0, 300));
        }

        [Test]
        public void HundredthSecond()
        {
            var time = new DateTime(2014, 12, 3, 17, 3, 4, 342);
            var s = time.ToString("ff");
            AssertEquals(s, "34");
        }

        [Test]
        public void ParseHundredthSecond()
        {
            var s = "342";
            var time = DateTime.ParseExact(s, "fff");
            AssertEquals(time, new DateTime(0, 0, 0, 0, 0, 0, 342));
        }

        [Test]
        public void Millisecond()
        {
            var time = new DateTime(2014, 12, 3, 17, 3, 4, 342);
            var s = time.ToString("fff");
            AssertEquals(s, "342");
        }

        [Test]
        public void ParseMillisecond()
        {
            var s = "34";
            var time = DateTime.ParseExact(s, "ff");
            AssertEquals(time, new DateTime(0, 0, 0, 0, 0, 0, 340));
        }

        [Test]
        public void AmSingleDigit()
        {
            var time = new DateTime(2014, 12, 3, 2, 13, 14);
            var s = time.ToString("t");
            AssertEquals(s, "A");
        }

        [Test]
        public void ParseAmSingleDigit()
        {
            var s = "12A";
            var time = DateTime.ParseExact(s, "ht");
            AssertEquals(time, new DateTime(0, 0, 0, 0, 0, 0));
        }

        [Test]
        public void PmSingleDigit()
        {
            var time = new DateTime(2014, 12, 3, 12, 13, 14);
            var s = time.ToString("t");
            AssertEquals(s, "P");
        }

        [Test]
        public void ParsePmSingleDigit()
        {
            var s = "12P";
            var time = DateTime.ParseExact(s, "ht");
            AssertEquals(time, new DateTime(0, 0, 0, 12, 0, 0));
        }

        [Test]
        public void Am()
        {
            var time = new DateTime(2014, 12, 3, 2, 13, 14);
            var s = time.ToString("tt");
            AssertEquals(s, "AM");
        }

        [Test]
        public void ParseAm()
        {
            var s = "2AM";
            var time = DateTime.ParseExact(s, "htt");
            AssertEquals(time, new DateTime(0, 0, 0, 2, 0, 0));
        }

        [Test]
        public void Pm()
        {
            var time = new DateTime(2014, 12, 3, 12, 13, 14);
            var s = time.ToString("tt");
            AssertEquals(s, "PM");
        }

        [Test]
        public void ParsePm()
        {
            var s = "2PM";
            var time = DateTime.ParseExact(s, "htt");
            AssertEquals(time, new DateTime(0, 0, 0, 14, 0, 0));
        }

        [Test]
        public void SpaceSeparator()
        {
            var time = new DateTime(2014, 12, 3, 12, 13, 14);
            var s = time.ToString("h m");
            AssertEquals(s, "12 13");            
        }

        [Test]
        public void ParseSpaceSeparator()
        {
            var s = "1 13";
            var time = DateTime.ParseExact(s, "h m");
            AssertEquals(time, new DateTime(0, 0, 0, 1, 13, 0));
        }

        [Test]
        public void EscapeSlash()
        {
            var time = new DateTime(2014, 12, 3, 12, 13, 14);
            var s = time.ToString("h\\\\m");
            AssertEquals(s, "12\\13");                        
        }

        [Test]
        public void ParseEscapeSlash()
        {
            var s = "1\\13";
            var time = DateTime.ParseExact(s, "h\\\\m");
            AssertEquals(time, new DateTime(0, 0, 0, 1, 13, 0));
        }

        [Test]
        public void ParseIso8601()
        {
            var s = "2014-09-13T00:17:00.553";
            var time = DateTime.ParseExact(s, "yyyy-MM-ddThh\\:mm\\:ss.fff");
            AssertEquals(time, new DateTime(2014, 9, 13, 0, 17, 0, 553));
        }
    }
}