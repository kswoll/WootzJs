namespace WootzJs.Compiler.JsAst
{
    public abstract class JsNode
    {
        public bool IsCompacted { get; set; }

        public abstract void Accept(IJsVisitor visitor);

        public override string ToString()
        {
            var renderer = new JsRenderer();
            Accept(renderer);
            return renderer.Output;
        }
    }
}
