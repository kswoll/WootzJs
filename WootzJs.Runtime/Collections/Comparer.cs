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
using System.Globalization;

namespace System.Collections
{
    /// <summary>
    /// Compares two objects for equivalence, where string comparisons are case-sensitive.
    /// </summary>
    /// <filterpriority>2</filterpriority>
    public sealed class Comparer : IComparer
    {
        /// <summary>
        /// Represents an instance of <see cref="T:System.Collections.Comparer"/> that is associated with the <see cref="P:System.Threading.Thread.CurrentCulture"/> of the current thread. This field is read-only.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public static readonly Comparer Default = new Comparer(CultureInfo.CurrentCulture);

        /// <summary>
        /// Represents an instance of <see cref="T:System.Collections.Comparer"/> that is associated with <see cref="P:System.Globalization.CultureInfo.InvariantCulture"/>. This field is read-only.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public static readonly Comparer DefaultInvariant = new Comparer(CultureInfo.InvariantCulture);

        private CompareInfo m_compareInfo;
        private const string CompareInfoName = "CompareInfo";

        static Comparer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Collections.Comparer"/> class using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for the new <see cref="T:System.Collections.Comparer"/>. </param><exception cref="T:System.ArgumentNullException"><paramref name="culture"/> is null. </exception>
        public Comparer(CultureInfo culture)
        {
            if (culture == null)
                throw new ArgumentNullException("culture");
            this.m_compareInfo = culture.CompareInfo;
        }

        private Comparer()
        {
            this.m_compareInfo = (CompareInfo)null;
        }

        /// <summary>
        /// Performs a case-sensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// 
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="a"/> and <paramref name="b"/>, as shown in the following table.Value Meaning Less than zero <paramref name="a"/> is less than <paramref name="b"/>. Zero <paramref name="a"/> equals <paramref name="b"/>. Greater than zero <paramref name="a"/> is greater than <paramref name="b"/>.
        /// </returns>
        /// <param name="a">The first object to compare. </param><param name="b">The second object to compare. </param><exception cref="T:System.ArgumentException">Neither <paramref name="a"/> nor <paramref name="b"/> implements the <see cref="T:System.IComparable"/> interface.-or- <paramref name="a"/> and <paramref name="b"/> are of different types and neither one can handle comparisons with the other. </exception><filterpriority>2</filterpriority>
        public int Compare(object a, object b)
        {
            if (a == b)
                return 0;
            if (a == null)
                return -1;
            if (b == null)
                return 1;
            if (m_compareInfo != null)
            {
                var string1 = a as string;
                var string2 = b as string;
                if (string1 != null && string2 != null)
                    return m_compareInfo.Compare(string1, string2);
            }
            var comparable1 = a as IComparable;
            if (comparable1 != null)
                return comparable1.CompareTo(b);
            var comparable2 = b as IComparable;
            if (comparable2 != null)
                return -comparable2.CompareTo(a);
            else
                throw new ArgumentException("Argument_ImplementIComparable");
        }
    }

    internal class ComparisonComparer : IComparer
    {
        private readonly Comparison<object> _comparison;

        public ComparisonComparer(Comparison<object> comparison)
        {
            _comparison = comparison;
        }

        public int Compare(object x, object y)
        {
            return _comparison(x, y);
        }
    }
}
