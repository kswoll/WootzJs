namespace WootzJs.Compiler.JsAst
{
    public interface IJsDeclaration
    {
        string Name { get; }
        JsExpression GetReference();
        JsExpression SetReference();
    }
}
