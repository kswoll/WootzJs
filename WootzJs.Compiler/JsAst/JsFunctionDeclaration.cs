namespace WootzJs.Compiler.JsAst
{
    public class JsFunctionDeclaration : JsStatement
    {
        public JsFunction Function { get; set; }

        public JsFunctionDeclaration(JsFunction function)
        {
            Function = function;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
