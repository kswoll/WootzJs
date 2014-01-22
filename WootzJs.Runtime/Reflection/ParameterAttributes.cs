namespace System.Reflection
{
    /// <summary>
    /// Defines the attributes that can be associated with a parameter. These are defined in CorHdr.h.
    /// </summary>
    [Flags]
    public enum ParameterAttributes
    {
        None = 0,
        In = 1,
        Out = 2,
        Lcid = 4,
        Retval = 8,
        Optional = 16,
        ReservedMask = 61440,
        HasDefault = 4096,
        HasFieldMarshal = 8192,
        Reserved3 = 16384,
        Reserved4 = 32768,
    }
}
