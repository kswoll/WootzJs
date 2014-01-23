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

namespace System.Collections
{
    /// <summary>
    /// Supports the structural comparison of collection objects.
    /// </summary>
    public interface IStructuralComparable
    {
        /// <summary>
        /// Determines whether the current collection object precedes, occurs in the same position as, or follows another object in the sort order.
        /// </summary>
        /// 
        /// <returns>
        /// An integer that indicates the relationship of the current collection object to <paramref name="other"/>, as shown in the following table.Return valueDescription-1The current instance precedes <paramref name="other"/>.0The current instance and <paramref name="other"/> are equal.1The current instance follows <paramref name="other"/>.
        /// </returns>
        /// <param name="other">The object to compare with the current instance.</param><param name="comparer">An object that compares members of the current collection object with the corresponding members of <paramref name="other"/>.</param><exception cref="T:System.ArgumentException">This instance and <paramref name="other"/> are not the same type.</exception>
        int CompareTo(object other, IComparer comparer);
    }
}
