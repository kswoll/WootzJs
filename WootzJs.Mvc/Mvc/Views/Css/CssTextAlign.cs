using System;

namespace WootzJs.Mvc.Mvc.Views.Css
{
    public enum CssTextAlign
    {
        Left, Right, Center, Justified 
    }

    public static class CssTextAligns
    {
        public static string GetCssValue(this CssTextAlign value)
        {
            return value.ToString().ToLower();
        }

        public static CssTextAlign Parse(string s)
        {
            switch (s)
            {
                case "left": return CssTextAlign.Left;
                case "center": return CssTextAlign.Center;
                case "right": return CssTextAlign.Right;
                case "justified": return CssTextAlign.Justified;
                default: throw new InvalidOperationException("Unknown text align: " + s);
            }
        }
    }
}