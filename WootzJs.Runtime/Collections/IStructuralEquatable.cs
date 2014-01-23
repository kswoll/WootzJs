namespace System.Collections
{
    /// <summary>
    /// Defines methods to support the comparison of objects for structural equality.
    /// </summary>
    public interface IStructuralEquatable
    {
        /// <summary>
        /// Determines whether an object is structurally equal to the current instance.
        /// </summary>
        /// 
        /// <returns>
        /// true if the two objects are equal; otherwise, false.
        /// </returns>
        /// <param name="other">The object to compare with the current instance.</param><param name="comparer">An object that determines whether the current instance and <paramref name="other"/> are equal. </param>
        bool Equals(object other, IEqualityComparer comparer);

        /// <summary>
        /// Returns a hash code for the current instance.
        /// </summary>
        /// 
        /// <returns>
        /// The hash code for the current instance.
        /// </returns>
        /// <param name="comparer">An object that computes the hash code of the current object.</param>
        int GetHashCode(IEqualityComparer comparer);
    }
}