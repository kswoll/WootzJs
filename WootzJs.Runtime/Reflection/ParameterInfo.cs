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

using System.Linq;

namespace System.Reflection
{
    /// <summary>
    /// Discovers the attributes of a parameter and provides access to parameter metadata.
    /// </summary>
    public class ParameterInfo : ICustomAttributeProvider
    {
        private string name;
        private JsTypeFunction type;
        private int position;
        private ParameterAttributes parameterAttributes;
        private object defaultValue;
        internal MemberInfo containingMember;
        private Attribute[] attributes;

        public ParameterInfo(string name, JsTypeFunction type, int position, ParameterAttributes parameterAttributes, object defaultValue, Attribute[] attributes)
        {
            this.name = name;
            this.type = type;
            this.position = position;
            this.parameterAttributes = parameterAttributes;
            this.defaultValue = defaultValue;
            this.attributes = attributes;
        }

        /// <summary>
        /// Gets the Type of this parameter.
        /// </summary>
        /// 
        /// <returns>
        /// The Type object that represents the Type of this parameter.
        /// </returns>
        public Type ParameterType
        {
            get { return Type._GetTypeFromTypeFunc(type); }
        }

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        /// 
        /// <returns>
        /// The simple name of this parameter.
        /// </returns>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Gets a value that indicates whether this parameter has a default value.
        /// </summary>
        /// 
        /// <returns>
        /// true if this parameter has a default value; otherwise, false.
        /// </returns>
        public bool HasDefaultValue
        {
            get { return IsOptional; }
        }

        /// <summary>
        /// Gets a value indicating the default value if the parameter has a default value.
        /// </summary>
        /// 
        /// <returns>
        /// The default value of the parameter, or <see cref="F:System.DBNull.Value"/> if the parameter has no default value.
        /// </returns>
        public object DefaultValue
        {
            get { return defaultValue; }
        }

        /// <summary>
        /// Gets a value indicating the default value if the parameter has a default value.
        /// </summary>
        /// 
        /// <returns>
        /// The default value of the parameter, or <see cref="F:System.DBNull.Value"/> if the parameter has no default value.
        /// </returns>
        public object RawDefaultValue
        {
            get { return (this.Attributes & ParameterAttributes.HasDefault) != ParameterAttributes.None; }
        }

        /// <summary>
        /// Gets the zero-based position of the parameter in the formal parameter list.
        /// </summary>
        /// 
        /// <returns>
        /// An integer representing the position this parameter occupies in the parameter list.
        /// </returns>
        public int Position
        {
            get { return position; }
        }

        /// <summary>
        /// Gets the attributes for this parameter.
        /// </summary>
        /// 
        /// <returns>
        /// A ParameterAttributes object representing the attributes for this parameter.
        /// </returns>
        public ParameterAttributes Attributes
        {
            get { return parameterAttributes; }
        }

        /// <summary>
        /// Gets a value indicating the member in which the parameter is implemented.
        /// </summary>
        /// 
        /// <returns>
        /// The member which implanted the parameter represented by this <see cref="T:System.Reflection.ParameterInfo"/>.
        /// </returns>
        public virtual MemberInfo Member
        {
            get { return containingMember; }
        }

        /// <summary>
        /// Gets a value indicating whether this is an input parameter.
        /// </summary>
        /// 
        /// <returns>
        /// true if the parameter is an input parameter; otherwise, false.
        /// </returns>
        public bool IsIn
        {
            get { return (this.Attributes & ParameterAttributes.In) != ParameterAttributes.None; }
        }

        /// <summary>
        /// Gets a value indicating whether this is an output parameter.
        /// </summary>
        /// 
        /// <returns>
        /// true if the parameter is an output parameter; otherwise, false.
        /// </returns>
        public bool IsOut
        {
            get { return (this.Attributes & ParameterAttributes.Out) != ParameterAttributes.None; }
        }

        /// <summary>
        /// Gets a value indicating whether this parameter is a locale identifier (lcid).
        /// </summary>
        /// 
        /// <returns>
        /// true if the parameter is a locale identifier; otherwise, false.
        /// </returns>
        public bool IsLcid
        {
            get { return (this.Attributes & ParameterAttributes.Lcid) != ParameterAttributes.None; }
        }

        /// <summary>
        /// Gets a value indicating whether this is a Retval parameter.
        /// </summary>
        /// 
        /// <returns>
        /// true if the parameter is a Retval; otherwise, false.
        /// </returns>
        public bool IsRetval
        {
            get { return (this.Attributes & ParameterAttributes.Retval) != ParameterAttributes.None; }
        }

        /// <summary>
        /// Gets a value indicating whether this parameter is optional.
        /// </summary>
        /// 
        /// <returns>
        /// true if the parameter is optional; otherwise, false.
        /// </returns>
        public bool IsOptional
        {
            get { return (this.Attributes & ParameterAttributes.Optional) != ParameterAttributes.None; }
        }

        /// <summary>
        /// Gets the parameter type and name represented as a string.
        /// </summary>
        /// 
        /// <returns>
        /// A string containing the type and the name of the parameter.
        /// </returns>
        public override string ToString()
        {
            return this.ParameterType + " " + this.Name;
        }

        /// <summary>
        /// Gets all the custom attributes defined on this parameter.
        /// </summary>
        /// 
        /// <returns>
        /// An array that contains all the custom attributes applied to this parameter.
        /// </returns>
        /// <param name="inherit">This argument is ignored for objects of this type. See Remarks.</param><exception cref="T:System.TypeLoadException">A custom attribute type could not be loaded. </exception>
        public virtual object[] GetCustomAttributes(bool inherit)
        {
            return attributes.ToArray();
        }

        /// <summary>
        /// Gets the custom attributes of the specified type or its derived types that are applied to this parameter.
        /// </summary>
        /// 
        /// <returns>
        /// An array that contains the custom attributes of the specified type or its derived types.
        /// </returns>
        /// <param name="attributeType">The custom attributes identified by type. </param><param name="inherit">This argument is ignored for objects of this type. See Remarks.</param><exception cref="T:System.ArgumentException">The type must be a type provided by the underlying runtime system.</exception><exception cref="T:System.ArgumentNullException"><paramref name="attributeType"/> is null.</exception><exception cref="T:System.TypeLoadException">A custom attribute type could not be loaded. </exception>
        public virtual object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            return GetCustomAttributes(inherit).Where(x => attributeType.IsInstanceOfType(x)).ToArray();
        }

        /// <summary>
        /// Determines whether the custom attribute of the specified type or its derived types is applied to this parameter.
        /// </summary>
        /// 
        /// <returns>
        /// true if one or more instances of <paramref name="attributeType"/> or its derived types are applied to this parameter; otherwise, false.
        /// </returns>
        /// <param name="attributeType">The Type object to search for. </param><param name="inherit">This argument is ignored for objects of this type. See Remarks.</param><exception cref="T:System.ArgumentNullException"><paramref name="attributeType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="attributeType"/> is not a <see cref="T:System.Type"/> object supplied by the common language runtime.</exception>
        public virtual bool IsDefined(Type attributeType, bool inherit)
        {
            return GetCustomAttributes(inherit).Any(x => attributeType.IsInstanceOfType(x));
        }
    }
}
