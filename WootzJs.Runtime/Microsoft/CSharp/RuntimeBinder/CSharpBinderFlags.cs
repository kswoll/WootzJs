using System;
using System.Runtime.WootzJs;

// ReSharper disable once CheckNamespace
namespace Microsoft.CSharp.RuntimeBinder
{
    [Flags]
    [Js(Export = false)]
    public enum CSharpBinderFlags
    {
        None = 0,
        CheckedContext = 1,
        InvokeSimpleName = 2,
        InvokeSpecialName = 4,
        BinaryOperationLogical = 8,
        ConvertExplicit = 16,
        ConvertArrayIndex = 32,
        ResultIndexed = 64,
        ValueFromCompoundAssignment = 128,
        ResultDiscarded = 256,
    }
}
