namespace WootzJs.Compiler.JsAst
{
    public class JsDeleteExpression : JsExpression
    {
        public JsExpression Target { get; set; }

        public JsDeleteExpression()
        {
        }

        public JsDeleteExpression(JsExpression target)
        {
            Target = target;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
