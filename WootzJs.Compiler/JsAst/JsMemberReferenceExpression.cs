namespace WootzJs.Compiler.JsAst
{
    public class JsMemberReferenceExpression : JsExpression
    {
        public JsExpression Target { get; set; }
        public string Name { get; set; }

        public JsMemberReferenceExpression()
        {
        }

        public JsMemberReferenceExpression(JsExpression target, string name)
        {
            Target = target;
            Name = name;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
