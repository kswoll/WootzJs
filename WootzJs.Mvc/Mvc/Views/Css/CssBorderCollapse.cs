using System;

namespace WootzJs.Mvc.Mvc.Views.Css
{
    public enum CssBorderCollapse
    {
        Collapse
    }

    public static class CssBorderCollapses
    {
        public static string GetValue(this CssBorderCollapse value)
        {
            switch (value)
            {
                case CssBorderCollapse.Collapse:
                    return "collapse";
                default:
                    throw new InvalidOperationException("Unknown border-collapse: " + value);
            }
        }

        public static CssBorderCollapse Parse(string s)
        {
            switch (s)
            {
                case "collapse":
                    return CssBorderCollapse.Collapse;
                default:
                    throw new InvalidOperationException("Unknown value for border-collapse: " + s);
            }
        }
    }
}