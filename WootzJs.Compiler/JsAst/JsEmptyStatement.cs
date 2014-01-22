namespace WootzJs.Compiler.JsAst
{
    public class JsEmptyStatement : JsStatement
    {
        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
