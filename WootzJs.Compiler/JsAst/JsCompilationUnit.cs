using System.Collections.Generic;

namespace WootzJs.Compiler.JsAst
{
    public class JsCompilationUnit : JsNode
    {
        public bool UseStrict { get; set; }
        public JsBlockStatement Body { get; set; }

        public JsCompilationUnit()
        {
            Body = new JsBlockStatement();
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
