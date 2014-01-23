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

using System;
using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
/*
    public class TypeNormalizer : SyntaxRewriter
    {
        private Compilation compilation;
        private SyntaxTree syntaxTree;
        private SemanticModel model;
        private Symbol asExtensionSymbol;

        public TypeNormalizer(Compilation compilation, SyntaxTree syntaxTree, SemanticModel model) 
        {
            this.compilation = compilation;
            this.syntaxTree = syntaxTree;
            this.model = model;

            asExtensionSymbol = compilation.GetTypeByMetadataName("System.Runtime.WootzJs.AsExtension").GetMembers("As").Single();
        }

        public override SyntaxNode VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            return base.VisitMemberAccessExpression(node);
        }

        public override SyntaxNode VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            var symbol = model.GetDeclaredSymbol(node.Variables[0]);

            var local = symbol as LocalSymbol;
            if (local != null)
            {
                if (local.Type.SpecialType == SpecialType.System_String)
                {
                    var result = node.WithType(Syntax.ParseTypeName("System.String"));
                    return result;
                }
            }

            return base.VisitVariableDeclaration(node);
        }

        public override SyntaxNode VisitCompilationUnit(CompilationUnitSyntax node)
        {
            var result = (CompilationUnitSyntax)base.VisitCompilationUnit(node);

            var namespaceDeclarationSyntax = result.Members.OfType<NamespaceDeclarationSyntax>().FirstOrDefault();
            if (namespaceDeclarationSyntax != null && namespaceDeclarationSyntax.Name.ToString() == "System")
            {
                return result;
            }
            if (!result.Usings.Any(x => x.Name.ToString() == "System"))
            {
                result = result.WithUsings(result.Usings.Add(Syntax.UsingDirective(Syntax.IdentifierName("System"))));
            }

            return result;
        }

        private static InvocationExpressionSyntax AsWrap(ExpressionSyntax expression, TypeInfo type)
        {
            string typeName;
            switch (type.ConvertedType.SpecialType)
            {
                case SpecialType.System_Int32: 
                    typeName = "Int32";
                    break;
                case SpecialType.System_String:
                    typeName = "String";
                    break;
                case SpecialType.System_Boolean: 
                    typeName = "Boolean";
                    break;
                case SpecialType.System_Byte: 
                    typeName = "Byte";
                    break;
                case SpecialType.System_SByte: 
                    typeName = "SByte";
                    break;
                case SpecialType.System_Int16: 
                    typeName = "Int16";
                    break;
                case SpecialType.System_UInt16: 
                    typeName = "UInt16";
                    break;
                case SpecialType.System_UInt32: 
                    typeName = "UInt32";
                    break;
                case SpecialType.System_Int64: 
                    typeName = "Int64";
                    break;
                case SpecialType.System_UInt64: 
                    typeName = "UInt64";
                    break;
                case SpecialType.System_Single: 
                    typeName = "Single";
                    break;
                case SpecialType.System_Double: 
                    typeName = "Double";
                    break;
                case SpecialType.System_Decimal: 
                    typeName = "Decimal";
                    break;
                case SpecialType.System_Object: 
                    typeName = "Object";
                    break;
                case SpecialType.System_Char: 
                    typeName = "Char";
                    break;
                default: 
                    throw new Exception();
            }

            var systemRuntime = Syntax.MemberAccessExpression(
                SyntaxKind.MemberAccessExpression, 
                Syntax.IdentifierName("System"),
                Syntax.IdentifierName("Runtime"));
            var WootzJs = Syntax.MemberAccessExpression(
                SyntaxKind.MemberAccessExpression, 
                systemRuntime,
                Syntax.IdentifierName("WootzJs"));
            var asExtension = Syntax.MemberAccessExpression(
                SyntaxKind.MemberAccessExpression, 
                WootzJs,
                Syntax.IdentifierName("AsExtension"));
            var asMethod = Syntax.MemberAccessExpression(
                SyntaxKind.MemberAccessExpression, 
                asExtension, 
                Syntax.GenericName(
                    Syntax.Identifier("As"),
                    Syntax.TypeArgumentList(Syntax.SeparatedList<TypeSyntax>(Syntax.IdentifierName(typeName)))));
            return Syntax.InvocationExpression(asMethod, Syntax.ArgumentList(Syntax.SeparatedList(Syntax.Argument(expression))));
        }

/*
        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            var argumentTypes = node.ArgumentList.Arguments.Select(x => model.GetTypeInfo(x.Expression)).ToArray();

            node = (InvocationExpressionSyntax)base.VisitInvocationExpression(node);

            if (node.Expression.ToString().Contains("Compare"))
            {
                var argument = node.ArgumentList.Arguments[0];
            }

            // If any parameters to the method are a predefined type then we need to ensure it's coerced into the type name so
            // overload resolution behaves
            var index = 0; 
            node = node.ReplaceNodes<InvocationExpressionSyntax, SyntaxNode>(node.ArgumentList.Arguments.Select(x => x.Expression), (argument, _) =>
            {
//                var model = compilation.GetSemanticModel(argument.SyntaxTree);
//                var typeInfo = model.GetTypeInfo((ExpressionSyntax)argument);
                var typeInfo = argumentTypes[index++];
                if (typeInfo.Type != null && typeInfo.Type.SpecialType != SpecialType.None)
                    return AsWrap((ExpressionSyntax)argument, typeInfo);
                return _;
            });
                
            return node;
        }
#1#

        public override SyntaxNode VisitPredefinedType(PredefinedTypeSyntax node)
        {
//            compilation.

            switch (node.Keyword.Kind)
            {
                case SyntaxKind.StringKeyword: return Syntax.IdentifierName("String");
                case SyntaxKind.IntKeyword: return Syntax.IdentifierName("Int32");
                case SyntaxKind.BoolKeyword: return Syntax.IdentifierName("Boolean");
                case SyntaxKind.ByteKeyword: return Syntax.IdentifierName("Byte");
                case SyntaxKind.SByteKeyword: return Syntax.IdentifierName("SByte");
                case SyntaxKind.ShortKeyword: return Syntax.IdentifierName("Int16");
                case SyntaxKind.UShortKeyword: return Syntax.IdentifierName("UInt16");
                case SyntaxKind.UIntKeyword: return Syntax.IdentifierName("UInt32");
                case SyntaxKind.LongKeyword: return Syntax.IdentifierName("Int64");
                case SyntaxKind.ULongKeyword: return Syntax.IdentifierName("UInt64");
                case SyntaxKind.FloatKeyword: return Syntax.IdentifierName("Single");
                case SyntaxKind.DoubleKeyword: return Syntax.IdentifierName("Double");
                case SyntaxKind.DecimalKeyword: return Syntax.IdentifierName("Decimal");
                case SyntaxKind.VoidKeyword: return Syntax.IdentifierName("Void");
                case SyntaxKind.ObjectKeyword: return Syntax.IdentifierName("Object");
                case SyntaxKind.CharKeyword: return Syntax.IdentifierName("Char");
                default: throw new Exception();
            }
        }
    }
*/
}
