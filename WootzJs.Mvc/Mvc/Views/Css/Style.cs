using WootzJs.JQuery;
using WootzJs.Web;

namespace WootzJs.Mvc.Mvc.Views.Css
{
    public class Style : CssDeclaration
    {
//        private Margin margin;
        private CssPadding padding;
        private CssBorder border;
        private CssBoxShadow boxShadow;
        private CssFont font;

        internal override void Attach(ElementStyle node)
        {
            base.Attach(node);
//            if (margin != null)
//                margin.Attach(node);
            if (padding != null)
                padding.Attach(node);
            if (border != null)
                border.Attach(node);
            if (boxShadow != null)
                boxShadow.Attach(node);
            if (font != null)
                font.Attach(node);
        }

/*
 * Margins do not participate in the box-sizing: border-box; fix.  This means if you apply margins anywhere, 
 * it will completely screw up the notion of 100% width and height.  Since that is such a fundamentally 
 * important concept, it seems better to just do away with margins.  After all, margins can always be 
 * simulated with more nesting and using padding instead.
        public Margin Margin
        {
            get { return margin; }
            set
            {
                margin = value;
                if (node != null)
                    value.Attach(node);
            }
        }
*/

        public CssBorder Border
        {
            get
            {
                if (border == null)
                    Border = new CssBorder();
                return border;
            }
            set
            {
                border = value;
                if (node != null)
                    value.Attach(node);
            }
        }

        public CssPadding Padding
        {
            get { return padding; }
            set
            {
                padding = value;
                if (node != null)
                    value.Attach(node);
            }
        }

        public CssBoxShadow BoxShadow
        {
            get { return boxShadow; }
            set
            {
                boxShadow = value;
                if (node != null)
                    value.Attach(node);
            }
        }

        public CssFont Font
        {
            get
            {
                if (font == null)
                    Font = new CssFont();
                return font;
            }
            set
            {
                font = value;
                if (node != null)
                    value.Attach(node);
            }
        }

        public CssColor BackgroundColor
        {
            get { return CssColor.Parse(Get("background-color")); }
            set { Set("background-color", value); }
        }

        public CssColor Color
        {
            get { return CssColor.Parse(Get("color")); }
            set { Set("color", value); }
        }

        public CssCursor Cursor
        {
            get { return CssCursors.Parse(Get("cursor")); }
            set { Set("cursor", value.GetName()); }
        }

        public CssNumericValue Width
        {
            get { return CssNumericValue.Parse(Get("width")); }
            set { Set("width", value); }
        }

        public CssNumericValue Height
        {
            get { return CssNumericValue.Parse(Get("height")); }
            set { Set("height", value); }
        }

        public CssNumericValue MinWidth
        {
            get { return CssNumericValue.Parse(Get("min-width")); }
            set { Set("min-width", value); }
        }

        public CssNumericValue MinHeight
        {
            get { return CssNumericValue.Parse(Get("min-height")); }
            set { Set("min-height", value); }
        }

        public CssNumericValue MaxWidth
        {
            get { return CssNumericValue.Parse(Get("max-width")); }
            set { Set("max-width", value); }
        }

        public CssNumericValue MaxHeight
        {
            get { return CssNumericValue.Parse(Get("max-height")); }
            set { Set("max-height", value); }
        }

        public CssBorderCollapse BorderCollapse
        {
            get { return CssBorderCollapses.Parse(Get("border-collapse")); }
            set { Set("border-collapse", value); }
        }

        public CssPercent Opacity
        {
            get { return CssPercent.Parse(Get("opacity")); }
            set { Set("opacity", value); }
        }
    }
}