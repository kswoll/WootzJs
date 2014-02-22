
namespace WootzJs.Mvc.Views.Css
{
    public class CssPadding : CssDeclaration
    {
        public CssPadding()
        {
        }

        public CssPadding(CssNumericValue size) 
        {
            Size = size;
        }

        public CssNumericValue Size
        {
            get { return CssNumericValue.Parse(Get("padding")); }
            set { Set("padding", value); }
        }
        
        public CssNumericValue Left
        {
            get { return CssNumericValue.Parse(Get("padding-left")); }
            set { Set("padding-left", value); }
        }

        public CssNumericValue Top
        {
            get { return CssNumericValue.Parse(Get("padding-top")); }
            set { Set("padding-top", value); }
        }

        public CssNumericValue Right
        {
            get { return CssNumericValue.Parse(Get("padding-right")); }
            set { Set("padding-right", value); }
        }

        public CssNumericValue Bottom
        {
            get { return CssNumericValue.Parse(Get("padding-bottom")); }
            set { Set("padding-bottom", value); }
        }

        public static implicit operator CssPadding(int sizeInPixels)
        {
            return new CssPadding(sizeInPixels);
        }
    }
}