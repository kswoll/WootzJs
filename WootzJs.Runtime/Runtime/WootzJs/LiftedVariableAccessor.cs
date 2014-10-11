namespace System.Runtime.WootzJs
{
    public class LiftedVariableAccessor
    {
        public JsFunction Getter { get; private set; }
        public JsFunction Setter { get; private set; }

        public LiftedVariableAccessor(JsFunction getter, JsFunction setter)
        {
            Getter = getter;
            Setter = setter;
        }
    }
}