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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.WootzJs;
using System.Text;
using System.Web;

namespace WootzJs.Web
{
    public class Cookie
    {
        public string Value { get; set; }
        public string Path { get; set; }
        public string Domain { get; set; }
        public TimeSpan? MaxAge { get; set; }
        public DateTime? Expires { get; set; }
        public bool IsSecure { get; set; }

        public string Encode()
        {
            var builder = new StringBuilder();
            
            var value = HttpUtility.UrlEncode(Value);
            builder.Append(value);

            if (Path != null)
                builder.Append(";path=" + Path);

            if (Domain != null)
                builder.Append(";domain=" + Domain);

            if (MaxAge != null)
            {
                var maxAgeInSeconds = (int)MaxAge.Value.TotalSeconds;
                builder.Append(";max-age=" + maxAgeInSeconds);
            }

            if (Expires != null)
            {
                var expiresString = Expires.Value.JsDate.toUTCString();
                builder.Append(";expires=" + expiresString);
            }

            if (IsSecure)
            {
                builder.Append(";secure");
            }

            return builder.ToString();
        }

        public static Cookie Decode(string s)
        {
            var cookie = new Cookie();
            var parts = new Queue<string>(s.Split(';'));

            var value = parts.Dequeue();
            cookie.Value = HttpUtility.UrlDecode(value);

            while (parts.Any())
            {
                var part = parts.Dequeue();
                var nameValue = part.Split('=');
                var partName = nameValue[0];
                var partValue = nameValue.Length > 1 ? nameValue[1] : null;
                switch (partName)
                {
                    case "path":
                        cookie.Path = partValue;
                        break;
                    case "domain":
                        cookie.Domain = partValue;
                        break;
                    case "max-age":
                        var maxAgeInSeconds = int.Parse(partValue);
                        var maxAge = TimeSpan.FromSeconds(maxAgeInSeconds);
                        cookie.MaxAge = maxAge;
                        break;
                    case "expires":
                        var expires = new DateTime(new JsDate(JsDate.parse(partValue)));
                        cookie.Expires = expires;
                        break;
                    case "secure":
                        cookie.IsSecure = true;
                        break;
                }
            }
            return cookie;
        }
    }
}