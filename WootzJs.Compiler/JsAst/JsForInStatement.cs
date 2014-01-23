namespace WootzJs.Compiler.JsAst
{
    public class JsForInStatement : JsStatement
    {
        public JsVariableDeclaration Declaration { get; set; }
        public JsExpression Target { get; set; }
        public JsStatement Body { get; set; }

        public JsForInStatement()
        {
        }

        public JsForInStatement(JsVariableDeclaration declaration, JsExpression target) 
        {
            Declaration = declaration;
            Target = target;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
