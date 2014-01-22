namespace WootzJs.Compiler.JsAst
{
    public class JsConditionalExpression : JsExpression
    {
        public JsExpression Condition { get; set; }
        public JsExpression IfTrue { get; set; }
        public JsExpression IfFalse { get; set; }

        public JsConditionalExpression()
        {
        }

        public JsConditionalExpression(JsExpression condition, JsExpression ifTrue, JsExpression ifFalse)
        {
            Condition = condition;
            IfTrue = ifTrue;
            IfFalse = ifFalse;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
