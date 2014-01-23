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
    /// Enumerates the elements of a nongeneric dictionary.
    /// </summary>
    /// <filterpriority>2</filterpriority>
    public interface IDictionaryEnumerator : IEnumerator
    {
        /// <summary>
        /// Gets the key of the current dictionary entry.
        /// </summary>
        /// 
        /// <returns>
        /// The key of the current element of the enumeration.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.IDictionaryEnumerator"/> is positioned before the first entry of the dictionary or after the last entry. </exception><filterpriority>2</filterpriority>
        object Key { get; }

        /// <summary>
        /// Gets the value of the current dictionary entry.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current element of the enumeration.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.IDictionaryEnumerator"/> is positioned before the first entry of the dictionary or after the last entry. </exception><filterpriority>2</filterpriority>
        object Value { get; }

        /// <summary>
        /// Gets both the key and the value of the current dictionary entry.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Collections.DictionaryEntry"/> containing both the key and the value of the current dictionary entry.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.IDictionaryEnumerator"/> is positioned before the first entry of the dictionary or after the last entry. </exception><filterpriority>2</filterpriority>
        DictionaryEntry Entry { get; }
    }
}
