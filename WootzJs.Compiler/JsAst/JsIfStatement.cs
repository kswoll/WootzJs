namespace WootzJs.Compiler.JsAst
{
    public class JsIfStatement : JsStatement
    {
        public JsExpression Condition { get; set; }
        public JsStatement IfTrue { get; set; }
        public JsStatement IfFalse { get; set; }

        public JsIfStatement()
        {
        }

        public JsIfStatement(JsExpression condition, JsStatement ifTrue)
        {
            Condition = condition;
            IfTrue = ifTrue;
        }

        public JsIfStatement(JsExpression condition, JsStatement ifTrue, JsStatement ifFalse)
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
