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
using System.Globalization;
using System.Linq;
using System.Runtime.WootzJs;

namespace System.Reflection
{
    /// <summary>
    /// Discovers the attributes of a property and provides access to property metadata.
    /// </summary>
    public class PropertyInfo : MemberInfo
    {
        internal JsTypeFunction propertyType;
        private MethodInfo getMethod;
        private MethodInfo setMethod;
        private ParameterInfo[] indexParameters;

        public PropertyInfo(string name, JsTypeFunction propertyType, MethodInfo getMethod, MethodInfo setMethod, ParameterInfo[] indexParameters, Attribute[] attributes) : base(name, attributes)
        {
            this.propertyType = propertyType;
            this.getMethod = getMethod;
            this.setMethod = setMethod;
            this.indexParameters = indexParameters;
        }

        /// <summary>
        /// Gets a <see cref="T:System.Reflection.MemberTypes"/> value indicating that this member is a property.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MemberTypes"/> value indicating that this member is a property.
        /// </returns>
        public override MemberTypes MemberType
        {
            get { return MemberTypes.Property; }
        }

        /// <summary>
        /// Gets the type of this property.
        /// </summary>
        /// 
        /// <returns>
        /// The type of this property.
        /// </returns>
        public Type PropertyType
        {
            get { return Type._GetTypeFromTypeFunc(propertyType); }
        }

        /// <summary>
        /// Gets the attributes for this property.
        /// </summary>
        /// 
        /// <returns>
        /// Attributes of this property.
        /// </returns>
        public PropertyAttributes Attributes
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a value indicating whether the property can be read.
        /// </summary>
        /// 
        /// <returns>
        /// true if this property can be read; otherwise, false.
        /// </returns>
        public bool CanRead
        {
            get { return getMethod != null; }
        }

        /// <summary>
        /// Gets a value indicating whether the property can be written to.
        /// </summary>
        /// 
        /// <returns>
        /// true if this property can be written to; otherwise, false.
        /// </returns>
        public bool CanWrite
        {
            get { return setMethod != null; }
        }

        /// <summary>
        /// Gets the get accessor for this property.
        /// </summary>
        /// 
        /// <returns>
        /// The get accessor for this property.
        /// </returns>
        public virtual MethodInfo GetMethod
        {
            get { return this.GetGetMethod(true); }
        }

        /// <summary>
        /// Gets the set accessor for this property.
        /// </summary>
        /// 
        /// <returns>
        /// The set accessor for this property.
        /// </returns>
        public virtual MethodInfo SetMethod
        {
            get { return this.GetSetMethod(true); }
        }

        /// <summary>
        /// Gets a value indicating whether the property is the special name.
        /// </summary>
        /// 
        /// <returns>
        /// true if this property is the special name; otherwise, false.
        /// </returns>
        public bool IsSpecialName
        {
            get { return (this.Attributes & PropertyAttributes.SpecialName) != PropertyAttributes.None; }
        }

