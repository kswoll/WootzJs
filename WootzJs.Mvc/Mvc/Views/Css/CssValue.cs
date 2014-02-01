
namespace WootzJs.Mvc.Mvc.Views.Css
{
    public class CssValue
    {
        public static CssValue Parse(string value)
        {
            if (value == "inherit")
                return CssInherit.Instance;
            if (value == "inset")
                return CssInset.Instance;

            var result = CssColor.Parse(value);
            if (result != null)
                return result;

            return CssNumericValue.Parse(value);
        }
    }
}