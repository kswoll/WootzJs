namespace WootzJs.Compiler.JsAst
{
    public class JsPrimitiveExpression : JsExpression
    {
        private object value;

        public JsPrimitiveExpression()
        {
        }

        public JsPrimitiveExpression(bool value)
        {
            this.value = value;
        }

        public JsPrimitiveExpression(int value)
        {
            this.value = value;
        }

        public JsPrimitiveExpression(char value)
        {
            this.value = value;
        }

        public JsPrimitiveExpression(uint value)
        {
            this.value = value;
        }

        public JsPrimitiveExpression(float value)
        {
            this.value = value;
        }

        public JsPrimitiveExpression(double value)
        {
            this.value = value;
        }

        public JsPrimitiveExpression(string value)
        {
            this.value = value;
        }

        public object Value
        {
            get { return value; }
        }

        public override void Accept(IJsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
