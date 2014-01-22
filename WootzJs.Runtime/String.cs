using System.Collections.Generic;
using System.Globalization;
using System.Runtime.WootzJs;

namespace System
{
    [Js(Name = "String", BuiltIn = true)]
    public class String
    {
        public static readonly string Empty = string.Empty;

        [Js(Export = false)]
        public String(string s)
        {
        }

        [Js(Name = "GetType")]
        public new Type GetType()
        {
            return base.GetType();
        }

        [Js(Name = "replace", Export = false)]
        public string Replace(string searchString, string replaceString)
        {
            return null;
        }

/*
        public char this[int index]
        {
            get { return this.As<JsString>().charAt(index); }
        }
*/

        /// <summary>
        /// Gets the number of characters in the current <see cref="T:System.String"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// The number of characters in the current string.
        /// </returns>
        [Js(Export = false, Name = "length")]
        public int Length
        {
            get { return 0; }
        }

        /// <summary>
        /// Returns a copy of this string converted to uppercase.
        /// </summary>
        /// 
        /// <returns>
        /// The uppercase equivalent of the current string.
        /// </returns>
        [Js(Export = false, Name = "toUpperCase")]
        public string ToUpper()
        {
            return null;
        }

        /// <summary>
        /// Returns a copy of this string converted to lowercase.
        /// </summary>
        /// 
        /// <returns>
        /// A string in lowercase.
        /// </returns>
        [Js(Export = false, Name = "toLowerCase")]
        public string ToLower()
        {
            return null;
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance.
        /// </summary>
        /// 
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"/>, the return value is 0.
        /// </returns>
        /// <param name="value">The string to seek. </param><param name="startIndex">The search starting position. </param><exception cref="T:System.ArgumentNullException"><paramref name="value"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="startIndex"/> is less than 0 (zero) or greater than the length of this string.</exception><filterpriority>1</filterpriority>
        [Js(Export = false, Name = "indexOf")]
        public int IndexOf(string value, int startIndex = 0)
        {
            return 0;
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this string. The search starts at a specified character position.
        /// </summary>
        /// 
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.
        /// </returns>  
        /// <param name="value">A Unicode character to seek. </param><param name="startIndex">The search starting position. </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="startIndex"/> is less than 0 (zero) or greater than the length of the string. </exception><filterpriority>1</filterpriority>
        [Js(Export = false, Name = "indexOf")]
        public int IndexOf(char value, int startIndex = 0)
        {
            return 0;
        }

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of a specified string within this instance.
        /// </summary>
        /// 
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"/>, the return value is the last index position in this instance.
        /// </returns>
        /// <param name="value">The string to seek. </param><param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex"/> toward the beginning of this instance.</param><exception cref="T:System.ArgumentNullException"><paramref name="value"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException">The current instance does not equal <see cref="F:System.String.Empty"/>, and <paramref name="startIndex"/> is less than zero or greater than the length of the current instance. -or-The current instance equals <see cref="F:System.String.Empty"/>, and <paramref name="startIndex"/> is greater than zero.</exception><filterpriority>1</filterpriority>
        [Js(Export = false, Name = "lastIndexOf")]
        public int LastIndexOf(string value, int startIndex = 0)
        {
            return 0;
        }

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of a specified Unicode character within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string.
        /// </summary>
        /// 
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty"/>.
        /// </returns>
        /// <param name="value">The Unicode character to seek. </param><param name="startIndex">The starting position of the search. The search proceeds from <paramref name="startIndex"/> toward the beginning of this instance.</param><exception cref="T:System.ArgumentOutOfRangeException">The current instance does not equal <see cref="F:System.String.Empty"/>, and <paramref name="startIndex"/> is less than zero or greater than or equal to the length of this instance.</exception><filterpriority>1</filterpriority>
        [Js(Export = false, Name = "lastIndexOf")]
        public int LastIndexOf(char value, int startIndex = 0)
        {
            return 0;
        }

        /// <summary>
        /// Determines whether the end of this string instance matches the specified string.
        /// </summary>
        /// 
        /// <returns>
        /// true if <paramref name="value"/> matches the end of this instance; otherwise, false.
        /// </returns>
        /// <param name="value">The string to compare to the substring at the end of this instance. </param><exception cref="T:System.ArgumentNullException"><paramref name="value"/> is null. </exception><filterpriority>1</filterpriority>
        [Js(Extension = true)]
        public bool EndsWith(String suffix)
        {
            return IndexOf(suffix, Length - suffix.Length) != -1;
        }

        /// <summary>
        /// Determines whether the beginning of this string instance matches the specified string.
        /// </summary>
        /// 
        /// <returns>
        /// true if <paramref name="value"/> matches the beginning of this string; otherwise, false.
        /// </returns>
        /// <param name="value">The string to compare. </param><exception cref="T:System.ArgumentNullException"><paramref name="value"/> is null. </exception><filterpriority>1</filterpriority>
        [Js(Extension = true)]
        public bool StartsWith(string prefix)
        {
            return IndexOf(prefix) == 0;
        }

        public char this[int index]
        {
            get { return ' '; }
        }

        /// <summary>
        /// Compares two specified <see cref="T:System.String"/> objects and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer that indicates the lexical relationship between the two comparands.Value Condition Less than zero <paramref name="strA"/> is less than <paramref name="strB"/>. Zero <paramref name="strA"/> equals <paramref name="strB"/>. Greater than zero <paramref name="strA"/> is greater than <paramref name="strB"/>.
        /// </returns>
        /// <param name="strA">The first string to compare. </param><param name="strB">The second string to compare. </param><filterpriority>1</filterpriority>
        [Js(Native = @"
if (strA < strB) return -1;
if (strA > strB) return 1;
return 0;
")]
        public static int Compare(string strA, string strB)
        {
            return 0;
        }

        /// <summary>
        /// Compares two specified <see cref="T:System.String"/> objects using the specified rules, and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer that indicates the lexical relationship between the two comparands.Value Condition Less than zero <paramref name="strA"/> is less than <paramref name="strB"/>. Zero <paramref name="strA"/> equals <paramref name="strB"/>. Greater than zero <paramref name="strA"/> is greater than <paramref name="strB"/>.
        /// </returns>
        /// <param name="strA">The first string to compare.</param><param name="strB">The second string to compare. </param><param name="comparisonType">One of the enumeration values that specifies the rules to use in the comparison. </param><exception cref="T:System.ArgumentException"><paramref name="comparisonType"/> is not a <see cref="T:System.StringComparison"/> value. </exception><exception cref="T:System.NotSupportedException"><see cref="T:System.StringComparison"/> is not supported.</exception><filterpriority>1</filterpriority>
        public static int Compare(string strA, string strB, StringComparison comparisonType)
        {
            if ((uint)comparisonType > 5U)
                throw new ArgumentException("NotSupported_StringComparison");
            if (strA == strB)
                return 0;
            if (strA == null)
                return -1;
            if (strB == null)
                return 1;
            switch (comparisonType)
            {
                case StringComparison.CurrentCulture:
                    return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
                case StringComparison.CurrentCultureIgnoreCase:
                    return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
                case StringComparison.InvariantCulture:
                    return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
                case StringComparison.InvariantCultureIgnoreCase:
                    return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
                case StringComparison.Ordinal:
                    return CultureInfo.Ordinal.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
                case StringComparison.OrdinalIgnoreCase:
                    return CultureInfo.OrdinalIgnoreCase.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
                default:
                    throw new NotSupportedException("NotSupported_StringComparison");
            }
        }


        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
        /// </summary>
        /// 
        /// <returns>
        /// A string that is equivalent to the substring of length <paramref name="length"/> that begins at <paramref name="startIndex"/> in this instance, or <see cref="F:System.String.Empty"/> if <paramref name="startIndex"/> is equal to the length of this instance and <paramref name="length"/> is zero.
        /// </returns>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance. </param><param name="length">The number of characters in the substring. </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="startIndex"/> plus <paramref name="length"/> indicates a position not within this instance.-or- <paramref name="startIndex"/> or <paramref name="length"/> is less than zero. </exception><filterpriority>1</filterpriority>
        [Js(Extension = true)]
        public string Substring(int startIndex, int length = 0)
        {
            var s = this.As<JsString>();
            if (length == 0)
                return s.substring(startIndex);
            else
                return s.substring(startIndex, startIndex + length);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this instance that are delimited by elements of a specified Unicode character array.
        /// </summary>
        /// 
        /// <returns>
        /// An array whose elements contain the substrings in this instance that are delimited by one or more characters in <paramref name="separator"/>. For more information, see the Remarks section.
        /// </returns>
        /// <param name="separator">An array of Unicode characters that delimit the substrings in this instance, an empty array that contains no delimiters, or null. </param><filterpriority>1</filterpriority>
        [Js(Extension = true)]
        public string[] Split(params char[] separator)
        {
            var s = this.As<JsString>();
            var stringSeparator = new string[separator.Length];
            for (var i = 0; i < separator.Length; i++)
                stringSeparator[i] = separator[i].ToString();
            var array = s.split(new JsRegExp(Join("|", stringSeparator)));
            return array.As<string[]>();
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this instance that are delimited by elements of a specified Unicode character array. A parameter specifies the maximum number of substrings to return.
        /// </summary>
        /// 
        /// <returns>
        /// An array whose elements contain the substrings in this instance that are delimited by one or more characters in <paramref name="separator"/>. For more information, see the Remarks section.
        /// </returns>
        /// <param name="separator">An array of Unicode characters that delimit the substrings in this instance, an empty array that contains no delimiters, or null. </param><param name="count">The maximum number of substrings to return. </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count"/> is negative. </exception><filterpriority>1</filterpriority>
        [Js(Extension = true)]
        public string[] Split(char[] separator, int count)
        {
            var s = this.As<JsString>();
            var stringSeparator = new string[separator.Length];
            for (var i = 0; i < separator.Length; i++)
                stringSeparator[i] = separator[i].ToString();
            var array = s.split(new JsRegExp(Join("|", stringSeparator)), count);
            return array.As<string[]>();
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by elements of a specified Unicode character array. A parameter specifies whether to return empty array elements.
        /// </summary>
        /// 
        /// <returns>
        /// An array whose elements contain the substrings in this string that are delimited by one or more characters in <paramref name="separator"/>. For more information, see the Remarks section.
        /// </returns>
        /// <param name="separator">An array of Unicode characters that delimit the substrings in this string, an empty array that contains no delimiters, or null. </param><param name="options"><see cref="F:System.StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="F:System.StringSplitOptions.None"/> to include empty array elements in the array returned. </param><exception cref="T:System.ArgumentException"><paramref name="options"/> is not one of the <see cref="T:System.StringSplitOptions"/> values.</exception><filterpriority>1</filterpriority>
        [Js(Extension = true)]
        public string[] Split(char[] separator, StringSplitOptions options)
        {
            return null;
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by elements of a specified Unicode character array. Parameters specify the maximum number of substrings to return and whether to return empty array elements.
        /// </summary>
        /// 
        /// <returns>
        /// An array whose elements contain the substrings in this string that are delimited by one or more characters in <paramref name="separator"/>. For more information, see the Remarks section.
        /// </returns>
        /// <param name="separator">An array of Unicode characters that delimit the substrings in this string, an empty array that contains no delimiters, or null. </param><param name="count">The maximum number of substrings to return. </param><param name="options"><see cref="F:System.StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="F:System.StringSplitOptions.None"/> to include empty array elements in the array returned. </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count"/> is negative. </exception><exception cref="T:System.ArgumentException"><paramref name="options"/> is not one of the <see cref="T:System.StringSplitOptions"/> values.</exception><filterpriority>1</filterpriority>
        [Js(Extension = true)]
        public string[] Split(char[] separator, int count, StringSplitOptions options)
        {
            return null;
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array. A parameter specifies whether to return empty array elements.
        /// </summary>
        /// 
        /// <returns>
        /// An array whose elements contain the substrings in this string that are delimited by one or more strings in <paramref name="separator"/>. For more information, see the Remarks section.
        /// </returns>
        /// <param name="separator">An array of strings that delimit the substrings in this string, an empty array that contains no delimiters, or null. </param><param name="options"><see cref="F:System.StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="F:System.StringSplitOptions.None"/> to include empty array elements in the array returned. </param><exception cref="T:System.ArgumentException"><paramref name="options"/> is not one of the <see cref="T:System.StringSplitOptions"/> values.</exception><filterpriority>1</filterpriority>
        [Js(Extension = true)]
        public string[] Split(string[] separator, StringSplitOptions options)
        {
            return this.Split(separator, int.MaxValue, options);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array. Parameters specify the maximum number of substrings to return and whether to return empty array elements.
        /// </summary>
        /// 
        /// <returns>
        /// An array whose elements contain the substrings in this string that are delimited by one or more strings in <paramref name="separator"/>. For more information, see the Remarks section.
        /// </returns>
        /// <param name="separator">An array of strings that delimit the substrings in this string, an empty array that contains no delimiters, or null. </param><param name="count">The maximum number of substrings to return. </param><param name="options"><see cref="F:System.StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="F:System.StringSplitOptions.None"/> to include empty array elements in the array returned. </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count"/> is negative. </exception><exception cref="T:System.ArgumentException"><paramref name="options"/> is not one of the <see cref="T:System.StringSplitOptions"/> values.</exception><filterpriority>1</filterpriority>
        [Js(Extension = true)]
        public string[] Split(string[] separator, int count, StringSplitOptions options)
        {
            return null;
        }

        /// <summary>
        /// Concatenates all the elements of a string array, using the specified separator between each element.
        /// </summary>
        /// 
        /// <returns>
        /// A string that consists of the elements in <paramref name="value"/> delimited by the <paramref name="separator"/> string. If <paramref name="value"/> is an empty array, the method returns <see cref="F:System.String.Empty"/>.
        /// </returns>
        /// <param name="separator">The string to use as a separator. </param><param name="value">An array that contains the elements to concatenate. </param><exception cref="T:System.ArgumentNullException"><paramref name="value"/> is null. </exception><filterpriority>1</filterpriority>
        [Js(Extension = true)]
        public static string Join(string separator, params string[] value)
        {
            var array = value.As<JsArray>();
            return array.join(separator.As<JsString>());
        }

        [Js(Export = false)]
        public static bool operator ==(string left, string right)
        {
            return left.Equals(right);
        }

        [Js(Export = false)]
        public static bool operator !=(string left, string right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return this == obj; // Looks bad, but becacuse the ==/!= operators are not exported, it will work properly
        }

// ReSharper disable once RedundantOverridenMember
        public override string GetStringHashCode()
        {
            // We need to override it to make sure this method gets added to the String prototype.
            return this;
        }

        public override int GetHashCode()
        {
            throw new Exception();
/*
 *      The below will work but is slow.  I could cache it, but that would be noisy.  I want to wait for a valid use-case before
 *      implementing.
            var hash = 0;
            for (var i = 0; i < Length; i++)
            {
                var character = this.As<JsString>().charCodeAt(i);
                hash = ((hash << 5) - hash) + character;
                hash = hash & hash; // Convert to 32bit integer
            }
            return hash;
*/
        }

        public override string ToString()
        {
            return this;
        }

        /// <summary>
        /// Creates the string  representation of a specified object.
        /// </summary>
        /// 
        /// <returns>
        /// The string representation of the value of <paramref name="arg0"/>, or <see cref="F:System.String.Empty"/> if <paramref name="arg0"/> is null.
        /// </returns>
        /// <param name="arg0">The object to represent, or null. </param><filterpriority>1</filterpriority>
        public static string Concat(object arg0)
        {
            if (arg0 == null)
                return string.Empty;
            else
                return arg0.ToString();
        }

        /// <summary>
        /// Concatenates the string representations of two specified objects.
        /// </summary>
        /// 
        /// <returns>
        /// The concatenated string representations of the values of <paramref name="arg0"/> and <paramref name="arg1"/>.
        /// </returns>
        /// <param name="arg0">The first object to concatenate. </param><param name="arg1">The second object to concatenate. </param><filterpriority>1</filterpriority>
        public static string Concat(object arg0, object arg1)
        {
            if (arg0 == null)
                arg0 = string.Empty;
            if (arg1 == null)
                arg1 = string.Empty;
            return arg0.ToString() + arg1;
        }

        /// <summary>
        /// Concatenates the string representations of three specified objects.
        /// </summary>
        /// 
        /// <returns>
        /// The concatenated string representations of the values of <paramref name="arg0"/>, <paramref name="arg1"/>, and <paramref name="arg2"/>.
        /// </returns>
        /// <param name="arg0">The first object to concatenate. </param><param name="arg1">The second object to concatenate. </param><param name="arg2">The third object to concatenate. </param><filterpriority>1</filterpriority>
        public static string Concat(object arg0, object arg1, object arg2)
        {
            if (arg0 == null)
                arg0 = string.Empty;
            if (arg1 == null)
                arg1 = string.Empty;
            if (arg2 == null)
                arg2 = string.Empty;
            return arg0.ToString() + arg1 + arg2;
        }

/*
        public static string Concat(object arg0, object arg1, object arg2, object arg3, __arglist)
        {
            ArgIterator argIterator = new ArgIterator(__arglist);
            int length = argIterator.GetRemainingCount() + 4;
            object[] objArray = new object[length];
            objArray[0] = arg0;
            objArray[1] = arg1;
            objArray[2] = arg2;
            objArray[3] = arg3;
            for (int index = 4; index < length; ++index)
                objArray[index] = TypedReference.ToObject(argIterator.GetNextArg());
            return string.Concat(objArray);
        }
*/

        /// <summary>
        /// Concatenates the string representations of the elements in a specified <see cref="T:System.Object"/> array.
        /// </summary>
        /// 
        /// <returns>
        /// The concatenated string representations of the values of the elements in <paramref name="args"/>.
        /// </returns>
        /// <param name="args">An object array that contains the elements to concatenate. </param><exception cref="T:System.ArgumentNullException"><paramref name="args"/> is null. </exception><exception cref="T:System.OutOfMemoryException">Out of memory.</exception><filterpriority>1</filterpriority>
        public static string Concat(params object[] args)
        {
            if (args == null)
                throw new ArgumentNullException("args");
            string[] values = new string[args.Length];
            int totalLength = 0;
            for (int index = 0; index < args.Length; ++index)
            {
                object obj = args[index];
                values[index] = obj == null ? string.Empty : obj.ToString();
                if (values[index] == null)
                    values[index] = string.Empty;
                totalLength += values[index].Length;
                if (totalLength < 0)
                    throw new Exception();
            }
            return string.ConcatArray(values, totalLength);
        }

        private static string ConcatArray(string[] values, int totalLength)
        {
            var s = "";
            foreach (var item in values)
            {
                s += item;
            }
            return s;
        }

        /// <summary>
        /// Concatenates the members of an <see cref="T:System.Collections.Generic.IEnumerable`1"/> implementation.
        /// </summary>
        /// 
        /// <returns>
        /// The concatenated members in <paramref name="values"/>.
        /// </returns>
        /// <param name="values">A collection object that implements the <see cref="T:System.Collections.Generic.IEnumerable`1"/> interface.</param><typeparam name="T">The type of the members of <paramref name="values"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="values"/> is null. </exception>
        public static string Concat<T>(IEnumerable<T> values)
        {
            var s = "";
            foreach (var item in values)
            {
                s += item.ToString();
            }
            return s;
        }

        /// <summary>
        /// Concatenates the members of a constructed <see cref="T:System.Collections.Generic.IEnumerable`1"/> collection of type <see cref="T:System.String"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The concatenated strings in <paramref name="values"/>.
        /// </returns>
        /// <param name="values">A collection object that implements <see cref="T:System.Collections.Generic.IEnumerable`1"/> and whose generic type argument is <see cref="T:System.String"/>.</param><exception cref="T:System.ArgumentNullException"><paramref name="values"/> is null. </exception>
        public static string Concat(IEnumerable<string> values)
        {
            var s = "";
            foreach (var item in values)
            {
                s += item;
            }
            return s;
        }

        /// <summary>
        /// Concatenates two specified instances of <see cref="T:System.String"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The concatenation of <paramref name="str0"/> and <paramref name="str1"/>.
        /// </returns>
        /// <param name="str0">The first string to concatenate. </param><param name="str1">The second string to concatenate. </param><filterpriority>1</filterpriority>
        public static string Concat(string str0, string str1)
        {
            return str0 + str1;
        }

        /// <summary>
        /// Concatenates three specified instances of <see cref="T:System.String"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The concatenation of <paramref name="str0"/>, <paramref name="str1"/>, and <paramref name="str2"/>.
        /// </returns>
        /// <param name="str0">The first string to concatenate. </param><param name="str1">The second string to concatenate. </param><param name="str2">The third string to concatenate. </param><filterpriority>1</filterpriority>
        public static string Concat(string str0, string str1, string str2)
        {
            if (str0 == null && str1 == null && str2 == null)
                return string.Empty;
            if (str0 == null)
                str0 = string.Empty;
            if (str1 == null)
                str1 = string.Empty;
            if (str2 == null)
                str2 = string.Empty;
            return str0 + str1 + str2;
        }

        /// <summary>
        /// Concatenates four specified instances of <see cref="T:System.String"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The concatenation of <paramref name="str0"/>, <paramref name="str1"/>, <paramref name="str2"/>, and <paramref name="str3"/>.
        /// </returns>
        /// <param name="str0">The first string to concatenate. </param><param name="str1">The second string to concatenate. </param><param name="str2">The third string to concatenate. </param><param name="str3">The fourth string to concatenate. </param><filterpriority>1</filterpriority>
        public static string Concat(string str0, string str1, string str2, string str3)
        {
            if (str0 == null && str1 == null && (str2 == null && str3 == null))
                return string.Empty;
            if (str0 == null)
                str0 = string.Empty;
            if (str1 == null)
                str1 = string.Empty;
            if (str2 == null)
                str2 = string.Empty;
            if (str3 == null)
                str3 = string.Empty;
            return str0 + str1 + str2 + str3;
        }

        /// <summary>
        /// Concatenates the elements of a specified <see cref="T:System.String"/> array.
        /// </summary>
        /// 
        /// <returns>
        /// The concatenated elements of <paramref name="values"/>.
        /// </returns>
        /// <param name="values">An array of string instances. </param><exception cref="T:System.ArgumentNullException"><paramref name="values"/> is null. </exception><exception cref="T:System.OutOfMemoryException">Out of memory.</exception><filterpriority>1</filterpriority>
        public static string Concat(params string[] values)
        {
            var s = "";
            foreach (var item in values)
            {
                s += item;
            }
            return s;
        }
    }
}