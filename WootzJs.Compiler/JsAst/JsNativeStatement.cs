namespace WootzJs.Compiler.JsAst
{
    public class JsNativeStatement : JsStatement
    {
        public string Code { get; set; }

        public JsNativeStatement()
        {
        }

        public JsNativeStatement(string code)
        {
            Code = code;
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
