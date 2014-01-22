using Roslyn.Compilers.Common;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class YieldChecker : SyntaxWalker
    {
        private bool yieldOnly;
        private bool isSpecial;

        public YieldChecker(bool yieldOnly) 
        {
            this.yieldOnly = yieldOnly;
        }

        public bool IsSpecial
        {
            get { return isSpecial; }
        }

        public static bool HasYield(MethodDeclarationSyntax method)
        {
            var yieldChecker = new YieldChecker(true);
            method.Accept(yieldChecker);
            return yieldChecker.isSpecial;
        }

        public static bool HasSpecialStatement(StatementSyntax statement)
        {
            var yieldChecker = new YieldChecker(false);
            statement.Accept(yieldChecker);
            return yieldChecker.isSpecial;
        }

        public override void VisitYieldStatement(YieldStatementSyntax node)
        {
            base.VisitYieldStatement(node);
            isSpecial = true;
        }

        public override void VisitLabeledStatement(LabeledStatementSyntax node)
        {
            base.VisitLabeledStatement(node);
            if (!yieldOnly)
                isSpecial = true;
        }

        public override void VisitGotoStatement(GotoStatementSyntax node)
        {
            base.VisitGotoStatement(node);
            if (!yieldOnly)
                isSpecial = true;
        }
    }
}