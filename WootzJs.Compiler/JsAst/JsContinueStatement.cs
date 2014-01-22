namespace WootzJs.Compiler.JsAst
{
    public class JsContinueStatement : JsStatement
    {
        public JsExpression Label { get; set; }

        public JsContinueStatement()
        {
        }

        public JsContinueStatement(JsExpression label)
        {
            Label = label;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
