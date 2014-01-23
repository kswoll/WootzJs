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

namespace System.Collections
{
    /// <summary>
    /// Defines a dictionary key/value pair that can be set or retrieved.
    /// </summary>
    /// <filterpriority>1</filterpriority>
    public struct DictionaryEntry
    {
        private object _key;
        private object _value;

        /// <summary>
        /// Gets or sets the key in the key/value pair.
        /// </summary>
        /// 
        /// <returns>
        /// The key in the key/value pair.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public object Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        /// <summary>
        /// Gets or sets the value in the key/value pair.
        /// </summary>
        /// 
        /// <returns>
        /// The value in the key/value pair.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public object Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        /// <summary>
        /// Initializes an instance of the <see cref="T:System.Collections.DictionaryEntry"/> type with the specified key and value.
        /// </summary>
        /// <param name="key">The object defined in each key/value pair. </param><param name="value">The definition associated with <paramref name="key"/>. </param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null and the .NET Framework version is 1.0 or 1.1. </exception>
        public DictionaryEntry(object key, object value)
        {
            this._key = key;
            this._value = value;
        }
    }
}
