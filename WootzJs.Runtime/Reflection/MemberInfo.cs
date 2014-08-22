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

namespace System.Reflection
{
    public abstract class MemberInfo : ICustomAttributeProvider
    {
        protected internal readonly Attribute[] attributes;

        private string name;
        internal Type declaringType;

        protected MemberInfo(string name, Attribute[] attributes)
        {
            this.name = name;
            this.attributes = attributes;
        }

        /// <summary>
        /// When overridden in a derived class, gets a <see cref="T:System.Reflection.MemberTypes"/> value indicating the type of the member — method, constructor, event, and so on.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MemberTypes"/> value indicating the type of member.
        /// </returns>
        public abstract MemberTypes MemberType { get; }

        /// <summary>
        /// Gets the name of the current member.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.String"/> containing the name of this member.
        /// </returns>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Gets the class that declares this member.
        /// </summary>
        /// 
        /// <returns>
        /// The Type object for the class that declares this member.
        /// </returns>
        public Type DeclaringType
        {
            get { return declaringType; }
        }

        /// <summary>
        /// When overridden in a derived class, returns an array of all custom attributes applied to this member.
        /// </summary>
        /// 
        /// <returns>
        /// An array that contains all the custom attributes applied to this member, or an array with zero elements if no attributes are defined.
        /// </returns>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param><exception cref="T:System.InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context. See How to: Load Assemblies into the Reflection-Only Context.</exception><exception cref="T:System.TypeLoadException">A custom attribute type could not be loaded. </exception>
        public virtual object[] GetCustomAttributes(bool inherit)
        {
            return attributes.ToArray();
        }

        /// <summary>
        /// When overridden in a derived class, returns an array of custom attributes applied to this member and identified by <see cref="T:System.Type"/>.
        /// </summary>
        /// 
        /// <returns>
        /// An array of custom attributes applied to this member, or an array with zero elements if no attributes assignable to <paramref name="attributeType"/> have been applied.
        /// </returns>
        /// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned. </param><param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks. </param><exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded. </exception><exception cref="T:System.ArgumentNullException">If <paramref name="attributeType"/> is null.</exception><exception cref="T:System.InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context. See How to: Load Assemblies into the Reflection-Only Context.</exception>
        public object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            return GetCustomAttributes(inherit).Where(x => attributeType.IsInstanceOfType(x)).ToArray();
        }

        /// <summary>
        /// When overridden in a derived class, indicates whether one or more attributes of the specified type or of its derived types is applied to this member.
        /// </summary>
        /// 
        /// <returns>
        /// true if one or more instances of <paramref name="attributeType"/> or any of its derived types is applied to this member; otherwise, false.
        /// </returns>
        /// <param name="attributeType">The type of custom attribute to search for. The search includes derived types. </param><param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param>
        public bool IsDefined(Type attributeType, bool inherit)
        {
            return GetCustomAttributes(inherit).Any(x => attributeType.IsInstanceOfType(x));
        }
    }
}
