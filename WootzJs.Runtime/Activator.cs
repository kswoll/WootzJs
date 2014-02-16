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
using System.Reflection;

namespace System
{
    /// <summary>
    /// Contains methods to create types of objects locally or remotely, or obtain references to existing remote objects. This class cannot be inherited.
    /// </summary>
    /// <filterpriority>2</filterpriority>
    public sealed class Activator 
    {
        internal const int LookupMask = 255;
        internal const BindingFlags ConLookup = BindingFlags.Instance | BindingFlags.Public;
        internal const BindingFlags ConstructorDefault = BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance;

        private Activator()
        {
        }

        /// <summary>
        /// Creates an instance of the specified type using the constructor that best matches the specified parameters.
        /// </summary>
        /// 
        /// <returns>
        /// A reference to the newly created object.
        /// </returns>
        /// <param name="type">The type of object to create. </param><param name="bindingAttr">A combination of zero or more bit flags that affect the search for the <paramref name="type"/> constructor. If <paramref name="bindingAttr"/> is zero, a case-sensitive search for public constructors is conducted. </param><param name="binder">An object that uses <paramref name="bindingAttr"/> and <paramref name="args"/> to seek and identify the <paramref name="type"/> constructor. If <paramref name="binder"/> is null, the default binder is used. </param><param name="args">An array of arguments that match in number, order, and type the parameters of the constructor to invoke. If <paramref name="args"/> is an empty array or null, the constructor that takes no parameters (the default constructor) is invoked. </param><param name="culture">Culture-specific information that governs the coercion of <paramref name="args"/> to the formal types declared for the <paramref name="type"/> constructor. If <paramref name="culture"/> is null, the <see cref="T:System.Globalization.CultureInfo"/> for the current thread is used. </param><exception cref="T:System.ArgumentNullException"><paramref name="type"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="type"/> is not a RuntimeType. -or-<paramref name="type"/> is an open generic type (that is, the <see cref="P:System.Type.ContainsGenericParameters"/> property returns true).</exception><exception cref="T:System.NotSupportedException"><paramref name="type"/> cannot be a <see cref="T:System.Reflection.Emit.TypeBuilder"/>.-or- Creation of <see cref="T:System.TypedReference"/>, <see cref="T:System.ArgIterator"/>, <see cref="T:System.Void"/>, and <see cref="T:System.RuntimeArgumentHandle"/> types, or arrays of those types, is not supported. -or-The assembly that contains <paramref name="type"/> is a dynamic assembly that was created with <see cref="F:System.Reflection.Emit.AssemblyBuilderAccess.Save"/>.-or-The constructor that best matches <paramref name="args"/> has varargs arguments.</exception><exception cref="T:System.Reflection.TargetInvocationException">The constructor being called throws an exception. </exception><exception cref="T:System.MethodAccessException">The caller does not have permission to call this constructor. </exception><exception cref="T:System.MemberAccessException">Cannot create an instance of an abstract class, or this member was invoked with a late-binding mechanism. </exception><exception cref="T:System.Runtime.InteropServices.InvalidComObjectException">The COM type was not obtained through <see cref="Overload:System.Type.GetTypeFromProgID"/> or <see cref="Overload:System.Type.GetTypeFromCLSID"/>. </exception><exception cref="T:System.MissingMethodException">No matching constructor was found. </exception><exception cref="T:System.Runtime.InteropServices.COMException"><paramref name="type"/> is a COM object but the class identifier used to obtain the type is invalid, or the identified class is not registered. </exception><exception cref="T:System.TypeLoadException"><paramref name="type"/> is not a valid type. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence, RemotingConfiguration"/></PermissionSet>
        public static object CreateInstance(Type type, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture)
        {
            return Activator.CreateInstance(type, bindingAttr, binder, args, culture, (object[])null);
        }

