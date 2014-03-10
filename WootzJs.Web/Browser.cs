using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    public class Browser
    {
        public const string InternetExplorer = "MSIE";
        public const string Chrome = "Chrome";
        public const string Firefox = "Mozilla";
        public const string Opera = "Opera";

        public static Window Window
        {
            get { return Jsni.reference("window").As<Window>(); }
        }

        public static Document Document
        {
            get { return Jsni.reference("document").As<Document>(); }
        }
    }
}