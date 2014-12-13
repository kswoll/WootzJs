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

        public static T WithHeight<T>(this T control, CssNumericValue value) where T : Control
        {
            control.Style.Height = value;
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

        public static T WithBackgroundColor<T>(this T control, CssColor color) where T : Control
        {
            control.Style.BackgroundColor = color;
            return control;
        }

        public static T WithPaddingTop<T>(this T control, CssNumericValue value) where T : Control
        {
            control.Style.Padding.Top = value;
            return control;
        }

        public static T WithPaddingBottom<T>(this T control, CssNumericValue value) where T : Control
        {
            control.Style.Padding.Bottom = value;
            return control;
        }

        public static T WithPaddingLeft<T>(this T control, CssNumericValue value) where T : Control
        {
            control.Style.Padding.Left = value;
            return control;
        }

        public static T WithPaddingRight<T>(this T control, CssNumericValue value) where T : Control
        {
            control.Style.Padding.Right = value;
            return control;
        }

        public static T WithDisplay<T>(this T control, CssDisplay value) where T : Control
        {
            control.Style.Display = value;
            return control;
        }

        public static T WithBorder<T>(this T control, CssBorder value) where T : Control
        {
            control.Style.Border = value;
            return control;
        }

        public static T WithBorderLeft<T>(this T control, CssBorderSide value) where T : Control
        {
            control.Style.Border.Left = value;
            return control;
        }

        public static T WithBorderTop<T>(this T control, CssBorderSide value) where T : Control
        {
            control.Style.Border.Top = value;
            return control;
        }

        public static T WithBorderRight<T>(this T control, CssBorderSide value) where T : Control
        {
            control.Style.Border.Right = value;
            return control;
        }

        public static T WithBorderBottom<T>(this T control, CssBorderSide value) where T : Control
        {
            control.Style.Border.Bottom = value;
            return control;
        }

        public static T WithWhiteSpace<T>(this T control, CssWhiteSpace value) where T : Control
        {
            control.Style.WhiteSpace = value;
            return control;
        }

        public static T WithFont<T>(this T control, CssFont value) where T : Control
        {
            control.Style.Font = value;
            return control;
        }
    }
}