        /// <summary>
        /// When overridden in a derived class, sets the property value for a specified object that has the specified binding, index, and culture-specific information.
        /// </summary>
        /// <param name="obj">The object whose property value will be set. </param><param name="value">The new property value. </param><param name="invokeAttr">A bitwise combination of the following enumeration members that specify the invocation attribute: InvokeMethod, CreateInstance, Static, GetField, SetField, GetProperty, or SetProperty. You must specify a suitable invocation attribute. For example, to invoke a static member, set the Static flag. </param><param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of <see cref="T:System.Reflection.MemberInfo"/> objects through reflection. If <paramref name="binder"/> is null, the default binder is used. </param><param name="index">Optional index values for indexed properties. This value should be null for non-indexed properties. </param><param name="culture">The culture for which the resource is to be localized. If the resource is not localized for this culture, the <see cref="P:System.Globalization.CultureInfo.Parent"/> property will be called successively in search of a match. If this value is null, the culture-specific information is obtained from the <see cref="P:System.Globalization.CultureInfo.CurrentUICulture"/> property. </param><exception cref="T:System.ArgumentException">The <paramref name="index"/> array does not contain the type of arguments needed.-or- The property's set accessor is not found. </exception><exception cref="T:System.Reflection.TargetException">The object does not match the target type, or a property is an instance property but <paramref name="obj"/> is null. </exception><exception cref="T:System.Reflection.TargetParameterCountException">The number of parameters in <paramref name="index"/> does not match the number of parameters the indexed property takes. </exception><exception cref="T:System.MethodAccessException">There was an illegal attempt to access a private or protected method inside a class. </exception><exception cref="T:System.Reflection.TargetInvocationException">An error occurred while setting the property value. For example, an index value specified for an indexed property is out of range. The <see cref="P:System.Exception.InnerException"/> property indicates the reason for the error.</exception>
        public void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            if (SetMethod == null)
                throw new InvalidOperationException("Property '" + DeclaringType.FullName + "." + Name + "' does not have a setter.");
            var args = Jsni.@new(Jsni.reference("Array"), (1 + (index != null ? index.Length : 0)).As<JsObject>()).As<JsArray>();
//                new object[1 + (index != null ? index.Length : 0)];
            args[0] = value.As<JsObject>();
            for (var i = 1; i < args.length; i++) 
                args[i] = index[i - 1].As<JsObject>();
            SetMethod.Invoke(obj, invokeAttr, binder, args.As<object[]>(), culture);
        }

        /// <summary>
        /// Returns an array whose elements reflect the public and, if specified, non-public get, set, and other accessors of the property reflected by the current instance.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.Reflection.MethodInfo"/> objects whose elements reflect the get, set, and other accessors of the property reflected by the current instance. If <paramref name="nonPublic"/> is true, this array contains public and non-public get, set, and other accessors. If <paramref name="nonPublic"/> is false, this array contains only public get, set, and other accessors. If no accessors with the specified visibility are found, this method returns an array with zero (0) elements.
        /// </returns>
        /// <param name="nonPublic">Indicates whether non-public methods should be returned in the MethodInfo array. true if non-public methods are to be included; otherwise, false. </param>
        public MethodInfo[] GetAccessors(bool nonPublic)
        {
            var methods = new List<MethodInfo>();
            if (getMethod != null)
                methods.Add(getMethod);
            if (setMethod != null)
                methods.Add(setMethod);
            return methods.ToArray();
        }

        /// <summary>
        /// When overridden in a derived class, returns the public or non-public get accessor for this property.
        /// </summary>
        /// 
        /// <returns>
        /// A MethodInfo object representing the get accessor for this property, if <paramref name="nonPublic"/> is true. Returns null if <paramref name="nonPublic"/> is false and the get accessor is non-public, or if <paramref name="nonPublic"/> is true but no get accessors exist.
        /// </returns>
        /// <param name="nonPublic">Indicates whether a non-public get accessor should be returned. true if a non-public accessor is to be returned; otherwise, false. </param><exception cref="T:System.Security.SecurityException">The requested method is non-public and the caller does not have <see cref="T:System.Security.Permissions.ReflectionPermission"/> to reflect on this non-public method. </exception>
        public MethodInfo GetGetMethod(bool nonPublic)
        {
            if (nonPublic)
                return getMethod;
            else
                return getMethod != null && getMethod.IsPublic ? getMethod : null;
        }

        /// <summary>
        /// When overridden in a derived class, returns the set accessor for this property.
        /// </summary>
        /// 
        /// <returns>
        /// Value Condition A <see cref="T:System.Reflection.MethodInfo"/> object representing the Set method for this property. The set accessor is public.-or- <paramref name="nonPublic"/> is true and the set accessor is non-public. null<paramref name="nonPublic"/> is true, but the property is read-only.-or- <paramref name="nonPublic"/> is false and the set accessor is non-public.-or- There is no set accessor.
        /// </returns>
        /// <param name="nonPublic">Indicates whether the accessor should be returned if it is non-public. true if a non-public accessor is to be returned; otherwise, false. </param><exception cref="T:System.Security.SecurityException">The requested method is non-public and the caller does not have <see cref="T:System.Security.Permissions.ReflectionPermission"/> to reflect on this non-public method. </exception>
        public MethodInfo GetSetMethod(bool nonPublic)
        {
            if (nonPublic)
                return setMethod;
            else
                return setMethod != null && setMethod.IsPublic ? setMethod : null;
        }

