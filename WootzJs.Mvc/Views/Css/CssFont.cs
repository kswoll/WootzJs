using System.Linq;

namespace WootzJs.Mvc.Views.Css
{
    public class CssFont : CssDeclaration
    {
        public string[] Families
        {
            get
            {
                var family = Get("font-family");
                if (family == null)
                    return null;
                else
                    return family.Split(' ');
            }
            set
            {
                Set("font-family", string.Join(",", value.Select(x => x.Contains(" ") ? "\"" + x + "\"" : x).ToArray()));
            }
        }

        public string Family
        {
            get
            {
                return Get("font-family");
            }
            set
            {
                Set("font-family", value.Contains(" ") ? "\"" + value + "\"" : value);
            }
        }

        public CssNumericValue Size
        {
            get { return CssNumericValue.Parse(Get("font-size")); }
            set { Set("font-size", value); }
        }

        public CssFontStyle Style
        {
            get { return CssFontStyles.Parse(Get("font-style")); }
            set { Set("font-style", value.GetName()); }
        }

        public CssFontWeight Weight
        {
            get { return CssFontWeight.Parse(Get("font-weight")); }
            set { Set("font-weight", value); }
        }
    }
}