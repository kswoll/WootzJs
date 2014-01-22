namespace WootzJs.Compiler.JsAst
{
    public class JsVariableReferenceExpression : JsExpression
    {
        public string Name { get; set; }

        public JsVariableReferenceExpression()
        {
        }

        public JsVariableReferenceExpression(string name)
        {
            Name = name;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
