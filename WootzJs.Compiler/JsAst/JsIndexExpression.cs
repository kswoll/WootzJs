namespace WootzJs.Compiler.JsAst
{
    public class JsIndexExpression : JsExpression
    {
        public JsExpression Target { get; set; }
        public JsExpression Index { get; set; }

        public JsIndexExpression()
        {
        }

        public JsIndexExpression(JsExpression target, JsExpression index)
        {
            Target = target;
            Index = index;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
