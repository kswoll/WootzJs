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
    /// <summary>
    /// Represents a globally unique identifier (GUID).
    /// </summary>
    /// <filterpriority>1</filterpriority>
    public struct Guid : IFormattable, IComparable, IComparable<Guid>, IEquatable<Guid>
    {
        private string value;

        public static Guid NewGuid()
        {
/*
            var pattern = "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".As<JsString>();
            pattern = pattern.replace(Jsni.regex("[xy]", "g"), Jsni.function(found =>
            {
                var r = Math
            }));

            'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
    var r = Math.random()*16|0, v = c == 'x' ? r : (r&0x3|0x8);
    return v.toString(16);
});
*/
            return default(Guid);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return value;
        }

        public int CompareTo(object obj)
        {
            return value.CompareTo(((Guid)obj).value);
        }

        public int CompareTo(Guid other)
        {
            return value.CompareTo(other.value);
        }

        public bool Equals(Guid other)
        {
            return value == other.value;
        }
    }
}