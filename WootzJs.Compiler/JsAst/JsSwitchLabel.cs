namespace WootzJs.Compiler.JsAst
{
    public class JsSwitchLabel : JsNode
    {
        public bool IsDefault { get; set; }
        public JsExpression Value { get; set; }

        public JsSwitchLabel()
        {
        }

        public JsSwitchLabel(bool isDefault, JsExpression value)
        {
            IsDefault = isDefault;
            Value = value;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
