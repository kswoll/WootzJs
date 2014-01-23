namespace WootzJs.Compiler.JsAst
{
    public class JsThrowStatement : JsStatement
    {
        public JsExpression Expression { get; set; }

        public JsThrowStatement()
        {
        }

        public JsThrowStatement(JsExpression expression)
        {
            Expression = expression;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
