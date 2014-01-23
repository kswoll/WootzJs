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
