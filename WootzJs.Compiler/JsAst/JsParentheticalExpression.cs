namespace WootzJs.Compiler.JsAst
{
    public class JsParentheticalExpression : JsExpression
    {
        public JsExpression Expression { get; set; }

        public JsParentheticalExpression()
        {
        }

        public JsParentheticalExpression(JsExpression expression)
        {
            Expression = expression;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
