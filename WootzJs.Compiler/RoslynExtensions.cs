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
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TypeInfo = Microsoft.CodeAnalysis.TypeInfo;

namespace WootzJs.Compiler
{
    public static class RoslynExtensions
    {
        public static string GetFullName(this TypeInfo typeInfo)
        {
            return typeInfo.ConvertedType.GetFullName();
        }

        public static string GetFullName(this INamespaceSymbol namespaceSymbol)
        {
            string result = namespaceSymbol.MetadataName;
            if (!namespaceSymbol.IsGlobalNamespace && !namespaceSymbol.ContainingNamespace.IsGlobalNamespace)
                result = namespaceSymbol.ContainingNamespace.GetFullName() + "." + result;
            return result;
        }

        public static string GetFullName(this ITypeSymbol type)
        {
            if (type.IsAnonymousType)
            {
                return type.GetTypeName();
            }
            if (type is IArrayTypeSymbol)
            {
                var arrayType = (IArrayTypeSymbol)type;
                return arrayType.ElementType.GetFullName() + "[]";
            }

            var typeParameter = type as ITypeParameterSymbol;
            if (typeParameter != null)
            {
                return typeParameter.Name;
            }
            else
            {
                string result = type.MetadataName;
                if (type.ContainingType != null)
                    result = type.ContainingType.GetFullName() + "." + result;
                else if (!type.ContainingNamespace.IsGlobalNamespace)
                    result = type.ContainingNamespace.GetFullName() + "." + result;
                return result;
            }
        }

        public static bool IsAssignableFrom(this ITypeSymbol baseType, ITypeSymbol type)
        {
            var current = type;
            while (current != null)
            {
                if (Equals(current, baseType))
                    return true;
                current = current.BaseType;
            }
            foreach (var intf in type.AllInterfaces)
            {
                if (Equals(intf, baseType))
                    return true;
            }
            return false;
        }

        public static bool IsSubclassOf(this ITypeSymbol @class, ITypeSymbol baseClass) 
        {
            var current = @class.BaseType;
            while (current != null)
            {
                if (Equals(current, baseClass))
                    return true;
                current = current.BaseType;
            }
            return false;
        }

        public static ITypeSymbol GetGenericArgument(this ITypeSymbol type, ITypeSymbol unconstructedType, int argumentIndex)
        {
            var current = type;
            while (current != null)
            {
                if (Equals(current.OriginalDefinition, unconstructedType))
                {
                    return ((INamedTypeSymbol)current).TypeArguments[argumentIndex];
                }
                current = current.BaseType;
            }
            if (type is INamedTypeSymbol)
            {
                var namedTypeSymbol = (INamedTypeSymbol)type;
                foreach (var intf in namedTypeSymbol.AllInterfaces)
                {
                    if (Equals(intf.OriginalDefinition, unconstructedType))
                    {
                        return intf.TypeArguments[argumentIndex];
                    }
                }
            }
            return null;
        }

        public static T GetAttributeValue<T>(this ISymbol symbol, INamedTypeSymbol attributeType, string propertyName, T defaultValue = default(T))
        {
            var jsAttributes = symbol.GetAttributes().Where(x => Equals(x.AttributeClass, attributeType)).ToArray();
            foreach (var jsAttribute in jsAttributes)
            {
                var argument = jsAttribute.NamedArguments.SingleOrDefault(x => x.Key == propertyName);
                if (argument.Value.Kind == TypedConstantKind.Array)
                {
                    var elementType = typeof(T).GetElementType();
                    var source = argument.Value.Values.Select(x => x.Value).ToArray();
                    var array = Array.CreateInstance(elementType, source.Length);
                    source.CopyTo(array, 0);
                    return (T)(object)array;
                }
                else
                {
                    if (argument.Value.Value != null)
                    {
                        return (T)argument.Value.Value;
                    }                    
                }
            }
            return defaultValue;
        }

