namespace WootzJs.Compiler.JsAst
{
    public class JsThisExpression : JsExpression
    {
        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
