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
using Roslyn.Compilers.CSharp;
using Roslyn.Services;

namespace WootzJs.Compiler
{
    public static class JsNames
    {
        internal static Context context;

        public static string GetShortTypeName(this TypeSymbol type)
        {
            var nameOverride = type.GetAttributeValue<string>(context.JsAttributeType, "Name");
            if (nameOverride != null) 
                return nameOverride;

            if (type.IsAnonymousType)
                return type.GetTypeName();

            // @todo refactor so the two typename methods share most of the code
            if (type is NamedTypeSymbol)
            {
                return type.MetadataName.Replace('`', '$');
            }
            else if (type is ArrayTypeSymbol)
            {
                var arrayType = (ArrayTypeSymbol)type;
                return arrayType.ElementType.Name + "$1";
            }
            else if (type is TypeParameterSymbol)
            {
                var typeParameter = (TypeParameterSymbol)type;
                return typeParameter.Name;
            }
            else
            {
                throw new Exception();
            }            
        }

        private static int anonymousTypeNameCounter = 1;
        private static Dictionary<TypeSymbol, string> anonymousTypeNames = new Dictionary<TypeSymbol, string>();

        public static string GetTypeName(this TypeSymbol type)
        {
            var nameOverride = type.GetAttributeValue<string>(context.JsAttributeType, "Name");
            if (nameOverride != null) 
                return nameOverride;

            if (type.IsAnonymousType)
            {
                string name;
                if (!anonymousTypeNames.TryGetValue(type, out name))
                {
                    name = "$AnonymousType$" + anonymousTypeNameCounter++;
                    anonymousTypeNames[type] = name;
                }
                return name;
            }

            var namedTypeSymbol = type as NamedTypeSymbol;
            if (namedTypeSymbol != null)
            {
                var result = GetTypeName(type.GetFullName()).Replace('`', '$');
                return result;
            }
            else if (type is ArrayTypeSymbol)
            {
                var arrayType = (ArrayTypeSymbol)type;
                return GetTypeName(arrayType.ElementType) + "$1";
            }
            else if (type is TypeParameterSymbol)
            {
                var typeParameter = (TypeParameterSymbol)type;
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

        public static string GetDefaultConstructorName(this NamedTypeSymbol type)
        {
            return type.InstanceConstructors.Single(x => x.Parameters.Count == 0).GetMemberName();
        }

        public static string MaskSpecialCharacters(this string s)
        {
            return s.Replace('.', '$').Replace('<', '$').Replace('>', '$').Replace(',', '$');
        }

        public static string GetMemberName(this MethodSymbol method)
        {
            var nameOverride = method.GetAttributeValue<string>(context.JsAttributeType, "Name");
            if (nameOverride != null) 
                return nameOverride;
            if (method.IsExtern)
                return method.Name;

            if (method.ReducedFrom != null)
                method = method.ReducedFrom;
            if (method.ConstructedFrom != method)
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
                    .OfType<MethodSymbol>()
                    // De-dup overrides from overloads, since we only want one name for a given override chain.
                    .Where(x => x.OverriddenMethod == null).ToList();

            if (overloads.Count == 1 || (method.MethodKind == MethodKind.Constructor && method.Parameters.Count == 0))
            {
                return baseMethodName;
            }
            else
            {
                // Sort overloads based on a constant algorithm where overloads from base types 
                overloads.Sort((x, y) =>
                {
                    if (x.ContainingType.IsSubclassOf(y.ContainingType))
                        return 1;
                    else if (y.ContainingType.IsSubclassOf(x.ContainingType))
                        return -1;
                    else
                    {
                        var xMethod = x;
                        var yMethod = y;
                        if (xMethod.TypeParameters.Count > yMethod.TypeParameters.Count)
                            return 1;
                        else if (xMethod.TypeParameters.Count < yMethod.TypeParameters.Count)
                            return -1;
                        else
                        {
                            if (xMethod.Parameters.Count > yMethod.Parameters.Count)
                                return 1;
                            else if (xMethod.Parameters.Count < yMethod.Parameters.Count)
                                return -1;
                            else
                            {
                                if (xMethod.ExplicitInterfaceImplementations.Count > yMethod.ExplicitInterfaceImplementations.Count) 
                                    return 1;
                                else if (xMethod.ExplicitInterfaceImplementations.Count < yMethod.ExplicitInterfaceImplementations.Count)
                                    return -1;
                                else
                                {
                                    for (var i = 0; i < xMethod.Parameters.Count; i++)
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

        public static string GetMemberName(this PropertySymbol symbol)
        {
            var nameOverride = symbol.GetAttributeValue<string>(context.JsAttributeType, "Name");
            if (nameOverride != null) 
                return nameOverride;

            var baseMethodName = symbol.Name.MaskSpecialCharacters();
            if (baseMethodName == "this[]")
                baseMethodName = "Item";

/*
            var overloads = symbol.ContainingType
                .GetAllMembers()
                .Where(x => x.Name == symbol.Name)
                .OfType<PropertySymbol>()
                // De-dup overrides from overloads, since we only want one name for a given override chain.
                .Where(x => x.OverriddenProperty == null)
                .Select(x => new { Property = x, Interfaces = x.FindImplementedInterfaceMembers(context.Solution).ToList() })
                .ToList();
*/

//            if (overloads.Count == 1)
            {
                return baseMethodName;
            }
/*
            else
            {
                // Sort overloads based on a constant algorithm where overloads from base types 
                overloads.Sort((x, y) =>
                {
                    if (x.Property.ContainingType.IsSubclass(y.Property.ContainingType))
                        return 1;
                    else if (y.Property.ContainingType.IsSubclass(x.Property.ContainingType))
                        return -1;
                    else
                    {
                        var xMethod = x;
                        var yMethod = y;
                        if (xMethod.Property.Parameters.Count > yMethod.Property.Parameters.Count)
                            return 1;
                        else if (xMethod.Property.Parameters.Count < yMethod.Property.Parameters.Count)
                            return -1;
                        else
                        {
                            if (xMethod.Interfaces.Count > yMethod.Interfaces.Count) 
                                return 1;
                            else if (xMethod.Interfaces.Count < yMethod.Interfaces.Count)
                                return -1;
                            else
                            {
                                for (var i = 0; i < xMethod.Property.Parameters.Count; i++)
                                {
                                    var xParameter = xMethod.Property.Parameters[i];
                                    var yParameter = yMethod.Property.Parameters[i];
                                    var result = string.Compare(xParameter.Type.ToString(), yParameter.Type.ToString(), StringComparison.Ordinal);
                                    if (result != 0)
                                        return result;
                                }                                            
                            }
                        }
                        return string.Compare(x.Property.ContainingType.ToString(), y.Property.ContainingType.ToString(), StringComparison.Ordinal);
                    }
                });
                var overloadSymbols = overloads.Select(x => x.Property).ToList();
                var indexOf = overloadSymbols.IndexOf(symbol.GetRootOverride());
                if (indexOf == 0)
                    return baseMethodName;          // If a type starts out with only one method, it will not have any $ suffix.  That means the first instance of an overload/override will always be naked.
                else
                    return baseMethodName + "$" + indexOf;
            }
*/
        }

        public static string GetMemberName(this FieldSymbol symbol)
        {
            var nameOverride = symbol.GetAttributeValue<string>(context.JsAttributeType, "Name");
            if (nameOverride != null) 
                return nameOverride;
            return GetDefaultMemberName(symbol);
        }

        public static string GetMemberName(this EventSymbol symbol)
        {
            var nameOverride = symbol.GetAttributeValue<string>(context.JsAttributeType, "Name");
            if (nameOverride != null) 
                return nameOverride;
            return GetDefaultMemberName(symbol);
        }

        private static string GetDefaultMemberName(Symbol symbol)
        {
            var overloads = symbol.ContainingType.GetAllMembers(symbol.Name).ToList();
            if (overloads.Count == 1)
            {
                return symbol.Name.MaskSpecialCharacters();
            }
            else
            {
                // Sort overloads based on a constant algorithm where overloads from base types 
                overloads.Sort((x, y) =>
                {
                    if (x.ContainingType.IsSubclassOf(y.ContainingType))
                        return 1;
                    else if (y.ContainingType.IsSubclassOf(x.ContainingType))
                        return -1;
                    else
                        return string.Compare(x.ContainingType.ToString(), y.ContainingType.ToString(), StringComparison.Ordinal);
                });
                var indexOf = overloads.IndexOf(symbol);
                if (indexOf == 0)
                    return symbol.Name;          // If a type starts out with only one method, it will not have any $ suffix.  That means the first instance of an overload/override will always be naked.
                else
                    return symbol.Name + "$" + indexOf;
            }            
        }

        public static string GetBackingFieldName(this EventSymbol eventSymbol)
        {
            return "$" + eventSymbol.GetMemberName() + "$k__BackingField";
        }

        public static string GetBackingFieldName(this PropertySymbol eventSymbol)
        {
            return "$" + eventSymbol.GetMemberName() + "$k__BackingField";
        }

        public static string GetAssemblyMethodName(this AssemblySymbol assembly)
        {
            return "window.$" + assembly.Name.MaskSpecialCharacters() + "$GetAssembly";
        }

        public static string GetAssemblyTypesArray(this AssemblySymbol assembly)
        {
            return "$" + assembly.Name.MaskSpecialCharacters() + "$AssemblyTypes";
        }
    }
}