        /// <summary>
        /// When overridden in a derived class, returns an array of all the index parameters for the property.
        /// </summary>
        /// 
        /// <returns>
        /// An array of type ParameterInfo containing the parameters for the indexes. If the property is not indexed, the array has 0 (zero) elements.
        /// </returns>
        public ParameterInfo[] GetIndexParameters()
        {
            return indexParameters.ToArray();
        }

        internal ParameterInfo[] GetIndexParametersNoCopy()
        {
            return indexParameters;
        }

        /// <summary>
        /// Returns the property value of a specified object.
        /// </summary>
        /// 
        /// <returns>
        /// The property value of the specified object.
        /// </returns>
        /// <param name="obj">The object whose property value will be returned.</param>
        public object GetValue(object obj)
        {
            return this.GetValue(obj, (object[])null);
        }

        /// <summary>
        /// Returns the property value of a specified object with optional index values for indexed properties.
        /// </summary>
        /// 
        /// <returns>
        /// The property value of the specified object.
        /// </returns>
        /// <param name="obj">The object whose property value will be returned. </param><param name="index">Optional index values for indexed properties. This value should be null for non-indexed properties. </param><exception cref="T:System.ArgumentException">The <paramref name="index"/> array does not contain the type of arguments needed.-or- The property's get accessor is not found. </exception><exception cref="T:System.Reflection.TargetException">The object does not match the target type, or a property is an instance property but <paramref name="obj"/> is null. </exception><exception cref="T:System.Reflection.TargetParameterCountException">The number of parameters in <paramref name="index"/> does not match the number of parameters the indexed property takes. </exception><exception cref="T:System.MethodAccessException">There was an illegal attempt to access a private or protected method inside a class. </exception><exception cref="T:System.Reflection.TargetInvocationException">An error occurred while retrieving the property value. For example, an index value specified for an indexed property is out of range. The <see cref="P:System.Exception.InnerException"/> property indicates the reason for the error.</exception>
        public virtual object GetValue(object obj, object[] index)
        {
            return this.GetValue(obj, BindingFlags.Default, (Binder)null, index, (CultureInfo)null);
        }

