namespace System.Globalization
{
    public class CompareInfo
    {
        /// <summary>
        /// Compares two strings.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer indicating the lexical relationship between the two comparands.Value Condition zero The two strings are equal. less than zero <paramref name="string1"/> is less than <paramref name="string2"/>. greater than zero <paramref name="string1"/> is greater than <paramref name="string2"/>.
        /// </returns>
        /// <param name="string1">The first string to compare. </param><param name="string2">The second string to compare. </param>
        public virtual int Compare(string string1, string string2)
        {
            return Compare(string1, string2, CompareOptions.None);
        }

        /// <summary>
        /// Compares two strings using the specified <see cref="T:System.Globalization.CompareOptions"/> value.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer indicating the lexical relationship between the two comparands.Value Condition zero The two strings are equal. less than zero <paramref name="string1"/> is less than <paramref name="string2"/>. greater than zero <paramref name="string1"/> is greater than <paramref name="string2"/>.
        /// </returns>
        /// <param name="string1">The first string to compare. </param><param name="string2">The second string to compare. </param><param name="options">A value that defines how <paramref name="string1"/> and <paramref name="string2"/> should be compared. <paramref name="options"/> is either the enumeration value <see cref="F:System.Globalization.CompareOptions.Ordinal"/>, or a bitwise combination of one or more of the following values: <see cref="F:System.Globalization.CompareOptions.IgnoreCase"/>, <see cref="F:System.Globalization.CompareOptions.IgnoreSymbols"/>, <see cref="F:System.Globalization.CompareOptions.IgnoreNonSpace"/>, <see cref="F:System.Globalization.CompareOptions.IgnoreWidth"/>, <see cref="F:System.Globalization.CompareOptions.IgnoreKanaType"/>, and <see cref="F:System.Globalization.CompareOptions.StringSort"/>.</param><exception cref="T:System.ArgumentException"><paramref name="options"/> contains an invalid <see cref="T:System.Globalization.CompareOptions"/> value. </exception>
        public virtual int Compare(string string1, string string2, CompareOptions options)
        {
            return string.Compare(string1, string2);
        }

        /// <summary>
        /// Compares a section of one string with a section of another string.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer indicating the lexical relationship between the two comparands.Value Condition zero The two strings are equal. less than zero The specified section of <paramref name="string1"/> is less than the specified section of <paramref name="string2"/>. greater than zero The specified section of <paramref name="string1"/> is greater than the specified section of <paramref name="string2"/>.
        /// </returns>
        /// <param name="string1">The first string to compare. </param><param name="offset1">The zero-based index of the character in <paramref name="string1"/> at which to start comparing. </param><param name="length1">The number of consecutive characters in <paramref name="string1"/> to compare. </param><param name="string2">The second string to compare. </param><param name="offset2">The zero-based index of the character in <paramref name="string2"/> at which to start comparing. </param><param name="length2">The number of consecutive characters in <paramref name="string2"/> to compare. </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="offset1"/> or <paramref name="length1"/> or <paramref name="offset2"/> or <paramref name="length2"/> is less than zero.-or- <paramref name="offset1"/> is greater than or equal to the number of characters in <paramref name="string1"/>.-or- <paramref name="offset2"/> is greater than or equal to the number of characters in <paramref name="string2"/>.-or- <paramref name="length1"/> is greater than the number of characters from <paramref name="offset1"/> to the end of <paramref name="string1"/>.-or- <paramref name="length2"/> is greater than the number of characters from <paramref name="offset2"/> to the end of <paramref name="string2"/>. </exception>
        public virtual int Compare(string string1, int offset1, int length1, string string2, int offset2, int length2)
        {
            return this.Compare(string1, offset1, length1, string2, offset2, length2, CompareOptions.None);
        }

        /// <summary>
        /// Compares the end section of a string with the end section of another string using the specified <see cref="T:System.Globalization.CompareOptions"/> value.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer indicating the lexical relationship between the two comparands.Value Condition zero The two strings are equal. less than zero The specified section of <paramref name="string1"/> is less than the specified section of <paramref name="string2"/>. greater than zero The specified section of <paramref name="string1"/> is greater than the specified section of <paramref name="string2"/>.
        /// </returns>
        /// <param name="string1">The first string to compare. </param><param name="offset1">The zero-based index of the character in <paramref name="string1"/> at which to start comparing. </param><param name="string2">The second string to compare. </param><param name="offset2">The zero-based index of the character in <paramref name="string2"/> at which to start comparing. </param><param name="options">A value that defines how <paramref name="string1"/> and <paramref name="string2"/> should be compared. <paramref name="options"/> is either the enumeration value <see cref="F:System.Globalization.CompareOptions.Ordinal"/>, or a bitwise combination of one or more of the following values: <see cref="F:System.Globalization.CompareOptions.IgnoreCase"/>, <see cref="F:System.Globalization.CompareOptions.IgnoreSymbols"/>, <see cref="F:System.Globalization.CompareOptions.IgnoreNonSpace"/>, <see cref="F:System.Globalization.CompareOptions.IgnoreWidth"/>, <see cref="F:System.Globalization.CompareOptions.IgnoreKanaType"/>, and <see cref="F:System.Globalization.CompareOptions.StringSort"/>.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="offset1"/> or <paramref name="offset2"/> is less than zero.-or- <paramref name="offset1"/> is greater than or equal to the number of characters in <paramref name="string1"/>.-or- <paramref name="offset2"/> is greater than or equal to the number of characters in <paramref name="string2"/>. </exception><exception cref="T:System.ArgumentException"><paramref name="options"/> contains an invalid <see cref="T:System.Globalization.CompareOptions"/> value. </exception>
        public virtual int Compare(string string1, int offset1, string string2, int offset2, CompareOptions options)
        {
            return this.Compare(string1, offset1, string1 == null ? 0 : string1.Length - offset1, string2, offset2, string2 == null ? 0 : string2.Length - offset2, options);
        }

