using System;

namespace WootzJs.Mvc.Views.Css
{
    public enum CssUnit
    {
        Pixels,
        Percent,
        Auto
    }

    public static class CssUnits
    {
        public static string GetAbbreviation(this CssUnit unit)
        {
            switch (unit)
            {
                case CssUnit.Pixels:
                    return "px";
                case CssUnit.Percent:
                    return "%";
                default:
                    throw new InvalidOperationException("Unknown unit: " + unit);
            }
        }

        public static CssUnit Parse(string s)
        {
            switch (s)
            {
                case "px":
                case "":
                    return CssUnit.Pixels;
                case "%":
                    return CssUnit.Percent;
                default:
                    throw new InvalidOperationException("Unknown unit: " + s);
            }
        }
    }
}