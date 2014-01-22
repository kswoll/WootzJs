namespace WootzJs.Compiler.JsAst
{
    public class JsParameter : JsNode, IJsDeclaration
    {
        public string Name { get; set; }

        public JsParameter()
        {
        }

        public JsParameter(string name)
        {
            Name = name;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }

        public JsExpression GetReference()
        {
            return Js.Reference(Name);
        }

        public JsExpression SetReference()
        {
            return Js.Reference(Name);
        }
    }
}
