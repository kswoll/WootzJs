namespace System
{
    /// <summary>
    /// Specifies the culture, case, and sort rules to be used by certain overloads of the <see cref="M:System.String.Compare(System.String,System.String)"/> and <see cref="M:System.String.Equals(System.Object)"/> methods.
    /// </summary>
    /// <filterpriority>2</filterpriority>
    public enum StringComparison
    {
        CurrentCulture,
        CurrentCultureIgnoreCase,
        InvariantCulture,
        InvariantCultureIgnoreCase,
        Ordinal,
        OrdinalIgnoreCase,
    }
}