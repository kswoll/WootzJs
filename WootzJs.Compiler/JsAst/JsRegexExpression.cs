namespace WootzJs.Compiler.JsAst
{
    public class JsRegexExpression : JsExpression
    {
        public string Pattern { get; set; }

        public JsRegexExpression()
        {
        }

        public JsRegexExpression(string pattern)
        {
            Pattern = pattern;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
