using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class IdentifierRenamer : SyntaxRewriter
    {
        private SyntaxToken renameFrom;
        private SyntaxToken renameTo;

        public IdentifierRenamer(SyntaxToken renameFrom, SyntaxToken renameTo) 
        {
            this.renameFrom = renameFrom;
            this.renameTo = renameTo;
        }

        public static SyntaxNode RenameIdentifier(SyntaxNode node, SyntaxToken renameFrom, SyntaxToken renameTo)
        {
            return node.Accept(new IdentifierRenamer(renameFrom, renameTo));
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (node.Identifier.ToString() == renameFrom.ToString())
                return Syntax.IdentifierName(renameTo);

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