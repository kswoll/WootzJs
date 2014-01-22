namespace WootzJs.Compiler.JsAst
{
    public class JsWhileStatement : JsStatement
    {
        public JsExpression Condition { get; set; }
        public JsStatement Body { get; set; }

        public JsWhileStatement()
        {
        }

        public JsWhileStatement(JsExpression condition, JsStatement body)
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
