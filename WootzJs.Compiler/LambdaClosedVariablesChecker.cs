using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class LambdaClosedVariablesChecker : SyntaxWalker
    {
        public static bool HasClosedVariables(SyntaxNode node)
        {
            var checker = new LambdaClosedVariablesChecker(node);
            node.Accept(checker);
            return checker.hasClosedVariables;
        }

        private SemanticModel model;
        private Symbol outerScope;
        private bool hasClosedVariables;

        public LambdaClosedVariablesChecker(SyntaxNode node)
        {
            model = Context.Instance.Compilation.GetSemanticModel(node.SyntaxTree);
            outerScope = node.GetContainingMethod();
        }

        private bool IsContainedInOuterScope(Symbol symbol)
        {
            var container = symbol.ContainingSymbol;
            while (container != null)
            {
                if (container == outerScope)
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