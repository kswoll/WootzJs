namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Indicates the name by which an indexer is known in programming languages that do not support indexers directly.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public sealed class IndexerNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.IndexerNameAttribute"/> class.
        /// </summary>
        /// <param name="indexerName">The name of the indexer, as shown to other languages. </param>
        public IndexerNameAttribute(string indexerName)
        {
        }
    }
}