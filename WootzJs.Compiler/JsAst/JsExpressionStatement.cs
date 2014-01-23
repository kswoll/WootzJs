namespace WootzJs.Compiler.JsAst
{
    public class JsExpressionStatement : JsStatement
    {
        public JsExpression Expression { get; set; }

        public JsExpressionStatement()
        {
        }

        public JsExpressionStatement(JsExpression expression)
        {
            Expression = expression;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
