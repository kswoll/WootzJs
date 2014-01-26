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
using System.Linq;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public static class RoslynExtensions
    {
        internal static Context context;

        public static string GetFullName(this TypeInfo typeInfo)
        {
            return typeInfo.ConvertedType.GetFullName();
        }

        public static string GetFullName(this NamespaceSymbol namespaceSymbol)
        {
            string result = namespaceSymbol.MetadataName;
            if (!namespaceSymbol.IsGlobalNamespace && !namespaceSymbol.ContainingNamespace.IsGlobalNamespace)
                result = context.SymbolNames[namespaceSymbol.ContainingNamespace, namespaceSymbol.ContainingNamespace.GetFullName()] + "." + result;
            return result;
        }

        public static string GetFullName(this TypeSymbol type)
        {
            if (type.IsAnonymousType)
            {
                return type.GetTypeName();
            }
            if (type is ArrayTypeSymbol)
            {
                var arrayType = (ArrayTypeSymbol)type;
                return arrayType.ElementType.GetFullName() + "[]";
            }

            var typeParameter = type as TypeParameterSymbol;
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

        public static bool IsSubclassOf(this TypeSymbol @class, TypeSymbol baseClass) 
        {
            var current = @class.BaseType;
            while (current != null)
            {
                if (current == baseClass)
                    return true;
                current = current.BaseType;
            }
            return false;
        }

        public static TypeSymbol GetGenericArgument(this TypeSymbol type, TypeSymbol unconstructedType, int argumentIndex)
        {
            var current = type;
            while (current != null)
            {
                if (current.OriginalDefinition == unconstructedType)
                {
                    return ((NamedTypeSymbol)current).TypeArguments[argumentIndex];
                }
                current = current.BaseType;
            }
            if (type is NamedTypeSymbol)
            {
                var namedTypeSymbol = (NamedTypeSymbol)type;
                foreach (var intf in namedTypeSymbol.AllInterfaces)
                {
                    if (intf.OriginalDefinition == unconstructedType)
                    {
                        return intf.TypeArguments[argumentIndex];
                    }
                }
            }
            return null;
        }

        public static T GetAttributeValue<T>(this Symbol type, NamedTypeSymbol attributeType, string propertyName, T defaultValue = default(T))
        {
            var jsAttribute = type.GetAttributes(attributeType).SingleOrDefault();
            if (jsAttribute != null)
            {
                // If the type is inlined, all the methods of the class will be written
                // at the same (root) level as the class declaration would have.  This is useful
                // for creating Javascript-Global functions.
                var isInlinedArgument = jsAttribute.NamedArguments.SingleOrDefault(x => x.Key == propertyName);
                if (isInlinedArgument.Value.Value != null)
                {
                    return (T)isInlinedArgument.Value.Value;
                }
            }
            return defaultValue;
        }

        public static Symbol[] GetAllMembers(this NamedTypeSymbol type, string name)
        {
            if (type.BaseType != null)
                return type.BaseType.GetAllMembers(name).Concat(type.GetMembers(name).ToArray()).ToArray();
            else
                return type.GetMembers(name).ToArray();
        }

        public static Symbol[] GetAllMembers(this NamedTypeSymbol type)
        {
            if (type.BaseType != null)
                return type.BaseType.GetAllMembers().Concat(type.GetMembers().ToArray()).ToArray();
            else
                return type.GetMembers().ToArray();
        }

        public static TypeSymbol GetContainingType(this SyntaxNode node)
        {
            var classDeclaration = node.FirstAncestorOrSelf<ClassDeclarationSyntax>(x => true);
            if (classDeclaration == null)
                return null;
            return context.Compilation.GetSemanticModel(classDeclaration.SyntaxTree).GetDeclaredSymbol(classDeclaration);
        }

        public static MethodSymbol GetContainingMethod(this SyntaxNode node)
        {
            var method = node.FirstAncestorOrSelf<SyntaxNode>(x => x is ConstructorDeclarationSyntax || x is MethodDeclarationSyntax);
            if (method is ConstructorDeclarationSyntax)
                return context.Compilation.GetSemanticModel(method.SyntaxTree).GetDeclaredSymbol((ConstructorDeclarationSyntax)method);
            else
                return context.Compilation.GetSemanticModel(method.SyntaxTree).GetDeclaredSymbol((MethodDeclarationSyntax)method);
        }

        public static MethodSymbol GetRootOverride(this MethodSymbol method)
        {
            if (method.OverriddenMethod == null)
                return method;
            else
                return method.OverriddenMethod.GetRootOverride();
        }

        public static PropertySymbol GetRootOverride(this PropertySymbol property)
        {
            if (property.OverriddenProperty == null)
                return property;
            else
                return property.OverriddenProperty.GetRootOverride();
        }

        public static bool HasOrIsEnclosedInGenericParameters(this NamedTypeSymbol type)
        {
            return type.TypeParameters.Count > 0 || (type.ContainingType != null && type.ContainingType.HasOrIsEnclosedInGenericParameters());
        }

/*
        public static bool HasOrIsEnclosedInUnconstructedType(this NamedTypeSymbol type)
        {
            return (type.TypeParameters.Count > 0 && type.TypeArguments.Any(x => IsUnconstructedType(x))) || (type.ContainingType != null && type.ContainingType.HasOrIsEnclosedInGenericParameters());
        }
*/

        public static bool IsUnconstructedType(this TypeSymbol type) 
        {
            var namedTypeSymbol = type as NamedTypeSymbol;
            if (type is TypeParameterSymbol)
                return true;
            if (namedTypeSymbol != null)
                return (namedTypeSymbol.TypeParameters.Count > 0 && namedTypeSymbol.TypeArguments.Any(x => IsUnconstructedType(x))) || 
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

        public static SyntaxNode GetBody(this ExpressionSyntax lambda)
        {
            if (lambda is SimpleLambdaExpressionSyntax)
                return ((SimpleLambdaExpressionSyntax)lambda).Body;
            if (lambda is ParenthesizedLambdaExpressionSyntax)
                return ((ParenthesizedLambdaExpressionSyntax)lambda).Body;
            else
                throw new Exception();
        }

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

        public static MethodSymbol GetMethodByName(this NamedTypeSymbol type, string name)
        {
            return type.GetMembers(name).OfType<MethodSymbol>().Single();
        }

        public static MethodSymbol GetMethod(this NamedTypeSymbol type, string name, params TypeSymbol[] parameterTypes)
        {
            var candidates = type.GetMembers(name).OfType<MethodSymbol>().ToArray();
            if (candidates.Length == 1)
                return candidates[0];
            foreach (var candidate in candidates)
            {
                if (candidate.Parameters.Count != parameterTypes.Length)
                    continue;
                bool valid = true;
                foreach (var item in parameterTypes.Zip(candidate.Parameters.Select(x => x.Type), (x, y) => new { ParameterType = x, Candidate = y }))
                {
                    if (item.Candidate != item.ParameterType)
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                    return candidate;
            }
            throw new Exception();
        }

        public static TypeSyntax ToTypeSyntax(this TypeSymbol symbol)
        {
            return Syntax.ParseTypeName(symbol.ToDisplayString());
        }

        public static InvocationExpressionSyntax Wrap(this BlockSyntax block)
        {
            var jsni = new CsJsni(context);
            return Syntax.InvocationExpression(Syntax.ParenthesizedExpression(Syntax.CastExpression(context.Func.Construct(context.JsObject).ToTypeSyntax(), jsni.Function(block))));
        }

        public static InvocationExpressionSyntax Invoke(this MethodSymbol method, params ExpressionSyntax[] arguments)
        {
            var methodTarget = Syntax.MemberAccessExpression(SyntaxKind.MemberAccessExpression, 
                method.ContainingType.ToTypeSyntax(), 
                Syntax.IdentifierName(method.Name));
            return arguments.Any() ? 
                Syntax.InvocationExpression(methodTarget, Syntax.ArgumentList(Syntax.SeparatedList(arguments.Select(x => Syntax.Argument(x)), arguments.Skip(1).Select(_ => Syntax.Token(SyntaxKind.CommaToken))))) :
                Syntax.InvocationExpression(methodTarget);
        }

        public static bool IsTrue(this ExpressionSyntax expression)
        {
            var literal = (LiteralExpressionSyntax)expression;
            return literal.Token.Kind == SyntaxKind.TrueKeyword;
        }

        public static Compilation Recompile(this Compilation compilation, CompilationUnitSyntax compilationUnit)
        {
            var document = context.Project.GetDocument(compilationUnit.SyntaxTree);
            document = document.UpdateSyntaxRoot(compilationUnit);
            compilation = (Compilation)compilation.ReplaceSyntaxTree(compilationUnit.SyntaxTree, document.GetSyntaxTree());            
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
    }
}
