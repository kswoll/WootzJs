using System.Collections.Generic;

namespace WootzJs.Compiler.JsAst
{
    public class JsSwitchSection : JsNode
    {
        public List<JsSwitchLabel> Labels { get; set; }
        public List<JsStatement> Statements { get; set; }

        public JsSwitchSection()
        {
            Labels = new List<JsSwitchLabel>();
            Statements = new List<JsStatement>();
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
