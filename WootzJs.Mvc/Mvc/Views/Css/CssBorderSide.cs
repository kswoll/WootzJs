using WootzJs.JQuery;

namespace WootzJs.Mvc.Mvc.Views.Css
{
    public class CssBorderSide : CssDeclaration
    {
        internal CssBorder border;
        internal string side;

        internal void Attach(jQuery node, CssBorder border, string side)
        {
            this.border = border;
            this.side = side;

            base.Attach(node);
        }

        public CssNumericValue Width
        {
            get { return CssNumericValue.Parse(Get("border-" + side + "-width")); }
            set
            {
                Act(() =>
                {
                    if (Get("border-" + side + "-style") == "")
                        Set("border-" + side + "-style", "solid");
                    Set("border-" + side + "-width", value);                                        
                });
            }
        }
    }
}