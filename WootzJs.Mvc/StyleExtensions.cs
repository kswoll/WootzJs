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
    }
}