using System;
using System.Collections.Generic;

namespace WootzJs.Compiler.JsAst
{
    public class JsInvocationExpression : JsExpression
    {
        public JsExpression Target { get; set; } 

        private List<JsExpression> arguments = new List<JsExpression>();

        public JsInvocationExpression()
        {
        }

        public void AddArgument(JsExpression argument)
        {
            if (argument == null)
                throw new ArgumentNullException();
            arguments.Add(argument);
        }

        public void AddArgumentRange(IEnumerable<JsExpression> arguments)
        {
            foreach (var argument in arguments)
                AddArgument(argument);
        }

        public IReadOnlyList<JsExpression> Arguments
        {
            get { return arguments; }
        }

        public JsInvocationExpression(JsExpression target) : this()
        {
            Target = target;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
