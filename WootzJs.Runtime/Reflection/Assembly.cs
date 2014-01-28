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
    /// Represents an assembly, which is a reusable, versionable, and self-describing building block of a common language runtime application.
    /// </summary>
    public class Assembly : ICustomAttributeProvider
    {
        private string fullName;
        private JsTypeFunction[] typeFunctions;
        private Type[] types;
        private Dictionary<string, JsTypeFunction> typesByName = new Dictionary<string, JsTypeFunction>();
        private Dictionary<string, JsTypeFunction> typesByNameUpper = new Dictionary<string, JsTypeFunction>();
        private Attribute[] attributes;

        protected Assembly(string fullName, JsArray types, Attribute[] attributes)
        {
            this.fullName = fullName;
            this.attributes = attributes;
            typeFunctions = new JsTypeFunction[types.length];
            for (var i = 0; i < types.length; i++)
            {
                typeFunctions[i] = types[i].As<JsTypeFunction>();
                typesByName[typeFunctions[i].TypeName] = typeFunctions[i];
                typesByNameUpper[typeFunctions[i].TypeName.ToUpper()] = typeFunctions[i];
            }
        }

        /// <summary>
        /// Gets the location of the assembly as specified originally, for example, in an <see cref="T:System.Reflection.AssemblyName"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// The location of the assembly as specified originally.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual string CodeBase
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the display name of the assembly.
        /// </summary>
        /// 
        /// <returns>
        /// The display name of the assembly.
        /// </returns>
        public virtual string FullName
        {
            get { return fullName; }
        }

        /// <summary>
        /// Gets the entry point of this assembly.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents the entry point of this assembly. If no entry point is found (for example, the assembly is a DLL), null is returned.
        /// </returns>
        public virtual MethodInfo EntryPoint
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the path or UNC location of the loaded file that contains the manifest.
        /// </summary>
        /// 
        /// <returns>
        /// The location of the loaded file that contains the manifest. If the loaded file was shadow-copied, the location is that of the file after being shadow-copied. If the assembly is loaded from a byte array, such as when using the <see cref="M:System.Reflection.Assembly.Load(System.Byte[])"/> method overload, the value returned is an empty string ("").
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The current assembly is a dynamic assembly, represented by an <see cref="T:System.Reflection.Emit.AssemblyBuilder"/> object. </exception><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual string Location
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Creates the name of a type qualified by the display name of its assembly.
        /// </summary>
        /// 
        /// <returns>
        /// The full name of the type qualified by the display name of the assembly.
        /// </returns>
        /// <param name="assemblyName">The display name of an assembly. </param><param name="typeName">The full name of a type. </param>
        public static string CreateQualifiedName(string assemblyName, string typeName)
        {
            return typeName + ", " + assemblyName;
        }

        /// <summary>
        /// Gets the currently loaded assembly in which the specified class is defined.
        /// </summary>
        /// 
        /// <returns>
        /// The assembly in which the specified class is defined.
        /// </returns>
        /// <param name="type">An object representing a class in the assembly that will be returned. </param><exception cref="T:System.ArgumentNullException"><paramref name="type"/> is null. </exception>
        public static Assembly GetAssembly(Type type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the assembly that contains the code that is currently executing.
        /// </summary>
        /// 
        /// <returns>
        /// The assembly that contains the code that is currently executing.
        /// </returns>
        public static Assembly GetExecutingAssembly()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the <see cref="T:System.Reflection.Assembly"/> of the method that invoked the currently executing method.
        /// </summary>
        /// 
        /// <returns>
        /// The Assembly object of the method that invoked the currently executing method.
        /// </returns>
        public static Assembly GetCallingAssembly()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the process executable in the default application domain. In other application domains, this is the first executable that was executed by <see cref="M:System.AppDomain.ExecuteAssembly(System.String)"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The assembly that is the process executable in the default application domain, or the first executable that was executed by <see cref="M:System.AppDomain.ExecuteAssembly(System.String)"/>. Can return null when called from unmanaged code.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public static Assembly GetEntryAssembly()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an <see cref="T:System.Reflection.AssemblyName"/> for this assembly.
        /// </summary>
        /// 
        /// <returns>
        /// An object that contains the fully parsed display name for this assembly.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual AssemblyName GetName()
        {
            return this.GetName(false);
        }

        /// <summary>
        /// Gets an <see cref="T:System.Reflection.AssemblyName"/> for this assembly, setting the codebase as specified by <paramref name="copiedName"/>.
        /// </summary>
        /// 
        /// <returns>
        /// An object that contains the fully parsed display name for this assembly.
        /// </returns>
        /// <param name="copiedName">true to set the <see cref="P:System.Reflection.Assembly.CodeBase"/> to the location of the assembly after it was shadow copied; false to set <see cref="P:System.Reflection.Assembly.CodeBase"/> to the original location. </param><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual AssemblyName GetName(bool copiedName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the <see cref="T:System.Type"/> object with the specified name in the assembly instance.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents the specified class, or null if the class is not found.
        /// </returns>
        /// <param name="name">The full name of the type. </param><exception cref="T:System.ArgumentException"><paramref name="name"/> is invalid. </exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null. </exception><exception cref="T:System.IO.FileNotFoundException"><paramref name="name"/> requires a dependent assembly that could not be found. </exception><exception cref="T:System.IO.FileLoadException"><paramref name="name"/> requires a dependent assembly that was found but could not be loaded.-or-The current assembly was loaded into the reflection-only context, and <paramref name="name"/> requires a dependent assembly that was not preloaded. </exception><exception cref="T:System.BadImageFormatException"><paramref name="name"/> requires a dependent assembly, but the file is not a valid assembly. -or-<paramref name="name"/> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception>
        public virtual Type GetType(string name)
        {
            return this.GetType(name, false, false);
        }

        /// <summary>
        /// Gets the <see cref="T:System.Type"/> object with the specified name in the assembly instance and optionally throws an exception if the type is not found.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents the specified class.
        /// </returns>
        /// <param name="name">The full name of the type. </param><param name="throwOnError">true to throw an exception if the type is not found; false to return null. </param><exception cref="T:System.ArgumentException"><paramref name="name"/> is invalid.-or- The length of <paramref name="name"/> exceeds 1024 characters. </exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null. </exception><exception cref="T:System.TypeLoadException"><paramref name="throwOnError"/> is true, and the type cannot be found.</exception><exception cref="T:System.IO.FileNotFoundException"><paramref name="name"/> requires a dependent assembly that could not be found. </exception><exception cref="T:System.IO.FileLoadException"><paramref name="name"/> requires a dependent assembly that was found but could not be loaded.-or-The current assembly was loaded into the reflection-only context, and <paramref name="name"/> requires a dependent assembly that was not preloaded. </exception><exception cref="T:System.BadImageFormatException"><paramref name="name"/> requires a dependent assembly, but the file is not a valid assembly. -or-<paramref name="name"/> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception>
        public virtual Type GetType(string name, bool throwOnError)
        {
            return this.GetType(name, throwOnError, false);
        }

        /// <summary>
        /// Gets the <see cref="T:System.Type"/> object with the specified name in the assembly instance, with the options of ignoring the case, and of throwing an exception if the type is not found.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents the specified class.
        /// </returns>
        /// <param name="name">The full name of the type. </param><param name="throwOnError">true to throw an exception if the type is not found; false to return null. </param><param name="ignoreCase">true to ignore the case of the type name; otherwise, false. </param><exception cref="T:System.ArgumentException"><paramref name="name"/> is invalid.-or- The length of <paramref name="name"/> exceeds 1024 characters. </exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null. </exception><exception cref="T:System.TypeLoadException"><paramref name="throwOnError"/> is true, and the type cannot be found.</exception><exception cref="T:System.IO.FileNotFoundException"><paramref name="name"/> requires a dependent assembly that could not be found. </exception><exception cref="T:System.IO.FileLoadException"><paramref name="name"/> requires a dependent assembly that was found but could not be loaded.-or-The current assembly was loaded into the reflection-only context, and <paramref name="name"/> requires a dependent assembly that was not preloaded. </exception><exception cref="T:System.BadImageFormatException"><paramref name="name"/> requires a dependent assembly, but the file is not a valid assembly. -or-<paramref name="name"/> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception>
        public virtual Type GetType(string name, bool throwOnError, bool ignoreCase)
        {
            JsTypeFunction result;
            if (ignoreCase)
                typesByNameUpper.TryGetValue(name, out result);
            else
                typesByName.TryGetValue(name, out result);

            if (result == null && throwOnError)
                throw new InvalidOperationException("Type not found: " + name);

            if (result != null)
                return Type._GetTypeFromTypeFunc(result);

            return null;
        }

        /// <summary>
        /// Gets the types defined in this assembly.
        /// </summary>
        /// 
        /// <returns>
        /// An array that contains all the types that are defined in this assembly.
        /// </returns>
        /// <exception cref="T:System.Reflection.ReflectionTypeLoadException">The assembly contains one or more types that cannot be loaded. The array returned by the <see cref="P:System.Reflection.ReflectionTypeLoadException.Types"/> property of this exception contains a <see cref="T:System.Type"/> object for each type that was loaded and null for each type that could not be loaded, while the <see cref="P:System.Reflection.ReflectionTypeLoadException.LoaderExceptions"/> property contains an exception for each type that could not be loaded.</exception>
        public virtual Type[] GetTypes()
        {
            if (types == null)
            {
                types = typeFunctions.Select(x => Type._GetTypeFromTypeFunc(x)).ToArray();
            }
            return types;
        }

        /// <summary>
        /// Gets all the custom attributes for this assembly.
        /// </summary>
        /// 
        /// <returns>
        /// An array that contains the custom attributes for this assembly.
        /// </returns>
        /// <param name="inherit">This argument is ignored for objects of type <see cref="T:System.Reflection.Assembly"/>. </param>
        public object[] GetCustomAttributes(bool inherit)
        {
            return attributes.ToArray();
        }

        /// <summary>
        /// Gets the custom attributes for this assembly as specified by type.
        /// </summary>
        /// 
        /// <returns>
        /// An array that contains the custom attributes for this assembly as specified by <paramref name="attributeType"/>.
        /// </returns>
        /// <param name="attributeType">The type for which the custom attributes are to be returned. </param><param name="inherit">This argument is ignored for objects of type <see cref="T:System.Reflection.Assembly"/>. </param><exception cref="T:System.ArgumentNullException"><paramref name="attributeType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="attributeType"/> is not a runtime type. </exception>
        public object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            return GetCustomAttributes(inherit).Where(x => attributeType.IsInstanceOfType(x)).ToArray();
        }

        /// <summary>
        /// Indicates whether or not a specified attribute has been applied to the assembly.
        /// </summary>
        /// 
        /// <returns>
        /// true if the attribute has been applied to the assembly; otherwise, false.
        /// </returns>
        /// <param name="attributeType">The type of the attribute to be checked for this assembly. </param><param name="inherit">This argument is ignored for objects of this type. </param><exception cref="T:System.ArgumentNullException"><paramref name="attributeType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="attributeType"/> uses an invalid type.</exception>
        public bool IsDefined(Type attributeType, bool inherit)
        {
            return GetCustomAttributes(inherit).Any(x => attributeType.IsInstanceOfType(x));
        }

        /// <summary>
        /// Locates the specified type from this assembly and creates an instance of it using the system activator, using case-sensitive search.
        /// </summary>
        /// 
        /// <returns>
        /// An instance of the specified type created with the default constructor; or null if <paramref name="typeName"/> is not found. The type is resolved using the default binder, without specifying culture or activation attributes, and with <see cref="T:System.Reflection.BindingFlags"/> set to Public or Instance.
        /// </returns>
        /// <param name="typeName">The <see cref="P:System.Type.FullName"/> of the type to locate. </param><exception cref="T:System.ArgumentException"><paramref name="typeName"/> is an empty string ("") or a string beginning with a null character.-or-The current assembly was loaded into the reflection-only context.</exception><exception cref="T:System.ArgumentNullException"><paramref name="typeName"/> is null. </exception><exception cref="T:System.MissingMethodException">No matching constructor was found. </exception><exception cref="T:System.IO.FileNotFoundException"><paramref name="typeName"/> requires a dependent assembly that could not be found. </exception><exception cref="T:System.IO.FileLoadException"><paramref name="typeName"/> requires a dependent assembly that was found but could not be loaded.-or-The current assembly was loaded into the reflection-only context, and <paramref name="typeName"/> requires a dependent assembly that was not preloaded. </exception><exception cref="T:System.BadImageFormatException"><paramref name="typeName"/> requires a dependent assembly, but the file is not a valid assembly. -or-<paramref name="typeName"/> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception><PermissionSet><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/></PermissionSet>
        public object CreateInstance(string typeName)
        {
            return this.CreateInstance(typeName, false, BindingFlags.Instance | BindingFlags.Public, (Binder)null, (object[])null, (CultureInfo)null, (object[])null);
        }

        /// <summary>
        /// Locates the specified type from this assembly and creates an instance of it using the system activator, with optional case-sensitive search.
        /// </summary>
        /// 
        /// <returns>
        /// An instance of the specified type created with the default constructor; or null if <paramref name="typeName"/> is not found. The type is resolved using the default binder, without specifying culture or activation attributes, and with <see cref="T:System.Reflection.BindingFlags"/> set to Public or Instance.
        /// </returns>
        /// <param name="typeName">The <see cref="P:System.Type.FullName"/> of the type to locate. </param><param name="ignoreCase">true to ignore the case of the type name; otherwise, false. </param><exception cref="T:System.ArgumentException"><paramref name="typeName"/> is an empty string ("") or a string beginning with a null character. -or-The current assembly was loaded into the reflection-only context.</exception><exception cref="T:System.MissingMethodException">No matching constructor was found. </exception><exception cref="T:System.ArgumentNullException"><paramref name="typeName"/> is null. </exception><exception cref="T:System.IO.FileNotFoundException"><paramref name="typeName"/> requires a dependent assembly that could not be found. </exception><exception cref="T:System.IO.FileLoadException"><paramref name="typeName"/> requires a dependent assembly that was found but could not be loaded.-or-The current assembly was loaded into the reflection-only context, and <paramref name="typeName"/> requires a dependent assembly that was not preloaded. </exception><exception cref="T:System.BadImageFormatException"><paramref name="typeName"/> requires a dependent assembly, but the file is not a valid assembly. -or-<paramref name="typeName"/> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception><PermissionSet><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/></PermissionSet>
        public object CreateInstance(string typeName, bool ignoreCase)
        {
            return this.CreateInstance(typeName, ignoreCase, BindingFlags.Instance | BindingFlags.Public, (Binder)null, (object[])null, (CultureInfo)null, (object[])null);
        }

        /// <summary>
        /// Locates the specified type from this assembly and creates an instance of it using the system activator, with optional case-sensitive search and having the specified culture, arguments, and binding and activation attributes.
        /// </summary>
        /// 
        /// <returns>
        /// An instance of the specified type, or null if <paramref name="typeName"/> is not found. The supplied arguments are used to resolve the type, and to bind the constructor that is used to create the instance.
        /// </returns>
        /// <param name="typeName">The <see cref="P:System.Type.FullName"/> of the type to locate. </param><param name="ignoreCase">true to ignore the case of the type name; otherwise, false. </param><param name="bindingAttr">A bitmask that affects the way in which the search is conducted. The value is a combination of bit flags from <see cref="T:System.Reflection.BindingFlags"/>. </param><param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of MemberInfo objects via reflection. If <paramref name="binder"/> is null, the default binder is used. </param><param name="args">An array that contains the arguments to be passed to the constructor. This array of arguments must match in number, order, and type the parameters of the constructor to be invoked. If the default constructor is desired, <paramref name="args"/> must be an empty array or null. </param><param name="culture">An instance of CultureInfo used to govern the coercion of types. If this is null, the CultureInfo for the current thread is used. (This is necessary to convert a String that represents 1000 to a Double value, for example, since 1000 is represented differently by different cultures.) </param><param name="activationAttributes">An array of one or more attributes that can participate in activation. Typically, an array that contains a single <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute"/> object. The <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute"/> specifies the URL that is required to activate a remote object.  </param><exception cref="T:System.ArgumentException"><paramref name="typeName"/> is an empty string ("") or a string beginning with a null character. -or-The current assembly was loaded into the reflection-only context.</exception><exception cref="T:System.ArgumentNullException"><paramref name="typeName"/> is null. </exception><exception cref="T:System.MissingMethodException">No matching constructor was found. </exception><exception cref="T:System.NotSupportedException">A non-empty activation attributes array is passed to a type that does not inherit from <see cref="T:System.MarshalByRefObject"/>. </exception><exception cref="T:System.IO.FileNotFoundException"><paramref name="typeName"/> requires a dependent assembly that could not be found. </exception><exception cref="T:System.IO.FileLoadException"><paramref name="typeName"/> requires a dependent assembly that was found but could not be loaded.-or-The current assembly was loaded into the reflection-only context, and <paramref name="typeName"/> requires a dependent assembly that was not preloaded. </exception><exception cref="T:System.BadImageFormatException"><paramref name="typeName"/> requires a dependent assembly, but the file is not a valid assembly. -or-<paramref name="typeName"/> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception><PermissionSet><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/></PermissionSet>
        public virtual object CreateInstance(string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
        {
            Type type = this.GetType(typeName, false, ignoreCase);
            if (type == (Type)null)
                return (object)null;
            else
                return Activator.CreateInstance(type, bindingAttr, binder, args, culture, activationAttributes);
        }

        /// <returns>
        /// An array that contains the fully parsed display names of all the assemblies referenced by this assembly.
        /// </returns>
        public virtual AssemblyName[] GetReferencedAssemblies()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the full name of the assembly, also known as the display name.
        /// </summary>
        /// 
        /// <returns>
        /// The full name of the assembly, or the class name if the full name of the assembly cannot be determined.
        /// </returns>
        public override string ToString()
        {
            return this.FullName ?? base.ToString();
        }
    }
}
