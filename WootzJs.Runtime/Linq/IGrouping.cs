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

using System.Collections;
using System.Collections.Generic;

namespace System.Linq
{
    /// <summary>
    /// Represents a collection of objects that have a common key.
    /// </summary>
    /// <typeparam name="TKey">The type of the key of the <see cref="T:System.Linq.IGrouping`2"/>.This type
    /// parameter is covariant. That is, you can use either the type you specified or any type that is more 
    /// derived. For more information about covariance and contravariance, see Covariance and Contravariance 
    /// in Generics.</typeparam>
    /// <typeparam name="TElement">The type of the values in the <see cref="T:System.Linq.IGrouping`2"/>.</typeparam>
    public interface IGrouping<out TKey, out TElement> : IEnumerable<TElement>
    {
        /// <summary>
        /// Gets the key of the <see cref="T:System.Linq.IGrouping`2"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The key of the <see cref="T:System.Linq.IGrouping`2"/>.
        /// </returns>
        TKey Key { get; }
    }
}