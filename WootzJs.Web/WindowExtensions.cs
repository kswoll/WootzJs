#region License

//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------

#endregion

using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    public static class WindowExtensions
    {
        private static string browserProduct;
        private static string browserVersion;

        public static bool IsTouchDevice(this Window window)
        {
            return "ontouchstart".@in(window) || "onmsgesturechange".@in(window);
        }

        public static string GetBrowserProduct(this Window window)
        {
            window.GetBrowserInfo();
            return browserProduct;
        }

        public static string GetBrowserVersion(this Window window)
        {
            window.GetBrowserInfo();
            return browserVersion;
        }

        private static void GetBrowserInfo(this Window window)
        {
            if (browserProduct != null)
                return;

            var userAgent = window.Navigator.UserAgent;
            var match = userAgent.match(Jsni.regex(@"(opera|chrome|safari|firefox|msie|trident(?=\/))\/?\s*([\d\.]+)", "i")) ?? Jsni.array();
            if (Jsni.regex("trident", "i").test(match[1].As<JsString>()))
            {
                browserProduct = "MSIE";
                browserVersion = (Jsni.regex(@"\brv[ :]+(\d+(\.\d+)?)", "g").exec(userAgent) ?? new string[0])[1] ?? "";
                return;
            }
            if (match[2])
            {
                browserProduct = match[1].As<JsString>();
                browserVersion = match[2].As<JsString>();
            }
            else
            {
                browserProduct = window.Navigator.AppName;
                browserVersion = window.Navigator.AppVersion;
            }
            var tailVersion = userAgent.match(Jsni.regex(@"version\/([\.\d]+)", "i"));
            if (tailVersion != null)
                browserVersion = tailVersion[1].As<JsString>();
        }
    }
}