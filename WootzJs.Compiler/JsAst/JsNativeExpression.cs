namespace WootzJs.Compiler.JsAst
{
    public class JsNativeExpression : JsExpression
    {
        public string Code { get; set; }

        public JsNativeExpression()
        {
        }

        public JsNativeExpression(string code)
        {
            Code = code;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override T Accept<T>(IJsVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}