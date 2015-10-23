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

using System.Globalization;
using System.Linq;

namespace System.Reflection
{
    /// <summary>
    /// Provides information about methods and constructors.
    /// </summary>
    public abstract class MethodBase : MemberInfo
    {
        private ParameterInfo[] parameters;
        protected readonly MethodAttributes methodAttributes;

        private bool isPublic;
        private bool isPrivate;
        private bool isFamily;
        private bool isAssembly;
        private bool isFamilyAndAssembly;
        private bool isFamilyOrAssembly;
        private bool isStatic;
        private bool isFinal;
        private bool isVirtual;
        private bool isAbstract;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Reflection.MethodBase"/> class.
        /// </summary>
        protected MethodBase(string name, ParameterInfo[] parameters, MethodAttributes methodAttributes, Attribute[] attributes) : base(name, attributes)
        {
            this.parameters = parameters;
            this.methodAttributes = methodAttributes;

            isPublic = (methodAttributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Public;
            isPrivate = (methodAttributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Private;
            isFamily = (methodAttributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Family;
            isAssembly = (methodAttributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Assembly;
            isFamilyAndAssembly = (methodAttributes & MethodAttributes.MemberAccessMask) == MethodAttributes.FamANDAssem;
            isFamilyOrAssembly = (methodAttributes & MethodAttributes.MemberAccessMask) == MethodAttributes.FamORAssem;
            isStatic = (methodAttributes & MethodAttributes.Static) != MethodAttributes.PrivateScope;
            isFinal = (methodAttributes & MethodAttributes.Final) != MethodAttributes.PrivateScope;
            isVirtual = (methodAttributes & MethodAttributes.Virtual) != MethodAttributes.PrivateScope;
            isAbstract = (methodAttributes & MethodAttributes.Abstract) != MethodAttributes.PrivateScope;

            foreach (var parameter in parameters)
                parameter.containingMember = this;
        }

        /// <summary>
        /// Gets the attributes associated with this method.
        /// </summary>
        /// 
        /// <returns>
        /// One of the <see cref="T:System.Reflection.MethodAttributes"/> values.
        /// </returns>
        public MethodAttributes Attributes
        {
            get { return methodAttributes; }
        }

        /// <summary>
        /// Gets a value indicating the calling conventions for this method.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Reflection.CallingConventions"/> for this method.
        /// </returns>
        public virtual CallingConventions CallingConvention
        {
            get { return CallingConventions.Standard; }
        }

        /// <summary>
        /// Gets a value indicating whether the method is a generic method definition.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current <see cref="T:System.Reflection.MethodBase"/> object represents the definition of a generic method; otherwise, false.
        /// </returns>
        public virtual bool IsGenericMethodDefinition
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether the generic method contains unassigned generic type parameters.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current <see cref="T:System.Reflection.MethodBase"/> object represents a generic method that contains unassigned generic type parameters; otherwise, false.
        /// </returns>
        public virtual bool ContainsGenericParameters
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether the method is generic.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current <see cref="T:System.Reflection.MethodBase"/> represents a generic method; otherwise, false.
        /// </returns>
        public virtual bool IsGenericMethod
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value that indicates whether the current method or constructor is security-critical or security-safe-critical at the current trust level, and therefore can perform critical operations.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current method or constructor is security-critical or security-safe-critical at the current trust level; false if it is transparent.
        /// </returns>
        public virtual bool IsSecurityCritical
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a value that indicates whether the current method or constructor is security-safe-critical at the current trust level; that is, whether it can perform critical operations and can be accessed by transparent code.
        /// </summary>
        /// 
        /// <returns>
        /// true if the method or constructor is security-safe-critical at the current trust level; false if it is security-critical or transparent.
        /// </returns>
        public virtual bool IsSecuritySafeCritical
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a value that indicates whether the current method or constructor is transparent at the current trust level, and therefore cannot perform critical operations.
        /// </summary>
        /// 
        /// <returns>
        /// true if the method or constructor is security-transparent at the current trust level; otherwise, false.
        /// </returns>
        public virtual bool IsSecurityTransparent
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a value indicating whether this is a public method.
        /// </summary>
        /// 
        /// <returns>
        /// true if this method is public; otherwise, false.
        /// </returns>
        public bool IsPublic
        {
            get { return isPublic; }
        }

        /// <summary>
        /// Gets a value indicating whether this member is private.
        /// </summary>
        /// 
        /// <returns>
        /// true if access to this method is restricted to other members of the class itself; otherwise, false.
        /// </returns>
        public bool IsPrivate
        {
            get { return isPrivate; }
        }

        /// <summary>
        /// Gets a value indicating whether the visibility of this method or constructor is described by <see cref="F:System.Reflection.MethodAttributes.Family"/>; that is, the method or constructor is visible only within its class and derived classes.
        /// </summary>
        /// 
        /// <returns>
        /// true if access to this method or constructor is exactly described by <see cref="F:System.Reflection.MethodAttributes.Family"/>; otherwise, false.
        /// </returns>
        public bool IsFamily
        {
            get { return isFamily; }
        }

        /// <summary>
        /// Gets a value indicating whether the potential visibility of this method or constructor is described by <see cref="F:System.Reflection.MethodAttributes.Assembly"/>; that is, the method or constructor is visible at most to other types in the same assembly, and is not visible to derived types outside the assembly.
        /// </summary>
        /// 
        /// <returns>
        /// true if the visibility of this method or constructor is exactly described by <see cref="F:System.Reflection.MethodAttributes.Assembly"/>; otherwise, false.
        /// </returns>
        public bool IsAssembly
        {
            get { return isAssembly; }
        }

        /// <summary>
        /// Gets a value indicating whether the visibility of this method or constructor is described by <see cref="F:System.Reflection.MethodAttributes.FamANDAssem"/>; that is, the method or constructor can be called by derived classes, but only if they are in the same assembly.
        /// </summary>
        /// 
        /// <returns>
        /// true if access to this method or constructor is exactly described by <see cref="F:System.Reflection.MethodAttributes.FamANDAssem"/>; otherwise, false.
        /// </returns>
        public bool IsFamilyAndAssembly
        {
            get { return isFamilyAndAssembly; }
        }

        /// <summary>
        /// Gets a value indicating whether the potential visibility of this method or constructor is described by <see cref="F:System.Reflection.MethodAttributes.FamORAssem"/>; that is, the method or constructor can be called by derived classes wherever they are, and by classes in the same assembly.
        /// </summary>
        /// 
        /// <returns>
        /// true if access to this method or constructor is exactly described by <see cref="F:System.Reflection.MethodAttributes.FamORAssem"/>; otherwise, false.
        /// </returns>
        public bool IsFamilyOrAssembly
        {
            get { return isFamilyOrAssembly; }
        }

        /// <summary>
        /// Gets a value indicating whether the method is static.
        /// </summary>
        /// 
        /// <returns>
        /// true if this method is static; otherwise, false.
        /// </returns>
        public bool IsStatic
        {
            get { return isStatic; }
        }

        /// <summary>
        /// Gets a value indicating whether this method is final.
        /// </summary>
        /// 
        /// <returns>
        /// true if this method is final; otherwise, false.
        /// </returns>
        public bool IsFinal
        {
            get { return isFinal; }
        }

        /// <summary>
        /// Gets a value indicating whether the method is virtual.
        /// </summary>
        /// 
        /// <returns>
        /// true if this method is virtual; otherwise, false.
        /// </returns>
        public bool IsVirtual
        {
            get { return isVirtual; }
        }

        /// <summary>
        /// Gets a value indicating whether only a member of the same kind with exactly the same signature is hidden in the derived class.
        /// </summary>
        /// 
        /// <returns>
        /// true if the member is hidden by signature; otherwise, false.
        /// </returns>
        public bool IsHideBySig
        {
            get { return (this.Attributes & MethodAttributes.HideBySig) != MethodAttributes.PrivateScope; }
        }

        /// <summary>
        /// Gets a value indicating whether the method is abstract.
        /// </summary>
        /// 
        /// <returns>
        /// true if the method is abstract; otherwise, false.
        /// </returns>
        public bool IsAbstract
        {
            get { return isAbstract; }
        }

        /// <summary>
        /// Gets a value indicating whether this method has a special name.
        /// </summary>
        /// 
        /// <returns>
        /// true if this method has a special name; otherwise, false.
        /// </returns>
        public bool IsSpecialName
        {
            get { return (this.Attributes & MethodAttributes.SpecialName) != MethodAttributes.PrivateScope; }
        }

        /// <summary>
        /// Gets a value indicating whether the method is a constructor.
        /// </summary>
        /// 
        /// <returns>
        /// true if this method is a constructor represented by a <see cref="T:System.Reflection.ConstructorInfo"/> object (see note in Remarks about <see cref="T:System.Reflection.Emit.ConstructorBuilder"/> objects); otherwise, false.
        /// </returns>
        public bool IsConstructor
        {
            get
            {
                if (this is ConstructorInfo && !this.IsStatic)
                    return true;
                else
                    return false;
            }
        }

        internal string FullName
        {
            get { return (object)this.DeclaringType.FullName + "." + (object)this.Name; }
        }

        /// <summary>
        /// Returns a MethodBase object representing the currently executing method.
        /// </summary>
        /// 
        /// <returns>
        /// A MethodBase object representing the currently executing method.
        /// </returns>
        /// <exception cref="T:System.Reflection.TargetException">This member was invoked with a late-binding mechanism.</exception>
        public static MethodBase GetCurrentMethod()
        {
            // This will be a fun one to try to implement.  Probably just need to instrument each method body to 
            // declare a $currentMethod$ variable to Type.prototype.method or Type.method
            throw new NotImplementedException();
        }

        internal virtual ParameterInfo[] GetParametersNoCopy()
        {
            return parameters;
        }

        /// <summary>
        /// When overridden in a derived class, gets the parameters of the specified method or constructor.
        /// </summary>
        /// 
        /// <returns>
        /// An array of type ParameterInfo containing information that matches the signature of the method (or constructor) reflected by this MethodBase instance.
        /// </returns>
        public ParameterInfo[] GetParameters()
        {
            return parameters.ToArray();
        }

        /// <summary>
        /// When overridden in a derived class, invokes the reflected method or constructor with the given parameters.
        /// </summary>
        /// 
        /// <returns>
        /// An Object containing the return value of the invoked method, or null in the case of a constructor, or null if the method's return type is void. Before calling the method or constructor, Invoke checks to see if the user has access permission and verifies that the parameters are valid.CautionElements of the <paramref name="parameters"/> array that represent parameters declared with the ref or out keyword may also be modified.
        /// </returns>
        /// <param name="obj">The object on which to invoke the method or constructor. If a method is static, this argument is ignored. If a constructor is static, this argument must be null or an instance of the class that defines the constructor.</param><param name="invokeAttr">A bitmask that is a combination of 0 or more bit flags from <see cref="T:System.Reflection.BindingFlags"/>. If <paramref name="binder"/> is null, this parameter is assigned the value <see cref="F:System.Reflection.BindingFlags.Default"/>; thus, whatever you pass in is ignored. </param><param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of MemberInfo objects via reflection. If <paramref name="binder"/> is null, the default binder is used. </param><param name="parameters">An argument list for the invoked method or constructor. This is an array of objects with the same number, order, and type as the parameters of the method or constructor to be invoked. If there are no parameters, this should be null.If the method or constructor represented by this instance takes a ByRef parameter, there is no special attribute required for that parameter in order to invoke the method or constructor using this function. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is null. For value-type elements, this value is 0, 0.0, or false, depending on the specific element type. </param><param name="culture">An instance of CultureInfo used to govern the coercion of types. If this is null, the CultureInfo for the current thread is used. (This is necessary to convert a String that represents 1000 to a Double value, for example, since 1000 is represented differently by different cultures.) </param><exception cref="T:System.Reflection.TargetException">The <paramref name="obj"/> parameter is null and the method is not static.-or- The method is not declared or inherited by the class of <paramref name="obj"/>. -or-A static constructor is invoked, and <paramref name="obj"/> is neither null nor an instance of the class that declared the constructor.</exception><exception cref="T:System.ArgumentException">The type of the <paramref name="parameters"/> parameter does not match the signature of the method or constructor reflected by this instance. </exception><exception cref="T:System.Reflection.TargetParameterCountException">The <paramref name="parameters"/> array does not have the correct number of arguments. </exception><exception cref="T:System.Reflection.TargetInvocationException">The invoked method or constructor throws an exception. </exception><exception cref="T:System.MethodAccessException">The caller does not have permission to execute the constructor. </exception><exception cref="T:System.InvalidOperationException">The type that declares the method is an open generic type. That is, the <see cref="P:System.Type.ContainsGenericParameters"/> property returns true for the declaring type.</exception>
        public abstract object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);

        /// <summary>
        /// Returns an array of <see cref="T:System.Type"/> objects that represent the type arguments of a generic method or the type parameters of a generic method definition.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.Type"/> objects that represent the type arguments of a generic method or the type parameters of a generic method definition. Returns an empty array if the current method is not a generic method.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The current object is a <see cref="T:System.Reflection.ConstructorInfo"/>. Generic constructors are not supported in the .NET Framework version 2.0. This exception is the default behavior if this method is not overridden in a derived class.</exception>
        public virtual Type[] GetGenericArguments()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Invokes the method or constructor represented by the current instance, using the specified parameters.
        /// </summary>
        /// 
        /// <returns>
        /// An object containing the return value of the invoked method, or null in the case of a constructor.CautionElements of the <paramref name="parameters"/> array that represent parameters declared with the ref or out keyword may also be modified.
        /// </returns>
        /// <param name="obj">The object on which to invoke the method or constructor. If a method is static, this argument is ignored. If a constructor is static, this argument must be null or an instance of the class that defines the constructor. </param><param name="parameters">An argument list for the invoked method or constructor. This is an array of objects with the same number, order, and type as the parameters of the method or constructor to be invoked. If there are no parameters, <paramref name="parameters"/> should be null.If the method or constructor represented by this instance takes a ref parameter (ByRef in Visual Basic), no special attribute is required for that parameter in order to invoke the method or constructor using this function. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is null. For value-type elements, this value is 0, 0.0, or false, depending on the specific element type. </param><exception cref="T:System.Reflection.TargetException">The <paramref name="obj"/> parameter is null and the method is not static.-or- The method is not declared or inherited by the class of <paramref name="obj"/>. -or-A static constructor is invoked, and <paramref name="obj"/> is neither null nor an instance of the class that declared the constructor.</exception><exception cref="T:System.ArgumentException">The elements of the <paramref name="parameters"/> array do not match the signature of the method or constructor reflected by this instance. </exception><exception cref="T:System.Reflection.TargetInvocationException">The invoked method or constructor throws an exception. -or-The current instance is a <see cref="T:System.Reflection.Emit.DynamicMethod"/> that contains unverifiable code. See the "Verification" section in Remarks for <see cref="T:System.Reflection.Emit.DynamicMethod"/>.</exception><exception cref="T:System.Reflection.TargetParameterCountException">The <paramref name="parameters"/> array does not have the correct number of arguments. </exception><exception cref="T:System.MethodAccessException">The caller does not have permission to execute the constructor. </exception><exception cref="T:System.InvalidOperationException">The type that declares the method is an open generic type. That is, the <see cref="P:System.Type.ContainsGenericParameters"/> property returns true for the declaring type.</exception><exception cref="T:System.NotSupportedException">The current instance is a <see cref="T:System.Reflection.Emit.MethodBuilder"/>.</exception>
        public object Invoke(object obj, object[] parameters)
        {
            return this.Invoke(obj, BindingFlags.Default, null, parameters, null);
        }

        /// <summary>
        /// Gets method information by using the method's internal metadata representation (handle).
        /// </summary>
        /// 
        /// <returns>
        /// A MethodBase containing information about the method.
        /// </returns>
        /// <param name="handle">The method's handle. </param><exception cref="T:System.ArgumentException"><paramref name="handle"/> is invalid.</exception>
        public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a <see cref="T:System.Reflection.MethodBase"/> object for the constructor or method represented by the specified handle, for the specified generic type.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MethodBase"/> object representing the method or constructor specified by <paramref name="handle"/>, in the generic type specified by <paramref name="declaringType"/>.
        /// </returns>
        /// <param name="handle">A handle to the internal metadata representation of a constructor or method.</param><param name="declaringType">A handle to the generic type that defines the constructor or method.</param><exception cref="T:System.ArgumentException"><paramref name="handle"/> is invalid.</exception>
        public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle, RuntimeTypeHandle declaringType)
        {
            throw new NotImplementedException();
        }
    }
}
