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

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class IdentifierRenamer : CSharpSyntaxRewriter
    {
        private SyntaxToken renameFrom;
        private SyntaxToken renameTo;

        public IdentifierRenamer(SyntaxToken renameFrom, SyntaxToken renameTo) 
        {
            this.renameFrom = renameFrom;
            this.renameTo = renameTo;
        }

        public static CSharpSyntaxNode RenameIdentifier(CSharpSyntaxNode node, SyntaxToken renameFrom, SyntaxToken renameTo)
        {
            return (CSharpSyntaxNode)node.Accept(new IdentifierRenamer(renameFrom, renameTo));
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (node.Identifier.ToString() == renameFrom.ToString())
                return SyntaxFactory.IdentifierName(renameTo);

            return base.VisitIdentifierName(node);
        }

        public override SyntaxNode VisitForEachStatement(ForEachStatementSyntax node)
        {
            if (node.Identifier.ToString() == renameFrom.ToString())
                node = node.WithIdentifier(renameTo);

            return base.VisitForEachStatement(node);
        }

        public override SyntaxNode VisitVariableDeclarator(VariableDeclaratorSyntax node)
        {
            if (node.Identifier.ToString() == renameFrom.ToString())
                node = node.WithIdentifier(renameTo);

            return base.VisitVariableDeclarator(node);
        }
    }
}
