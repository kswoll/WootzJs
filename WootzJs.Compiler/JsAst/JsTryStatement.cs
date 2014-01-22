namespace WootzJs.Compiler.JsAst
{
    public class JsTryStatement : JsStatement
    {
        public JsBlockStatement Body { get; set; }
        public JsCatchClause Catch { get; set; }
        public JsBlockStatement Finally { get; set; }

        public JsTryStatement()
        {
            Body = new JsBlockStatement();
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
