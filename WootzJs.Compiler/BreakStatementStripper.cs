using System;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class BreakStatementStripper : SyntaxRewriter
    {
        public static SyntaxNode StripStatements(SyntaxNode root)
        {
            return root.Accept(new BreakStatementStripper());
        }

        public override SyntaxNode VisitBreakStatement(BreakStatementSyntax node)
        {
            return Syntax.EmptyStatement();
        }

        public override SyntaxNode VisitForEachStatement(ForEachStatementSyntax node)
        {
            return node;
        }

        public override SyntaxNode VisitWhileStatement(WhileStatementSyntax node)
        {
            return node;
        }

        public override SyntaxNode VisitForStatement(ForStatementSyntax node)
        {
            return node;
        }

        public override SyntaxNode VisitDoStatement(DoStatementSyntax node)
        {
            return node;
        }

        public override SyntaxNode VisitSwitchStatement(SwitchStatementSyntax node)
        {
            return node;
        }
    }
}