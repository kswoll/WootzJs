namespace System.Collections
{
    public interface IEnumerator
    {
        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        /// 
        /// <returns>
        /// The current element in the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        object Current { get; }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// 
        /// <returns>
        /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
        bool MoveNext();

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
        void Reset();
    }
}
