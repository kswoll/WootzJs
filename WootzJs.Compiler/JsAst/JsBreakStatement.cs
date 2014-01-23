namespace WootzJs.Compiler.JsAst
{
    public class JsBreakStatement : JsStatement
    {
        public JsExpression Label { get; set; }

        public JsBreakStatement()
        {
        }

        public JsBreakStatement(JsExpression label)
        {
            Label = label;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
