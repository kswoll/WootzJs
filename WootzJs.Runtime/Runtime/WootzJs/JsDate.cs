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

namespace System.Runtime.WootzJs
{
    /// <summary>
    /// Corresponds to the built-in Javascript Date type.
    /// </summary>
    [Js(Name = "Date", Export = false)]
    public class JsDate : JsObject
    {
        public JsDate()
        {
        }

        public JsDate(long millisecondsSinceEpoch)
        {
        }

        public JsDate(string date)
        {
        }

        public JsDate(int year, int month, int day = 1, int hour = 0, int minute = 0, int second = 0, int millisecond = 0)
        {
        }

        public static extern long now();
        public static extern long parse(string date);
        public static extern long UTC(int year, int month, int day = 1, int hour = 0, int minute = 0, int second = 0, int millisecond = 0);

        public extern int getDate();
        public extern int getDay();
        public extern int getFullYear();
        public extern int getHours();
        public extern int getMilliseconds();
        public extern int getMinutes();
        public extern int getMonth();
        public extern int getSeconds();
        public extern long getTime();
        public extern int getTimezoneOffset();
        public extern int getUTCDate();
        public extern int getUTCDay();
        public extern int getUTCFullYear();
        public extern int getUTCHours();
        public extern int getUTCMilliseconds();
        public extern int getUTCMinutes();
        public extern int getUTCMonth();
        public extern int getUTCSeconds();
        public extern void setDate(int value);
        public extern void setFullYear(int value);
        public extern void setHours(int value);
        public extern void setMilliseconds(int value);
        public extern void setMinutes(int value);
        public extern void setMonth(int value);
        public extern void setSeconds(int value);
        public extern void setTime(long value);
        public extern void setUTCDate(int value);
        public extern void setUTCFullYear(int value);
        public extern void setUTCHours(int value);
        public extern void setUTCMilliseconds(int value);
        public extern void setUTCMinutes(int value);
        public extern void setUTCMonth(int value);
        public extern void setUTCSeconds(int value);
        public extern JsString toDateString();
        public extern JsString toISOString();
        public extern JsString toJSON();
        public extern JsString toGMTString();
        public extern JsString toLocaleDateString();
        public extern JsString toLocaleString();
        public extern JsString toLocaleTimeString();
        public extern JsString toTimeString();
        public extern JsString toUTCString();
        public extern JsDate valueOf();
        
        public static extern JsNumber operator -(JsDate left, JsDate right);
        public static extern JsNumber operator +(JsDate left, JsDate right);
    }
}