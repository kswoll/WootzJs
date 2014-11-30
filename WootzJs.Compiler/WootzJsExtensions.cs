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
using Microsoft.CodeAnalysis;

namespace WootzJs.Compiler
{
    public static class WootzJsExtensions
    {
        public static string GetName(this ISymbol symbol)
        {
            var result = symbol.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name");
            return result ?? symbol.Name;
        }

        public static string GetCode(this ISymbol symbol)
        {
            return symbol.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Code");
        }

        public static string GetInline(this ISymbol symbol)
        {
            return symbol.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Inline");
        }

        public static bool IsExported(this ISymbol symbol)
        {
            if (symbol.IsExtern)
                return false;

            var result = symbol.GetAttributeValue(Context.Instance.JsAttributeType, "Export", true);
            if (!(symbol is ITypeSymbol))
                result = result && symbol.ContainingType.IsExported();
            return result;
        }

        public static bool IsReflectionMinimized(this IAssemblySymbol assembly)
        {
            return assembly.GetAttributeValue(Context.Instance.JsCompilerOptionsAttribute, "IsReflectionMinimized", false);
        }

        public static bool IsCultureInfoExportDisabled(this IAssemblySymbol assembly)
        {
            return assembly.GetAttributeValue(Context.Instance.JsCompilerOptionsAttribute, "IsCultureInfoExportDisabled", false);
        }

        public static bool AreAutoPropertiesMinimized(this IAssemblySymbol assembly)
        {
            return assembly.GetAttributeValue(Context.Instance.JsCompilerOptionsAttribute, "AreAutoPropertiesMinimized", false);
        }

        public static bool AreDelegatesMinimized(this IAssemblySymbol assembly)
        {
            return assembly.GetAttributeValue(Context.Instance.JsCompilerOptionsAttribute, "AreDelegatesMinimized", false);
        }

        public static bool AreAutoPropertiesMinimized(this IPropertySymbol property)
        {
            return property.GetAttributeValue(Context.Instance.JsAttributeType, "AreAutoPropertiesMinimized", false) ||
                property.ContainingType.GetAttributeValue(Context.Instance.JsAttributeType, "AreAutoPropertiesMinimized", false);
        }

        public static bool IsBuiltIn(this ISymbol symbol)
        {
            return symbol.GetAttributeValue(Context.Instance.JsAttributeType, "BuiltIn", false);
        }

        public static string[] GetExtraBuiltInExports(this ISymbol symbol)
        {
            return symbol.GetAttributeValue<string[]>(Context.Instance.JsAttributeType, "ExtraBuiltInExports", null);
        }

        public static bool IsExtension(this ISymbol symbol)
        {
            return symbol.GetAttributeValue(Context.Instance.JsAttributeType, "Extension", false);
        }

        public static bool IsAutoNotifyPropertyChange(this ISymbol symbol, out IMethodSymbol method)
        {
            var classType = symbol is INamedTypeSymbol ? (INamedTypeSymbol)symbol : symbol.ContainingType;

            // If the type is INotifyPropertyChanged and it duck types to NotifyPropertyChanged
            var isNotifyPropertyChanged = classType.Interfaces.Any(x => Context.Instance.INotifyPropertyChanged.IsAssignableFrom(x));
            var isDuckTypedToNotifyPropertyChanged = classType.TryGetMethod("NotifyPropertyChanged", out method, Context.Instance.String);
            return isNotifyPropertyChanged && isDuckTypedToNotifyPropertyChanged;
        }
    }
}
