namespace System.Reflection
{
    /// <summary>
    /// Defines the attributes that can be associated with a property. These attribute values are defined in corhdr.h.
    /// </summary>
    [Flags]
    public enum PropertyAttributes
    {
        None = 0,
        SpecialName = 512,
        ReservedMask = 62464,
        RTSpecialName = 1024,
        HasDefault = 4096,
        Reserved2 = 8192,
        Reserved3 = 16384,
        Reserved4 = 32768,
    }
}
