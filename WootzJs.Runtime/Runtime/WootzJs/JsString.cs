namespace System.Runtime.WootzJs
{
    [Js(Name = "String", Export = false)]
    public class JsString : JsObject
    {
        [Js(Name = "substring")]
        public string substring(int startIndex, int endIndex = 0)
        {
            return null;
        }

        [Js(Name = "split")]
        public JsArray split(string separator, int count = 0)
        {
            return null;
        }

        [Js(Name = "split")]
        public JsArray split(JsRegexLiteral separator, int count = 0)
        {
            return null;
        }

        [Js(Name = "split")]
        public JsArray split(JsRegExp separator, int count = 0)
        {
            return null;
        }

        [Js(Name = "charCodeAt")]
        public int charCodeAt(int index)
        {
            return 0;
        }

        [Js(Name = "charCodeAt")]
        public char charAt(int index)
        {
            return '?';
        }

        public static implicit operator string(JsString s)
        {
            return s.As<string>();
        }

        public static implicit operator JsString(string s)
        {
            return s.As<JsString>();
        }
    }
}
