using System;
using System.Linq;
using WootzJs.Web;

namespace WootzJs.Mvc.Views.Css
{
    public class Style : CssDeclaration
    {
//        private Margin margin;
        private CssPadding padding;
        private CssBorder border;
        private CssBoxShadow boxShadow;
        private CssFont font;
        private CssBorderRadius borderRadius;

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
            if (borderRadius != null)
                borderRadius.Attach(node);
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
                if (node != null)
                    border.Attach(node);
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
            get
            {
                if (padding == null)
                    Padding = new CssPadding();
                return padding;
            }
            set
            {
                padding = value;
                if (node != null)
                    value.Attach(node);
            }
        }

        public CssBorderRadius BorderRadius
        {
            get
            {
                if (borderRadius == null)
                    BorderRadius = new CssBorderRadius();
                return borderRadius;
            }
            set
            {
                borderRadius = value;
                if (node != null)
                    value.Attach(node);
            }
        }

        public CssBoxShadow BoxShadow
        {
            get
            {
                if (boxShadow == null)
                    BoxShadow = new CssBoxShadow();
                return boxShadow;
            }
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

        public CssNumericValue BorderSpacing
        {
            get { return CssNumericValue.Parse(Get("border-spacing")); }
            set { Set("border-spacing", value); }
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

        public CssTextDecoration TextDecoration
        {
            get { return CssTextDecorations.Parse(Get("text-decoration")); }
            set { Set("text-decoration", value.GetCssValue()); }
        }

        public CssTextTransform TextTransform
        {
            get { return CssTextTransforms.Parse(Get("text-transform")); }
            set { Set("text-transform", value.GetCssValue()); }
        }

        public CssTextAlign TextAlign
        {
            get { return CssTextAligns.Parse(Get("text-align")); }
            set { Set("text-align", value.GetCssValue()); }
        }

        public CssDisplay Display
        {
            get { return CssDisplays.Parse(Get("display")); }
            set { Set("display", value.GetCssValue()); }
        }

        public CssWhiteSpace WhiteSpace
        {
            get { return CssWhiteSpaces.Parse(Get("white-space")); }
            set { Set("white-space", value.GetCssValue()); }
        }

        public CssNumericValue LineHeight
        {
            get { return CssNumericValue.Parse(Get("line-height")); }
            set { Set("line-height", value); }
        }

        public Style Clone()
        {
            if (node == null)
            {
                var result = new Style();
                result.actions = actions.ToList();
                return result;
            }
            else
            {
                throw new Exception("Cannot clone a style that has already been attached. (Cloning of styles is intended to support \"template\" styles for which attaching is not intended.");
            }
        }

        public void ApplyTo(Style other)
        {
            if (node == null)
            {
                if (other.node == null)
                {
                    other.actions = actions.ToList();
                }
                else
                {
                    foreach (var action in actions)
                    {
                        action.Act(other);
                    }                    
                }
            }
            else
            {
                throw new Exception("Cannot apply a style that has already been attached.");
            }
        }

/*

        public CssTextAlign TextAlign
        {
            get { return CssTextAligns.Parse(Get("text-align")); }
            set { Set("text-align", value.GetCssValue()); }
        }

        public CssVerticalAlign VerticalAlign
        {
            get { return CssVerticalAligns.Parse(Get("vertical-align")); }
            set { Set("vertical-align", value.GetCssValue()); }
        }
*/
    }
}