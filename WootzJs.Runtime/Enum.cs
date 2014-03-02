#region License

//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------

#endregion

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.WootzJs;

namespace System
{
    public abstract class Enum : ValueType
    {
        private readonly string name;
        private readonly object value;

        private static Dictionary<string, Dictionary<string, Enum>> enumsByTypeAndName = new Dictionary<string, Dictionary<string, Enum>>();
        private static Dictionary<string, Dictionary<object, Enum>> enumsByTypeAndValue = new Dictionary<string, Dictionary<object, Enum>>();
        private static Dictionary<string, List<Enum>> enumsByType = new Dictionary<string, List<Enum>>();

        public Enum(string name, object value)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (value == null)
                throw new ArgumentNullException("value");

            this.name = name;
            this.value = value;

            Dictionary<string, Enum> enumsByName;
            if (!enumsByTypeAndName.TryGetValue(___type.TypeName, out enumsByName))
            {
                enumsByName = new Dictionary<string, Enum>();
                enumsByTypeAndName[___type.TypeName] = enumsByName;
            }
            enumsByName[name] = this;

            Dictionary<object, Enum> enumsByValue;
            if (!enumsByTypeAndValue.TryGetValue(___type.TypeName, out enumsByValue))
            {
                enumsByValue = new Dictionary<object, Enum>();
                enumsByTypeAndValue[___type.TypeName] = enumsByValue;
            }
            enumsByValue[value] = this;

            List<Enum> enums;
            if (!enumsByType.TryGetValue(___type.TypeName, out enums))
            {
                enums = new List<Enum>();
                enumsByType[___type.TypeName] = enums;
            }
            enums.Add(this);
        }

        public static Array GetEnumValues(Type type)
        {
            return enumsByType[type.___type.TypeName].ToArray();
        }

        public object GetValue()
        {
            return value;
        }

        public override string ToString()
        {
            return name;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
        /// </summary>
        /// 
        /// <returns>
        /// An object of type <paramref name="enumType"/> whose value is represented by <paramref name="value"/>.
        /// </returns>
        /// <param name="enumType">An enumeration type. </param><param name="value">A string containing the name or value to convert. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> or <paramref name="value"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>.-or- <paramref name="value"/> is either an empty string or only contains white space.-or- <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration. </exception><exception cref="T:System.OverflowException"><paramref name="value"/> is outside the range of the underlying type of <paramref name="enumType"/>.</exception><filterpriority>1</filterpriority>
        public static object Parse(Type enumType, string value)
        {
            return enumsByTypeAndName[enumType.thisType.TypeName][value];
        }

        /// <summary>
        /// Converts the specified object with an integer value to an enumeration member.
        /// </summary>
        /// 
        /// <returns>
        /// An enumeration object whose value is <paramref name="value"/>.
        /// </returns>
        /// <param name="enumType">The enumeration type to return. </param><param name="value">The value convert to an enumeration member. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> or <paramref name="value"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>.-or- <paramref name="value"/> is not type <see cref="T:System.SByte"/>, <see cref="T:System.Int16"/>, <see cref="T:System.Int32"/>, <see cref="T:System.Int64"/>, <see cref="T:System.Byte"/>, <see cref="T:System.UInt16"/>, <see cref="T:System.UInt32"/>, or <see cref="T:System.UInt64"/>. </exception><filterpriority>1</filterpriority>
        public static object ToObject(Type enumType, object value)
        {
            return enumsByTypeAndValue[enumType.thisType.TypeName][value];
        }

        public static object InternalToObject(JsTypeFunction enumType, object value)
        {
            var enumsByValue = enumsByTypeAndValue[enumType.TypeName];
            Enum result;
            if (enumsByValue.TryGetValue(value, out result))
            {
                return result;
            }
            else
            {
                // Otherwise it's an enum value that isn't represented by a declared member.  In 
                // this case, we need to box the value and then force it to be recognized as the 
                // enum type.
                result = Jsni.@new(Jsni.reference("Number"), value.As<JsObject>()).As<Enum>();

                foreach (var property in enumType.member("prototype"))
                {
                    result.As<JsObject>()[property] = enumType.member("prototype")[property];
                }
                foreach (var property in Jsni.type<Enum>().member("prototype"))
                {
                    result.As<JsObject>()[property] = Jsni.type<Enum>().member("prototype")[property];
                }

                result.___type = enumType;
                result.As<JsObject>().memberset("value", value.As<JsObject>());
                return result;
            }
        }

        protected bool Equals(Enum other)
        {
            return Equals(value, other.value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Enum)obj);
        }

        public override int GetHashCode()
        {
            return (value != null ? value.GetHashCode() : 0);
        }

        /// <summary>
        /// Retrieves an array of the names of the constants in a specified enumeration.
        /// </summary>
        /// 
        /// <returns>
        /// A string array of the names of the constants in <paramref name="enumType"/>.
        /// </returns>
        /// <param name="enumType">An enumeration type. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> parameter is not an <see cref="T:System.Enum"/>. </exception><filterpriority>1</filterpriority>
        public static string[] GetNames(Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException("enumType");
            enumType.thisType.invoke();
            return enumsByType[enumType.thisType.TypeName].Select(x => x.name).ToArray();
        }
    }
}