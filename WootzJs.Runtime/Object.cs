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

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.WootzJs;

namespace System
{
	public class Object
	{
        [Js(Name = SpecialNames.TypeField, Export = false)]
        internal JsTypeFunction ___type;

	    public Object()
	    {
	    }

	    /// <summary>
		/// Retrieves the type associated with an object instance.
		/// </summary>
		/// <returns>The type of the object.</returns>
		public Type GetType()
		{
			return Type._GetTypeFromInstance(this.As<JsObject>());
		}
		/// <summary>
		/// Converts an object to its string representation.
		/// </summary>
		/// <returns>The string representation of the object.</returns>
		public virtual string ToString()
		{
			return this.As<JsObject>().toString();
		}
		/// <summary>
		/// Converts an object to its culture-sensitive string representation.
		/// </summary>
		/// <returns>The culture-sensitive string representation of the object.</returns>
		public virtual string ToLocaleString()
		{
			return null;
		}

        public virtual bool Equals(object obj)
        {
            return this == obj;
        }

        public virtual int GetHashCode()
        {
            return GetStringHashCode().GetHashCode();
        }

        /// <summary>
        /// This is the more important hash function in Javascript, since we use Javascript objects with strings as keys as the base for 
        /// dictoinary data structures.
        /// </summary>
        /// <returns></returns>
        public virtual string GetStringHashCode()
        {
            return this.As<JsObject>().toString();
        }

        /// <summary>
        /// All == comparisons are reference comparisons in Javascript, so this method is implemented just that way.  The compiler will unwrap
        /// this method so that o1 is compared to o2 as an == comparison.  However, this method still serves its original function -- if you 
        /// want to bypass == overloading, this is the way to go.
        /// </summary>
        /// <param name="o1">The left side of the comparison</param>
        /// <param name="o2">The right side of the comparison</param>
        /// <returns>True if o1 is literally the same object as o2.</returns>
        public static bool ReferenceEquals(object o1, object o2)
        {
            return true;
        }

        public Type MakeArrayType()
        {
            return MakeArrayType(1);
        }

        public Type MakeArrayType(int rank)
        {
            if (rank > 1)
                throw new InvalidOperationException("Rank must be 1");
            return Type._GetTypeFromTypeFunc(MakeArrayType(___type));
        }

        [Js(Name = "$$MakeArrayType")]
        internal static JsTypeFunction MakeArrayType(JsTypeFunction elementType)
        {
            if (elementType.ArrayType == null)
            {
                var arrayType = Jsni.procedure(() => {}).As<JsTypeFunction>();
                arrayType.prototype = new JsArray();
                Jsni.apply(
                    Jsni.type<Object>().TypeInitializer, 
                    Jsni.@this(), 
                    Jsni.array(arrayType, arrayType.prototype));
                Jsni.apply(
                    Jsni.type<Array>().TypeInitializer, 
                    Jsni.@this(), 
                    Jsni.invoke(
                        Jsni.member(Jsni.array(arrayType, arrayType.prototype), "concat"), 
                        elementType
                    ).As<JsArray>());
                arrayType.TypeInitializer = Jsni.procedure((t, p) =>
                {
                    p.___type = arrayType;
                    t.As<JsTypeFunction>().BaseType = Jsni.type<Array>();
                    t.As<JsTypeFunction>().GetTypeFromType = Jsni.function(() => Type._GetTypeFromTypeFunc(Jsni.@this().As<JsTypeFunction>()).As<JsObject>());
                    t.As<JsTypeFunction>().CreateTypeField = Jsni.function(() =>
                    {
                        var lastIndex = elementType.TypeName.LastIndexOf('.');
                        if (lastIndex == -1)
                            lastIndex = 0;
                        else
                            lastIndex++;
                        var type = new Type(elementType.TypeName.Substring(lastIndex) + "[]", new Attribute[0]);
                        arrayType.Type = type;
                        type.Init(
                            elementType.TypeName + "[]", 
                            elementType, 
                            Jsni.type<Array>(), 
                            typeof(Array).interfaces.Concat(new[] { MakeGenericTypeFactory(Jsni.type(typeof(IEnumerable<>)), Jsni.array(elementType)) }).ToArray(), 
                            new FieldInfo[0], 
                            new MethodInfo[0], 
                            new ConstructorInfo[0], 
                            new PropertyInfo[0], 
                            new EventInfo[0], 
                            false, 
                            elementType);
                        return type.As<JsObject>();
                    });
                }, "$t", "$p");
                Jsni.call(arrayType.TypeInitializer, Jsni.@this(), arrayType, arrayType.prototype);
                var result = arrayType;
                elementType.ArrayType = result;
            }
            return elementType.ArrayType;
        }

