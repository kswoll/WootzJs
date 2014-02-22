
namespace WootzJs.Mvc.Views.Css
{
    public class CssFontWeight
    {
        private string value;

        public CssFontWeight(int value)
        {
            this.value = value.ToString();
        }

        public CssFontWeight(CssFontWeightType type)
        {
            value = type.GetName();
        }

        public static implicit operator CssFontWeight(int value)
        {
            return new CssFontWeight(value);
        }

        public static implicit operator CssFontWeight(CssFontWeightType value)
        {
            return new CssFontWeight(value);
        }

        public override string ToString()
        {
            return value;
        }

        public static CssFontWeight Parse(string s)
        {
            int value;
            if (int.TryParse(s, out value))
                return new CssFontWeight(value);
            else
                return new CssFontWeight(CssFontWeightTypes.Parse(s));
        }
    }
}