        /// <summary>
        /// Creates an instance of the specified type using the constructor that best matches the specified parameters.
        /// </summary>
        /// 
        /// <returns>
        /// A reference to the newly created object.
        /// </returns>
        /// <param name="type">The type of object to create. </param><param name="bindingAttr">A combination of zero or more bit flags that affect the search for the <paramref name="type"/> constructor. If <paramref name="bindingAttr"/> is zero, a case-sensitive search for public constructors is conducted. </param><param name="binder">An object that uses <paramref name="bindingAttr"/> and <paramref name="args"/> to seek and identify the <paramref name="type"/> constructor. If <paramref name="binder"/> is null, the default binder is used. </param><param name="args">An array of arguments that match in number, order, and type the parameters of the constructor to invoke. If <paramref name="args"/> is an empty array or null, the constructor that takes no parameters (the default constructor) is invoked. </param><param name="culture">Culture-specific information that governs the coercion of <paramref name="args"/> to the formal types declared for the <paramref name="type"/> constructor. If <paramref name="culture"/> is null, the <see cref="T:System.Globalization.CultureInfo"/> for the current thread is used. </param><param name="activationAttributes">An array of one or more attributes that can participate in activation. This is typically an array that contains a single <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute"/> object. The <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute"/> specifies the URL that is required to activate a remote object.  </param><exception cref="T:System.ArgumentNullException"><paramref name="type"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="type"/> is not a RuntimeType. -or-<paramref name="type"/> is an open generic type (that is, the <see cref="P:System.Type.ContainsGenericParameters"/> property returns true).</exception><exception cref="T:System.NotSupportedException"><paramref name="type"/> cannot be a <see cref="T:System.Reflection.Emit.TypeBuilder"/>.-or- Creation of <see cref="T:System.TypedReference"/>, <see cref="T:System.ArgIterator"/>, <see cref="T:System.Void"/>, and <see cref="T:System.RuntimeArgumentHandle"/> types, or arrays of those types, is not supported.-or- <paramref name="activationAttributes"/> is not an empty array, and the type being created does not derive from <see cref="T:System.MarshalByRefObject"/>. -or-The assembly that contains <paramref name="type"/> is a dynamic assembly that was created with <see cref="F:System.Reflection.Emit.AssemblyBuilderAccess.Save"/>.-or-The constructor that best matches <paramref name="args"/> has varargs arguments.</exception><exception cref="T:System.Reflection.TargetInvocationException">The constructor being called throws an exception. </exception><exception cref="T:System.MethodAccessException">The caller does not have permission to call this constructor. </exception><exception cref="T:System.MemberAccessException">Cannot create an instance of an abstract class, or this member was invoked with a late-binding mechanism. </exception><exception cref="T:System.Runtime.InteropServices.InvalidComObjectException">The COM type was not obtained through <see cref="Overload:System.Type.GetTypeFromProgID"/> or <see cref="Overload:System.Type.GetTypeFromCLSID"/>. </exception><exception cref="T:System.MissingMethodException">No matching constructor was found. </exception><exception cref="T:System.Runtime.InteropServices.COMException"><paramref name="type"/> is a COM object but the class identifier used to obtain the type is invalid, or the identified class is not registered. </exception><exception cref="T:System.TypeLoadException"><paramref name="type"/> is not a valid type. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence, RemotingConfiguration"/></PermissionSet>
        public static object CreateInstance(Type type, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an instance of the specified type using the constructor that best matches the specified parameters.
        /// </summary>
        /// 
        /// <returns>
        /// A reference to the newly created object.
        /// </returns>
        /// <param name="type">The type of object to create. </param><param name="args">An array of arguments that match in number, order, and type the parameters of the constructor to invoke. If <paramref name="args"/> is an empty array or null, the constructor that takes no parameters (the default constructor) is invoked. </param><exception cref="T:System.ArgumentNullException"><paramref name="type"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="type"/> is not a RuntimeType. -or-<paramref name="type"/> is an open generic type (that is, the <see cref="P:System.Type.ContainsGenericParameters"/> property returns true).</exception><exception cref="T:System.NotSupportedException"><paramref name="type"/> cannot be a <see cref="T:System.Reflection.Emit.TypeBuilder"/>.-or- Creation of <see cref="T:System.TypedReference"/>, <see cref="T:System.ArgIterator"/>, <see cref="T:System.Void"/>, and <see cref="T:System.RuntimeArgumentHandle"/> types, or arrays of those types, is not supported. -or-The assembly that contains <paramref name="type"/> is a dynamic assembly that was created with <see cref="F:System.Reflection.Emit.AssemblyBuilderAccess.Save"/>.-or-The constructor that best matches <paramref name="args"/> has varargs arguments.</exception><exception cref="T:System.Reflection.TargetInvocationException">The constructor being called throws an exception. </exception><exception cref="T:System.MethodAccessException">The caller does not have permission to call this constructor. </exception><exception cref="T:System.MemberAccessException">Cannot create an instance of an abstract class, or this member was invoked with a late-binding mechanism. </exception><exception cref="T:System.Runtime.InteropServices.InvalidComObjectException">The COM type was not obtained through <see cref="Overload:System.Type.GetTypeFromProgID"/> or <see cref="Overload:System.Type.GetTypeFromCLSID"/>. </exception><exception cref="T:System.MissingMethodException">No matching public constructor was found. </exception><exception cref="T:System.Runtime.InteropServices.COMException"><paramref name="type"/> is a COM object but the class identifier used to obtain the type is invalid, or the identified class is not registered. </exception><exception cref="T:System.TypeLoadException"><paramref name="type"/> is not a valid type. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence, RemotingConfiguration"/></PermissionSet>
        public static object CreateInstance(Type type, params object[] args)
        {
            return CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, (Binder)null, args, (CultureInfo)null, (object[])null);
        }

