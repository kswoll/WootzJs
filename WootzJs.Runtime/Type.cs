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

using System.Linq;
using System.Reflection;
using System.Runtime.WootzJs;

namespace System
{
    public class Type : MemberInfo
    {
        public static readonly Type[] EmptyTypes = new Type[0];
        public static readonly Binder DefaultBinder = new Binder();

        public string FullName { get; set; }

        internal JsTypeFunction thisType;
        private JsTypeFunction baseType;
        internal JsTypeFunction[] interfaces;
        internal JsTypeFunction[] typeArguments;
        internal FieldInfo[] fields;
        internal MethodInfo[] methods;
        internal ConstructorInfo[] constructors;
        internal PropertyInfo[] properties;
        internal EventInfo[] events;
        private JsTypeFunction elementType;
        private JsTypeFunction unconstructedType;
        private bool isValueType;
        private bool isInterface;
        private bool isAbstract;
        private bool isPrimitive;
        private bool isGenericType;
        private bool isGenericTypeDefinition;

        public Type(string name, Attribute[] attributes) : base(name, attributes)
        {
        }

        public override MemberTypes MemberType
        {
            get { return MemberTypes.TypeInfo; }
        }

        public static Type CreateTypeParameter(string fullName, JsTypeFunction baseType)
        {
            var type = new Type(fullName, new Attribute[0]);
            type.Init(fullName, null, baseType, new JsTypeFunction[0], new JsTypeFunction[0],
                new FieldInfo[0], new MethodInfo[0], new ConstructorInfo[0], new PropertyInfo[0],
                new EventInfo[0], false, false, false, false, false, false, null, null);
            return type;
        }

        public void Init(string fullName, JsTypeFunction thisType, JsTypeFunction baseType, JsTypeFunction[] interfaces, JsTypeFunction[] typeArguments, FieldInfo[] fields, MethodInfo[] methods, ConstructorInfo[] constructors, PropertyInfo[] properties, EventInfo[] events, bool isValueType, bool isAbstract, bool isInterface, bool isPrimitive, bool isGenericType, bool isGenericTypeDefinition, JsTypeFunction elementType, JsTypeFunction unconstructedType)
        {
            FullName = fullName;

            this.thisType = thisType;
            this.baseType = baseType;
            this.interfaces = interfaces;
            this.typeArguments = typeArguments;
            this.fields = fields;
            this.methods = methods;
            this.constructors = constructors;
            this.properties = properties;
            this.events = events;
            this.isValueType = isValueType;
            this.isAbstract = isAbstract;
            this.isInterface = isInterface;
            this.isPrimitive = isPrimitive;
            this.isGenericType = isGenericType;
            this.isGenericTypeDefinition = isGenericTypeDefinition;
            this.elementType = elementType;
            this.unconstructedType = unconstructedType;

            foreach (var field in fields)
                field.declaringType = this;
            foreach (var method in methods)
                method.declaringType = this;
            foreach (var property in properties)
                property.declaringType = this;
            foreach (var constructor in constructors)
                constructor.declaringType = this;
        }

        internal static Type _GetTypeFromInstance(JsObject instance)
        {
            var typeFunction = instance["$type"].As<JsTypeFunction>();
            if (typeFunction == null)
            {
                var typeString = Jsni._typeof(instance);
                if (typeString == "string".As<JsString>())
                {
                    return GetType("System.String");
                }
                if (typeString == "number".As<JsString>())
                {
                    return GetType("System.Number");
                }
                if (typeString == "object".As<JsString>())
                {
                    return GetType("System.Object");
                }
                if (typeString == "function".As<JsString>())
                {
                    return GetType("System.Delegate");
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                return _GetTypeFromTypeFunc(typeFunction);
            }
        }

        public static Type _GetTypeFromTypeFunc(JsTypeFunction typeFunction)
        {
            if (typeFunction.Type == null)
                typeFunction.CreateType();
            return typeFunction.Type;
        }

        public static Type GetTypeFromHandle(RuntimeTypeHandle typeHandle)
        {
            return null;
        }

        public Type BaseType
        {
            get
            {
                if (baseType == null)
                    return null;
                else
                    return _GetTypeFromTypeFunc(baseType);
            }
        }

        public Assembly Assembly
        {
            get { return thisType.GetAssembly.invoke().As<Assembly>(); }
        }

        public static Type GetType(string typeName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var result = assembly.GetType(typeName);
                if (result != null)
                    return result;
            }
            return null;
        }

