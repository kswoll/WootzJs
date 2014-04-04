
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class LambdaClosedVariablesChecker : CSharpSyntaxWalker
    {
        public static bool HasClosedVariables(CSharpSyntaxNode node)
        {
            var checker = new LambdaClosedVariablesChecker(node);
            node.Accept(checker);
            return checker.hasClosedVariables;
        }

        private SemanticModel model;
        private ISymbol outerScope;
        private bool hasClosedVariables;

        public LambdaClosedVariablesChecker(SyntaxNode node)
        {
            model = Context.Instance.Compilation.GetSemanticModel(node.SyntaxTree);
            outerScope = node.GetContainingMethod();
        }

        private bool IsContainedInOuterScope(ISymbol symbol)
        {
            var container = symbol.ContainingSymbol;
            while (container != null)
            {
                if (Equals(container, outerScope))
                    return true;
                container = container.ContainingSymbol;
            }
            return false;
        }

        public override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            var symbol = model.GetSymbolInfo(node).Symbol;
            if (!IsContainedInOuterScope(symbol))
                hasClosedVariables = true;
        }
    }
}