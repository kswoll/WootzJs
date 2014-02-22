
namespace WootzJs.Mvc.Views.Css
{
    public sealed class CssInset : CssValue
    {
        public static readonly CssInset Instance = new CssInset();

        public override string ToString()
        {
            return "inset";
        }

        public static implicit operator CssInset(bool value)
        {
            return new CssInset();
        }
    }
}