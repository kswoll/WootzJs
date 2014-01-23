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
        public static JsFunction Define(string name)
        {
            JsTypeFunction typeFunction = null;
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
            return typeFunction;
        }

        [Js(Name = "$cast")]
        public static T ObjectCast<T>(object o)
        {
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
            Jsni.invoke(Jsni.member(Jsni.member(Jsni.type<MulticastDelegate>().prototype, "$ctor"), "call"), delegateFunc, thisExpression, Jsni.array(delegateFunc));
            return delegateFunc;
        }
    }
}