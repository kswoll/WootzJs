using System.Collections.Generic;

namespace WootzJs.Compiler.JsAst
{
    public class JsFunction : JsExpression
    {
        public string Name { get; set; }
        public List<IJsDeclaration> Parameters { get; set; }
        public JsBlockStatement Body { get; set; }

        public JsFunction()
        {
            Parameters = new List<IJsDeclaration>();
            Body = new JsBlockStatement();
        }

        public JsFunction(string name) : this()
        {
            Name = name;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
