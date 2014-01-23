namespace WootzJs.Compiler.JsAst
{
    public class JsCatchClause : JsNode
    {
        public JsVariableDeclarator Declaration { get; set; }
        public JsBlockStatement Body { get; set; }

        public JsCatchClause()
        {
            Body = new JsBlockStatement();
        }

        public JsCatchClause(JsVariableDeclarator declaration) : this()
        {
            Declaration = declaration;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
