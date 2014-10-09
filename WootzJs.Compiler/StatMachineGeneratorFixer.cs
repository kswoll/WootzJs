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
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class StatMachineGeneratorFixer : CSharpSyntaxRewriter
    {
        private Compilation compilation;
        private SyntaxTree syntaxTree;
        private SemanticModel semanticModel;
        private string enclosingTypeName;

        public StatMachineGeneratorFixer(Compilation compilation, SyntaxTree syntaxTree, SemanticModel semanticModel, string enclosingTypeName)
        {
            this.compilation = compilation;
            this.syntaxTree = syntaxTree;
            this.semanticModel = semanticModel;
            this.enclosingTypeName = enclosingTypeName;
        }

        public override SyntaxNode VisitGenericName(GenericNameSyntax node)
        {
            if (!(node.Parent is MemberAccessExpressionSyntax) || ((MemberAccessExpressionSyntax)node.Parent).Expression == node)
            {
                if (node.GetContainingMethod() == null)
                {
                    return base.VisitGenericName(node);
                }

                var containingType = node.GetContainingType();
                if (containingType == null || !containingType.Name.StartsWith(enclosingTypeName))
                    return node;

                var symbol = semanticModel.GetSymbolInfo(node).Symbol;
                if (symbol == null || (new[] { SymbolKind.Field, SymbolKind.Event, SymbolKind.Method, SymbolKind.Property }.Contains(symbol.Kind) && !symbol.ContainingType.Name.StartsWith(enclosingTypeName) && !symbol.IsStatic))
                {
                    return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("$this"), node);
                }
            }
            return base.VisitGenericName(node);
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (!(node.Parent is MemberAccessExpressionSyntax) || ((MemberAccessExpressionSyntax)node.Parent).Expression == node)
            {
                if (node.GetContainingMethod() == null)
                {
                    return base.VisitIdentifierName(node);
                }

                var containingType = node.GetContainingType();
                if (containingType == null || !containingType.Name.StartsWith(enclosingTypeName))
                    return node;

                var symbol = semanticModel.GetSymbolInfo(node).Symbol;
                var isObjectInitializer = node.Parent != null && node.Parent.Parent is InitializerExpressionSyntax;
                if (!isObjectInitializer)
                {
                    if (symbol == null || (new[] { SymbolKind.Field, SymbolKind.Event, SymbolKind.Method, SymbolKind.Property }.Contains(symbol.Kind) && !symbol.ContainingType.Name.StartsWith(enclosingTypeName) && !symbol.IsStatic))
                    {
                        return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("$this"), node);
                    }
                }
            }
            return base.VisitIdentifierName(node);
        }

/*
        public override SyntaxNode VisitThisExpression(ThisExpressionSyntax node)
        {
            var containingType = node.GetContainingType();
            if (containingType == null || !containingType.Name.StartsWith("YieldEnumerator$"))
                return node;

            var symbol = semanticModel.GetSymbolInfo(node).Symbol;
            if (symbol == null)
            {
                return Syntax.IdentifierName("$this");
            }

            return base.VisitThisExpression(node);
        }
*/
    }
}