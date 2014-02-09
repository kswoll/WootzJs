using System;

namespace WootzJs.Mvc.Mvc.Views
{
    public enum TextBoxType
    {
        Text, Password, Color, Email, Number, Range, Search, Telephone, Url
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
                default:
                    throw new Exception();
            }
        }
    }
}