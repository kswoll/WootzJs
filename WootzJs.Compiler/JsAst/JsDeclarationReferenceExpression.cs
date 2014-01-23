namespace WootzJs.Compiler.JsAst
{
    public class JsDeclarationReferenceExpression : JsExpression
    {
        public IJsDeclaration Declaration { get; set; }

        public JsDeclarationReferenceExpression()
        {
        }

        public JsDeclarationReferenceExpression(IJsDeclaration declaration)
        {
            Declaration = declaration;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
