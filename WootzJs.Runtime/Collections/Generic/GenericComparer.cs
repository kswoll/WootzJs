namespace System.Collections.Generic
{
    internal class GenericComparer<T> : Comparer<T> where T : IComparable<T>
    {
        public GenericComparer()
        {
        }

        public override int Compare(T x, T y)
        {
            if ((object)x != null)
            {
                if ((object)y != null)
                    return x.CompareTo(y);
                else
                    return 1;
            }
            else
                return (object)y != null ? -1 : 0;
        }

        public override bool Equals(object obj)
        {
            return obj is GenericComparer<T>;
        }

        public override int GetHashCode()
        {
            return this.GetType().Name.GetHashCode();
        }
    }
}