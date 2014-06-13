using WootzJs.Web;

namespace WootzJs.Mvc.Views.Css
{
    public class CssBorderSide : CssDeclaration
    {
        internal CssBorder border;
        internal string side;

        internal void Attach(ElementStyle node, CssBorder border, string side)
        {
            this.border = border;
            this.side = side;

            base.Attach(node);
        }

        public CssNumericValue Width
        {
            get { return CssNumericValue.Parse(Get("border-" + side + "-width")); }
            set { Set("border-" + side + "-width", value); }
        }

        public CssBorderStyle Style
        {
            get { return CssBorderStyles.Parse(Get("border-" + side + "-style")); }
            set { Set("border-" + side + "-style", value); }
        }

        public CssColor Color
        {
            get { return CssColor.Parse(Get("border-" + side + "-color")); }
            set { Set("border-" + side + "-color", value); }
        }
    }
}