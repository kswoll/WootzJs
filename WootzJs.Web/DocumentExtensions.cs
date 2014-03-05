using System;
using System.Linq;
using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    public static class DocumentExtensions
    {
//        private static int mouseX;
//        private static int mouseY;

/*
        static DocumentExtensions()
        {
            Browser.Document.AddEventListener("mousemove", evt =>
            {
                var mouseEvent = (MouseEvent)evt;
                mouseX = mouseEvent.ScreenX;
                mouseY = mouseEvent.ScreenY;
            });
        }

        public static int GetMouseX(this Document document)
        {
            return mouseX;
        }

        public static int GetMouseY(this Document document)
        {
            return mouseY;
        }
*/

        public static Element GetElementByTagName(this Document document, string tagName)
        {
            var result = document.GetElementsByTagName(tagName);
            return result.Length > 0 ? result[0] : null;
        }

        public static Event CreateCustomEvent(this Document document, string eventType, object args)
        {
            try
            {
                return Jsni.@new(Jsni.reference("CustomEvent"), eventType, args.As<JsObject>()).As<Event>();
            } 
            catch (Exception e)
            {
                var evt = document.CreateEvent("CustomEvent");
                evt.As<JsObject>().member("initCustomEvent").invoke(eventType, false, true, args.As<JsObject>());
                return evt;
            }
        }

        public static string GetCookie(this Document document, string name)
        {
            var allCookies = document.Cookie;
            var tokens = allCookies
                .Split(';')
                .Select(x => x.Split('='))
                .Select(x => new { Name = x[0], Value = x[1] })
                .ToArray();
            var token = tokens.SingleOrDefault(x => x.Name == name);
            if (token == null)
                return null;

            return token.Value;
        }

        public static void SetCookie(this Document document, string name, Cookie value)
        {
            var newValue = value.Encode();
            document.Cookie = name + "=" + newValue;
        }

        public static void DeleteCookie(this Document document, string name)
        {
            var cookie = new Cookie
            {
                Value = "", 
                MaxAge = TimeSpan.FromSeconds(0)
            };
            var newValue = cookie.Encode();
            document.Cookie = name + "=" + newValue;
        }
    }
}