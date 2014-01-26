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
        public static JsFunction Define(string name, JsTypeFunction prototype)
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
    }
}
