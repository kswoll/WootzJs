using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    public class Browser
    {
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