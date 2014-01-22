namespace WootzJs.Compiler.JsAst
{
    public class JsNewExpression : JsExpression
    {
        public JsExpression Expression { get; set; }

        public JsNewExpression()
        {
        }

        public JsNewExpression(JsExpression expression)
        {
            Expression = expression;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
