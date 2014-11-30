// ReSharper disable once CheckNamespace
namespace System.Runtime.WootzJs
{
    [Flags]
    public enum TypeFlags
    {
        None = 0,
        Public =                0x00000001,
        Internal =              0x00000002,
        Private =               0x00000004,
        Protected =             0x00000008,
        Nested =                0x00000010,
        Class =                 0x00000020,
        Interface =             0x00000040,
        Enum =                  0x00000080,
        Delegate =              0x00000100,
        Abstract =              0x00000200,
        Sealed =                0x00000400,
        ValueType =             0x00000800,
        Primitive =             0x00001000,
        GenericType =           0x00002000,
        GenericTypeDefenition = 0x00004000,
        GenericParameter =      0x00008000
    }
}