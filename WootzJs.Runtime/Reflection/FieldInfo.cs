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

using System.Globalization;
using System.Runtime.WootzJs;

namespace System.Reflection
{
    /// <summary>
    /// Discovers the attributes of a field and provides access to field metadata.
    /// </summary>
    public class FieldInfo : MemberInfo
    {
        private JsTypeFunction fieldType;
        private FieldAttributes fieldAttributes;
        private object constantValue;

        public FieldInfo(string name, JsTypeFunction fieldType, FieldAttributes fieldAttributes, object constantValue, Attribute[] attributes) : base(name, attributes)
        {
            this.fieldType = fieldType;
            this.fieldAttributes = fieldAttributes;
            this.constantValue = constantValue;
        }

        /// <summary>
        /// Gets a <see cref="T:System.Reflection.MemberTypes"/> value indicating that this member is a field.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MemberTypes"/> value indicating that this member is a field.
        /// </returns>
        public override MemberTypes MemberType
        {
            get { return MemberTypes.Field; }
        }

        /// <summary>
        /// Gets the type of this field object.
        /// </summary>
        /// 
        /// <returns>
        /// The type of this field object.
        /// </returns>
        public Type FieldType
        {
            get { return Type._GetTypeFromTypeFunc(fieldType); }
        }

        /// <summary>
        /// Gets the attributes associated with this field.
        /// </summary>
        /// 
        /// <returns>
        /// The FieldAttributes for this field.
        /// </returns>
        public FieldAttributes Attributes
        {
            get { return fieldAttributes; }
        }

        /// <summary>
        /// Gets a value indicating whether the field is public.
        /// </summary>
        /// 
        /// <returns>
        /// true if this field is public; otherwise, false.
        /// </returns>
        public bool IsPublic
        {
            get { return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Public; }
        }

        /// <summary>
        /// Gets a value indicating whether the field is private.
        /// </summary>
        /// 
        /// <returns>
        /// true if the field is private; otherwise; false.
        /// </returns>
        public bool IsPrivate
        {
            get { return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Private; }
        }

        /// <summary>
        /// Gets a value indicating whether the visibility of this field is described by <see cref="F:System.Reflection.FieldAttributes.Family"/>; that is, the field is visible only within its class and derived classes.
        /// </summary>
        /// 
        /// <returns>
        /// true if access to this field is exactly described by <see cref="F:System.Reflection.FieldAttributes.Family"/>; otherwise, false.
        /// </returns>
        public bool IsFamily
        {
            get { return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Family; }
        }

        /// <summary>
        /// Gets a value indicating whether the potential visibility of this field is described by <see cref="F:System.Reflection.FieldAttributes.Assembly"/>; that is, the field is visible at most to other types in the same assembly, and is not visible to derived types outside the assembly.
        /// </summary>
        /// 
        /// <returns>
        /// true if the visibility of this field is exactly described by <see cref="F:System.Reflection.FieldAttributes.Assembly"/>; otherwise, false.
        /// </returns>
        public bool IsAssembly
        {
            get { return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Assembly; }
        }

        /// <summary>
        /// Gets a value indicating whether the visibility of this field is described by <see cref="F:System.Reflection.FieldAttributes.FamANDAssem"/>; that is, the field can be accessed from derived classes, but only if they are in the same assembly.
        /// </summary>
        /// 
        /// <returns>
        /// true if access to this field is exactly described by <see cref="F:System.Reflection.FieldAttributes.FamANDAssem"/>; otherwise, false.
        /// </returns>
        public bool IsFamilyAndAssembly
        {
            get { return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.FamANDAssem; }
        }

        /// <summary>
        /// Gets a value indicating whether the potential visibility of this field is described by <see cref="F:System.Reflection.FieldAttributes.FamORAssem"/>; that is, the field can be accessed by derived classes wherever they are, and by classes in the same assembly.
        /// </summary>
        /// 
        /// <returns>
        /// true if access to this field is exactly described by <see cref="F:System.Reflection.FieldAttributes.FamORAssem"/>; otherwise, false.
        /// </returns>
        public bool IsFamilyOrAssembly
        {
            get { return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.FamORAssem; }
        }

