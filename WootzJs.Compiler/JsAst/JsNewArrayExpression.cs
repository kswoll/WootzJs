namespace WootzJs.Compiler.JsAst
{
    public class JsNewArrayExpression : JsExpression
    {
        public JsExpression Size { get; set; }

        public JsNewArrayExpression()
        {
        }

        public JsNewArrayExpression(JsExpression size)
        {
            Size = size;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
