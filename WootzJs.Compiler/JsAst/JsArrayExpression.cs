using System.Collections.Generic;

namespace WootzJs.Compiler.JsAst
{
    public class JsArrayExpression : JsExpression
    {
        public List<JsExpression> Elements { get; set; }

        public JsArrayExpression()
        {
            Elements = new List<JsExpression>();
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
