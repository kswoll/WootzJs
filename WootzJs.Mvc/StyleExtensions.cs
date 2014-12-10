using WootzJs.Mvc.Views;
using WootzJs.Mvc.Views.Css;

namespace WootzJs.Mvc
{
    public static class StyleExtensions
    {
        public static T WithBold<T>(this T control) where T : Control
        {
            control.Style.Font.Weight = new CssFontWeight(CssFontWeightType.Bold);
            return control;
        }

        public static T WithPadding<T>(this T control, CssPadding padding) where T : Control
        {
            control.Style.Padding = padding;
            return control;
        }

        public static T WithWidth<T>(this T control, CssNumericValue width) where T : Control
        {
            control.Style.Width = width;
            return control;
        }

        public static T WithMaxWidth<T>(this T control, CssNumericValue width) where T : Control
        {
            control.Style.MaxWidth = width;
            return control;
        }

        public static T WithColor<T>(this T control, CssColor color) where T : Control
        {
            control.Style.Color = color;
            return control;
        }
    }
}