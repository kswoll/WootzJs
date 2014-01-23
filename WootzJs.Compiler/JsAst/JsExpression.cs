namespace WootzJs.Compiler.JsAst
{
    public abstract class JsExpression : JsNode
    {
        public static implicit operator JsExpression(bool value)
        {
            return new JsPrimitiveExpression(value);
        }
    }
}
