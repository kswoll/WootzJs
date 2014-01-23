namespace System.Reflection
{
    /// <summary>
    /// Specifies flags for method attributes. These flags are defined in the corhdr.h file.
    /// </summary>
    [Flags]
    public enum MethodAttributes
    {
        MemberAccessMask = 7,
        PrivateScope = 0,
        Private = 1,
        FamANDAssem = 2,
        Assembly = FamANDAssem | Private,
        Family = 4,
        FamORAssem = Family | Private,
        Public = Family | FamANDAssem,
        Static = 16,
        Final = 32,
        Virtual = 64,
        HideBySig = 128,
        CheckAccessOnOverride = 512,
        VtableLayoutMask = 256,
//        ReuseSlot = 0,
//        NewSlot = VtableLayoutMask,
        Abstract = 1024,
        SpecialName = 2048,
        PinvokeImpl = 8192,
        UnmanagedExport = 8,
        RTSpecialName = 4096,
        ReservedMask = 53248,
        HasSecurity = 16384,
        RequireSecObject = 32768,
    }
}
