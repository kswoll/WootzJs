using System.Runtime.WootzJs;

namespace System.Collections.Generic
{
    [Js(Export = false)]
    public abstract class EqualityComparer<T> : IEqualityComparer, IEqualityComparer<T>
    {
        private static volatile EqualityComparer<T> defaultComparer;

        /// <summary>
        /// Returns a default equality comparer for the type specified by the generic argument.
        /// </summary>
        /// 
        /// <returns>
        /// The default instance of the <see cref="T:System.Collections.Generic.EqualityComparer`1"/> class for type <paramref name="T"/>.
        /// </returns>
        public static EqualityComparer<T> Default
        {
            get
            {
                EqualityComparer<T> equalityComparer = defaultComparer;
                if (equalityComparer == null)
                {
                    equalityComparer = CreateComparer();
                    defaultComparer = equalityComparer;
                }
                return equalityComparer;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Collections.Generic.EqualityComparer`1"/> class.
        /// </summary>
        protected EqualityComparer()
        {
        }

        private static EqualityComparer<T> CreateComparer()
        {
            return null;
        }

        /// <summary>
        /// When overridden in a derived class, determines whether two objects of type <paramref name="T"/> are equal.
        /// </summary>
        /// 
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        /// <param name="x">The first object to compare.</param><param name="y">The second object to compare.</param>
        public abstract bool Equals(T x, T y);

        /// <summary>
        /// When overridden in a derived class, serves as a hash function for the specified object for hashing algorithms and data structures, such as a hash table.
        /// </summary>
        /// 
        /// <returns>
        /// A hash code for the specified object.
        /// </returns>
        /// <param name="obj">The object for which to get a hash code.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
        public abstract int GetHashCode(T obj);

        internal virtual int IndexOf(T[] array, T value, int startIndex, int count)
        {
            int num = startIndex + count;
            for (int index = startIndex; index < num; ++index)
            {
                if (this.Equals(array[index], value))
                    return index;
            }
            return -1;
        }

        internal virtual int LastIndexOf(T[] array, T value, int startIndex, int count)
        {
            int num = startIndex - count + 1;
            for (int index = startIndex; index >= num; --index)
            {
                if (this.Equals(array[index], value))
                    return index;
            }
            return -1;
        }

        int IEqualityComparer.GetHashCode(object obj)
        {
            if (obj == null)
                return 0;
            if (obj is T)
                return this.GetHashCode((T)obj);
            throw new Exception();
        }

        bool IEqualityComparer.Equals(object x, object y)
        {
            if (x == y)
                return true;
            if (x == null || y == null)
                return false;
            if (x is T && y is T)
                return this.Equals((T)x, (T)y);
            throw new Exception();
        }
    }
}
