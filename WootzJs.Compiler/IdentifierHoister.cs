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

using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class IdentifierHoister : SyntaxRewriter
    {
        private Compilation compilation;
        private SemanticModel model;
        private SyntaxToken identifier;

        public IdentifierHoister(Compilation compilation, SemanticModel model, SyntaxToken identifier) 
        {
            this.compilation = compilation;
            this.model = model;
            this.identifier = identifier;
        }

        public static T HoistIdentifiers<T>(T syntax, 
            Compilation compilation, SyntaxToken thisIdentifier)
            where T : SyntaxNode
        {
            return (T)syntax.Accept(new IdentifierHoister(compilation, 
                compilation.GetSemanticModel(syntax.SyntaxTree), thisIdentifier));
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (!(node.Parent is MemberAccessExpressionSyntax))
            {
                var symbol = model.GetSymbolInfo(node).Symbol;
                if (symbol is FieldSymbol || symbol is MethodSymbol || symbol is EventSymbol || symbol is PropertySymbol)
                {
                    return Syntax.MemberAccessExpression(SyntaxKind.MemberAccessExpression, Syntax.IdentifierName(identifier), node);
                }
            }

            return base.VisitIdentifierName(node);
        }

        public override SyntaxNode VisitThisExpression(ThisExpressionSyntax node)
        {
            return base.VisitThisExpression(node);
        }
    }
}