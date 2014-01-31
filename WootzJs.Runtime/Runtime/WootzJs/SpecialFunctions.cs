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
using System.Linq;
using System.Reflection;

namespace System.Runtime.WootzJs
{
    /// <summary>
    /// This is a special class handled by the compiler such that each method is declared as
    /// a global function.
    /// </summary>
    public static class SpecialFunctions
    {
        [Js(Name = "$define")]
        public static JsTypeFunction Define(string name, JsTypeFunction prototype)
        {
            JsTypeFunction typeFunction = null;

            // Create constructor function, which is a superconstructor that takes in the actual
            // constructor as the first argument, and the rest of the arguments are passed directly 
            // to that constructor.  These subconstructors are not Javascript constructors -- they 
            // are not called via new, they exist for initialization only.
            typeFunction = Jsni.function(constructor =>
            {
                if (!Jsni.member(typeFunction, "$isStaticInitialized").As<bool>() && 
                    (constructor != null || !(Jsni.instanceof(Jsni.@this(), typeFunction))))
                {
                    Jsni.memberset(typeFunction, "$isStaticInitialized", true.As<JsObject>());
                    Jsni.invoke(Jsni.member(typeFunction, "$StaticInitializer"));
                }
                if (constructor != null) 
                    Jsni.apply(constructor, Jsni.@this(), Jsni.call(Jsni.reference("Array.prototype.slice"), Jsni.arguments(), 1.As<JsObject>()).As<JsArray>());
                if (!Jsni.instanceof(Jsni.@this(), typeFunction))
                    return typeFunction;
                else
                    return Jsni.@this();
            }).As<JsTypeFunction>();
            Jsni.memberset(typeFunction, "toString", Jsni.function(() => name.As<JsObject>()));
            Jsni.memberset(typeFunction, SpecialNames.TypeName, name.As<JsString>());
            Jsni.memberset(typeFunction, "prototype", Jsni.@new(prototype));
            return typeFunction;
        }

        [Js(Name = "$cast")]
        public static T ObjectCast<T>(object o)
        {
            if (o == null)
                return default(T);

            var type = o.GetType();
            if (!typeof(T).IsAssignableFrom(type))
                throw new InvalidCastException("Cannot cast object of type " + o.GetType().FullName + " to type " + typeof(T).FullName);

            return o.As<T>();
        }

        [Js(Name = "$delegate")]
        public static JsFunction CreateDelegate(JsObject thisExpression, JsTypeFunction delegateType, JsFunction lambda)
        {
            JsFunction delegateFunc = null;
            delegateFunc = Jsni.function(() =>
            {
                return lambda.apply(delegateFunc.As<Delegate>().Target.As<JsObject>(), Jsni.arguments().As<JsArray>());
            });
            delegateFunc.prototype = Jsni.@new(delegateType);
            Jsni.type<object>().TypeInitializer.invoke(delegateFunc, delegateFunc);
            Jsni.type<Delegate>().TypeInitializer.invoke(delegateFunc, delegateFunc);
            Jsni.type<MulticastDelegate>().TypeInitializer.invoke(delegateFunc, delegateFunc);
            delegateType.TypeInitializer.invoke(delegateFunc, delegateFunc);
            Jsni.invoke(Jsni.member(Jsni.member(Jsni.type<MulticastDelegate>().prototype, "$ctor"), "call"), delegateFunc, thisExpression, new[] { delegateFunc }.As<JsArray>());
            Jsni.memberset(delegateFunc, SpecialNames.TypeField, delegateType);
            return delegateFunc;
        }

        [Js(Name=SpecialNames.InitializeArray)]
        internal static JsArray InitializeArray(JsArray array, JsTypeFunction elementType)
        {
            var arrayType = MakeArrayType(elementType);
            foreach (var property in arrayType.member("prototype"))
            {
                array[property] = arrayType.member("prototype")[property];
            }

            arrayType.member("prototype").member("$ctor").member("call").invoke(array);

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
            var keyString = keyParts.join(", ");
            var result = cache[keyString];
            if (result == null)
            {
                var lastIndexOfDollar = unconstructedType.TypeName.LastIndexOf('$');
                var newTypeName = unconstructedType.TypeName.Substring(0, lastIndexOfDollar) + "<" + keyString + ">";
                var generic = SpecialFunctions.Define(newTypeName, unconstructedType);

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


        [Js(Name = SpecialNames.MakeArrayType)]
        internal static JsTypeFunction MakeArrayType(JsTypeFunction elementType)
        {
            if (elementType.ArrayType == null)
            {
                var baseType = SpecialFunctions.MakeGenericTypeFactory(Jsni.type(typeof(GenericArray<>)), Jsni.array(elementType));
                var arrayType = Jsni.procedure(() => {}).As<JsTypeFunction>();
                arrayType.prototype = Jsni.@new(baseType);
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
                    t.As<JsTypeFunction>().TypeName = elementType.TypeName + "[]";
                    t.As<JsTypeFunction>().BaseType = baseType;
                    t.As<JsTypeFunction>().ElementType = elementType;
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
                            typeof(Array).interfaces.Concat(new[] { SpecialFunctions.MakeGenericTypeFactory(Jsni.type(typeof(IEnumerable<>)), Jsni.array(elementType)) }).ToArray(), 
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

        [Js(Name = SpecialNames.SafeToString)]
        public static string SafeToString(object o)
        {
            return o == null ? "" : o.ToString();
        }
    }
}
