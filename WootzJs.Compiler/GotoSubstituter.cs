using System.Collections.Generic;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class GotoSubstituter : SyntaxRewriter
    {
        private Compilation compilation;
        private Dictionary<object, YieldState> labelStates;

        public GotoSubstituter(Compilation compilation, Dictionary<object, YieldState> labelStates) 
        {
            this.compilation = compilation;
            this.labelStates = labelStates;
        }

        public override SyntaxNode VisitGotoStatement(GotoStatementSyntax node)
        {
            var label = node.Expression.ToString();
            if (label.StartsWith("$"))
                return node;

            return YieldStateGenerator.ChangeState(labelStates[label]);
        }
    }
}