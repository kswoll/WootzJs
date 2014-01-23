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

using System.Collections.Generic;
using System.Reflection;

namespace System.Collections.Generic
{
    /// <summary>
    /// Provides a base class for implementations of the <see cref="T:System.Collections.Generic.IComparer`1"/> generic interface.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam><filterpriority>1</filterpriority>
    public abstract class Comparer<T> : IComparer, IComparer<T>
    {
        private static volatile Comparer<T> defaultComparer;

        /// <summary>
        /// Returns a default sort order comparer for the type specified by the generic argument.
        /// </summary>
        /// 
        /// <returns>
        /// An object that inherits <see cref="T:System.Collections.Generic.Comparer`1"/> and serves as a sort order comparer for type <paramref name="T"/>.
        /// </returns>
        public static Comparer<T> Default
        {
            get
            {
                Comparer<T> comparer = defaultComparer;
                if (comparer == null)
                {
                    comparer = CreateComparer();
                    defaultComparer = comparer;
                }
                return comparer;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Collections.Generic.Comparer`1"/> class.
        /// </summary>
        protected Comparer()
        {
        }

        /// <summary>
        /// Creates a comparer by using the specified comparison.
        /// </summary>
        /// 
        /// <returns>
        /// The new comparer.
        /// </returns>
        /// <param name="comparison">The comparison to use.</param>
        public static Comparer<T> Create(Comparison<T> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException("comparison");
            else
                return new ComparisonComparer<T>(comparison);
        }

        private static Comparer<T> CreateComparer()
        {
            var genericParameter1 = typeof(T);
            if (typeof (IComparable<T>).IsAssignableFrom(genericParameter1))
                return (Comparer<T>)Activator.CreateInstance(typeof(GenericComparer<int>), genericParameter1);
            return new ObjectComparer<T>();
        }

        /// <summary>
        /// When overridden in a derived class, performs a comparison of two objects of the same type and returns a value indicating whether one object is less than, equal to, or greater than the other.
        /// </summary>
        /// 
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table.Value Meaning Less than zero <paramref name="x"/> is less than <paramref name="y"/>.Zero <paramref name="x"/> equals <paramref name="y"/>.Greater than zero <paramref name="x"/> is greater than <paramref name="y"/>.
        /// </returns>
        /// <param name="x">The first object to compare.</param><param name="y">The second object to compare.</param><exception cref="T:System.ArgumentException">Type <paramref name="T"/> does not implement either the <see cref="T:System.IComparable`1"/> generic interface or the <see cref="T:System.IComparable"/> interface.</exception>
        public abstract int Compare(T x, T y);

        int IComparer.Compare(object x, object y)
        {
            if (x == null)
            {
                return y != null ? -1 : 0;
            }
            else
            {
                if (y == null)
                    return 1;
                if (x is T && y is T)
                    return this.Compare((T)x, (T)y);
                throw new ArgumentException("Argument_InvalidArgumentForComparison");
            }
        }
    }

    internal class ComparisonComparer<T> : Comparer<T>
    {
        private readonly Comparison<T> _comparison;

        public ComparisonComparer(Comparison<T> comparison)
        {
            _comparison = comparison;
        }

        public override int Compare(T x, T y)
        {
            return _comparison(x, y);
        }
    }
}
