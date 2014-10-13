using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class VariableUsageFinder : CSharpSyntaxWalker
    {
        private CSharpSyntaxNode node;
        private string identifier;
        private List<ISymbol> symbols = new List<ISymbol>();
        private SemanticModel model;

        public VariableUsageFinder(SemanticModel model, CSharpSyntaxNode node, string identifier)
        {
            this.node = node;
            this.identifier = identifier;
            this.model = model;
        }

        public static ILocalSymbol FirstValidSymbolOccuranceOfVariable(SemanticModel model, CSharpSyntaxNode context, string identifier)
        {
            var outerForLoop  = context.FirstAncestorOrSelf<ForStatementSyntax>();
            var outerCatchClause = context.FirstAncestorOrSelf<CatchClauseSyntax>();
            var foreachLoop = context.FirstAncestorOrSelf<ForEachStatementSyntax>();
            var usings = context.FirstAncestorOrSelf<UsingStatementSyntax>();

            if (outerForLoop != null && outerForLoop.Declaration.Variables.Any(x => x.Identifier.ToString() == identifier))
                context = outerForLoop;
            else if (outerCatchClause != null && outerCatchClause.Declaration.Identifier.ToString() == identifier)
                context = outerCatchClause;
            else if (foreachLoop != null && foreachLoop.Identifier.ToString() == identifier)
                context = foreachLoop;
            else if (usings.Declaration.Variables.Any(x => x.Identifier.ToString() == identifier))
                context = usings;
            else
                context = context.FirstAncestorOrSelf<BlockSyntax>();

            var walker = new VariableUsageFinder(model, context, identifier);
            context.Accept(walker);
            return (ILocalSymbol)walker.symbols.FirstOrDefault();
        }

        public override void VisitIdentifierName(Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax node)
        {
            if (node.ToString() == identifier)
            {
                var symbol = model.GetSymbolInfo(node).Symbol;
                if (symbol != null)
                {
                    symbols.Add(symbol);
                }
            }
            base.VisitIdentifierName(node);
        }
    }
}