        [Js(Name="$$InitializeArray")]
        internal static JsArray InitializeArray(JsArray array, JsTypeFunction elementType)
        {
            var arrayType = MakeArrayType(elementType);
            foreach (var property in Jsni.member(arrayType, "prototype"))
            {
                array[property] = Jsni.member(arrayType, "prototype")[property];
            }
            Jsni.invoke(Jsni.member(Jsni.member(Jsni.member(arrayType, "prototype"), "$ctor"), "call"), array);

/*
            Jsni.apply(
                Jsni.type<Object>().TypeInitializer, 
                Jsni.@this(), 
                Jsni.array(arrayType, array)).As<JsArray>();
            Jsni.apply(
                Jsni.type<Array>().TypeInitializer, 
                Jsni.@this(), 
                Jsni.array(arrayType, array)).As<JsArray>();
            Jsni.apply(
                arrayType.TypeInitializer, 
                Jsni.@this(), 
                Jsni.array(arrayType, array)).As<JsArray>();
*/
            return array;
        }

        [Js(Name = SpecialNames.MakeGenericTypeConstructor)]
        internal static JsTypeFunction MakeGenericTypeFactory(JsTypeFunction unconstructedType, JsArray typeArgs)
        {
//            if (typeArgs.length > 0 && typeArgs[0] == null)
//                return unconstructedType;

            var cache = Jsni.member(unconstructedType, "$typecache");
            if (cache == null)
            {
                cache = new JsObject();
                Jsni.memberset(unconstructedType, "$typecache", cache);
            }
            // Array.prototype.slice.call(typeArgs, 0))
            var keyArray = Jsni.call<JsArray>(x => x.slice(0), typeArgs, 0.As<JsNumber>()).As<JsArray>();
            var keyParts = new JsArray();
            for (var i = 0; i < keyArray.length; i++)
            {
                keyParts[i] = Jsni.member(Jsni.member(keyArray[i], "prototype"), SpecialNames.TypeName);
            }
            var keyString = keyParts.join();
            var result = cache[keyString];
            if (result == null)
            {
                var generic = Jsni.procedure(constructor =>
                {
                    if (constructor != null) 
                        Jsni.apply(constructor, Jsni.@this(), Jsni.call<JsArray>(x => x.slice(0), Jsni.arguments(), 1.As<JsNumber>()).As<JsArray>());
                }).As<JsTypeFunction>();
                generic.prototype = Jsni.@new(unconstructedType);

                // unconstructedType.$TypeInitializer.apply(this, [generic, generic.prototype].concat(Array.prototype.slice.call(arguments, 0)));
                Jsni.apply(
                    Jsni.member(unconstructedType, SpecialNames.TypeInitializer), 
                    Jsni.@this(), 
                    Jsni.invoke(
                        Jsni.member(Jsni.array(generic, generic.prototype), "concat"), 
                        keyArray
                    ).As<JsArray>());

                generic.TypeInitializer = Jsni.procedure((t, p) =>
                {
                    p.___type = generic;
                    t.As<JsTypeFunction>().BaseType = unconstructedType;
                    t.As<JsTypeFunction>().GetTypeFromType = Jsni.function(() => Type._GetTypeFromTypeFunc(Jsni.@this().As<JsTypeFunction>()).As<JsObject>());
                }, "$t", "$p");
                Jsni.call(generic.TypeInitializer, Jsni.@this(), generic, generic.prototype);
                result = generic;
                cache[keyString] = result;
            }

            return result.As<JsTypeFunction>();
        }
	}
}
