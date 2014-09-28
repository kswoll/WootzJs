namespace System.Globalization
{
    public class DateTimeFormatInfo
    {
        public string ShortDatePattern { get; private set; }
        public string ShortTimePattern { get; private set; }
        public string LongDatePattern { get; private set; }
        public string LongTimePattern { get; private set; }
        public string FullDateTimePattern { get; private set; }
        public string YearMonthPattern { get; private set; }
        public string[] MonthNames { get; private set; }
        public string[] AbbreviatedMonthNames { get; private set; }
        public string[] DayNames { get; private set; }

        public DateTimeFormatInfo(string shortDatePattern, string shortTimePattern, string longDatePattern, string longTimePattern, string fullDateTimePattern, string yearMonthPattern, string[] monthNames, string[] abbreviatedMonthNames, string[] dayNames)
        {
            ShortDatePattern = shortDatePattern;
            ShortTimePattern = shortTimePattern;
            LongDatePattern = longDatePattern;
            LongTimePattern = longTimePattern;
            FullDateTimePattern = fullDateTimePattern;
            YearMonthPattern = yearMonthPattern;
            MonthNames = monthNames;
            AbbreviatedMonthNames = abbreviatedMonthNames;
            DayNames = dayNames;
        }

        public string GetMonthName(int month)
        {
            return MonthNames[month - 1];
        }
        
        public string GetAbbreviatedMonthName(int month)
        {
            return AbbreviatedMonthNames[month - 1];
        }
        
        public string GetDayName(DayOfWeek day)
        {
            return DayNames[(int)day];
        }
    }
}