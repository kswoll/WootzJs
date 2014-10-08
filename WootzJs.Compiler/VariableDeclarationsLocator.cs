using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class VariableDeclarationsLocator : CSharpSyntaxWalker
    {
        private List<VariableDeclarationSyntax> variables = new List<VariableDeclarationSyntax>();
        private CSharpSyntaxNode context;
        private HashSet<SyntaxNode> contextParents = new HashSet<SyntaxNode>();
        private bool isInScope = true;

        public VariableDeclarationsLocator(CSharpSyntaxNode context)
        {
            this.context = context;

            SyntaxNode current = context;
            while (!(current is MemberDeclarationSyntax))
            {
                contextParents.Add(current);
                current = current.Parent;
            }
        }

        public IEnumerable<VariableDeclarationSyntax> Variables
        {
            get { return variables; }
        }

        public override void VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            base.VisitVariableDeclaration(node);
            if (node.Span.End < context.Span.Start)
                variables.Add(node);
        }

        public override void VisitBlock(BlockSyntax node)
        {
            var oldIsInScope = isInScope;
            if (!contextParents.Contains(node))
                isInScope = false;
            base.VisitBlock(node);
            if (!isInScope && oldIsInScope)
                isInScope = true;
        }
    }
}