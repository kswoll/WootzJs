namespace WootzJs.Compiler.JsAst
{
    public class JsLocalVariableDeclaration : JsStatement
    {
        public JsVariableDeclaration Declaration { get; set; }

        public JsLocalVariableDeclaration()
        {
        }

        public JsLocalVariableDeclaration(JsVariableDeclaration declaration)
        {
            Declaration = declaration;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
