using System.Globalization;
using System.Runtime.WootzJs;

namespace System.Reflection
{
    /// <summary>
    /// Discovers the attributes of a method and provides access to method metadata.
    /// </summary>
    public class MethodInfo : MethodBase
    {
        private JsFunction jsMethod;
        private JsTypeFunction returnType;

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
            throw new NotImplementedException();
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

            return Jsni.apply(jsMethod, obj.As<JsObject>(), parameters.As<JsArray>());
        }
    }
}
