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
using System.Runtime.WootzJs;
using System.Linq;

namespace System.Reflection
{
    /// <summary>
    /// Discovers the attributes of a method and provides access to method metadata.
    /// </summary>
    public class MethodInfo : MethodBase
    {
        private JsFunction jsMethod;
        private JsTypeFunction returnType;
        private Type[] typeArguments;
        private Dictionary<string, MethodInfo> constructedMethods;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Reflection.MethodInfo"/> class.
        /// </summary>
        public MethodInfo(string name, JsFunction jsMethod, ParameterInfo[] parameters, JsTypeFunction returnType, MethodAttributes methodAttributes, Attribute[] attributes) : base(name, parameters, methodAttributes, attributes)
        {
            this.jsMethod = jsMethod;
            this.returnType = returnType;
        }

        /// <summary>
        /// Gets a <see cref="T:System.Reflection.MemberTypes"/> value indicating that this member is a method.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MemberTypes"/> value indicating that this member is a method.
        /// </returns>
        public override MemberTypes MemberType
        {
            get { return MemberTypes.Method; }
        }

        /// <summary>
        /// Gets the return type of this method.
        /// </summary>
        /// 
        /// <returns>
        /// The return type of this method.
        /// </returns>
        public virtual Type ReturnType
        {
            get { return Type._GetTypeFromTypeFunc(returnType); }
        }

        /// <summary>
        /// Gets the custom attributes for the return type.
        /// </summary>
        /// 
        /// <returns>
        /// An ICustomAttributeProvider object representing the custom attributes for the return type.
        /// </returns>
        public ICustomAttributeProvider ReturnTypeCustomAttributes
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// When overridden in a derived class, returns the MethodInfo object for the method on the direct or indirect base class in which the method represented by this instance was first declared.
        /// </summary>
        /// 
        /// <returns>
        /// A MethodInfo object for the first implementation of this method.
        /// </returns>
        public MethodInfo GetBaseDefinition()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an array of <see cref="T:System.Type"/> objects that represent the type arguments of a generic method or the type parameters of a generic method definition.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.Type"/> objects that represent the type arguments of a generic method or the type parameters of a generic method definition. Returns an empty array if the current method is not a generic method.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
        public override Type[] GetGenericArguments()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a <see cref="T:System.Reflection.MethodInfo"/> object that represents a generic method definition from which the current method can be constructed.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MethodInfo"/> object representing a generic method definition from which the current method can be constructed.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The current method is not a generic method. That is, <see cref="P:System.Reflection.MethodInfo.IsGenericMethod"/> returns false. </exception><exception cref="T:System.NotSupportedException">This method is not supported.</exception>
        public virtual MethodInfo GetGenericMethodDefinition()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Substitutes the elements of an array of types for the type parameters of the current generic method definition, and returns a <see cref="T:System.Reflection.MethodInfo"/> object representing the resulting constructed method.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MethodInfo"/> object that represents the constructed method formed by substituting the elements of <paramref name="typeArguments"/> for the type parameters of the current generic method definition.
        /// </returns>
        /// <param name="typeArguments">An array of types to be substituted for the type parameters of the current generic method definition.</param><exception cref="T:System.InvalidOperationException">The current <see cref="T:System.Reflection.MethodInfo"/> does not represent a generic method definition. That is, <see cref="P:System.Reflection.MethodInfo.IsGenericMethodDefinition"/> returns false.</exception><exception cref="T:System.ArgumentNullException"><paramref name="typeArguments"/> is null.-or- Any element of <paramref name="typeArguments"/> is null. </exception><exception cref="T:System.ArgumentException">The number of elements in <paramref name="typeArguments"/> is not the same as the number of type parameters of the current generic method definition.-or- An element of <paramref name="typeArguments"/> does not satisfy the constraints specified for the corresponding type parameter of the current generic method definition. </exception><exception cref="T:System.NotSupportedException">This method is not supported.</exception>
        public virtual MethodInfo MakeGenericMethod(params Type[] typeArguments)
        {
            if (this.typeArguments != null)
                throw new InvalidOperationException("Cannot call MakeGenericMethod on a constructed generic method");

            if (constructedMethods == null)
                constructedMethods = new Dictionary<string, MethodInfo>();
            var keyString = string.Join(", ", typeArguments.Select(x => x.FullName));
            MethodInfo result;
            if (!constructedMethods.TryGetValue(keyString, out result))
            {
                result = new MethodInfo(Name, jsMethod, GetParameters(), returnType, methodAttributes, attributes);
                result.typeArguments = typeArguments;
                constructedMethods[keyString] = result;
            }
            return result;
        }

        /// <summary>
        /// Creates a delegate of the specified type from this method.
        /// </summary>
        /// 
        /// <returns>
        /// The delegate for this method.
        /// </returns>
        /// <param name="delegateType">The type of the delegate to create.</param>
        public virtual Delegate CreateDelegate(Type delegateType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a delegate of the specified type with the specified target from this method.
        /// </summary>
        /// 
        /// <returns>
        /// The delegate for this method.
        /// </returns>
        /// <param name="delegateType">The type of the delegate to create.</param><param name="target">The object targeted by the delegate.</param>
        public virtual Delegate CreateDelegate(Type delegateType, object target)
        {
            throw new NotImplementedException();
        }

        public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
        {
            if (IsStatic && obj != null)
                throw new InvalidOperationException("Static methods cannot have a target");
            if (!IsStatic && obj == null)
                throw new InvalidOperationException("Instance methods must have a target");

            var args = new JsArray();
            if (typeArguments != null)
            {
                foreach (var typeArgument in typeArguments)
                    args.push(typeArgument.thisType);
            }
            if (parameters != null)
            {
                foreach (var argument in parameters)
                    args.push(argument.As<JsObject>());
            }
            return Jsni.apply(jsMethod, obj.As<JsObject>(), args);
        }

        public override string ToString()
        {
            return DeclaringType.FullName + "." + Name + "(" + string.Format(", ", GetParameters().Select(x => x.ParameterType.FullName + " " + x.Name)) + ")";
        }
    }
}
