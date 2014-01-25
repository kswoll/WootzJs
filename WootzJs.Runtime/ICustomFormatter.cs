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

namespace System
{
    /// <summary>
    /// Defines a method that supports custom formatting of the value of an object.
    /// </summary>
    /// <filterpriority>2</filterpriority>
    public interface ICustomFormatter
    {
        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
        /// </summary>
        /// 
        /// <returns>
        /// The string representation of the value of <paramref name="arg"/>, formatted as specified by <paramref name="format"/> and <paramref name="formatProvider"/>.
        /// </returns>
        /// <param name="format">A format string containing formatting specifications. </param><param name="arg">An object to format. </param><param name="formatProvider">An object that supplies format information about the current instance. </param><filterpriority>2</filterpriority>
        string Format(string format, object arg, IFormatProvider formatProvider);
    }
}