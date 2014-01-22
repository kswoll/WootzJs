namespace WootzJs.Compiler.JsAst
{
    public class JsVariableDeclarator : JsNode, IJsDeclaration
    {
        public string Name { get; set; } 
        public JsExpression Initializer { get; set; }

        public JsVariableDeclarator()
        {
        }

        public JsVariableDeclarator(string name, JsExpression initializer)
        {
            Name = name;
            Initializer = initializer;
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
