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
    /// 
    /// </summary>
    public class Console
    {
        /// <summary>
        /// Writes the specified string value, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write. </param><exception cref="T:System.IO.IOException">An I/O error occurred. </exception><filterpriority>1</filterpriority>
        public static void WriteLine(string value)
        {
            Jsni.invoke(Jsni.member(Jsni.reference("console"), "log"), value.As<JsString>());
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write. </param><exception cref="T:System.IO.IOException">An I/O error occurred. </exception><filterpriority>1</filterpriority>
        public static void WriteLine(object value)
        {
            if (value == null)
                WriteLine("null");
            else
                WriteLine(value.ToString());
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects, followed by the current line terminator, to the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg">An array of objects to write using <paramref name="format"/>. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="format"/> or <paramref name="arg"/> is null. </exception><exception cref="T:System.FormatException">The format specification in <paramref name="format"/> is invalid. </exception>
        public static void WriteLine(string format, params object[] arg)
        {
            if (arg == null)
                WriteLine(format);
            else
                WriteLine(string.Format(format, arg));
        }
    }
}