namespace WootzJs.Compiler.JsAst
{
    public class JsLabeledStatement : JsStatement
    {
        public string Label { get; set; }
        public JsStatement Statement { get; set; }

        public JsLabeledStatement()
        {
        }

        public JsLabeledStatement(string label, JsStatement statement)
        {
            Label = label;
            Statement = statement;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}