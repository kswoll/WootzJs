using System;

namespace WootzJs.Mvc.Views.Css
{
    public enum CssFontStyle
    {
        Normal, 
        Italic,
        Oblique,
        Inherit
    }

    public static class CssFontStyles
    {
        public static string GetName(this CssFontStyle value)
        {
            switch (value)
            {
                case CssFontStyle.Inherit: return "inherit";
                case CssFontStyle.Italic: return "italic";
                case CssFontStyle.Normal: return "normal";
                case CssFontStyle.Oblique: return "oblique";
                default: throw new Exception("Unable to get name for: " + value);
            }
        }

        public static CssFontStyle Parse(string s)
        {
            switch (s)
            {
                case null:
                case "normal": return CssFontStyle.Normal;
                case "italic": return CssFontStyle.Italic;
                case "oblique": return CssFontStyle.Oblique;
                case "inherit": return CssFontStyle.Inherit;
                default: throw new Exception("Unable to parse: " + s);
            }
        }
    }
}