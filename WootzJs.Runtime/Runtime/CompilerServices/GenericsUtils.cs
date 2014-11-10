namespace System.Runtime.CompilerServices
{
    public static class GenericsUtils
    {
        public static bool IsNullableValueType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}