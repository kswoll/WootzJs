namespace WootzJs.Compiler.JsAst
{
    public class JsDoWhileStatement : JsStatement
    {
        public JsExpression Condition { get; set; }
        public JsStatement Body { get; set; }

        public JsDoWhileStatement()
        {
        }

        public JsDoWhileStatement(JsExpression condition, JsStatement body)
        {
            Condition = condition;
            Body = body;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}