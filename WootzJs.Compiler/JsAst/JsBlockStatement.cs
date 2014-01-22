using System.Collections.Generic;
using System.Linq;

namespace WootzJs.Compiler.JsAst
{
    public class JsBlockStatement : JsStatement
    {
        public bool Inline { get; set; }

        private List<JsStatement> statements = new List<JsStatement>();

        public IReadOnlyCollection<JsStatement> Statements
        {
            get { return statements; }
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Add(JsStatement statement)
        {
            statements.Add(statement);
        }

        public void Aggregate(JsStatement statement)
        {
            if (statement is JsBlockStatement)
            {
                var block = (JsBlockStatement)statement;
                foreach (var current in block.Statements)
                {
                    statements.Add(current);
                }
            }
            else
            {
                Add(statement);
            }
        }
    }
}