        public Type GetElementType()
        {
            return elementType == null ? null : _GetTypeFromTypeFunc(elementType);
        }

        public bool IsAssignableFrom(Type type)
        {
            // Special hack for handling the merged numeric types
            if (type == typeof (Number))
            {
                if (this == typeof (int) || this == typeof (float) || this == typeof (long) ||
                    this == typeof (byte) || this == typeof (sbyte) || this == typeof (short) ||
                    this == typeof (ushort) || this == typeof (uint) || this == typeof (ulong) ||
                    this == typeof (double))
                {
                    return true;
                }
            }
            // Special hack to allow arbitrary delegates to be force cast into particular delegate
//            if (type == typeof (Delegate) && type.IsAssignableFrom(this))
//            {
//                return true;
//            }


            // Check base type hierarchy
            var current = type;
            while (current != null)
            {
                if (current == this)
                    return true;
                current = current.BaseType;
            }

            // Now check interfaces
            foreach (var item in type.GetInterfaces())
            {
                if (item == this)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified object is an instance of the current <see cref="T:System.Type"/>.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current Type is in the inheritance hierarchy of the object represented by <paramref name="o"/>, or if the current Type is an interface that <paramref name="o"/> supports. false if neither of these conditions is the case, or if <paramref name="o"/> is null, or if the current Type is an open generic type (that is, <see cref="P:System.Type.ContainsGenericParameters"/> returns true).
        /// </returns>
        /// <param name="o">The object to compare with the current type. </param><filterpriority>2</filterpriority>
        public bool IsInstanceOfType(object o)
        {
            if (o == null)
                return false;
            else
                return IsAssignableFrom(o.GetType());
        }

        /// <summary>
        /// When overridden in a derived class, gets all the interfaces implemented or inherited by the current <see cref="T:System.Type"/>.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.Type"/> objects representing all the interfaces implemented or inherited by the current <see cref="T:System.Type"/>.-or- An empty array of type <see cref="T:System.Type"/>, if no interfaces are implemented or inherited by the current <see cref="T:System.Type"/>.
        /// </returns>
        /// <exception cref="T:System.Reflection.TargetInvocationException">A static initializer is invoked and throws an exception. </exception><filterpriority>2</filterpriority>
        public Type[] GetInterfaces()
        {
            return interfaces.Select(x => _GetTypeFromTypeFunc(x)).ToArray();
        }

        public PropertyInfo[] GetProperties()
        {
            return properties.ToArray();
        }

        public EventInfo[] GetEvents()
        {
            return events.ToArray();
        }

        public MethodInfo[] GetMethods()
        {
            return methods.ToArray();
        }

        private MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            foreach (var method in methods)
            {
                if (method.Name != name)
                    continue;
                if ((bindingAttr & BindingFlags.NonPublic) != BindingFlags.NonPublic && !method.IsPublic)
                    continue;
                var parameters = method.GetParameters();
                if (types != null && types.Length != parameters.Length)
                    continue;
                if (types != null)
                {
                    bool isValid = true;
                    for (var i = 0; i < types.Length; i++)
                        if (types[i] != parameters[i].ParameterType)
                            isValid = false;
                    if (!isValid)
                        continue;
                }
                return method;
            }
            return null;
        }

        /// <summary>
        /// Searches for the specified public method whose parameters match the specified argument types.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the public method whose parameters match the specified argument types, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the public method to get. </param><param name="types">An array of <see cref="T:System.Type"/> objects representing the number, order, and type of the parameters for the method to get.-or- An empty array of <see cref="T:System.Type"/> objects (as provided by the <see cref="F:System.Type.EmptyTypes"/> field) to get a method that takes no parameters. </param><exception cref="T:System.Reflection.AmbiguousMatchException">More than one method is found with the specified name and specified parameters. </exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null.-or- <paramref name="types"/> is null.-or- One of the elements in <paramref name="types"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="types"/> is multidimensional. </exception><filterpriority>2</filterpriority>
        public MethodInfo GetMethod(string name, Type[] types)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (types == null)
                throw new ArgumentNullException("types");
            for (int index = 0; index < types.Length; ++index)
            {
                if (types[index] == (Type)null)
                    throw new ArgumentNullException("types");
            }
            return this.GetMethodImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, (Binder)null, CallingConventions.Any, types, (ParameterModifier[])null);
        }