        /// <summary>
        /// Gets a value indicating whether the field is static.
        /// </summary>
        /// 
        /// <returns>
        /// true if this field is static; otherwise, false.
        /// </returns>
        public bool IsStatic
        {
            get { return (this.Attributes & FieldAttributes.Static) != FieldAttributes.PrivateScope; }
        }

        /// <summary>
        /// Gets a value indicating whether the field can only be set in the body of the constructor.
        /// </summary>
        /// 
        /// <returns>
        /// true if the field has the InitOnly attribute set; otherwise, false.
        /// </returns>
        public bool IsInitOnly
        {
            get { return (this.Attributes & FieldAttributes.InitOnly) != FieldAttributes.PrivateScope; }
        }

        /// <summary>
        /// Gets a value indicating whether the value is written at compile time and cannot be changed.
        /// </summary>
        /// 
        /// <returns>
        /// true if the field has the Literal attribute set; otherwise, false.
        /// </returns>
        public bool IsLiteral
        {
            get { return (this.Attributes & FieldAttributes.Literal) != FieldAttributes.PrivateScope; }
        }

        /// <summary>
        /// Gets a value indicating whether this field has the NotSerialized attribute.
        /// </summary>
        /// 
        /// <returns>
        /// true if the field has the NotSerialized attribute set; otherwise, false.
        /// </returns>
        public bool IsNotSerialized
        {
            get { return (this.Attributes & FieldAttributes.NotSerialized) != FieldAttributes.PrivateScope; }
        }

        /// <summary>
        /// Gets a value indicating whether the corresponding SpecialName attribute is set in the <see cref="T:System.Reflection.FieldAttributes"/> enumerator.
        /// </summary>
        /// 
        /// <returns>
        /// true if the SpecialName attribute is set in <see cref="T:System.Reflection.FieldAttributes"/>; otherwise, false.
        /// </returns>
        public bool IsSpecialName
        {
            get { return (this.Attributes & FieldAttributes.SpecialName) != FieldAttributes.PrivateScope; }
        }

        /// <summary>
        /// Gets a value indicating whether the corresponding PinvokeImpl attribute is set in <see cref="T:System.Reflection.FieldAttributes"/>.
        /// </summary>
        /// 
        /// <returns>
        /// true if the PinvokeImpl attribute is set in <see cref="T:System.Reflection.FieldAttributes"/>; otherwise, false.
        /// </returns>
        public bool IsPinvokeImpl
        {
            get { return (this.Attributes & FieldAttributes.PinvokeImpl) != FieldAttributes.PrivateScope; }
        }

