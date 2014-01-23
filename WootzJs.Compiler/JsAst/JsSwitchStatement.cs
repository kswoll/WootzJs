using System.Collections.Generic;

namespace WootzJs.Compiler.JsAst
{
    public class JsSwitchStatement : JsStatement
    {
        public JsExpression Expression { get; set; }
        public List<JsSwitchSection> Sections { get; set; }

        public JsSwitchStatement()
        {
            Sections = new List<JsSwitchSection>();
        }

        public JsSwitchStatement(JsExpression expression) : this()
        {
            Expression = expression;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
