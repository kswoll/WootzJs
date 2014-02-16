namespace System
{
    public class Convert
    {
        /// <summary>
        /// Returns an object of the specified type and whose value is equivalent to the specified object.
        /// </summary>
        /// 
        /// <returns>
        /// An object whose type is <paramref name="conversionType"/> and whose value is equivalent to <paramref name="value"/>.-or-A null reference (Nothing in Visual Basic), if <paramref name="value"/> is null and <paramref name="conversionType"/> is not a value type.
        /// </returns>
        /// <param name="value">An object that implements the <see cref="T:System.IConvertible"/> interface. </param><param name="conversionType">The type of object to return. </param><exception cref="T:System.InvalidCastException">This conversion is not supported.  -or-<paramref name="value"/> is null and <paramref name="conversionType"/> is a value type.-or-<paramref name="value"/> does not implement the <see cref="T:System.IConvertible"/> interface.</exception><exception cref="T:System.FormatException"><paramref name="value"/> is not in a format recognized by <paramref name="conversionType"/>.</exception><exception cref="T:System.OverflowException"><paramref name="value"/> represents a number that is out of the range of <paramref name="conversionType"/>.</exception><exception cref="T:System.ArgumentNullException"><paramref name="conversionType"/> is null.</exception><filterpriority>1</filterpriority>
        public static object ChangeType(object value, Type conversionType)
        {
            if (value == null)
            {
                if (conversionType.IsValueType)
                    throw new Exception("Null object cannot be converted to a value type");
                return null;
            }
            if (value.GetType() == conversionType)
            {
                return value;
            }
            if (value is string)
            {
                var s = (string)value;
                if (conversionType == typeof(int))
                    return int.Parse(s);
                if (conversionType == typeof(short))
                    return short.Parse(s);
            }
            throw new Exception("Could not convert " + value + " (" + value.GetType().FullName + ") to " + conversionType.FullName);
        }
    }
}