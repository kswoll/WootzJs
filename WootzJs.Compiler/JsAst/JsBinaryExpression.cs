namespace WootzJs.Compiler.JsAst
{
    public class JsBinaryExpression : JsExpression
    {
        public JsBinaryOperator Operator { get; set; }
        public JsExpression Left { get; set; }
        public JsExpression Right { get; set; }

        public JsBinaryExpression()
        {
        }

        public JsBinaryExpression(JsBinaryOperator @operator, JsExpression left, JsExpression right)
        {
            Operator = @operator;
            Left = left;
            Right = right;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
