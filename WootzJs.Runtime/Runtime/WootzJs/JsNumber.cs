namespace System.Runtime.WootzJs
{
    [Js(Name = "Number", Export = false)]
    public class JsNumber : JsObject
    {
        public JsNumber valueOf()
        {
            return null;
        }

        public static bool operator <(JsNumber left, JsNumber right)
        {
            return false;
        }

        public static bool operator >(JsNumber left, JsNumber right)
        {
            return false;            
        }

        public static JsNumber operator -(JsNumber left, JsNumber right)
        {
            return null;
        }

        public static JsNumber operator +(JsNumber left, JsNumber right)
        {
            return null;
        }

        public static JsNumber operator /(JsNumber left, JsNumber right)
        {
            return null;
        }

        public static JsNumber operator *(JsNumber left, JsNumber right)
        {
            return null;
        }

        public static JsNumber operator %(JsNumber left, JsNumber right)
        {
            return null;
        }
    }
}