        public static int GetBaseMemberNameCount(this INamedTypeSymbol type, string name)
        {
            if (type.BaseType != null)
                return type.BaseType.GetMemberNameCount(name);
            else
                return 0;
        }

        public static int GetMemberNameCount(this INamedTypeSymbol type, string name)
        {
            var count = 0;
            if (type.DeclaringSyntaxReferences.Any())
            {
                if (type.GetMembers(name).Any())
                    count++;
            }
            else
            {
                throw new Exception("This exception happens because we can't find the referenced project.  All project references should be true project references and not assembly references.  This is because we need all symbol information to be available when deriving JS symbol names.  When using dll references all non-public symbols will be missing.  Missing type: " + type.GetFullName());
                var reflectedType = Context.Instance.ReflectionCache.GetReflectedType(type);
                if (reflectedType != null && reflectedType.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).Any(x => x.Name == name))
                    count++;
            }

            if (type.BaseType != null)
            {
                count += type.BaseType.GetMemberNameCount(name);
            }

            return count;
        }

        public static ISymbol[] GetAllMembers(this INamedTypeSymbol type, string name)
        {
            if (type.BaseType != null)
                return type.BaseType.GetAllMembers(name).Concat(type.GetMembers(name).ToArray()).ToArray();
            else
                return type.GetMembers(name).ToArray();
        }

        public static ISymbol[] GetAllMembers(this INamedTypeSymbol type)
        {
            if (type.BaseType != null)
                return type.BaseType.GetAllMembers().Concat(type.GetMembers().ToArray()).ToArray();
            else
                return type.GetMembers().ToArray();
        }

        public static TypeDeclarationSyntax GetContainingTypeDeclaration(this SyntaxNode node)
        {
            var current = node.Parent;
            while (current != null)
            {
                if (current is TypeDeclarationSyntax)
                    return (TypeDeclarationSyntax)current;
                current = current.Parent;
            }
            return null;
        }

        public static ITypeSymbol GetContainingType(this SyntaxNode node)
        {
            var classDeclaration = node.FirstAncestorOrSelf<ClassDeclarationSyntax>(x => true);
            if (classDeclaration == null)
            {
                var structDeclaration = node.FirstAncestorOrSelf<StructDeclarationSyntax>(x => true);
                if (structDeclaration != null)
                    return Context.Instance.Compilation.GetSemanticModel(structDeclaration.SyntaxTree).GetDeclaredSymbol(structDeclaration);                
            }
            if (classDeclaration == null)
                return null;
            return Context.Instance.Compilation.GetSemanticModel(classDeclaration.SyntaxTree).GetDeclaredSymbol(classDeclaration);
        }

        public static BaseMethodDeclarationSyntax GetContainingMethodDeclaration(this SyntaxNode node)
        {
            return (BaseMethodDeclarationSyntax)node.FirstAncestorOrSelf<SyntaxNode>(x => x is ConstructorDeclarationSyntax || x is MethodDeclarationSyntax);
        }

        public static IMethodSymbol GetContainingMethod(this SyntaxNode node)
        {
            var method = node.FirstAncestorOrSelf<SyntaxNode>(x => x is ConstructorDeclarationSyntax || x is MethodDeclarationSyntax);
            if (method == null)
                return null;
            if (method is ConstructorDeclarationSyntax)
                return Context.Instance.Compilation.GetSemanticModel(method.SyntaxTree).GetDeclaredSymbol((ConstructorDeclarationSyntax)method);
            else
                return Context.Instance.Compilation.GetSemanticModel(method.SyntaxTree).GetDeclaredSymbol((MethodDeclarationSyntax)method);
        }

        public static IMethodSymbol GetRootOverride(this IMethodSymbol method)
        {
            if (method.OverriddenMethod == null)
                return method;
            else
                return method.OverriddenMethod.GetRootOverride();
        }

        public static IPropertySymbol GetRootOverride(this IPropertySymbol property)
        {
            if (property.OverriddenProperty == null)
                return property;
            else
                return property.OverriddenProperty.GetRootOverride();
        }

