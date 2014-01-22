using System.Globalization;
using System.Runtime.WootzJs;

namespace System.Reflection
{
    /// <summary>
    /// Discovers the attributes of a class constructor and provides access to constructor metadata.
    /// </summary>
    public class ConstructorInfo : MethodBase
    {
        private JsFunction jsConstructor;

        /// <summary>
        /// Represents the name of the class constructor method as it is stored in metadata. This name is always ".ctor". This field is read-only.
        /// </summary>
        public static readonly string ConstructorName = ".ctor";

        /// <summary>
        /// Represents the name of the type constructor method as it is stored in metadata. This name is always ".cctor". This property is read-only.
        /// </summary>
        public static readonly string TypeConstructorName = ".cctor";

        /// <summary>
        /// Gets a <see cref="T:System.Reflection.MemberTypes"/> value indicating that this member is a constructor.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MemberTypes"/> value indicating that this member is a constructor.
        /// </returns>
        public override MemberTypes MemberType
        {
            get { return MemberTypes.Constructor; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Reflection.ConstructorInfo"/> class.
        /// </summary>
        public ConstructorInfo(string name, JsFunction jsConstructor, ParameterInfo[] parameters, MethodAttributes methodAttributes, Attribute[] attributes) : base(name, parameters, methodAttributes, attributes)
        {
            this.jsConstructor = jsConstructor;
        }

        /// <summary>
        /// When implemented in a derived class, invokes the constructor reflected by this ConstructorInfo with the specified arguments, under the constraints of the specified Binder.
        /// </summary>
        /// 
        /// <returns>
        /// An instance of the class associated with the constructor.
        /// </returns>
        /// <param name="invokeAttr">One of the BindingFlags values that specifies the type of binding. </param><param name="binder">A Binder that defines a set of properties and enables the binding, coercion of argument types, and invocation of members using reflection. If <paramref name="binder"/> is null, then Binder.DefaultBinding is used. </param><param name="parameters">An array of type Object used to match the number, order and type of the parameters for this constructor, under the constraints of <paramref name="binder"/>. If this constructor does not require parameters, pass an array with zero elements, as in Object[] parameters = new Object[0]. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is null. For value-type elements, this value is 0, 0.0, or false, depending on the specific element type. </param><param name="culture">A <see cref="T:System.Globalization.CultureInfo"/> used to govern the coercion of types. If this is null, the <see cref="T:System.Globalization.CultureInfo"/> for the current thread is used. </param><exception cref="T:System.ArgumentException">The <paramref name="parameters"/> array does not contain values that match the types accepted by this constructor, under the constraints of the <paramref name="binder"/>. </exception><exception cref="T:System.Reflection.TargetInvocationException">The invoked constructor throws an exception. </exception><exception cref="T:System.Reflection.TargetParameterCountException">An incorrect number of parameters was passed. </exception><exception cref="T:System.NotSupportedException">Creation of <see cref="T:System.TypedReference"/>, <see cref="T:System.ArgIterator"/>, and <see cref="T:System.RuntimeArgumentHandle"/> types is not supported.</exception><exception cref="T:System.Security.SecurityException">The caller does not have the necessary code access permissions.</exception><exception cref="T:System.MemberAccessException">The class is abstract.-or- The constructor is a class initializer. </exception><exception cref="T:System.MethodAccessException">The constructor is private or protected, and the caller lacks <see cref="F:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess"/>. </exception>
        public object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
        {
            return Jsni.invoke(Jsni.member(jsConstructor, "$new"), parameters.As<JsObject[]>());
        }

        public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
        {
            return Invoke(invokeAttr, binder, parameters, culture);
        }

        /// <summary>
        /// Invokes the constructor reflected by the instance that has the specified parameters, providing default values for the parameters not commonly used.
        /// </summary>
        /// 
        /// <returns>
        /// An instance of the class associated with the constructor.
        /// </returns>
        /// <param name="parameters">An array of values that matches the number, order and type (under the constraints of the default binder) of the parameters for this constructor. If this constructor takes no parameters, then use either an array with zero elements or null, as in Object[] parameters = new Object[0]. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is null. For value-type elements, this value is 0, 0.0, or false, depending on the specific element type. </param><exception cref="T:System.MemberAccessException">The class is abstract.-or- The constructor is a class initializer. </exception><exception cref="T:System.MethodAccessException">The constructor is private or protected, and the caller lacks <see cref="F:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess"/>. </exception><exception cref="T:System.ArgumentException">The <paramref name="parameters"/> array does not contain values that match the types accepted by this constructor. </exception><exception cref="T:System.Reflection.TargetInvocationException">The invoked constructor throws an exception. </exception><exception cref="T:System.Reflection.TargetParameterCountException">An incorrect number of parameters was passed. </exception><exception cref="T:System.NotSupportedException">Creation of <see cref="T:System.TypedReference"/>, <see cref="T:System.ArgIterator"/>, and <see cref="T:System.RuntimeArgumentHandle"/> types is not supported.</exception><exception cref="T:System.Security.SecurityException">The caller does not have the necessary code access permission.</exception>
        public object Invoke(object[] parameters)
        {
            return this.Invoke(BindingFlags.Default, (Binder)null, parameters, (CultureInfo)null);
        }
    }
}
