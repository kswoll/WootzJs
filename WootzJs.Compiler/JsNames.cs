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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.WootzJs;
using Microsoft.CodeAnalysis;

namespace WootzJs.Compiler
{
    public static class JsNames
    {
        public static string GetMemberName(this ISymbol symbol)
        {
            if (symbol is IMethodSymbol)
                return ((IMethodSymbol)symbol).GetMemberName();
            else if (symbol is IFieldSymbol)
                return ((IFieldSymbol)symbol).GetMemberName();
            else if (symbol is IPropertySymbol)
                return ((IPropertySymbol)symbol).GetMemberName();
            else if (symbol is IEventSymbol)
                return ((IEventSymbol)symbol).GetMemberName();
            else
                throw new Exception();
        }

        public static string GetShortTypeName(this ITypeSymbol type)
        {
            var nameOverride = type.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name");
            if (nameOverride != null) 
                return nameOverride;

            if (type.IsAnonymousType)
                return type.GetTypeName();

            // @todo refactor so the two typename methods share most of the code
            if (type is INamedTypeSymbol)
            {
                return type.MetadataName.Replace('`', '$');
            }
            else if (type is IArrayTypeSymbol)
            {
                var arrayType = (IArrayTypeSymbol)type;
                return arrayType.ElementType.Name + "$1";
            }
            else if (type is ITypeParameterSymbol)
            {
                var typeParameter = (ITypeParameterSymbol)type;
                return typeParameter.Name;
            }
            else
            {
                throw new Exception();
            }            
        }

        private static int anonymousTypeNameCounter = 1;
        private static Dictionary<ITypeSymbol, string> anonymousTypeNames = new Dictionary<ITypeSymbol, string>();

        public static string GetTypeName(this ITypeSymbol type)
        {
            var nameOverride = type.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name");
            if (nameOverride != null) 
                return nameOverride;

            if (type.IsAnonymousType)
            {
                string name;
                if (!anonymousTypeNames.TryGetValue(type, out name))
                {
                    var index = anonymousTypeNameCounter++;
                    name = type.ContainingAssembly.GetAssemblyAnonymousTypesArray() + "[" + index + "]";
                    anonymousTypeNames[type] = name;
                }
                return name;
            }

            var namedTypeSymbol = type as INamedTypeSymbol;
            if (namedTypeSymbol != null)
            {
                var result = GetTypeName(type.GetFullName()).Replace('`', '$');
                return result;
            }
            else if (type is IArrayTypeSymbol)
            {
                var arrayType = (IArrayTypeSymbol)type;
                return GetTypeName(arrayType.ElementType) + "$1";
            }
            else if (type is ITypeParameterSymbol)
            {
                var typeParameter = (ITypeParameterSymbol)type;
                return typeParameter.Name;
            }
            else
            {
                throw new Exception();
            }
        } 

        public static string GetTypeName(string typeName)
        {
            return typeName;//typeName.Replace(".", "$");
        }

        public static string GetDefaultConstructorName(this INamedTypeSymbol type)
        {
            return type.InstanceConstructors.Single(x => x.Parameters.Count() == 0).GetMemberName();
        }

        public static string MaskSpecialCharacters(this string s)
        {
            return s.Replace('.', '$').Replace('<', '$').Replace('>', '$').Replace(',', '$');
        }

