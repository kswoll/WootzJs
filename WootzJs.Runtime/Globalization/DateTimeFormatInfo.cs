namespace System.Globalization
{
    public class DateTimeFormatInfo
    {
        public string ShortDatePattern { get; private set; }
        public string ShortTimePattern { get; private set; }
        public string LongDatePattern { get; private set; }
        public string LongTimePattern { get; private set; }
        public string FullDateTimePattern { get; private set; }
        public string[] MonthNames { get; private set; }
        public string[] DayNames { get; private set; }

        public DateTimeFormatInfo(string shortDatePattern, string shortTimePattern, string longDatePattern, string longTimePattern, string fullDateTimePattern, string[] monthNames, string[] dayNames)
        {
            ShortDatePattern = shortDatePattern;
            ShortTimePattern = shortTimePattern;
            LongDatePattern = longDatePattern;
            LongTimePattern = longTimePattern;
            FullDateTimePattern = fullDateTimePattern;
            MonthNames = monthNames;
            DayNames = dayNames;
        }

        public string GetMonthName(int month)
        {
            return MonthNames[month - 1];
        }
        
        public string GetDayName(DayOfWeek day)
        {
            return DayNames[(int)day];
        }
    }
}