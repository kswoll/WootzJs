using System;

namespace WootzJs.Mvc.Views
{
    public enum TextBoxType
    {
        Text, Password, Color, Email, Number, Range, Search, Telephone, Url, Date, DateTime, Time
    }

    public static class TextBoxTypes
    {
        public static string GetInputType(this TextBoxType type)
        {
            switch (type)
            {
                case TextBoxType.Color:
                    return "color";
                case TextBoxType.Email:
                    return "email";
                case TextBoxType.Number:
                    return "number";
                case TextBoxType.Password:
                    return "password";
                case TextBoxType.Range:
                    return "range";
                case TextBoxType.Url:
                    return "url";
                case TextBoxType.Search:
                    return "search";
                case TextBoxType.Telephone:
                    return "tel";
                case TextBoxType.Text:
                    return "text";
                case TextBoxType.Date:
                    return "date";
                case TextBoxType.DateTime:
                    return "datetime";
                case TextBoxType.Time:
                    return "time";
                default:
                    throw new Exception();
            }
        }

        public static TextBoxType Parse(string s)
        {
            switch (s)
            {
                case "color":
                    return TextBoxType.Color;
                case "email":
                    return TextBoxType.Email;
                case "number":
                    return TextBoxType.Number;
                case "password":
                    return TextBoxType.Password;
                case "range":
                    return TextBoxType.Range;
                case "url":
                    return TextBoxType.Url;
                case "search":
                    return TextBoxType.Search;
                case "tel":
                    return TextBoxType.Telephone;
                case "text":
                    return TextBoxType.Text;
                case "date":
                    return TextBoxType.Date;
                case "datetime":
                    return TextBoxType.DateTime;
                case "time":
                    return TextBoxType.Time;
                default:
                    throw new Exception();
            }
        }
    }
}