        public static string GetMemberName(this IMethodSymbol method)
        {
            var nameOverride = method.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name");
            if (nameOverride != null) 
                return nameOverride;

            if (method.ReducedFrom != null)
                method = method.ReducedFrom;
            if (!Equals(method.ConstructedFrom, method))
                method = method.ConstructedFrom;

            var baseMethodName = method.MethodKind == MethodKind.Constructor ? "$ctor" : method.Name.Replace('.', '$');

            if (method.ContainingType.TypeKind == TypeKind.Interface)
            {
                baseMethodName = method.ContainingType.GetTypeName().MaskSpecialCharacters() + "$" + baseMethodName;
            }

            baseMethodName = baseMethodName.MaskSpecialCharacters();

            var overloads = method.MethodKind == MethodKind.Constructor ? 
                method.ContainingType.InstanceConstructors.ToList() :
                method.ContainingType
                    .GetAllMembers(method.Name)
                    .OfType<IMethodSymbol>()
                    // De-dup overrides from overloads, since we only want one name for a given override chain.
                    .Where(x => x.OverriddenMethod == null).ToList();

            if (overloads.Count == 1 || (method.MethodKind == MethodKind.Constructor && !method.Parameters.Any()))
            {
                return baseMethodName;
            }
            else
            {
                // Sort overloads based on a constant algorithm where overloads from base types 
                overloads.Sort((x, y) =>
                {
                    var xIsExported = x.DeclaredAccessibility == Accessibility.Protected || x.DeclaredAccessibility == Accessibility.ProtectedAndInternal || x.DeclaredAccessibility == Accessibility.ProtectedOrInternal || x.DeclaredAccessibility == Accessibility.Public;
                    var yIsExported = y.DeclaredAccessibility == Accessibility.Protected || y.DeclaredAccessibility == Accessibility.ProtectedAndInternal || y.DeclaredAccessibility == Accessibility.ProtectedOrInternal || y.DeclaredAccessibility == Accessibility.Public;
                    if (xIsExported != yIsExported)
                        return xIsExported ? -1 : 1;
                    else if (x.ContainingType.IsSubclassOf(y.ContainingType))
                        return 1;
                    else if (y.ContainingType.IsSubclassOf(x.ContainingType))
                        return -1;
                    else
                    {
                        var xMethod = x;
                        var yMethod = y;
                        if (xMethod.TypeParameters.Count() > yMethod.TypeParameters.Count())
                            return 1;
                        else if (xMethod.TypeParameters.Count() < yMethod.TypeParameters.Count())
                            return -1;
                        else
                        {
                            if (xMethod.Parameters.Count() > yMethod.Parameters.Count())
                                return 1;
                            else if (xMethod.Parameters.Count() < yMethod.Parameters.Count())
                                return -1;
                            else
                            {
                                if (xMethod.ExplicitInterfaceImplementations.Count() > yMethod.ExplicitInterfaceImplementations.Count()) 
                                    return 1;
                                else if (xMethod.ExplicitInterfaceImplementations.Count() < yMethod.ExplicitInterfaceImplementations.Count())
                                    return -1;
                                else
                                {
                                    for (var i = 0; i < xMethod.Parameters.Count(); i++)
                                    {
                                        var xParameter = xMethod.Parameters[i];
                                        var yParameter = yMethod.Parameters[i];
                                        var result = string.Compare(xParameter.Type.ToString(), yParameter.Type.ToString(), StringComparison.Ordinal);
                                        if (result != 0)
                                            return result;
                                    }                                            
                                }
                            }
                        }
                        return string.Compare(x.ContainingType.ToString(), y.ContainingType.ToString(), StringComparison.Ordinal);
                    }
                });
                var indexOf = overloads.IndexOf(method.GetRootOverride());
                if (indexOf == -1)
                    throw new Exception();
                if (indexOf == 0)
                    return baseMethodName;          // If a type starts out with only one method, it will not have any $ suffix.  That means the first instance of an overload/override will always be naked.
                else
                    return baseMethodName + "$" + indexOf;
            }
        }

        public static string GetMemberName(this IPropertySymbol symbol)
        {
            var nameOverride = symbol.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name");
            if (nameOverride != null) 
                return nameOverride;

            var baseMethodName = symbol.Name.MaskSpecialCharacters();
            if (baseMethodName == "this[]")
                return "Item";

            return EscapeIfReservedWord(GetDefaultMemberName(symbol));
        }

        public static string GetMemberName(this IFieldSymbol symbol)
        {
            var nameOverride = symbol.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name");
            if (nameOverride != null) 
                return EscapeIfReservedWord(nameOverride);
            return EscapeIfReservedWord(GetDefaultMemberName(symbol));
        }

        public static string GetMemberName(this IEventSymbol symbol)
        {
            var nameOverride = symbol.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name");
            if (nameOverride != null) 
                return nameOverride;
            return GetDefaultMemberName(symbol);
        }

        private static string GetDefaultMemberName(ISymbol symbol)
        {
            var baseCount = symbol.ContainingType.GetBaseMemberNameCount(symbol.Name);
            if (baseCount == 0)
                return symbol.Name;
            else
                return symbol.Name + "$" + (baseCount + 1);
        }

        public static string GetBackingFieldName(this IEventSymbol eventSymbol)
        {
            return "$" + eventSymbol.GetMemberName() + "$k__BackingField";
        }

        public static string GetBackingFieldName(this IPropertySymbol propertySymbol)
        {
            return "$" + propertySymbol.GetMemberName() + "$k__BackingField";
        }

        public static string GetAssemblyMethodName(this IAssemblySymbol assembly)
        {
            return "window.$" + assembly.Name.MaskSpecialCharacters() + "$GetAssembly";
        }

        public static string GetAssemblyTypesArray(this IAssemblySymbol assembly)
        {
            return "$" + assembly.Name.MaskSpecialCharacters() + SpecialNames.AssemblyTypesArray;
        }

        public static string GetAssemblyAnonymousTypesArray(this IAssemblySymbol assembly)
        {
            return "$" + assembly.Name.MaskSpecialCharacters() + "$AnonymousTypes";
        }

        private static HashSet<string> javascriptReservedWords = new HashSet<string>(new[]
        {
            "break", "default", "function", "return", "var", "case", "delete", "if", "switch",
            "void", "catch", "do", "in", "this", "while", "const", "else", "instanceof",
            "throw", "with", "continue", "finally", "let", "try", "debugger", "for", "new",
            "typeof"
        });

        public static bool IsJavascriptReservedWord(string s)
        {
            return javascriptReservedWords.Contains(s);
        }

        public static string EscapeIfReservedWord(string s)
        {
            if (s.StartsWith("@"))
                s = s.Substring(1);
            if (IsJavascriptReservedWord(s))
                return "$" + s;
            else
                return s;
        }
    }
}
