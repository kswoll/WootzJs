namespace WootzJs.Compiler.JsAst
{
    public class JsInstanceOfExpression : JsExpression
    {
        public JsExpression Expression { get; set; } 
        public JsExpression Type { get; set; }

        public JsInstanceOfExpression()
        {
        }

        public JsInstanceOfExpression(JsExpression expression, JsExpression type)
        {
            Expression = expression;
            Type = type;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}