        public static bool HasOrIsEnclosedInGenericParameters(this INamedTypeSymbol type)
        {
            return type.HasOrIsBaseTypeWithGenericParameters() || (type.ContainingType != null && type.ContainingType.HasOrIsEnclosedInGenericParameters()) || type.IsAnonymousTypeWithTypeParameters();
        }

        public static bool HasOrIsBaseTypeWithGenericParameters(this INamedTypeSymbol type)
        {
            return type.IsGenericType || (type.BaseType != null && type.BaseType.HasOrIsBaseTypeWithGenericParameters());
        }

        public static bool HasGenericParameters(this INamedTypeSymbol type)
        {
            return type.TypeArguments.Any(x => x.TypeKind == TypeKind.TypeParameter || (x is INamedTypeSymbol && ((INamedTypeSymbol)x).HasGenericParameters()));
        }

        public static bool IsAnonymousTypeWithTypeParameters(this INamedTypeSymbol type)
        {
            return type.GetAnonymousTypeParameters().Any();
        }

        public static IEnumerable<Tuple<INamedTypeSymbol, string>> GetAnonymousTypeParameters(this INamedTypeSymbol type)
        {
            if (type.IsAnonymousType)
            {
                foreach (var property in type.GetMembers().OfType<IPropertySymbol>())
                {
                    foreach (var current in property.Type.GetAllTypeParameters())
                    {
                        yield return Tuple.Create(current.BaseType, current.Name);
                    }
                }
            }
        }

        public static IEnumerable<ITypeParameterSymbol> GetAllTypeParameters(this ITypeSymbol type) 
        {
            if (type.TypeKind == TypeKind.TypeParameter)
            {
                yield return (ITypeParameterSymbol)type;
            }
            else if (type is INamedTypeSymbol)
            {
                var namedType = (INamedTypeSymbol)type;
                foreach (var typeArgument in namedType.TypeArguments)
                {
                    foreach (var current in typeArgument.GetAllTypeParameters())
                    {
                        yield return current;
                    }
                }
            }
        }

/*
        public static bool HasOrIsEnclosedInUnconstructedType(this NamedTypeSymbol type)
        {
            return (type.TypeParameters.Count > 0 && type.TypeArguments.Any(x => IsUnconstructedType(x))) || (type.ContainingType != null && type.ContainingType.HasOrIsEnclosedInGenericParameters());
        }
*/

        public static bool IsUnconstructedType(this ITypeSymbol type) 
        {
            var namedTypeSymbol = type as INamedTypeSymbol;
            if (type is ITypeParameterSymbol)
                return true;
            if (namedTypeSymbol != null)
                return (namedTypeSymbol.TypeParameters.Any() && namedTypeSymbol.TypeArguments.Any(x => IsUnconstructedType(x))) || 
                       (type.ContainingType != null && type.ContainingType.IsUnconstructedType());
            else
                return false;
//            namedTypeSymbol.ConstructedFrom.ToString() != namedTypeSymbol.ToString() && namedTypeSymbol.ConstructedFrom.ConstructedFrom.ToString() == namedTypeSymbol.ConstructedFrom.ToString() && namedTypeSymbol.HasOrIsEnclosedInGenericParameters()
        }

        public static ParameterSyntax[] GetParameters(this ExpressionSyntax lambda)
        {
            if (lambda is SimpleLambdaExpressionSyntax)
                return new[] { ((SimpleLambdaExpressionSyntax)lambda).Parameter };
            if (lambda is ParenthesizedLambdaExpressionSyntax)
                return ((ParenthesizedLambdaExpressionSyntax)lambda).ParameterList.Parameters.ToArray();
            else
                throw new Exception();
        }