        /// <summary>
        /// Compares the end section of a string with the end section of another string.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer indicating the lexical relationship between the two comparands.Value Condition zero The two strings are equal. less than zero The specified section of <paramref name="string1"/> is less than the specified section of <paramref name="string2"/>. greater than zero The specified section of <paramref name="string1"/> is greater than the specified section of <paramref name="string2"/>.
        /// </returns>
        /// <param name="string1">The first string to compare. </param><param name="offset1">The zero-based index of the character in <paramref name="string1"/> at which to start comparing. </param><param name="string2">The second string to compare. </param><param name="offset2">The zero-based index of the character in <paramref name="string2"/> at which to start comparing. </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="offset1"/> or <paramref name="offset2"/> is less than zero.-or- <paramref name="offset1"/> is greater than or equal to the number of characters in <paramref name="string1"/>.-or- <paramref name="offset2"/> is greater than or equal to the number of characters in <paramref name="string2"/>. </exception>
        public virtual int Compare(string string1, int offset1, string string2, int offset2)
        {
            return this.Compare(string1, offset1, string2, offset2, CompareOptions.None);
        }

        /// <summary>
        /// Compares a section of one string with a section of another string using the specified <see cref="T:System.Globalization.CompareOptions"/> value.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer indicating the lexical relationship between the two comparands.Value Condition zero The two strings are equal. less than zero The specified section of <paramref name="string1"/> is less than the specified section of <paramref name="string2"/>. greater than zero The specified section of <paramref name="string1"/> is greater than the specified section of <paramref name="string2"/>.
        /// </returns>
        /// <param name="string1">The first string to compare. </param><param name="offset1">The zero-based index of the character in <paramref name="string1"/> at which to start comparing. </param><param name="length1">The number of consecutive characters in <paramref name="string1"/> to compare. </param><param name="string2">The second string to compare. </param><param name="offset2">The zero-based index of the character in <paramref name="string2"/> at which to start comparing. </param><param name="length2">The number of consecutive characters in <paramref name="string2"/> to compare. </param><param name="options">A value that defines how <paramref name="string1"/> and <paramref name="string2"/> should be compared. <paramref name="options"/> is either the enumeration value <see cref="F:System.Globalization.CompareOptions.Ordinal"/>, or a bitwise combination of one or more of the following values: <see cref="F:System.Globalization.CompareOptions.IgnoreCase"/>, <see cref="F:System.Globalization.CompareOptions.IgnoreSymbols"/>, <see cref="F:System.Globalization.CompareOptions.IgnoreNonSpace"/>, <see cref="F:System.Globalization.CompareOptions.IgnoreWidth"/>, <see cref="F:System.Globalization.CompareOptions.IgnoreKanaType"/>, and <see cref="F:System.Globalization.CompareOptions.StringSort"/>.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="offset1"/> or <paramref name="length1"/> or <paramref name="offset2"/> or <paramref name="length2"/> is less than zero.-or- <paramref name="offset1"/> is greater than or equal to the number of characters in <paramref name="string1"/>.-or- <paramref name="offset2"/> is greater than or equal to the number of characters in <paramref name="string2"/>.-or- <paramref name="length1"/> is greater than the number of characters from <paramref name="offset1"/> to the end of <paramref name="string1"/>.-or- <paramref name="length2"/> is greater than the number of characters from <paramref name="offset2"/> to the end of <paramref name="string2"/>. </exception><exception cref="T:System.ArgumentException"><paramref name="options"/> contains an invalid <see cref="T:System.Globalization.CompareOptions"/> value. </exception>
        public virtual int Compare(string string1, int offset1, int length1, string string2, int offset2, int length2, CompareOptions options)
        {
            return string.Compare(string1.Substring(offset1, length1), string2.Substring(offset2, length2), StringComparison.OrdinalIgnoreCase);
        }
    }
}