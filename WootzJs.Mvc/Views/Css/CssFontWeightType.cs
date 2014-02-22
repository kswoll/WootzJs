using System;

namespace WootzJs.Mvc.Views.Css
{
    public enum CssFontWeightType
    {
        Normal,
        Bold,
        Bolder,
        Lighter,
        Inherit
    }

    public static class CssFontWeightTypes
    {
        public static string GetName(this CssFontWeightType value)
        {
            switch (value)
            {
                case CssFontWeightType.Bold: return "bold";
                case CssFontWeightType.Bolder: return "bolder";
                case CssFontWeightType.Inherit: return "inherit";
                case CssFontWeightType.Lighter: return "lighter";
                case CssFontWeightType.Normal: return "normal";
                default: throw new Exception("Unknown value: " + value);
            }
        }

        public static CssFontWeightType Parse(string s)
        {
            switch (s)
            {
                case null:
                case "normal": return CssFontWeightType.Normal;
                case "bold": return CssFontWeightType.Normal;
                case "bolder": return CssFontWeightType.Normal;
                case "lighter": return CssFontWeightType.Normal;
                case "inherit": return CssFontWeightType.Normal;
                default: throw new Exception("Unexpected value: " + s);
            }
        }
    }
}