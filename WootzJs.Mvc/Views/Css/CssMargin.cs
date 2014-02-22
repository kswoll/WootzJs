
namespace WootzJs.Mvc.Views.Css
{
    public class CssMargin : CssDeclaration
    {
        public CssMargin(CssNumericValue size) 
        {
            Size = size;
        }

        public CssNumericValue Size
        {
            get { return CssNumericValue.Parse(Get("margin")); }
            set { Set("margin", value); }
        }
        
        public CssNumericValue Left
        {
            get { return CssNumericValue.Parse(Get("margin-left")); }
            set { Set("margin-left", value); }
        }

        public CssNumericValue Top
        {
            get { return CssNumericValue.Parse(Get("margin-top")); }
            set { Set("margin-top", value); }
        }

        public CssNumericValue Right
        {
            get { return CssNumericValue.Parse(Get("margin-right")); }
            set { Set("margin-right", value); }
        }

        public CssNumericValue Bottom
        {
            get { return CssNumericValue.Parse(Get("margin-bottom")); }
            set { Set("margin-bottom", value); }
        }
    }
}