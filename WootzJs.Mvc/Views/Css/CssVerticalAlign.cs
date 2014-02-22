
using System;

namespace WootzJs.Mvc.Views.Css
{
    public enum CssVerticalAlign
    {
        Top, Middle, Bottom
    }

    public static class CssVerticalAligns
    {
        public static string GetCssValue(this CssVerticalAlign value)
        {
            return value.ToString().ToLower();
        }

        public static CssVerticalAlign Parse(string s)
        {
            switch (s)
            {
                case "top": return CssVerticalAlign.Top;
                case "middle": return CssVerticalAlign.Middle;
                case "bottom": return CssVerticalAlign.Bottom;
                default: throw new InvalidOperationException("Unknown text align: " + s);
            }
        }
    }
}