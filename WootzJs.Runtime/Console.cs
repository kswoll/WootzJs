using System.Runtime.WootzJs;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public class Console
    {
        public static void WriteLine(string s)
        {
            Jsni.invoke(Jsni.member(Jsni.reference("console"), "log"), s.As<JsString>());
        }

        public static void WriteLine(object o)
        {
            WriteLine(o.ToString());
        }
    }
}
