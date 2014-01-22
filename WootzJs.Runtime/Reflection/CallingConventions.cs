namespace System.Reflection
{
    /// <summary>
    /// Defines the valid calling conventions for a method.
    /// </summary>
    [Flags]
    public enum CallingConventions
    {
        Standard = 1,
        VarArgs = 2,
        Any = VarArgs | Standard,
        HasThis = 32,
        ExplicitThis = 64,
    }
}
