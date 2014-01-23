namespace WootzJs.Compiler.JsAst
{
    public class JsTypeOfExpression : JsExpression
    {
        public JsExpression Target { get; set; }

        public JsTypeOfExpression()
        {
        }

        public JsTypeOfExpression(JsExpression target)
        {
            Target = target;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
