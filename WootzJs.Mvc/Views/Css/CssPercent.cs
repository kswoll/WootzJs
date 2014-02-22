
namespace WootzJs.Mvc.Views.Css
{
    public class CssPercent : CssValue
    {
        private float value;

        public CssPercent(float value)
        {
            this.value = value;
        }

        public static implicit operator CssPercent(float value)
        {
            return new CssPercent(value);
        }

        public float Value
        {
            get { return value; }
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public new static CssPercent Parse(string s)
        {
            return float.Parse(s);
        }
    }
}