        /// <summary>
        /// Searches for the specified method, using the specified binding constraints.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the method that matches the specified requirements, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the method to get. </param><param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags"/> that specify how the search is conducted.-or- Zero, to return null. </param><exception cref="T:System.Reflection.AmbiguousMatchException">More than one method is found with the specified name and matching the specified binding constraints. </exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null. </exception><filterpriority>2</filterpriority>
        public MethodInfo GetMethod(string name, BindingFlags bindingAttr)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            else
                return this.GetMethodImpl(name, bindingAttr, (Binder)null, CallingConventions.Any, (Type[])null, (ParameterModifier[])null);
        }

        /// <summary>
        /// Searches for the public method with the specified name.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents the public method with the specified name, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the public method to get. </param><exception cref="T:System.Reflection.AmbiguousMatchException">More than one method is found with the specified name. </exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null. </exception><filterpriority>2</filterpriority>
        public MethodInfo GetMethod(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            else
                return this.GetMethodImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, (Binder)null, CallingConventions.Any, (Type[])null, (ParameterModifier[])null);
        }

        /// <summary>
        /// Searches for the specified property whose parameters match the specified argument types and modifiers, using the specified binding constraints.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the property that matches the specified requirements, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the property to get. </param><param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags"/> that specify how the search is conducted.-or- Zero, to return null. </param><param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.-or- A null reference (Nothing in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder"/>. </param><param name="returnType">The return type of the property. </param><param name="types">An array of <see cref="T:System.Type"/> objects representing the number, order, and type of the parameters for the indexed property to get.-or- An empty array of the type <see cref="T:System.Type"/> (that is, Type[] types = new Type[0]) to get a property that is not indexed. </param><param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier"/> objects representing the attributes associated with the corresponding element in the <paramref name="types"/> array. The default binder does not process this parameter. </param><exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name and matching the specified binding constraints. </exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null.-or- <paramref name="types"/> is null.</exception><exception cref="T:System.ArgumentException"><paramref name="types"/> is multidimensional.-or- <paramref name="modifiers"/> is multidimensional.-or- <paramref name="types"/> and <paramref name="modifiers"/> do not have the same length. </exception><exception cref="T:System.NullReferenceException">An element of <paramref name="types"/> is null.</exception><filterpriority>2</filterpriority>
        public PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (types == null)
                throw new ArgumentNullException("types");
            else
                return this.GetPropertyImpl(name, bindingAttr, binder, returnType, types, modifiers);
        }

        /// <summary>
        /// Searches for the specified public property whose parameters match the specified argument types and modifiers.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the public property that matches the specified requirements, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the public property to get. </param><param name="returnType">The return type of the property. </param><param name="types">An array of <see cref="T:System.Type"/> objects representing the number, order, and type of the parameters for the indexed property to get.-or- An empty array of the type <see cref="T:System.Type"/> (that is, Type[] types = new Type[0]) to get a property that is not indexed. </param><param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier"/> objects representing the attributes associated with the corresponding element in the <paramref name="types"/> array. The default binder does not process this parameter. </param><exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name and matching the specified argument types and modifiers. </exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null.-or- <paramref name="types"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="types"/> is multidimensional.-or- <paramref name="modifiers"/> is multidimensional.-or- <paramref name="types"/> and <paramref name="modifiers"/> do not have the same length. </exception><exception cref="T:System.NullReferenceException">An element of <paramref name="types"/> is null.</exception><filterpriority>2</filterpriority>
        public PropertyInfo GetProperty(string name, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (types == null)
                throw new ArgumentNullException("types");
            else
                return this.GetPropertyImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, (Binder)null, returnType, types, modifiers);
        }

        /// <summary>
        /// Searches for the specified property, using the specified binding constraints.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the property that matches the specified requirements, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the property to get. </param><param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags"/> that specify how the search is conducted.-or- Zero, to return null. </param><exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name and matching the specified binding constraints. See Remarks.</exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null. </exception><filterpriority>2</filterpriority>
        public PropertyInfo GetProperty(string name, BindingFlags bindingAttr)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            else
                return this.GetPropertyImpl(name, bindingAttr, (Binder)null, (Type)null, (Type[])null, (ParameterModifier[])null);
        }

        /// <summary>
        /// Searches for the specified public property whose parameters match the specified argument types.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the public property whose parameters match the specified argument types, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the public property to get. </param><param name="returnType">The return type of the property. </param><param name="types">An array of <see cref="T:System.Type"/> objects representing the number, order, and type of the parameters for the indexed property to get.-or- An empty array of the type <see cref="T:System.Type"/> (that is, Type[] types = new Type[0]) to get a property that is not indexed. </param><exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name and matching the specified argument types. </exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null.-or- <paramref name="types"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="types"/> is multidimensional. </exception><exception cref="T:System.NullReferenceException">An element of <paramref name="types"/> is null.</exception><filterpriority>2</filterpriority>
        public PropertyInfo GetProperty(string name, Type returnType, Type[] types)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (types == null)
                throw new ArgumentNullException("types");
            else
                return this.GetPropertyImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, (Binder)null, returnType, types, (ParameterModifier[])null);
        }

        /// <summary>
        /// Searches for the specified public property whose parameters match the specified argument types.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the public property whose parameters match the specified argument types, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the public property to get. </param><param name="types">An array of <see cref="T:System.Type"/> objects representing the number, order, and type of the parameters for the indexed property to get.-or- An empty array of the type <see cref="T:System.Type"/> (that is, Type[] types = new Type[0]) to get a property that is not indexed. </param><exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name and matching the specified argument types. </exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null.-or- <paramref name="types"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="types"/> is multidimensional. </exception><exception cref="T:System.NullReferenceException">An element of <paramref name="types"/> is null.</exception><filterpriority>2</filterpriority>
        public PropertyInfo GetProperty(string name, Type[] types)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (types == null)
                throw new ArgumentNullException("types");
            else
                return this.GetPropertyImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, (Binder)null, (Type)null, types, (ParameterModifier[])null);
        }

        /// <summary>
        /// Searches for the public property with the specified name and return type.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the public property with the specified name, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the public property to get. </param><param name="returnType">The return type of the property. </param><exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name. </exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null, or <paramref name="returnType"/> is null. </exception><filterpriority>2</filterpriority>
        public PropertyInfo GetProperty(string name, Type returnType)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (returnType == (Type)null)
                throw new ArgumentNullException("returnType");
            else
                return this.GetPropertyImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, (Binder)null, returnType, (Type[])null, (ParameterModifier[])null);
        }

        internal PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Type returnType)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (returnType == (Type)null)
                throw new ArgumentNullException("returnType");
            else
                return this.GetPropertyImpl(name, bindingAttr, (Binder)null, returnType, (Type[])null, (ParameterModifier[])null);
        }

        /// <summary>
        /// Searches for the public property with the specified name.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the public property with the specified name, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the public property to get. </param><exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name. See Remarks.</exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null. </exception><filterpriority>2</filterpriority>
        public PropertyInfo GetProperty(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            else
                return this.GetPropertyImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, (Binder)null, (Type)null, (Type[])null, (ParameterModifier[])null);
        }

        /// <summary>
        /// When overridden in a derived class, searches for the specified property whose parameters match the specified argument types and modifiers, using the specified binding constraints.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the property that matches the specified requirements, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the property to get. </param><param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags"/> that specify how the search is conducted.-or- Zero, to return null. </param><param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded member, coercion of argument types, and invocation of a member through reflection.-or- A null reference (Nothing in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder"/>. </param><param name="returnType">The return type of the property. </param><param name="types">An array of <see cref="T:System.Type"/> objects representing the number, order, and type of the parameters for the indexed property to get.-or- An empty array of the type <see cref="T:System.Type"/> (that is, Type[] types = new Type[0]) to get a property that is not indexed. </param><param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier"/> objects representing the attributes associated with the corresponding element in the <paramref name="types"/> array. The default binder does not process this parameter. </param><exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name and matching the specified binding constraints. </exception><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null.-or- <paramref name="types"/> is null.-or- One of the elements in <paramref name="types"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="types"/> is multidimensional.-or- <paramref name="modifiers"/> is multidimensional.-or- <paramref name="types"/> and <paramref name="modifiers"/> do not have the same length. </exception><exception cref="T:System.NotSupportedException">The current type is a <see cref="T:System.Reflection.Emit.TypeBuilder"/>, <see cref="T:System.Reflection.Emit.EnumBuilder"/>, or <see cref="T:System.Reflection.Emit.GenericTypeParameterBuilder"/>.</exception>
        protected PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            foreach (var property in properties)
            {
                var anAccessor = property.GetMethod ?? property.SetMethod;

                if (property.Name != name)
                    continue;
                if ((bindingAttr & BindingFlags.NonPublic) != BindingFlags.NonPublic && !anAccessor.IsPublic)
                    continue;
                var parameters = property.GetIndexParameters();
                if (types != null && types.Length != parameters.Length)
                    continue;
                if (types != null)
                {
                    bool isValid = true;
                    for (var i = 0; i < types.Length; i++)
                        if (types[i] != parameters[i].ParameterType)
                            isValid = false;
                    if (!isValid)
                        continue;
                }
                return property;
            }
            return null;
        }

        public ConstructorInfo[] GetConstructors()
        {
            return constructors.ToArray();
        }

        /// <summary>
        /// Searches for the specified field, using the specified binding constraints.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the field that matches the specified requirements, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the data field to get. </param><param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags"/> that specify how the search is conducted.-or- Zero, to return null. </param><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null. </exception><filterpriority>2</filterpriority>
        public FieldInfo GetField(string name, BindingFlags bindingAttr)
        {
            foreach (var field in fields)
            {
                if (field.Name != name)
                    continue;
                if ((bindingAttr & BindingFlags.NonPublic) != BindingFlags.NonPublic && !field.IsPublic)
                    continue;
                return field;
            }
            return null;
        }

        /// <summary>
        /// Searches for the public field with the specified name.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the public field with the specified name, if found; otherwise, null.
        /// </returns>
        /// <param name="name">The string containing the name of the data field to get. </param><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null. </exception><exception cref="T:System.NotSupportedException">This <see cref="T:System.Type"/> object is a <see cref="T:System.Reflection.Emit.TypeBuilder"/> whose <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType"/> method has not yet been called. </exception><filterpriority>2</filterpriority>
        public FieldInfo GetField(string name)
        {
            return this.GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        }

        /// <summary>
        /// Returns all the public fields of the current <see cref="T:System.Type"/>.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.Reflection.FieldInfo"/> objects representing all the public fields defined for the current <see cref="T:System.Type"/>.-or- An empty array of type <see cref="T:System.Reflection.FieldInfo"/>, if no public fields are defined for the current <see cref="T:System.Type"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public FieldInfo[] GetFields()
        {
            return this.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        }

        /// <summary>
        /// When overridden in a derived class, searches for the fields defined for the current <see cref="T:System.Type"/>, using the specified binding constraints.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.Reflection.FieldInfo"/> objects representing all fields defined for the current <see cref="T:System.Type"/> that match the specified binding constraints.-or- An empty array of type <see cref="T:System.Reflection.FieldInfo"/>, if no fields are defined for the current <see cref="T:System.Type"/>, or if none of the defined fields match the binding constraints.
        /// </returns>
        /// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags"/> that specify how the search is conducted.-or- Zero, to return null. </param><filterpriority>2</filterpriority>
        public FieldInfo[] GetFields(BindingFlags bindingAttr)
        {
            return fields.ToArray();
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Type"/> is a value type.
        /// </summary>
        /// 
        /// <returns>
        /// true if the <see cref="T:System.Type"/> is a value type; otherwise, false.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public bool IsValueType
        {
            get { return isValueType; }
        }

        /// <summary>
        /// Searches for a constructor whose parameters match the specified argument types and modifiers, using the specified binding constraints and the specified calling convention.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the constructor that matches the specified requirements, if found; otherwise, null.
        /// </returns>
        /// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags"/> that specify how the search is conducted.-or- Zero, to return null. </param><param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.-or- A null reference (Nothing in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder"/>. </param><param name="callConvention">The object that specifies the set of rules to use regarding the order and layout of arguments, how the return value is passed, what registers are used for arguments, and the stack is cleaned up. </param><param name="types">An array of <see cref="T:System.Type"/> objects representing the number, order, and type of the parameters for the constructor to get.-or- An empty array of the type <see cref="T:System.Type"/> (that is, Type[] types = new Type[0]) to get a constructor that takes no parameters. </param><param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier"/> objects representing the attributes associated with the corresponding element in the <paramref name="types"/> array. The default binder does not process this parameter. </param><exception cref="T:System.ArgumentNullException"><paramref name="types"/> is null.-or- One of the elements in <paramref name="types"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="types"/> is multidimensional.-or- <paramref name="modifiers"/> is multidimensional.-or- <paramref name="types"/> and <paramref name="modifiers"/> do not have the same length. </exception><filterpriority>2</filterpriority>
        public ConstructorInfo GetConstructor(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            if (types == null)
                throw new ArgumentNullException("types");
            for (int index = 0; index < types.Length; ++index)
            {
                if (types[index] == (Type)null)
                    throw new ArgumentNullException("types");
            }
            return this.GetConstructorImpl(bindingAttr, binder, callConvention, types, modifiers);
        }

        /// <summary>
        /// Searches for a constructor whose parameters match the specified argument types and modifiers, using the specified binding constraints.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.ConstructorInfo"/> object representing the constructor that matches the specified requirements, if found; otherwise, null.
        /// </returns>
        /// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags"/> that specify how the search is conducted.-or- Zero, to return null. </param><param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.-or- A null reference (Nothing in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder"/>. </param><param name="types">An array of <see cref="T:System.Type"/> objects representing the number, order, and type of the parameters for the constructor to get.-or- An empty array of the type <see cref="T:System.Type"/> (that is, Type[] types = new Type[0]) to get a constructor that takes no parameters.-or- <see cref="F:System.Type.EmptyTypes"/>. </param><param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier"/> objects representing the attributes associated with the corresponding element in the parameter type array. The default binder does not process this parameter. </param><exception cref="T:System.ArgumentNullException"><paramref name="types"/> is null.-or- One of the elements in <paramref name="types"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="types"/> is multidimensional.-or- <paramref name="modifiers"/> is multidimensional.-or- <paramref name="types"/> and <paramref name="modifiers"/> do not have the same length. </exception><filterpriority>2</filterpriority>
        public ConstructorInfo GetConstructor(BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            if (types == null)
                throw new ArgumentNullException("types");
            for (int index = 0; index < types.Length; ++index)
            {
                if (types[index] == (Type)null)
                    throw new ArgumentNullException("types");
            }
            return this.GetConstructorImpl(bindingAttr, binder, CallingConventions.Any, types, modifiers);
        }

        /// <summary>
        /// Searches for a public instance constructor whose parameters match the types in the specified array.
        /// </summary>
        /// 
        /// <returns>
        /// An object representing the public instance constructor whose parameters match the types in the parameter type array, if found; otherwise, null.
        /// </returns>
        /// <param name="types">An array of <see cref="T:System.Type"/> objects representing the number, order, and type of the parameters for the desired constructor.-or- An empty array of <see cref="T:System.Type"/> objects, to get a constructor that takes no parameters. Such an empty array is provided by the static field <see cref="F:System.Type.EmptyTypes"/>. </param><exception cref="T:System.ArgumentNullException"><paramref name="types"/> is null.-or- One of the elements in <paramref name="types"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="types"/> is multidimensional. </exception><filterpriority>2</filterpriority>
        public ConstructorInfo GetConstructor(Type[] types)
        {
            return this.GetConstructor(BindingFlags.Instance | BindingFlags.Public, (Binder)null, types, (ParameterModifier[])null);
        }

        /// <summary>
        /// When overridden in a derived class, searches for a constructor whose parameters match the specified argument types and modifiers, using the specified binding constraints and the specified calling convention.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.ConstructorInfo"/> object representing the constructor that matches the specified requirements, if found; otherwise, null.
        /// </returns>
        /// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags"/> that specify how the search is conducted.-or- Zero, to return null. </param><param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.-or- A null reference (Nothing in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder"/>. </param><param name="callConvention">The object that specifies the set of rules to use regarding the order and layout of arguments, how the return value is passed, what registers are used for arguments, and the stack is cleaned up. </param><param name="types">An array of <see cref="T:System.Type"/> objects representing the number, order, and type of the parameters for the constructor to get.-or- An empty array of the type <see cref="T:System.Type"/> (that is, Type[] types = new Type[0]) to get a constructor that takes no parameters. </param><param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier"/> objects representing the attributes associated with the corresponding element in the <paramref name="types"/> array. The default binder does not process this parameter. </param><exception cref="T:System.ArgumentNullException"><paramref name="types"/> is null.-or- One of the elements in <paramref name="types"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="types"/> is multidimensional.-or- <paramref name="modifiers"/> is multidimensional.-or- <paramref name="types"/> and <paramref name="modifiers"/> do not have the same length. </exception><exception cref="T:System.NotSupportedException">The current type is a <see cref="T:System.Reflection.Emit.TypeBuilder"/> or <see cref="T:System.Reflection.Emit.GenericTypeParameterBuilder"/>.</exception>
        protected ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            foreach (var method in constructors)
            {
                if ((bindingAttr & BindingFlags.NonPublic) != BindingFlags.NonPublic && !method.IsPublic)
                    continue;
                var parameters = method.GetParameters();
                if (types != null && types.Length != parameters.Length)
                    continue;
                if (types != null)
                {
                    bool isValid = true;
                    for (var i = 0; i < types.Length; i++)
                        if (types[i] != parameters[i].ParameterType)
                            isValid = false;
                    if (!isValid)
                        continue;
                }
                return method;
            }
            return null;
        }

        public Array GetEnumValues()
        {
            return Enum.GetEnumValues(this);
        }

        public Type MakeArrayType()
        {
            return MakeArrayType(1);
        }

        public Type MakeArrayType(int rank)
        {
            if (rank > 1)
                throw new InvalidOperationException("Rank must be 1");
            return _GetTypeFromTypeFunc(SpecialFunctions.MakeArrayType(___type));
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Type"/> is one of the primitive types.
        /// </summary>
        /// 
        /// <returns>
        /// true if the <see cref="T:System.Type"/> is one of the primitive types; otherwise, false.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public bool IsPrimitive
        {
            get { return isPrimitive; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Type"/> is abstract and must be overridden.
        /// </summary>
        /// 
        /// <returns>
        /// true if the <see cref="T:System.Type"/> is abstract; otherwise, false.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public bool IsAbstract
        {
            get { return isAbstract; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Type"/> is an interface; that is, not a class or a value type.
        /// </summary>
        /// 
        /// <returns>
        /// true if the <see cref="T:System.Type"/> is an interface; otherwise, false.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public bool IsInterface
        {
            get { return isInterface; }
        }

        /// <summary>
        /// Gets a value indicating whether the current type is a generic type.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current type is a generic type; otherwise, false.
        /// </returns>
        public virtual bool IsGenericType
        {
            get { return isGenericType; }
        }

        /// <summary>
        /// Returns a <see cref="T:System.Type"/> object that represents a generic type definition from which the current generic type can be constructed.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Type"/> object representing a generic type from which the current type can be constructed.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The current type is not a generic type.  That is, <see cref="P:System.Type.IsGenericType"/> returns false. </exception><exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class. Derived classes must provide an implementation.</exception><filterpriority>2</filterpriority>
        public virtual Type GetGenericTypeDefinition()
        {
            if (unconstructedType != null)
                return _GetTypeFromTypeFunc(unconstructedType);
            else
                throw new NotSupportedException("This operation is only valid on generic types");
        }

        /// <summary>
        /// Substitutes the elements of an array of types for the type parameters of the current generic type definition and returns a <see cref="T:System.Type"/> object representing the resulting constructed type.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Type"/> representing the constructed type formed by substituting the elements of <paramref name="typeArguments"/> for the type parameters of the current generic type.
        /// </returns>
        /// <param name="typeArguments">An array of types to be substituted for the type parameters of the current generic type.</param><exception cref="T:System.InvalidOperationException">The current type does not represent a generic type definition. That is, <see cref="P:System.Type.IsGenericTypeDefinition"/> returns false. </exception><exception cref="T:System.ArgumentNullException"><paramref name="typeArguments"/> is null.-or- Any element of <paramref name="typeArguments"/> is null. </exception><exception cref="T:System.ArgumentException">The number of elements in <paramref name="typeArguments"/> is not the same as the number of type parameters in the current generic type definition.-or- Any element of <paramref name="typeArguments"/> does not satisfy the constraints specified for the corresponding type parameter of the current generic type. -or- <paramref name="typeArguments"/> contains an element that is a pointer type (<see cref="P:System.Type.IsPointer"/> returns true), a by-ref type (<see cref="P:System.Type.IsByRef"/> returns true), or <see cref="T:System.Void"/>.</exception><exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class. Derived classes must provide an implementation.</exception>
        public virtual Type MakeGenericType(params Type[] typeArguments)
        {
            return _GetTypeFromTypeFunc(SpecialFunctions.MakeGenericTypeFactory(GetGenericTypeDefinition().___type, typeArguments.Select(x => x.___type).ToArray().As<JsArray>()));
        }

        /// <summary>
        /// Gets an array of the generic type arguments for this type.
        /// </summary>
        /// 
        /// <returns>
        /// An array of the generic type arguments for this type.
        /// </returns>
        public virtual Type[] GenericTypeArguments
        {
            get
            {
                if (IsGenericType && !IsGenericTypeDefinition)
                    return typeArguments.Select(x => _GetTypeFromTypeFunc(x)).ToArray();
                else
                    return Type.EmptyTypes;
            }
        }

        /// <summary>
        /// Returns an array of <see cref="T:System.Type"/> objects that represent the type arguments of a generic type or the type parameters of a generic type definition.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.Type"/> objects that represent the type arguments of a generic type. Returns an empty array if the current type is not a generic type.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class. Derived classes must provide an implementation.</exception><filterpriority>2</filterpriority>
        public virtual Type[] GetGenericArguments()
        {
            return GenericTypeArguments;
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="T:System.Type"/> represents a generic type definition, from which other generic types can be constructed.
        /// </summary>
        /// 
        /// <returns>
        /// true if the <see cref="T:System.Type"/> object represents a generic type definition; otherwise, false.
        /// </returns>
        public virtual bool IsGenericTypeDefinition
        {
            get { return isGenericTypeDefinition; }
        }
    }
}