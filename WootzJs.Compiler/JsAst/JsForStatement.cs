using System.Collections.Generic;

namespace WootzJs.Compiler.JsAst
{
    public class JsForStatement : JsStatement
    {
        public JsVariableDeclaration Declaration { get; set; }
        public JsExpression Condition { get; set; }
        public List<JsExpression> Incrementors { get; set; }
        public JsStatement Body { get; set; }

        public JsForStatement()
        {
            Incrementors = new List<JsExpression>();
        }

        public JsForStatement(JsVariableDeclaration declaration, JsExpression condition) : this()
        {
            Declaration = declaration;
            Condition = condition;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
