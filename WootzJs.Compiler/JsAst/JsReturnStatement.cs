namespace WootzJs.Compiler.JsAst
{
    public class JsReturnStatement : JsStatement
    {
        public JsExpression Expression { get; set; }

        public JsReturnStatement()
        {
        }

        public JsReturnStatement(JsExpression expression)
        {
            Expression = expression;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
