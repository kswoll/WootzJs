using System.Collections.Generic;

namespace WootzJs.Compiler.JsAst
{
    public class JsSnippetExpression : JsExpression
    {
        private List<JsExpression> parts = new List<JsExpression>();

        public List<JsExpression> Parts
        {
            get { return parts; }
        }

        public JsSnippetExpression(params JsExpression[] parts)
        {
            this.parts.AddRange(parts);
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override T Accept<T>(IJsVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}