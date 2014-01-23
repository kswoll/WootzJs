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