        /// <summary>
        /// Creates an instance of the specified type using the constructor that best matches the specified parameters.
        /// </summary>
        /// 
        /// <returns>
        /// A reference to the newly created object.
        /// </returns>
        /// <param name="type">The type of object to create. </param><param name="args">An array of arguments that match in number, order, and type the parameters of the constructor to invoke. If <paramref name="args"/> is an empty array or null, the constructor that takes no parameters (the default constructor) is invoked. </param><param name="activationAttributes">An array of one or more attributes that can participate in activation. This is typically an array that contains a single <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute"/> object. The <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute"/> specifies the URL that is required to activate a remote object.  </param><exception cref="T:System.ArgumentNullException"><paramref name="type"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="type"/> is not a RuntimeType. -or-<paramref name="type"/> is an open generic type (that is, the <see cref="P:System.Type.ContainsGenericParameters"/> property returns true).</exception><exception cref="T:System.NotSupportedException"><paramref name="type"/> cannot be a <see cref="T:System.Reflection.Emit.TypeBuilder"/>.-or- Creation of <see cref="T:System.TypedReference"/>, <see cref="T:System.ArgIterator"/>, <see cref="T:System.Void"/>, and <see cref="T:System.RuntimeArgumentHandle"/> types, or arrays of those types, is not supported.-or- <paramref name="activationAttributes"/> is not an empty array, and the type being created does not derive from <see cref="T:System.MarshalByRefObject"/>. -or-The assembly that contains <paramref name="type"/> is a dynamic assembly that was created with <see cref="F:System.Reflection.Emit.AssemblyBuilderAccess.Save"/>.-or-The constructor that best matches <paramref name="args"/> has varargs arguments.</exception><exception cref="T:System.Reflection.TargetInvocationException">The constructor being called throws an exception. </exception><exception cref="T:System.MethodAccessException">The caller does not have permission to call this constructor. </exception><exception cref="T:System.MemberAccessException">Cannot create an instance of an abstract class, or this member was invoked with a late-binding mechanism. </exception><exception cref="T:System.Runtime.InteropServices.InvalidComObjectException">The COM type was not obtained through <see cref="Overload:System.Type.GetTypeFromProgID"/> or <see cref="Overload:System.Type.GetTypeFromCLSID"/>. </exception><exception cref="T:System.MissingMethodException">No matching public constructor was found. </exception><exception cref="T:System.Runtime.InteropServices.COMException"><paramref name="type"/> is a COM object but the class identifier used to obtain the type is invalid, or the identified class is not registered. </exception><exception cref="T:System.TypeLoadException"><paramref name="type"/> is not a valid type. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence, RemotingConfiguration"/></PermissionSet>
        public static object CreateInstance(Type type, object[] args, object[] activationAttributes)
        {
            return Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, (Binder)null, args, (CultureInfo)null, activationAttributes);
        }

        /// <summary>
        /// Creates an instance of the specified type using that type's default constructor.
        /// </summary>
        /// 
        /// <returns>
        /// A reference to the newly created object.
        /// </returns>
        /// <param name="type">The type of object to create. </param><exception cref="T:System.ArgumentNullException"><paramref name="type"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="type"/> is not a RuntimeType. -or-<paramref name="type"/> is an open generic type (that is, the <see cref="P:System.Type.ContainsGenericParameters"/> property returns true).</exception><exception cref="T:System.NotSupportedException"><paramref name="type"/> cannot be a <see cref="T:System.Reflection.Emit.TypeBuilder"/>.-or- Creation of <see cref="T:System.TypedReference"/>, <see cref="T:System.ArgIterator"/>, <see cref="T:System.Void"/>, and <see cref="T:System.RuntimeArgumentHandle"/> types, or arrays of those types, is not supported.-or-The assembly that contains <paramref name="type"/> is a dynamic assembly that was created with <see cref="F:System.Reflection.Emit.AssemblyBuilderAccess.Save"/>. </exception><exception cref="T:System.Reflection.TargetInvocationException">The constructor being called throws an exception. </exception><exception cref="T:System.MethodAccessException">The caller does not have permission to call this constructor. </exception><exception cref="T:System.MemberAccessException">Cannot create an instance of an abstract class, or this member was invoked with a late-binding mechanism. </exception><exception cref="T:System.Runtime.InteropServices.InvalidComObjectException">The COM type was not obtained through <see cref="Overload:System.Type.GetTypeFromProgID"/> or <see cref="Overload:System.Type.GetTypeFromCLSID"/>. </exception><exception cref="T:System.MissingMethodException">No matching public constructor was found. </exception><exception cref="T:System.Runtime.InteropServices.COMException"><paramref name="type"/> is a COM object but the class identifier used to obtain the type is invalid, or the identified class is not registered. </exception><exception cref="T:System.TypeLoadException"><paramref name="type"/> is not a valid type. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/></PermissionSet>
        public static object CreateInstance(Type type)
        {
            return CreateInstance(type, false);
        }

