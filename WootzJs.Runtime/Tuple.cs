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

using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// Provides static methods for creating tuple objects.
    /// </summary>
    public static class Tuple
    {
        /// <summary>
        /// Creates a new 1-tuple, or singleton.
        /// </summary>
        /// 
        /// <returns>
        /// A tuple whose value is (<paramref name="item1"/>).
        /// </returns>
        /// <param name="item1">The value of the only component of the tuple.</param><typeparam name="T1">The type of the only component of the tuple.</typeparam>
        public static Tuple<T1> Create<T1>(T1 item1)
        {
            return new Tuple<T1>(item1);
        }

        /// <summary>
        /// Creates a new 2-tuple, or pair.
        /// </summary>
        /// 
        /// <returns>
        /// A 2-tuple whose value is (<paramref name="item1"/>, <paramref name="item2"/>).
        /// </returns>
        /// <param name="item1">The value of the first component of the tuple.</param><param name="item2">The value of the second component of the tuple.</param><typeparam name="T1">The type of the first component of the tuple.</typeparam><typeparam name="T2">The type of the second component of the tuple.</typeparam>
        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {
            return new Tuple<T1, T2>(item1, item2);
        }

        /// <summary>
        /// Creates a new 3-tuple, or triple.
        /// </summary>
        /// 
        /// <returns>
        /// A 3-tuple whose value is (<paramref name="item1"/>, <paramref name="item2"/>, <paramref name="item3"/>).
        /// </returns>
        /// <param name="item1">The value of the first component of the tuple.</param><param name="item2">The value of the second component of the tuple.</param><param name="item3">The value of the third component of the tuple.</param><typeparam name="T1">The type of the first component of the tuple.</typeparam><typeparam name="T2">The type of the second component of the tuple.</typeparam><typeparam name="T3">The type of the third component of the tuple.</typeparam>
        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            return new Tuple<T1, T2, T3>(item1, item2, item3);
        }

        /// <summary>
        /// Creates a new 4-tuple, or quadruple.
        /// </summary>
        /// 
        /// <returns>
        /// A 4-tuple whose value is (<paramref name="item1"/>, <paramref name="item2"/>, <paramref name="item3"/>, <paramref name="item4"/>).
        /// </returns>
        /// <param name="item1">The value of the first component of the tuple.</param><param name="item2">The value of the second component of the tuple.</param><param name="item3">The value of the third component of the tuple.</param><param name="item4">The value of the fourth component of the tuple.</param><typeparam name="T1">The type of the first component of the tuple.</typeparam><typeparam name="T2">The type of the second component of the tuple.</typeparam><typeparam name="T3">The type of the third component of the tuple.</typeparam><typeparam name="T4">The type of the fourth component of the tuple.  </typeparam>
        public static Tuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            return new Tuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        }

        /// <summary>
        /// Creates a new 5-tuple, or quintuple.
        /// </summary>
        /// 
        /// <returns>
        /// A 5-tuple whose value is (<paramref name="item1"/>, <paramref name="item2"/>, <paramref name="item3"/>, <paramref name="item4"/>, <paramref name="item5"/>).
        /// </returns>
        /// <param name="item1">The value of the first component of the tuple.</param><param name="item2">The value of the second component of the tuple.</param><param name="item3">The value of the third component of the tuple.</param><param name="item4">The value of the fourth component of the tuple.</param><param name="item5">The value of the fifth component of the tuple.</param><typeparam name="T1">The type of the first component of the tuple.</typeparam><typeparam name="T2">The type of the second component of the tuple.</typeparam><typeparam name="T3">The type of the third component of the tuple.</typeparam><typeparam name="T4">The type of the fourth component of the tuple.</typeparam><typeparam name="T5">The type of the fifth component of the tuple.</typeparam>
        public static Tuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            return new Tuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        }

        /// <summary>
        /// Creates a new 6-tuple, or sextuple.
        /// </summary>
        /// 
        /// <returns>
        /// A 6-tuple whose value is (<paramref name="item1"/>, <paramref name="item2"/>, <paramref name="item3"/>, <paramref name="item4"/>, <paramref name="item5"/>, <paramref name="item6"/>).
        /// </returns>
        /// <param name="item1">The value of the first component of the tuple.</param><param name="item2">The value of the second component of the tuple.</param><param name="item3">The value of the third component of the tuple.</param><param name="item4">The value of the fourth component of the tuple.</param><param name="item5">The value of the fifth component of the tuple.</param><param name="item6">The value of the sixth component of the tuple.</param><typeparam name="T1">The type of the first component of the tuple.</typeparam><typeparam name="T2">The type of the second component of the tuple.</typeparam><typeparam name="T3">The type of the third component of the tuple.</typeparam><typeparam name="T4">The type of the fourth component of the tuple.</typeparam><typeparam name="T5">The type of the fifth component of the tuple.</typeparam><typeparam name="T6">The type of the sixth component of the tuple.</typeparam>
        public static Tuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        }

        /// <summary>
        /// Creates a new 7-tuple, or septuple.
        /// </summary>
        /// 
        /// <returns>
        /// A 7-tuple whose value is (<paramref name="item1"/>, <paramref name="item2"/>, <paramref name="item3"/>, <paramref name="item4"/>, <paramref name="item5"/>, <paramref name="item6"/>, <paramref name="item7"/>).
        /// </returns>
        /// <param name="item1">The value of the first component of the tuple.</param><param name="item2">The value of the second component of the tuple.</param><param name="item3">The value of the third component of the tuple.</param><param name="item4">The value of the fourth component of the tuple.</param><param name="item5">The value of the fifth component of the tuple.</param><param name="item6">The value of the sixth component of the tuple.</param><param name="item7">The value of the seventh component of the tuple.</param><typeparam name="T1">The type of the first component of the tuple.</typeparam><typeparam name="T2">The type of the second component of the tuple.</typeparam><typeparam name="T3">The type of the third component of the tuple.</typeparam><typeparam name="T4">The type of the fourth component of the tuple.</typeparam><typeparam name="T5">The type of the fifth component of the tuple.</typeparam><typeparam name="T6">The type of the sixth component of the tuple.</typeparam><typeparam name="T7">The type of the seventh component of the tuple.</typeparam>
        public static Tuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        }

        /// <summary>
        /// Creates a new 8-tuple, or octuple.
        /// </summary>
        /// 
        /// <returns>
        /// An 8-tuple (octuple) whose value is (<paramref name="item1"/>, <paramref name="item2"/>, <paramref name="item3"/>, <paramref name="item4"/>, <paramref name="item5"/>, <paramref name="item6"/>, <paramref name="item7"/>, <paramref name="item8"/>).
        /// </returns>
        /// <param name="item1">The value of the first component of the tuple.</param><param name="item2">The value of the second component of the tuple.</param><param name="item3">The value of the third component of the tuple.</param><param name="item4">The value of the fourth component of the tuple.</param><param name="item5">The value of the fifth component of the tuple.</param><param name="item6">The value of the sixth component of the tuple.</param><param name="item7">The value of the seventh component of the tuple.</param><param name="item8">The value of the eighth component of the tuple.</param><typeparam name="T1">The type of the first component of the tuple.</typeparam><typeparam name="T2">The type of the second component of the tuple.</typeparam><typeparam name="T3">The type of the third component of the tuple.</typeparam><typeparam name="T4">The type of the fourth component of the tuple.</typeparam><typeparam name="T5">The type of the fifth component of the tuple.</typeparam><typeparam name="T6">The type of the sixth component of the tuple.</typeparam><typeparam name="T7">The type of the seventh component of the tuple.</typeparam><typeparam name="T8">The type of the eighth component of the tuple.</typeparam>
        public static Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>>(item1, item2, item3, item4, item5, item6, item7, new Tuple<T8>(item8));
        }

        internal static int CombineHashCodes(int h1, int h2)
        {
            return (h1 << 5) + h1 ^ h2;
        }

        internal static int CombineHashCodes(int h1, int h2, int h3)
        {
            return Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2), h3);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4)
        {
            return Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2), Tuple.CombineHashCodes(h3, h4));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5)
        {
            return Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2, h3, h4), h5);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6)
        {
            return Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2, h3, h4), Tuple.CombineHashCodes(h5, h6));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7)
        {
            return Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2, h3, h4), Tuple.CombineHashCodes(h5, h6, h7));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8)
        {
            return Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2, h3, h4), Tuple.CombineHashCodes(h5, h6, h7, h8));
        }
    }

    /// <summary>
    /// Represents a 1-tuple, or singleton.
    /// </summary>
    /// <typeparam name="T1">The type of the tuple's only component.</typeparam><filterpriority>1</filterpriority>
    public class Tuple<T1> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        private readonly T1 m_Item1;

        /// <summary>
        /// Gets the value of the <see cref="T:System.Tuple`1"/> object's single component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`1"/> object's single component.
        /// </returns>
        public T1 Item1
        {
            get { return this.m_Item1; }
        }

        int ITuple.Size
        {
            get { return 1; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Tuple`1"/> class.
        /// </summary>
        /// <param name="item1">The value of the tuple's only component.</param>
        public Tuple(T1 item1)
        {
            this.m_Item1 = item1;
        }

        /// <summary>
        /// Returns a value that indicates whether the current <see cref="T:System.Tuple`1"/> object is equal to a specified object.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current instance is equal to the specified object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with this instance.</param>
        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;
            Tuple<T1> tuple = other as Tuple<T1>;
            if (tuple == null)
                return false;
            else
                return comparer.Equals((object)this.m_Item1, (object)tuple.m_Item1);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;
            Tuple<T1> tuple = other as Tuple<T1>;
            if (tuple != null)
                return comparer.Compare((object)this.m_Item1, (object)tuple.m_Item1);
            throw new ArgumentException("ArgumentException_TupleIncorrectType");
        }

        /// <summary>
        /// Returns the hash code for the current <see cref="T:System.Tuple`1"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return comparer.GetHashCode((object)this.m_Item1);
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        /// <summary>
        /// Returns a string that represents the value of this <see cref="T:System.Tuple`1"/> instance.
        /// </summary>
        /// 
        /// <returns>
        /// The string representation of this <see cref="T:System.Tuple`1"/> object.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("(");
            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            sb.Append(m_Item1);
            sb.Append(")");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents a 2-tuple, or pair.
    /// </summary>
    /// <typeparam name="T1">The type of the tuple's first component.</typeparam><typeparam name="T2">The type of the tuple's second component.</typeparam><filterpriority>2</filterpriority>
    public class Tuple<T1, T2> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        private readonly T1 m_Item1;
        private readonly T2 m_Item2;

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`2"/> object's first component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`2"/> object's first component.
        /// </returns>
        public T1 Item1
        {
            get { return this.m_Item1; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`2"/> object's second component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`2"/> object's second component.
        /// </returns>
        public T2 Item2
        {
            get { return this.m_Item2; }
        }

        int ITuple.Size
        {
            get { return 2; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Tuple`2"/> class.
        /// </summary>
        /// <param name="item1">The value of the tuple's first component.</param><param name="item2">The value of the tuple's second component.</param>
        public Tuple(T1 item1, T2 item2)
        {
            this.m_Item1 = item1;
            this.m_Item2 = item2;
        }

        /// <summary>
        /// Returns a value that indicates whether the current <see cref="T:System.Tuple`2"/> object is equal to a specified object.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current instance is equal to the specified object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with this instance.</param>
        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;
            Tuple<T1, T2> tuple = other as Tuple<T1, T2>;
            if (tuple == null || !comparer.Equals((object)this.m_Item1, (object)tuple.m_Item1))
                return false;
            else
                return comparer.Equals((object)this.m_Item2, (object)tuple.m_Item2);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;
            Tuple<T1, T2> tuple = other as Tuple<T1, T2>;
            if (tuple == null)
            {
                throw new ArgumentException("ArgumentException_TupleIncorrectType");
            }
            else
            {
                int num = comparer.Compare((object)this.m_Item1, (object)tuple.m_Item1);
                if (num != 0)
                    return num;
                else
                    return comparer.Compare((object)this.m_Item2, (object)tuple.m_Item2);
            }
        }

        /// <summary>
        /// Returns the hash code for the current <see cref="T:System.Tuple`2"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item1), comparer.GetHashCode((object)this.m_Item2));
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        /// <summary>
        /// Returns a string that represents the value of this <see cref="T:System.Tuple`2"/> instance.
        /// </summary>
        /// 
        /// <returns>
        /// The string representation of this <see cref="T:System.Tuple`2"/> object.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            sb.Append((object)this.m_Item1);
            sb.Append(", ");
            sb.Append((object)this.m_Item2);
            sb.Append(")");
            return ((object)sb).ToString();
        }
    }

    /// <summary>
    /// Represents a 3-tuple, or triple.
    /// </summary>
    /// <typeparam name="T1">The type of the tuple's first component.</typeparam><typeparam name="T2">The type of the tuple's second component.</typeparam><typeparam name="T3">The type of the tuple's third component.</typeparam><filterpriority>2</filterpriority>
    public class Tuple<T1, T2, T3> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        private readonly T1 m_Item1;
        private readonly T2 m_Item2;
        private readonly T3 m_Item3;

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`3"/> object's first component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`3"/> object's first component.
        /// </returns>
        public T1 Item1
        {
            get { return this.m_Item1; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`3"/> object's second component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`3"/> object's second component.
        /// </returns>
        public T2 Item2
        {
            get { return this.m_Item2; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`3"/> object's third component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`3"/> object's third component.
        /// </returns>
        public T3 Item3
        {
            get { return this.m_Item3; }
        }

        int ITuple.Size
        {
            get { return 3; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Tuple`3"/> class.
        /// </summary>
        /// <param name="item1">The value of the tuple's first component.</param><param name="item2">The value of the tuple's second component.</param><param name="item3">The value of the tuple's third component.</param>
        public Tuple(T1 item1, T2 item2, T3 item3)
        {
            this.m_Item1 = item1;
            this.m_Item2 = item2;
            this.m_Item3 = item3;
        }

        /// <summary>
        /// Returns a value that indicates whether the current <see cref="T:System.Tuple`3"/> object is equal to a specified object.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current instance is equal to the specified object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with this instance.</param>
        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;
            Tuple<T1, T2, T3> tuple = other as Tuple<T1, T2, T3>;
            if (tuple == null || !comparer.Equals((object)this.m_Item1, (object)tuple.m_Item1) || !comparer.Equals((object)this.m_Item2, (object)tuple.m_Item2))
                return false;
            else
                return comparer.Equals((object)this.m_Item3, (object)tuple.m_Item3);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;
            Tuple<T1, T2, T3> tuple = other as Tuple<T1, T2, T3>;
            if (tuple == null)
            {
                throw new ArgumentException("ArgumentException_TupleIncorrectType");
            }
            else
            {
                int num1 = comparer.Compare((object)this.m_Item1, (object)tuple.m_Item1);
                if (num1 != 0)
                    return num1;
                int num2 = comparer.Compare((object)this.m_Item2, (object)tuple.m_Item2);
                if (num2 != 0)
                    return num2;
                else
                    return comparer.Compare((object)this.m_Item3, (object)tuple.m_Item3);
            }
        }

        /// <summary>
        /// Returns the hash code for the current <see cref="T:System.Tuple`3"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item1), comparer.GetHashCode((object)this.m_Item2), comparer.GetHashCode((object)this.m_Item3));
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        /// <summary>
        /// Returns a string that represents the value of this <see cref="T:System.Tuple`3"/> instance.
        /// </summary>
        /// 
        /// <returns>
        /// The string representation of this <see cref="T:System.Tuple`3"/> object.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            sb.Append((object)this.m_Item1);
            sb.Append(", ");
            sb.Append((object)this.m_Item2);
            sb.Append(", ");
            sb.Append((object)this.m_Item3);
            sb.Append(")");
            return ((object)sb).ToString();
        }
    }

    /// <summary>
    /// Represents a 4-tuple, or quadruple.
    /// </summary>
    /// <typeparam name="T1">The type of the tuple's first component.</typeparam><typeparam name="T2">The type of the tuple's second component.</typeparam><typeparam name="T3">The type of the tuple's third component.</typeparam><typeparam name="T4">The type of the tuple's fourth component.</typeparam><filterpriority>2</filterpriority>
    public class Tuple<T1, T2, T3, T4> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        private readonly T1 m_Item1;
        private readonly T2 m_Item2;
        private readonly T3 m_Item3;
        private readonly T4 m_Item4;

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`4"/> object's first component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`4"/> object's first component.
        /// </returns>
        public T1 Item1
        {
            get { return this.m_Item1; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`4"/> object's second component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`4"/> object's second component.
        /// </returns>
        public T2 Item2
        {
            get { return this.m_Item2; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`4"/> object's third component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`4"/> object's third component.
        /// </returns>
        public T3 Item3
        {
            get { return this.m_Item3; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`4"/> object's fourth component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`4"/> object's fourth component.
        /// </returns>
        public T4 Item4
        {
            get { return this.m_Item4; }
        }

        int ITuple.Size
        {
            get { return 4; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Tuple`4"/> class.
        /// </summary>
        /// <param name="item1">The value of the tuple's first component.</param><param name="item2">The value of the tuple's second component.</param><param name="item3">The value of the tuple's third component.</param><param name="item4">The value of the tuple's fourth component</param>
        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            this.m_Item1 = item1;
            this.m_Item2 = item2;
            this.m_Item3 = item3;
            this.m_Item4 = item4;
        }

        /// <summary>
        /// Returns a value that indicates whether the current <see cref="T:System.Tuple`4"/> object is equal to a specified object.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current instance is equal to the specified object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with this instance.</param>
        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;
            Tuple<T1, T2, T3, T4> tuple = other as Tuple<T1, T2, T3, T4>;
            if (tuple == null || !comparer.Equals((object)this.m_Item1, (object)tuple.m_Item1) || (!comparer.Equals((object)this.m_Item2, (object)tuple.m_Item2) || !comparer.Equals((object)this.m_Item3, (object)tuple.m_Item3)))
                return false;
            else
                return comparer.Equals((object)this.m_Item4, (object)tuple.m_Item4);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;
            Tuple<T1, T2, T3, T4> tuple = other as Tuple<T1, T2, T3, T4>;
            if (tuple == null)
            {
                throw new ArgumentException("ArgumentException_TupleIncorrectType");
            }
            else
            {
                int num1 = comparer.Compare((object)this.m_Item1, (object)tuple.m_Item1);
                if (num1 != 0)
                    return num1;
                int num2 = comparer.Compare((object)this.m_Item2, (object)tuple.m_Item2);
                if (num2 != 0)
                    return num2;
                int num3 = comparer.Compare((object)this.m_Item3, (object)tuple.m_Item3);
                if (num3 != 0)
                    return num3;
                else
                    return comparer.Compare((object)this.m_Item4, (object)tuple.m_Item4);
            }
        }

        /// <summary>
        /// Returns the hash code for the current <see cref="T:System.Tuple`4"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item1), comparer.GetHashCode((object)this.m_Item2), comparer.GetHashCode((object)this.m_Item3), comparer.GetHashCode((object)this.m_Item4));
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        /// <summary>
        /// Returns a string that represents the value of this <see cref="T:System.Tuple`4"/> instance.
        /// </summary>
        /// 
        /// <returns>
        /// The string representation of this <see cref="T:System.Tuple`4"/> object.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            sb.Append((object)this.m_Item1);
            sb.Append(", ");
            sb.Append((object)this.m_Item2);
            sb.Append(", ");
            sb.Append((object)this.m_Item3);
            sb.Append(", ");
            sb.Append((object)this.m_Item4);
            sb.Append(")");
            return ((object)sb).ToString();
        }
    }

    /// <summary>
    /// Represents a 5-tuple, or quintuple.
    /// </summary>
    /// <typeparam name="T1">The type of the tuple's first component.</typeparam><typeparam name="T2">The type of the tuple's second component.</typeparam><typeparam name="T3">The type of the tuple's third component.</typeparam><typeparam name="T4">The type of the tuple's fourth component.</typeparam><typeparam name="T5">The type of the tuple's fifth component.</typeparam><filterpriority>2</filterpriority>
    public class Tuple<T1, T2, T3, T4, T5> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        private readonly T1 m_Item1;
        private readonly T2 m_Item2;
        private readonly T3 m_Item3;
        private readonly T4 m_Item4;
        private readonly T5 m_Item5;

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`5"/> object's first component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`5"/> object's first component.
        /// </returns>
        public T1 Item1
        {
            get { return this.m_Item1; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`5"/> object's second component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`5"/> object's second component.
        /// </returns>
        public T2 Item2
        {
            get { return this.m_Item2; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`5"/> object's third component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`5"/> object's third component.
        /// </returns>
        public T3 Item3
        {
            get { return this.m_Item3; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`5"/> object's fourth component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`5"/> object's fourth component.
        /// </returns>
        public T4 Item4
        {
            get { return this.m_Item4; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`5"/> object's fifth component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`5"/> object's fifth component.
        /// </returns>
        public T5 Item5
        {
            get { return this.m_Item5; }
        }

        int ITuple.Size
        {
            get { return 5; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Tuple`5"/> class.
        /// </summary>
        /// <param name="item1">The value of the tuple's first component.</param><param name="item2">The value of the tuple's second component.</param><param name="item3">The value of the tuple's third component.</param><param name="item4">The value of the tuple's fourth component</param><param name="item5">The value of the tuple's fifth component.</param>
        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            this.m_Item1 = item1;
            this.m_Item2 = item2;
            this.m_Item3 = item3;
            this.m_Item4 = item4;
            this.m_Item5 = item5;
        }

        /// <summary>
        /// Returns a value that indicates whether the current <see cref="T:System.Tuple`5"/> object is equal to a specified object.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current instance is equal to the specified object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with this instance.</param>
        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;
            Tuple<T1, T2, T3, T4, T5> tuple = other as Tuple<T1, T2, T3, T4, T5>;
            if (tuple == null || !comparer.Equals((object)this.m_Item1, (object)tuple.m_Item1) || (!comparer.Equals((object)this.m_Item2, (object)tuple.m_Item2) || !comparer.Equals((object)this.m_Item3, (object)tuple.m_Item3)) || !comparer.Equals((object)this.m_Item4, (object)tuple.m_Item4))
                return false;
            else
                return comparer.Equals((object)this.m_Item5, (object)tuple.m_Item5);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;
            Tuple<T1, T2, T3, T4, T5> tuple = other as Tuple<T1, T2, T3, T4, T5>;
            if (tuple == null)
            {
                throw new ArgumentException("ArgumentException_TupleIncorrectType");
            }
            else
            {
                int num1 = comparer.Compare((object)this.m_Item1, (object)tuple.m_Item1);
                if (num1 != 0)
                    return num1;
                int num2 = comparer.Compare((object)this.m_Item2, (object)tuple.m_Item2);
                if (num2 != 0)
                    return num2;
                int num3 = comparer.Compare((object)this.m_Item3, (object)tuple.m_Item3);
                if (num3 != 0)
                    return num3;
                int num4 = comparer.Compare((object)this.m_Item4, (object)tuple.m_Item4);
                if (num4 != 0)
                    return num4;
                else
                    return comparer.Compare((object)this.m_Item5, (object)tuple.m_Item5);
            }
        }

        /// <summary>
        /// Returns the hash code for the current <see cref="T:System.Tuple`5"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item1), comparer.GetHashCode((object)this.m_Item2), comparer.GetHashCode((object)this.m_Item3), comparer.GetHashCode((object)this.m_Item4), comparer.GetHashCode((object)this.m_Item5));
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        /// <summary>
        /// Returns a string that represents the value of this <see cref="T:System.Tuple`5"/> instance.
        /// </summary>
        /// 
        /// <returns>
        /// The string representation of this <see cref="T:System.Tuple`5"/> object.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            sb.Append((object)this.m_Item1);
            sb.Append(", ");
            sb.Append((object)this.m_Item2);
            sb.Append(", ");
            sb.Append((object)this.m_Item3);
            sb.Append(", ");
            sb.Append((object)this.m_Item4);
            sb.Append(", ");
            sb.Append((object)this.m_Item5);
            sb.Append(")");
            return ((object)sb).ToString();
        }
    }

    /// <summary>
    /// Represents a 6-tuple, or sextuple.
    /// </summary>
    /// <typeparam name="T1">The type of the tuple's first component.</typeparam><typeparam name="T2">The type of the tuple's second component.</typeparam><typeparam name="T3">The type of the tuple's third component.</typeparam><typeparam name="T4">The type of the tuple's fourth component.</typeparam><typeparam name="T5">The type of the tuple's fifth component.</typeparam><typeparam name="T6">The type of the tuple's sixth component.</typeparam><filterpriority>2</filterpriority>
    public class Tuple<T1, T2, T3, T4, T5, T6> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        private readonly T1 m_Item1;
        private readonly T2 m_Item2;
        private readonly T3 m_Item3;
        private readonly T4 m_Item4;
        private readonly T5 m_Item5;
        private readonly T6 m_Item6;

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`6"/> object's first component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`6"/> object's first component.
        /// </returns>
        public T1 Item1
        {
            get { return this.m_Item1; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`6"/> object's second component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`6"/> object's second component.
        /// </returns>
        public T2 Item2
        {
            get { return this.m_Item2; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`6"/> object's third component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`6"/> object's third component.
        /// </returns>
        public T3 Item3
        {
            get { return this.m_Item3; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`6"/> object's fourth component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`6"/> object's fourth component.
        /// </returns>
        public T4 Item4
        {
            get { return this.m_Item4; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`6"/> object's fifth component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`6"/> object's fifth  component.
        /// </returns>
        public T5 Item5
        {
            get { return this.m_Item5; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`6"/> object's sixth component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`6"/> object's sixth component.
        /// </returns>
        public T6 Item6
        {
            get { return this.m_Item6; }
        }

        int ITuple.Size
        {
            get { return 6; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Tuple`6"/> class.
        /// </summary>
        /// <param name="item1">The value of the tuple's first component.</param><param name="item2">The value of the tuple's second component.</param><param name="item3">The value of the tuple's third component.</param><param name="item4">The value of the tuple's fourth component</param><param name="item5">The value of the tuple's fifth component.</param><param name="item6">The value of the tuple's sixth component.</param>
        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            this.m_Item1 = item1;
            this.m_Item2 = item2;
            this.m_Item3 = item3;
            this.m_Item4 = item4;
            this.m_Item5 = item5;
            this.m_Item6 = item6;
        }

        /// <summary>
        /// Returns a value that indicates whether the current <see cref="T:System.Tuple`6"/> object is equal to a specified object.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current instance is equal to the specified object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with this instance.</param>
        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;
            Tuple<T1, T2, T3, T4, T5, T6> tuple = other as Tuple<T1, T2, T3, T4, T5, T6>;
            if (tuple == null || !comparer.Equals((object)this.m_Item1, (object)tuple.m_Item1) || (!comparer.Equals((object)this.m_Item2, (object)tuple.m_Item2) || !comparer.Equals((object)this.m_Item3, (object)tuple.m_Item3)) || (!comparer.Equals((object)this.m_Item4, (object)tuple.m_Item4) || !comparer.Equals((object)this.m_Item5, (object)tuple.m_Item5)))
                return false;
            else
                return comparer.Equals((object)this.m_Item6, (object)tuple.m_Item6);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;
            Tuple<T1, T2, T3, T4, T5, T6> tuple = other as Tuple<T1, T2, T3, T4, T5, T6>;
            if (tuple == null)
            {
                throw new ArgumentException("ArgumentException_TupleIncorrectType");
            }
            else
            {
                int num1 = comparer.Compare((object)this.m_Item1, (object)tuple.m_Item1);
                if (num1 != 0)
                    return num1;
                int num2 = comparer.Compare((object)this.m_Item2, (object)tuple.m_Item2);
                if (num2 != 0)
                    return num2;
                int num3 = comparer.Compare((object)this.m_Item3, (object)tuple.m_Item3);
                if (num3 != 0)
                    return num3;
                int num4 = comparer.Compare((object)this.m_Item4, (object)tuple.m_Item4);
                if (num4 != 0)
                    return num4;
                int num5 = comparer.Compare((object)this.m_Item5, (object)tuple.m_Item5);
                if (num5 != 0)
                    return num5;
                else
                    return comparer.Compare((object)this.m_Item6, (object)tuple.m_Item6);
            }
        }

        /// <summary>
        /// Returns the hash code for the current <see cref="T:System.Tuple`6"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item1), comparer.GetHashCode((object)this.m_Item2), comparer.GetHashCode((object)this.m_Item3), comparer.GetHashCode((object)this.m_Item4), comparer.GetHashCode((object)this.m_Item5), comparer.GetHashCode((object)this.m_Item6));
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        /// <summary>
        /// Returns a string that represents the value of this <see cref="T:System.Tuple`6"/> instance.
        /// </summary>
        /// 
        /// <returns>
        /// The string representation of this <see cref="T:System.Tuple`6"/> object.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            sb.Append((object)this.m_Item1);
            sb.Append(", ");
            sb.Append((object)this.m_Item2);
            sb.Append(", ");
            sb.Append((object)this.m_Item3);
            sb.Append(", ");
            sb.Append((object)this.m_Item4);
            sb.Append(", ");
            sb.Append((object)this.m_Item5);
            sb.Append(", ");
            sb.Append((object)this.m_Item6);
            sb.Append(")");
            return ((object)sb).ToString();
        }
    }

    /// <summary>
    /// Represents a 7-tuple, or septuple.
    /// </summary>
    /// <typeparam name="T1">The type of the tuple's first component.</typeparam><typeparam name="T2">The type of the tuple's second component.</typeparam><typeparam name="T3">The type of the tuple's third component.</typeparam><typeparam name="T4">The type of the tuple's fourth component.</typeparam><typeparam name="T5">The type of the tuple's fifth component.</typeparam><typeparam name="T6">The type of the tuple's sixth component.</typeparam><typeparam name="T7">The type of the tuple's seventh component.</typeparam><filterpriority>2</filterpriority>
    public class Tuple<T1, T2, T3, T4, T5, T6, T7> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        private readonly T1 m_Item1;
        private readonly T2 m_Item2;
        private readonly T3 m_Item3;
        private readonly T4 m_Item4;
        private readonly T5 m_Item5;
        private readonly T6 m_Item6;
        private readonly T7 m_Item7;

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`7"/> object's first component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`7"/> object's first component.
        /// </returns>
        public T1 Item1
        {
            get { return this.m_Item1; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`7"/> object's second component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`7"/> object's second component.
        /// </returns>
        public T2 Item2
        {
            get { return this.m_Item2; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`7"/> object's third component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`7"/> object's third component.
        /// </returns>
        public T3 Item3
        {
            get { return this.m_Item3; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`7"/> object's fourth component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`7"/> object's fourth component.
        /// </returns>
        public T4 Item4
        {
            get { return this.m_Item4; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`7"/> object's fifth component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`7"/> object's fifth component.
        /// </returns>
        public T5 Item5
        {
            get { return this.m_Item5; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`7"/> object's sixth component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`7"/> object's sixth component.
        /// </returns>
        public T6 Item6
        {
            get { return this.m_Item6; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`7"/> object's seventh component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`7"/> object's seventh component.
        /// </returns>
        public T7 Item7
        {
            get { return this.m_Item7; }
        }

        int ITuple.Size
        {
            get { return 7; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Tuple`7"/> class.
        /// </summary>
        /// <param name="item1">The value of the tuple's first component.</param><param name="item2">The value of the tuple's second component.</param><param name="item3">The value of the tuple's third component.</param><param name="item4">The value of the tuple's fourth component</param><param name="item5">The value of the tuple's fifth component.</param><param name="item6">The value of the tuple's sixth component.</param><param name="item7">The value of the tuple's seventh component.</param>
        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            this.m_Item1 = item1;
            this.m_Item2 = item2;
            this.m_Item3 = item3;
            this.m_Item4 = item4;
            this.m_Item5 = item5;
            this.m_Item6 = item6;
            this.m_Item7 = item7;
        }

        /// <summary>
        /// Returns a value that indicates whether the current <see cref="T:System.Tuple`7"/> object is equal to a specified object.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current instance is equal to the specified object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with this instance.</param>
        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;
            Tuple<T1, T2, T3, T4, T5, T6, T7> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7>;
            if (tuple == null || !comparer.Equals((object)this.m_Item1, (object)tuple.m_Item1) || (!comparer.Equals((object)this.m_Item2, (object)tuple.m_Item2) || !comparer.Equals((object)this.m_Item3, (object)tuple.m_Item3)) || (!comparer.Equals((object)this.m_Item4, (object)tuple.m_Item4) || !comparer.Equals((object)this.m_Item5, (object)tuple.m_Item5) || !comparer.Equals((object)this.m_Item6, (object)tuple.m_Item6)))
                return false;
            else
                return comparer.Equals((object)this.m_Item7, (object)tuple.m_Item7);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;
            Tuple<T1, T2, T3, T4, T5, T6, T7> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7>;
            if (tuple == null)
            {
                throw new ArgumentException("ArgumentException_TupleIncorrectType");
            }
            else
            {
                int num1 = comparer.Compare((object)this.m_Item1, (object)tuple.m_Item1);
                if (num1 != 0)
                    return num1;
                int num2 = comparer.Compare((object)this.m_Item2, (object)tuple.m_Item2);
                if (num2 != 0)
                    return num2;
                int num3 = comparer.Compare((object)this.m_Item3, (object)tuple.m_Item3);
                if (num3 != 0)
                    return num3;
                int num4 = comparer.Compare((object)this.m_Item4, (object)tuple.m_Item4);
                if (num4 != 0)
                    return num4;
                int num5 = comparer.Compare((object)this.m_Item5, (object)tuple.m_Item5);
                if (num5 != 0)
                    return num5;
                int num6 = comparer.Compare((object)this.m_Item6, (object)tuple.m_Item6);
                if (num6 != 0)
                    return num6;
                else
                    return comparer.Compare((object)this.m_Item7, (object)tuple.m_Item7);
            }
        }

        /// <summary>
        /// Returns the hash code for the current <see cref="T:System.Tuple`7"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item1), comparer.GetHashCode((object)this.m_Item2), comparer.GetHashCode((object)this.m_Item3), comparer.GetHashCode((object)this.m_Item4), comparer.GetHashCode((object)this.m_Item5), comparer.GetHashCode((object)this.m_Item6), comparer.GetHashCode((object)this.m_Item7));
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        /// <summary>
        /// Returns a string that represents the value of this <see cref="T:System.Tuple`7"/> instance.
        /// </summary>
        /// 
        /// <returns>
        /// The string representation of this <see cref="T:System.Tuple`7"/> object.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            sb.Append((object)this.m_Item1);
            sb.Append(", ");
            sb.Append((object)this.m_Item2);
            sb.Append(", ");
            sb.Append((object)this.m_Item3);
            sb.Append(", ");
            sb.Append((object)this.m_Item4);
            sb.Append(", ");
            sb.Append((object)this.m_Item5);
            sb.Append(", ");
            sb.Append((object)this.m_Item6);
            sb.Append(", ");
            sb.Append((object)this.m_Item7);
            sb.Append(")");
            return ((object)sb).ToString();
        }
    }

    /// <summary>
    /// Represents an n-tuple, where n is 8 or greater.
    /// </summary>
    /// <typeparam name="T1">The type of the tuple's first component.</typeparam><typeparam name="T2">The type of the tuple's second component.</typeparam><typeparam name="T3">The type of the tuple's third component.</typeparam><typeparam name="T4">The type of the tuple's fourth component.</typeparam><typeparam name="T5">The type of the tuple's fifth component.</typeparam><typeparam name="T6">The type of the tuple's sixth component.</typeparam><typeparam name="T7">The type of the tuple's seventh component.</typeparam><typeparam name="TRest">Any generic Tuple object that defines the types of the tuple's remaining components.</typeparam><filterpriority>2</filterpriority>
    public class Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        private readonly T1 m_Item1;
        private readonly T2 m_Item2;
        private readonly T3 m_Item3;
        private readonly T4 m_Item4;
        private readonly T5 m_Item5;
        private readonly T6 m_Item6;
        private readonly T7 m_Item7;
        private readonly TRest m_Rest;

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`8"/> object's first component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`8"/> object's first component.
        /// </returns>
        public T1 Item1
        {
            get { return this.m_Item1; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`8"/> object's second component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`8"/> object's second component.
        /// </returns>
        public T2 Item2
        {
            get { return this.m_Item2; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`8"/> object's third component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`8"/> object's third component.
        /// </returns>
        public T3 Item3
        {
            get { return this.m_Item3; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`8"/> object's fourth component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`8"/> object's fourth component.
        /// </returns>
        public T4 Item4
        {
            get { return this.m_Item4; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`8"/> object's fifth component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`8"/> object's fifth component.
        /// </returns>
        public T5 Item5
        {
            get { return this.m_Item5; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`8"/> object's sixth component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`8"/> object's sixth component.
        /// </returns>
        public T6 Item6
        {
            get { return this.m_Item6; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.Tuple`8"/> object's seventh component.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`8"/> object's seventh component.
        /// </returns>
        public T7 Item7
        {
            get { return this.m_Item7; }
        }

        /// <summary>
        /// Gets the current <see cref="T:System.Tuple`8"/> object's remaining components.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the current <see cref="T:System.Tuple`8"/> object's remaining components.
        /// </returns>
        public TRest Rest
        {
            get { return this.m_Rest; }
        }

        int ITuple.Size
        {
            get { return 7 + ((ITuple)(object)this.m_Rest).Size; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Tuple`8"/> class.
        /// </summary>
        /// <param name="item1">The value of the tuple's first component.</param><param name="item2">The value of the tuple's second component.</param><param name="item3">The value of the tuple's third component.</param><param name="item4">The value of the tuple's fourth component</param><param name="item5">The value of the tuple's fifth component.</param><param name="item6">The value of the tuple's sixth component.</param><param name="item7">The value of the tuple's seventh component.</param><param name="rest">Any generic Tuple object that contains the values of the tuple's remaining components.</param><exception cref="T:System.ArgumentException"><paramref name="rest"/> is not a generic Tuple object.</exception>
        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
        {
            if (!((object)rest is ITuple))
                throw new ArgumentException("ArgumentException_TupleLastArgumentNotATuple");
            this.m_Item1 = item1;
            this.m_Item2 = item2;
            this.m_Item3 = item3;
            this.m_Item4 = item4;
            this.m_Item5 = item5;
            this.m_Item6 = item6;
            this.m_Item7 = item7;
            this.m_Rest = rest;
        }

        /// <summary>
        /// Returns a value that indicates whether the current <see cref="T:System.Tuple`8"/> object is equal to a specified object.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current instance is equal to the specified object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with this instance.</param>
        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;
            Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
            if (tuple == null || !comparer.Equals((object)this.m_Item1, (object)tuple.m_Item1) || (!comparer.Equals((object)this.m_Item2, (object)tuple.m_Item2) || !comparer.Equals((object)this.m_Item3, (object)tuple.m_Item3)) || (!comparer.Equals((object)this.m_Item4, (object)tuple.m_Item4) || !comparer.Equals((object)this.m_Item5, (object)tuple.m_Item5) || (!comparer.Equals((object)this.m_Item6, (object)tuple.m_Item6) || !comparer.Equals((object)this.m_Item7, (object)tuple.m_Item7))))
                return false;
            else
                return comparer.Equals((object)this.m_Rest, (object)tuple.m_Rest);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;
            Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
            if (tuple == null)
            {
                throw new ArgumentException("ArgumentException_TupleIncorrectType");
            }
            else
            {
                int num1 = comparer.Compare((object)this.m_Item1, (object)tuple.m_Item1);
                if (num1 != 0)
                    return num1;
                int num2 = comparer.Compare((object)this.m_Item2, (object)tuple.m_Item2);
                if (num2 != 0)
                    return num2;
                int num3 = comparer.Compare((object)this.m_Item3, (object)tuple.m_Item3);
                if (num3 != 0)
                    return num3;
                int num4 = comparer.Compare((object)this.m_Item4, (object)tuple.m_Item4);
                if (num4 != 0)
                    return num4;
                int num5 = comparer.Compare((object)this.m_Item5, (object)tuple.m_Item5);
                if (num5 != 0)
                    return num5;
                int num6 = comparer.Compare((object)this.m_Item6, (object)tuple.m_Item6);
                if (num6 != 0)
                    return num6;
                int num7 = comparer.Compare((object)this.m_Item7, (object)tuple.m_Item7);
                if (num7 != 0)
                    return num7;
                else
                    return comparer.Compare((object)this.m_Rest, (object)tuple.m_Rest);
            }
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="T:System.Tuple`8"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            ITuple tuple = (ITuple)(object)this.m_Rest;
            if (tuple.Size >= 8)
                return tuple.GetHashCode(comparer);
            switch (8 - tuple.Size)
            {
                case 1:
                    return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item7), tuple.GetHashCode(comparer));
                case 2:
                    return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item6), comparer.GetHashCode((object)this.m_Item7), tuple.GetHashCode(comparer));
                case 3:
                    return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item5), comparer.GetHashCode((object)this.m_Item6), comparer.GetHashCode((object)this.m_Item7), tuple.GetHashCode(comparer));
                case 4:
                    return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item4), comparer.GetHashCode((object)this.m_Item5), comparer.GetHashCode((object)this.m_Item6), comparer.GetHashCode((object)this.m_Item7), tuple.GetHashCode(comparer));
                case 5:
                    return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item3), comparer.GetHashCode((object)this.m_Item4), comparer.GetHashCode((object)this.m_Item5), comparer.GetHashCode((object)this.m_Item6), comparer.GetHashCode((object)this.m_Item7), tuple.GetHashCode(comparer));
                case 6:
                    return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item2), comparer.GetHashCode((object)this.m_Item3), comparer.GetHashCode((object)this.m_Item4), comparer.GetHashCode((object)this.m_Item5), comparer.GetHashCode((object)this.m_Item6), comparer.GetHashCode((object)this.m_Item7), tuple.GetHashCode(comparer));
                case 7:
                    return Tuple.CombineHashCodes(comparer.GetHashCode((object)this.m_Item1), comparer.GetHashCode((object)this.m_Item2), comparer.GetHashCode((object)this.m_Item3), comparer.GetHashCode((object)this.m_Item4), comparer.GetHashCode((object)this.m_Item5), comparer.GetHashCode((object)this.m_Item6), comparer.GetHashCode((object)this.m_Item7), tuple.GetHashCode(comparer));
                default:
                    return -1;
            }
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        /// <summary>
        /// Returns a string that represents the value of this <see cref="T:System.Tuple`8"/> instance.
        /// </summary>
        /// 
        /// <returns>
        /// The string representation of this <see cref="T:System.Tuple`8"/> object.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            sb.Append((object)this.m_Item1);
            sb.Append(", ");
            sb.Append((object)this.m_Item2);
            sb.Append(", ");
            sb.Append((object)this.m_Item3);
            sb.Append(", ");
            sb.Append((object)this.m_Item4);
            sb.Append(", ");
            sb.Append((object)this.m_Item5);
            sb.Append(", ");
            sb.Append((object)this.m_Item6);
            sb.Append(", ");
            sb.Append((object)this.m_Item7);
            sb.Append(", ");
            return ((ITuple)(object)this.m_Rest).ToString(sb);
        }
    }

    internal interface ITuple
    {
        int Size { get; }

        string ToString(StringBuilder sb);

        int GetHashCode(IEqualityComparer comparer);
    }
}