        /// <summary>
        /// Gets a <see cref="T:System.Reflection.FieldInfo"/> for the field represented by the specified handle.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.FieldInfo"/> object representing the field specified by <paramref name="handle"/>.
        /// </returns>
        /// <param name="handle">A <see cref="T:System.RuntimeFieldHandle"/> structure that contains the handle to the internal metadata representation of a field. </param><exception cref="T:System.ArgumentException"><paramref name="handle"/> is invalid.</exception>
        public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a <see cref="T:System.Reflection.FieldInfo"/> for the field represented by the specified handle, for the specified generic type.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.FieldInfo"/> object representing the field specified by <paramref name="handle"/>, in the generic type specified by <paramref name="declaringType"/>.
        /// </returns>
        /// <param name="handle">A <see cref="T:System.RuntimeFieldHandle"/> structure that contains the handle to the internal metadata representation of a field.</param><param name="declaringType">A <see cref="T:System.RuntimeTypeHandle"/> structure that contains the handle to the generic type that defines the field.</param><exception cref="T:System.ArgumentException"><paramref name="handle"/> is invalid.-or-<paramref name="declaringType"/> is not compatible with <paramref name="handle"/>. For example, <paramref name="declaringType"/> is the runtime type handle of the generic type definition, and <paramref name="handle"/> comes from a constructed type. See Remarks.</exception>
        public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle, RuntimeTypeHandle declaringType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an array of types that identify the required custom modifiers of the property.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.Type"/> objects that identify the required custom modifiers of the current property, such as <see cref="T:System.Runtime.CompilerServices.IsConst"/> or <see cref="T:System.Runtime.CompilerServices.IsImplicitlyDereferenced"/>.
        /// </returns>
        public virtual Type[] GetRequiredCustomModifiers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an array of types that identify the optional custom modifiers of the field.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.Type"/> objects that identify the optional custom modifiers of the current field, such as <see cref="T:System.Runtime.CompilerServices.IsConst"/>.
        /// </returns>
        public virtual Type[] GetOptionalCustomModifiers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When overridden in a derived class, returns the value of a field supported by a given object.
        /// </summary>
        /// 
        /// <returns>
        /// An object containing the value of the field reflected by this instance.
        /// </returns>
        /// <param name="obj">The object whose field value will be returned. </param><exception cref="T:System.Reflection.TargetException">The field is non-static and <paramref name="obj"/> is null. </exception><exception cref="T:System.NotSupportedException">A field is marked literal, but the field does not have one of the accepted literal types. </exception><exception cref="T:System.FieldAccessException">The caller does not have permission to access this field. </exception><exception cref="T:System.ArgumentException">The method is neither declared nor inherited by the class of <paramref name="obj"/>. </exception>
        public object GetValue(object obj)
        {
            if (IsStatic)
                return DeclaringType.thisType[Name];
            else
                return obj.As<JsObject>()[Name];
        }

        /// <summary>
        /// When overridden in a derived class, sets the value of the field supported by the given object.
        /// </summary>
        /// <param name="obj">The object whose field value will be set. </param><param name="value">The value to assign to the field. </param><param name="invokeAttr">A field of Binder that specifies the type of binding that is desired (for example, Binder.CreateInstance or Binder.ExactBinding). </param><param name="binder">A set of properties that enables the binding, coercion of argument types, and invocation of members through reflection. If <paramref name="binder"/> is null, then Binder.DefaultBinding is used. </param><param name="culture">The software preferences of a particular culture. </param><exception cref="T:System.FieldAccessException">The caller does not have permission to access this field. </exception><exception cref="T:System.Reflection.TargetException">The <paramref name="obj"/> parameter is null and the field is an instance field. </exception><exception cref="T:System.ArgumentException">The field does not exist on the object.-or- The <paramref name="value"/> parameter cannot be converted and stored in the field. </exception>
        public void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
        {
            if (IsStatic)
                DeclaringType.thisType[Name] = value.As<JsObject>();
            else
                obj.As<JsObject>()[Name] = value.As<JsObject>();
        }

        /// <summary>
        /// Returns a literal value associated with the field by a compiler.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Object"/> that contains the literal value associated with the field. If the literal value is a class type with an element value of zero, the return value is null.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The Constant table in unmanaged metadata does not contain a constant value for the current field.</exception><exception cref="T:System.FormatException">The type of the value is not one of the types permitted by the Common Language Specification (CLS). See the ECMA Partition II specification Metadata Logical Format: Other Structures, Element Types used in Signatures. </exception><exception cref="T:System.NotSupportedException">The constant value for the field is not set. </exception>
        public virtual object GetRawConstantValue()
        {
            return constantValue;
        }

        /// <summary>
        /// Sets the value of the field supported by the given object.
        /// </summary>
        /// <param name="obj">The object whose field value will be set. </param><param name="value">The value to assign to the field. </param><exception cref="T:System.FieldAccessException">The caller does not have permission to access this field. </exception><exception cref="T:System.Reflection.TargetException">The <paramref name="obj"/> parameter is null and the field is an instance field. </exception><exception cref="T:System.ArgumentException">The field does not exist on the object.-or- The <paramref name="value"/> parameter cannot be converted and stored in the field. </exception>
        public void SetValue(object obj, object value)
        {
            this.SetValue(obj, value, BindingFlags.Default, Type.DefaultBinder, null);
        }


    }
}
