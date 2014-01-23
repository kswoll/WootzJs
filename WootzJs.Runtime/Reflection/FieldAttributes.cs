namespace System.Reflection
{
    /// <summary>
    /// Specifies flags that describe the attributes of a field.
    /// </summary>
    [Flags]
    public enum FieldAttributes
    {
        FieldAccessMask = 7,
        PrivateScope = 0,
        Private = 1,
        FamANDAssem = 2,
        Assembly = FamANDAssem | Private,
        Family = 4,
        FamORAssem = Family | Private,
        Public = Family | FamANDAssem,
        Static = 16,
        InitOnly = 32,
        Literal = 64,
        NotSerialized = 128,
        SpecialName = 512,
        PinvokeImpl = 8192,
        ReservedMask = 38144,
        RTSpecialName = 1024,
        HasFieldMarshal = 4096,
        HasDefault = 32768,
        HasFieldRVA = 256,
    }
}
