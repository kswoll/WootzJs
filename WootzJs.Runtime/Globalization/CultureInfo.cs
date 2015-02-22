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

using System.Collections.Generic;
using System.Linq;
using System.Runtime.WootzJs;

namespace System.Globalization
{
    /// <summary>
    /// Provides information about a specific culture (called a locale for unmanaged code development). The information includes the names for the culture, the writing system, the calendar used, and formatting for dates and sort strings.
    /// </summary>
    public class CultureInfo : IFormatProvider
    {
        public static CultureInfo CurrentCulture { get; private set; }
        public static readonly CultureInfo InvariantCulture = new CultureInfo();
        public static readonly CultureInfo Ordinal = new CultureInfo();
        public static readonly CultureInfo OrdinalIgnoreCase = new CultureInfo();

        public string Name { get; private set; }
        public CompareInfo CompareInfo { get; private set; }
        public DateTimeFormatInfo DateTimeFormat { get; private set; }

        private static readonly List<CultureInfo> cultures = new List<CultureInfo>();
        private static string currentCultureName;

        static CultureInfo()
        {
            CurrentCulture = new CultureInfo();

            // Set up default culture
            var navigator = Jsni.reference("window").member("navigator");
            currentCultureName = (navigator.member("userLanguage") ?? navigator.member("language") ?? navigator.member("browserLanguage") ?? navigator.member("systemLanguage")).As<string>();
        }

        public CultureInfo()
        {
            CompareInfo = new CompareInfo();
        }

        internal static void RegisterCulture(string name, string shortDatePattern, string longDatePattern, string shortTimePattern, string longTimePattern, string fullDateTimePattern, string yearMonthPattern, string[] monthNames, string[] abbreviatedMonthNames, string[] dayNames)
        {
            cultures.Add(new CultureInfo
            {
                Name = name,
                DateTimeFormat = new DateTimeFormatInfo(shortDatePattern, shortTimePattern, longDatePattern, longTimePattern, fullDateTimePattern, yearMonthPattern, monthNames, abbreviatedMonthNames, dayNames)
            });
            if (name.ToUpper() == currentCultureName.ToUpper())
            {
                var currentCulture = cultures.SingleOrDefault(x => x.Name == name.As<string>());
                CurrentCulture = currentCulture;
            }
        }

        public object GetFormat(Type formatType)
        {
            return null;
        }

        public static CultureInfo CurrentUICulture
        {
            get { return CurrentCulture; }
        }
    }
}
