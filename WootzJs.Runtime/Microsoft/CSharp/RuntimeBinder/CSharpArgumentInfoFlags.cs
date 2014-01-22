using System;
using System.Runtime.WootzJs;

// ReSharper disable once CheckNamespace


namespace Microsoft.CSharp.RuntimeBinder
{
    [Flags]
    [Js(Export = false)]
    public enum CSharpArgumentInfoFlags
    {
        None = 0,
        UseCompileTimeType = 1,
        Constant = 2,
        NamedArgument = 4,
        IsRef = 8,
        IsOut = 16,
        IsStaticType = 32,
    }
}
