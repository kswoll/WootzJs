namespace WootzJs.Compiler.JsAst
{
    public class JsUnaryExpression : JsExpression
    {
        public JsUnaryOperator Operator { get; set; } 
        public JsExpression Operand { get; set; }

        public JsUnaryExpression()
        {
        }

        public JsUnaryExpression(JsUnaryOperator @operator, JsExpression operand)
        {
            Operator = @operator;
            Operand = operand;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
