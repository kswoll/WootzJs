namespace WootzJs.Compiler.JsAst
{
    public class JsObjectItem : JsNode
    {
        public string Name { get; set; } 
        public JsExpression Value { get; set; }

        public JsObjectItem()
        {
        }

        public JsObjectItem(string name, JsExpression value)
        {
            Name = name;
            Value = value;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
