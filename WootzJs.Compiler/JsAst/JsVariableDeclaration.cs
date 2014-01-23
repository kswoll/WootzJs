using System.Collections.Generic;

namespace WootzJs.Compiler.JsAst
{
    public class JsVariableDeclaration : JsNode
    {
        public List<JsVariableDeclarator> Declarations { get; set; }

        public JsVariableDeclaration()
        {
            Declarations = new List<JsVariableDeclarator>();
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
