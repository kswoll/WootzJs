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

using System.Runtime.WootzJs;

namespace System
{
    public struct DateTime : IComparable, IFormattable, IConvertible, IComparable<DateTime>, IEquatable<DateTime>
    {
        private JsDate value;

        internal DateTime(JsDate value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the date component of this instance.
        /// </summary>
        /// 
        /// <returns>
        /// A new object with the same date as this instance, and the time value set to 12:00:00 midnight 
        /// (00:00:00).
        /// </returns>
        public DateTime Date
        {
            get
            {
                var clone = new JsDate(value.getTime());
                clone.setHours(0);
                clone.setMinutes(0);
                clone.setSeconds(0);
                clone.setMilliseconds(0);
                return new DateTime(clone);
            }
        }

        /// <summary>
        /// Gets the day of the month represented by this instance.
        /// </summary>
        /// 
        /// <returns>
        /// The day component, expressed as a value between 1 and 31.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public int Day
        {
            get { return value.getDate(); }
        }

        /// <summary>
        /// Gets the day of the week represented by this instance.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerated constant that indicates the day of the week of this <see cref="T:System.DateTime"/> value.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public DayOfWeek DayOfWeek
        {
            get { return (DayOfWeek)value.getDay(); }
        }
    }
}