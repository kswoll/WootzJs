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

using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// Defines a key/value pair that can be set or retrieved.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam><typeparam name="TValue">The type of the value.</typeparam><filterpriority>1</filterpriority>
    public struct KeyValuePair<TKey, TValue>
    {
        private TKey key;
        private TValue value;

        /// <summary>
        /// Gets the key in the key/value pair.
        /// </summary>
        /// 
        /// <returns>
        /// A <paramref name="TKey"/> that is the key of the <see cref="T:System.Collections.Generic.KeyValuePair`2"/>.
        /// </returns>
        public TKey Key
        {
            get { return this.key; }
        }

        /// <summary>
        /// Gets the value in the key/value pair.
        /// </summary>
        /// 
        /// <returns>
        /// A <paramref name="TValue"/> that is the value of the <see cref="T:System.Collections.Generic.KeyValuePair`2"/>.
        /// </returns>
        public TValue Value
        {
            get { return this.value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Collections.Generic.KeyValuePair`2"/> structure with the specified key and value.
        /// </summary>
        /// <param name="key">The object defined in each key/value pair.</param><param name="value">The definition associated with <paramref name="key"/>.</param>
        public KeyValuePair(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }

        /// <summary>
        /// Returns a string representation of the <see cref="T:System.Collections.Generic.KeyValuePair`2"/>, using the string representations of the key and value.
        /// </summary>
        /// 
        /// <returns>
        /// A string representation of the <see cref="T:System.Collections.Generic.KeyValuePair`2"/>, which includes the string representations of the key and value.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append('[');
            if (this.Key != null)
                sb.Append(this.Key.ToString());
            sb.Append(", ");
            if (this.Value != null)
                sb.Append(this.Value.ToString());
            sb.Append(']');
            return sb.ToString();
        }
    }
}
