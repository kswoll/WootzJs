using System;

namespace WootzJs.Mvc.Views.Css
{
    public enum CssTextTransform
    {
        None,
        Capitalize,
        Uppercase,
        Lowercase,
        FullWidth,
        Inherit
    }

    public static class CssTextTransforms
    {
        public static string GetCssValue(this CssTextTransform value)
        {
            switch (value)
            {
                case CssTextTransform.None:
                    return "none";
                case CssTextTransform.Capitalize:
                    return "capitalize";
                case CssTextTransform.Lowercase:
                    return "lowercase";
                case CssTextTransform.Uppercase:
                    return "uppercase";
                case CssTextTransform.FullWidth:
                    return "full-width";
                case CssTextTransform.Inherit:
                    return "inherit";
                default:
                    throw new Exception();
            }
        }

        public static CssTextTransform Parse(string s)
        {
            switch (s)
            {
                case "none":
                    return CssTextTransform.None;
                case "capitalize":
                    return CssTextTransform.Capitalize;
                case "lowercase":
                    return CssTextTransform.Lowercase;
                case "uppercase":
                    return CssTextTransform.Uppercase;
                case "full-width":
                    return CssTextTransform.FullWidth;
                case "inherit":
                    return CssTextTransform.Inherit;
                default:
                    throw new Exception();
            }
        }
    }
}