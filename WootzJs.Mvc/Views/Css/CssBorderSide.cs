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
            set { Act(new CssBorderSideAction(this, "border-{0}-width", value.ToString())); }
        }

        public CssBorderStyle Style
        {
            get { return CssBorderStyles.Parse(Get("border-" + side + "-style")); }
            set { Act(new CssBorderSideAction(this, "border-{0}-style", value.ToString())); }
        }

        public CssColor Color
        {
            get { return CssColor.Parse(Get("border-" + side + "-color")); }
            set { Act(new CssBorderSideAction(this, "border-{0}-style", value.ToString())); }
        }
    }
}