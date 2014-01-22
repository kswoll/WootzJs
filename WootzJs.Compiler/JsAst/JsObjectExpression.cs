using System.Collections.Generic;

namespace WootzJs.Compiler.JsAst
{
    public class JsObjectExpression : JsExpression
    {
        public List<JsObjectItem> Items { get; set; }

        public JsObjectExpression()
        {
            Items = new List<JsObjectItem>();
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
