
namespace WootzJs.Mvc.Mvc.Views.Css
{
    public class CssInherit : CssValue
    {
        private static CssInherit instance = new CssInherit();

        public static CssInherit Instance
        {
            get { return instance; }
        }
    }
}