        /// <summary>
        /// When overridden in a derived class, returns the property value of a specified object that has the specified binding, index, and culture-specific information.
        /// </summary>
        /// 
        /// <returns>
        /// The property value of the specified object.
        /// </returns>
        /// <param name="obj">The object whose property value will be returned. </param><param name="invokeAttr">A bitwise combination of the following enumeration members that specify the invocation attribute: InvokeMethod, CreateInstance, Static, GetField, SetField, GetProperty, and SetProperty. You must specify a suitable invocation attribute. For example, to invoke a static member, set the Static flag. </param><param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of <see cref="T:System.Reflection.MemberInfo"/> objects through reflection. If <paramref name="binder"/> is null, the default binder is used. </param><param name="index">Optional index values for indexed properties. This value should be null for non-indexed properties. </param><param name="culture">The culture for which the resource is to be localized. If the resource is not localized for this culture, the <see cref="P:System.Globalization.CultureInfo.Parent"/> property will be called successively in search of a match. If this value is null, the culture-specific information is obtained from the <see cref="P:System.Globalization.CultureInfo.CurrentUICulture"/> property. </param><exception cref="T:System.ArgumentException">The <paramref name="index"/> array does not contain the type of arguments needed.-or- The property's get accessor is not found. </exception><exception cref="T:System.Reflection.TargetException">The object does not match the target type, or a property is an instance property but <paramref name="obj"/> is null. </exception><exception cref="T:System.Reflection.TargetParameterCountException">The number of parameters in <paramref name="index"/> does not match the number of parameters the indexed property takes. </exception><exception cref="T:System.MethodAccessException">There was an illegal attempt to access a private or protected method inside a class. </exception><exception cref="T:System.Reflection.TargetInvocationException">An error occurred while retrieving the property value. For example, an index value specified for an indexed property is out of range. The <see cref="P:System.Exception.InnerException"/> property indicates the reason for the error.</exception>
        public object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            return GetMethod.Invoke(obj, invokeAttr, binder, index, culture);
        }

        /// <summary>
        /// Sets the property value of a specified object.
        /// </summary>
        /// <param name="obj">The object whose property value will be set.</param><param name="value">The new property value.</param>
        public void SetValue(object obj, object value)
        {
            this.SetValue(obj, value, (object[])null);
        }

        /// <summary>
        /// Sets the property value of a specified object with optional index values for index properties.
        /// </summary>
        /// <param name="obj">The object whose property value will be set. </param><param name="value">The new property value. </param><param name="index">Optional index values for indexed properties. This value should be null for non-indexed properties. </param><exception cref="T:System.ArgumentException">The <paramref name="index"/> array does not contain the type of arguments needed.-or- The property's set accessor is not found. </exception><exception cref="T:System.Reflection.TargetException">The object does not match the target type, or a property is an instance property but <paramref name="obj"/> is null. </exception><exception cref="T:System.Reflection.TargetParameterCountException">The number of parameters in <paramref name="index"/> does not match the number of parameters the indexed property takes. </exception><exception cref="T:System.MethodAccessException">There was an illegal attempt to access a private or protected method inside a class. </exception><exception cref="T:System.Reflection.TargetInvocationException">An error occurred while setting the property value. For example, an index value specified for an indexed property is out of range. The <see cref="P:System.Exception.InnerException"/> property indicates the reason for the error.</exception>
        public virtual void SetValue(object obj, object value, object[] index)
        {
            this.SetValue(obj, value, BindingFlags.Default, (Binder)null, index, (CultureInfo)null);
        }

        /// <summary>
        /// Returns an array of types representing the required custom modifiers of the property.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.Type"/> objects that identify the required custom modifiers of the current property, such as <see cref="T:System.Runtime.CompilerServices.IsConst"/> or <see cref="T:System.Runtime.CompilerServices.IsImplicitlyDereferenced"/>.
        /// </returns>
        public virtual Type[] GetRequiredCustomModifiers()
        {
            return new Type[0];
        }

        /// <summary>
        /// Returns an array of types representing the optional custom modifiers of the property.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.Type"/> objects that identify the optional custom modifiers of the current property, such as <see cref="T:System.Runtime.CompilerServices.IsConst"/> or <see cref="T:System.Runtime.CompilerServices.IsImplicitlyDereferenced"/>.
        /// </returns>
        public virtual Type[] GetOptionalCustomModifiers()
        {
            return new Type[0];
        }

        /// <summary>
        /// Returns an array whose elements reflect the public get, set, and other accessors of the property reflected by the current instance.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.Reflection.MethodInfo"/> objects that reflect the public get, set, and other accessors of the property reflected by the current instance, if found; otherwise, this method returns an array with zero (0) elements.
        /// </returns>
        public MethodInfo[] GetAccessors()
        {
            return this.GetAccessors(false);
        }

        /// <summary>
        /// Returns the public get accessor for this property.
        /// </summary>
        /// 
        /// <returns>
        /// A MethodInfo object representing the public get accessor for this property, or null if the get accessor is non-public or does not exist.
        /// </returns>
        public MethodInfo GetGetMethod()
        {
            return this.GetGetMethod(false);
        }

        /// <summary>
        /// Returns the public set accessor for this property.
        /// </summary>
        /// 
        /// <returns>
        /// The MethodInfo object representing the Set method for this property if the set accessor is public, or null if the set accessor is not public.
        /// </returns>
        public MethodInfo GetSetMethod()
        {
            return this.GetSetMethod(false);
        }
    }
}
