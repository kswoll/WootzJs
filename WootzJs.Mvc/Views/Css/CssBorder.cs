using WootzJs.Web;

namespace WootzJs.Mvc.Views.Css
{
    public class CssBorder : CssDeclaration
    {
        private CssBorderSide left;
        private CssBorderSide top;
        private CssBorderSide right;
        private CssBorderSide bottom;

        public CssBorder()
        {
        }

        public CssBorder(CssBorderSide left, CssBorderSide top, CssBorderSide right, CssBorderSide bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public CssBorder(CssNumericValue width, CssBorderStyle style, CssColor color)
        {
            Width = width;
            Style = style;
            Color = color;
        }

        internal override void Attach(ElementStyle node)
        {
            base.Attach(node);

            if (Left != null)
                Left.Attach(node, this, "left");
            if (Top != null)
                Top.Attach(node, this, "top");
            if (Right != null)
                Right.Attach(node, this, "right");
            if (Bottom != null)
                Bottom.Attach(node, this, "bottom");
        }

        public CssBorderSide Left
        {
            get { return left; }
            set
            {
                left = value;
                if (node != null)
                    value.Attach(node, this, "left");
            }
        }

        public CssBorderSide Top
        {
            get { return top; }
            set
            {
                top = value;
                if (node != null)
                    value.Attach(node, this, "top");
            }
        }

        public CssBorderSide Right
        {
            get { return right; }
            set
            {
                right = value;
                if (node != null)
                    value.Attach(node, this, "right");
            }
        }

        public CssBorderSide Bottom
        {
            get { return bottom; }
            set
            {
                bottom = value;
                if (node != null)
                    value.Attach(node, this, "bottom");
            }
        }

        public CssNumericValue Width
        {
            get { return CssNumericValue.Parse(Get("border-width")); }
            set { Set("border-width", value); }
        }

        public CssBorderStyle Style
        {
            get { return CssBorderStyles.Parse(Get("border-style")); }
            set { Set("border-style", value); }
        }

        public CssColor Color
        {
            get { return CssColor.Parse(Get("border-color")); }
            set { Set("border-color", value); }
        }
    }
}