        public static CSharpSyntaxNode GetBody(this ExpressionSyntax lambda)
        {
            if (lambda is SimpleLambdaExpressionSyntax)
                return ((SimpleLambdaExpressionSyntax)lambda).Body;
            if (lambda is ParenthesizedLambdaExpressionSyntax)
                return ((ParenthesizedLambdaExpressionSyntax)lambda).Body;
            else
                throw new Exception();
        }

/*
        public static bool IsAssignment(this SyntaxKind type)
        {
            switch (type)
            {
                case SyntaxKind.AssignExpression:
                case SyntaxKind.AddAssignExpression:
                case SyntaxKind.AndAssignExpression:
                case SyntaxKind.DivideAssignExpression:
                case SyntaxKind.ExclusiveOrAssignExpression:
                case SyntaxKind.LeftShiftAssignExpression:
                case SyntaxKind.RightShiftAssignExpression:
                case SyntaxKind.ModuloAssignExpression:
                case SyntaxKind.MultiplyAssignExpression:
                case SyntaxKind.OrAssignExpression:
                case SyntaxKind.SubtractAssignExpression:
                    return true;
                default:
                    return false;
            }
        }
*/

        public static StatementSyntax GetNextStatement(this StatementSyntax statement)
        {
            if (statement.Parent is BlockSyntax)
            {
                var block = (BlockSyntax)statement.Parent;
                var indexOfStatement = block.Statements.IndexOf(statement);
                if (indexOfStatement == -1)
                    throw new Exception();
                if (indexOfStatement < block.Statements.Count - 1)
                    return block.Statements[indexOfStatement + 1];
                else
                    return null;
            }
            else if (statement.Parent is SwitchSectionSyntax)
            {
                var section = (SwitchSectionSyntax)statement.Parent;
                var indexOfStatement = section.Statements.IndexOf(statement);
                if (indexOfStatement == -1)
                    throw new Exception();
                if (indexOfStatement < section.Statements.Count - 1)
                    return section.Statements[indexOfStatement + 1];
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        public static IMethodSymbol GetMethodByName(this INamedTypeSymbol type, string name)
        {
            return type.GetMembers(name).OfType<IMethodSymbol>().Single();
        }

        public static IMethodSymbol GetMethod(this INamedTypeSymbol type, string name, params ITypeSymbol[] parameterTypes)
        {
            IMethodSymbol method;
            if (!TryGetMethod(type, name, out method, parameterTypes))
                throw new Exception();
            return method;
        }

        public static bool TryGetMethod(this INamedTypeSymbol type, string name, out IMethodSymbol method, params ITypeSymbol[] parameterTypes)
        {
            var candidates = type.GetMembers(name).OfType<IMethodSymbol>().ToArray();
            if (candidates.Length == 1)
            {
                method = candidates[0];
                return true;
            }
            foreach (var candidate in candidates)
            {
                if (candidate.Parameters.Count() != parameterTypes.Length)
                    continue;
                bool valid = true;
                foreach (var item in parameterTypes.Zip(candidate.Parameters.Select(x => x.Type), (x, y) => new { ParameterType = x, Candidate = y }))
                {
                    if (!Equals(item.Candidate, item.ParameterType))
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                {
                    method = candidate;
                    return true;                    
                }
            }
            if (type.BaseType != null)
            {
                return type.BaseType.TryGetMethod(name, out method, parameterTypes);
            }
            method = null;
            return false;
        }

        public static TypeSyntax ToTypeSyntax(this ITypeSymbol symbol)
        {
            return SyntaxFactory.ParseTypeName(symbol.ToDisplayString());
        }

        public static InvocationExpressionSyntax Wrap(this BlockSyntax block)
        {
            var jsni = new CsJsni(Context.Instance);
            return SyntaxFactory.InvocationExpression(SyntaxFactory.ParenthesizedExpression(SyntaxFactory.CastExpression(
                Context.Instance.Func.Construct(Context.Instance.JsObject).ToTypeSyntax(), 
                jsni.Function(block))));
        }

        public static InvocationExpressionSyntax Invoke(this IMethodSymbol method, params ExpressionSyntax[] arguments)
        {
            var methodTarget = SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, 
                method.ContainingType.ToTypeSyntax(), 
                SyntaxFactory.IdentifierName(method.Name));
            return arguments.Any() ? 
                SyntaxFactory.InvocationExpression(methodTarget, SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(arguments.Select(x => SyntaxFactory.Argument(x)), arguments.Skip(1).Select(_ => SyntaxFactory.Token(SyntaxKind.CommaToken))))) :
                SyntaxFactory.InvocationExpression(methodTarget);
        }

        public static bool IsTrue(this ExpressionSyntax expression)
        {
            var literal = (LiteralExpressionSyntax)expression;
            return literal.Token.IsKind(SyntaxKind.TrueKeyword);
        }

        public static Compilation Recompile(this Compilation compilation, CompilationUnitSyntax compilationUnit)
        {
            var document = Context.Instance.Project.GetDocument(compilationUnit.SyntaxTree);
            document = document.WithSyntaxRoot(compilationUnit);
            SyntaxTree syntaxTree;
            document.TryGetSyntaxTree(out syntaxTree);
            compilation = compilation.ReplaceSyntaxTree(compilationUnit.SyntaxTree, syntaxTree);
            return compilation;
        }

        public static Compilation Recompile(this Compilation compilation, SyntaxNode oldNode, SyntaxNode newNode)
        {
            while (oldNode != null)
            {
                var oldParent = oldNode.Parent;
                var newParent = oldParent.ReplaceNode(oldNode, newNode);

                oldNode = oldParent;
                newNode = newParent;

                if (oldNode is CompilationUnitSyntax)
                    break;
            }
            return compilation.Recompile((CompilationUnitSyntax)newNode);
        }

        public static INamedTypeSymbol FindType(this Compilation compilation, string fullName)
        {
            var result = compilation.GetTypeByMetadataName(fullName);
            if (result == null)
            {
                foreach (IAssemblySymbol assembly in Context.Instance.Project.MetadataReferences.Select(x => compilation.GetAssemblyOrModuleSymbol(x)))
                {
                    result = assembly.GetTypeByMetadataName(fullName);
                    if (result != null)
                        break;
                }
            }
            return result;
        }

        public static IEnumerable<ITypeSymbol> GetAllInnerTypes(this ITypeSymbol type)
        {
            foreach (var innerType in type.GetMembers().OfType<ITypeSymbol>())
            {
                yield return innerType;
                foreach (var inner in innerType.GetAllInnerTypes())
                {
                    yield return inner;
                }
            }
        }

        public static void ReportError(this SyntaxNode node, string message)
        {
            var fileName = node.SyntaxTree.FilePath;
            var text = node.SyntaxTree.GetText();
            var span = node.GetLocation().SourceSpan;
            var startLine = text.Lines.GetLinePosition(span.Start);
            var endLine = text.Lines.GetLinePosition(span.End);

            Console.WriteLine("{0} ({1},{2},{3},{4}): error: {5}", fileName, startLine.Line + 1, startLine.Character + 1, endLine.Line + 1, endLine.Character + 1, message);
        }

        public static bool IsPrimitive(this ITypeSymbol type)
        {
            switch (type.SpecialType)
            {
                case SpecialType.System_Boolean:
                case SpecialType.System_Byte:
                case SpecialType.System_Char:
                case SpecialType.System_Decimal:
                case SpecialType.System_Double:
                case SpecialType.System_Enum:
                case SpecialType.System_Int16:
                case SpecialType.System_Int32:
                case SpecialType.System_Int64:
                case SpecialType.System_Nullable_T:
                case SpecialType.System_SByte:
                case SpecialType.System_Single:
                case SpecialType.System_UInt16:
                case SpecialType.System_UInt32:
                case SpecialType.System_UInt64:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsAsync(this MethodDeclarationSyntax method)
        {
            return method.Modifiers.Any(x => x.IsKind(SyntaxKind.AsyncKeyword));
        }
    }
}