        /// <summary>
        /// Creates an instance of the specified type using that type's default constructor.
        /// </summary>
        /// 
        /// <returns>
        /// A reference to the newly created object.
        /// </returns>
        /// <param name="type">The type of object to create. </param><param name="nonPublic">true if a public or nonpublic default constructor can match; false if only a public default constructor can match. </param><exception cref="T:System.ArgumentNullException"><paramref name="type"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="type"/> is not a RuntimeType. -or-<paramref name="type"/> is an open generic type (that is, the <see cref="P:System.Type.ContainsGenericParameters"/> property returns true).</exception><exception cref="T:System.NotSupportedException"><paramref name="type"/> cannot be a <see cref="T:System.Reflection.Emit.TypeBuilder"/>.-or- Creation of <see cref="T:System.TypedReference"/>, <see cref="T:System.ArgIterator"/>, <see cref="T:System.Void"/>, and <see cref="T:System.RuntimeArgumentHandle"/> types, or arrays of those types, is not supported. -or-The assembly that contains <paramref name="type"/> is a dynamic assembly that was created with <see cref="F:System.Reflection.Emit.AssemblyBuilderAccess.Save"/>.</exception><exception cref="T:System.Reflection.TargetInvocationException">The constructor being called throws an exception. </exception><exception cref="T:System.MethodAccessException">The caller does not have permission to call this constructor. </exception><exception cref="T:System.MemberAccessException">Cannot create an instance of an abstract class, or this member was invoked with a late-binding mechanism. </exception><exception cref="T:System.Runtime.InteropServices.InvalidComObjectException">The COM type was not obtained through <see cref="Overload:System.Type.GetTypeFromProgID"/> or <see cref="Overload:System.Type.GetTypeFromCLSID"/>. </exception><exception cref="T:System.MissingMethodException">No matching public constructor was found. </exception><exception cref="T:System.Runtime.InteropServices.COMException"><paramref name="type"/> is a COM object but the class identifier used to obtain the type is invalid, or the identified class is not registered. </exception><exception cref="T:System.TypeLoadException"><paramref name="type"/> is not a valid type. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/></PermissionSet>
        public static object CreateInstance(Type type, bool nonPublic)
        {
            return type.GetConstructors().Where(x => x.GetParameters().Length == 0).Single().Invoke(new object[0]);
        }

        /// <summary>
        /// Creates an instance of the type designated by the specified generic type parameter, using the parameterless constructor .
        /// </summary>
        /// 
        /// <returns>
        /// A reference to the newly created object.
        /// </returns>
        /// <typeparam name="T">The type to create.</typeparam><exception cref="T:System.MissingMethodException">The type that is specified for <paramref name="T"/> does not have a parameterless constructor.</exception>
        public static T CreateInstance<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a proxy for the well-known object indicated by the specified type and URL.
        /// </summary>
        /// 
        /// <returns>
        /// A proxy that points to an endpoint served by the requested well-known object.
        /// </returns>
        /// <param name="type">The type of the well-known object to which you want to connect. </param><param name="url">The URL of the well-known object. </param><exception cref="T:System.ArgumentNullException"><paramref name="type"/> or <paramref name="url"/> is null. </exception><exception cref="T:System.Runtime.Remoting.RemotingException"><paramref name="type"/> is not marshaled by reference and is not an interface.</exception><exception cref="T:System.MemberAccessException">This member was invoked with a late-binding mechanism. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration"/></PermissionSet>
        public static object GetObject(Type type, string url)
        {
            return Activator.GetObject(type, url, (object)null);
        }

        /// <summary>
        /// Creates a proxy for the well-known object indicated by the specified type, URL, and channel data.
        /// </summary>
        /// 
        /// <returns>
        /// A proxy that points to an endpoint served by the requested well-known object.
        /// </returns>
        /// <param name="type">The type of the well-known object to which you want to connect. </param><param name="url">The URL of the well-known object. </param><param name="state">Channel-specific data or null. </param><exception cref="T:System.ArgumentNullException"><paramref name="type"/> or <paramref name="url"/> is null. </exception><exception cref="T:System.Runtime.Remoting.RemotingException"><paramref name="type"/> is not marshaled by reference and is not an interface.</exception><exception cref="T:System.MemberAccessException">This member was invoked with a late-binding mechanism. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration"/></PermissionSet>
        public static object GetObject(Type type, string url, object state)
        {
            throw new NotImplementedException();
        }
    }
}
