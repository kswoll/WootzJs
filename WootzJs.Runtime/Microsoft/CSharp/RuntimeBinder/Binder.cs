using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.WootzJs;

// ReSharper disable once CheckNamespace
namespace Microsoft.CSharp.RuntimeBinder
{
    [Js(Export = false)]
    public static class Binder
    {
        public static CallSiteBinder InvokeMember(CSharpBinderFlags flags, string name, IEnumerable<Type> typeArguments, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
        {
            return null;
        }

        public static CallSiteBinder InvokeConstructor(CSharpBinderFlags flags, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
        {
            return null;
        }

        public static CallSiteBinder Invoke(CSharpBinderFlags flags, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
        {
            return null;
        }

        public static CallSiteBinder Convert(CSharpBinderFlags flags, Type type, Type context)
        {
            return null;
        }

        public static CallSiteBinder GetMember(CSharpBinderFlags flags, string name, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
        {
            return null;
        }

        public static CallSiteBinder SetMember(CSharpBinderFlags flags, string name, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
        {
            return null;
        }

        public static CallSiteBinder BinaryOperation(CSharpBinderFlags flags, ExpressionType operation, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
        {
            return null;
        }

        public static CallSiteBinder UnaryOperation(CSharpBinderFlags flags, ExpressionType operation, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
        {
            return null;
        }

        public static CallSiteBinder GetIndex(CSharpBinderFlags flags, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
        {
            return null;
        }

        public static CallSiteBinder SetIndex(CSharpBinderFlags flags, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
        {
            return null;
        }

        public static CallSiteBinder IsEvent(CSharpBinderFlags flags, string name, Type context)
        {
            return null;
        }

    }
}
