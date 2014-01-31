#region License

//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------

#endregion

using System.Runtime.WootzJs;

namespace WootzJs.Web
{
    [Js(Export = false)]
    public class Style
    {
        [Js(Name = "background")]
        public string Background { get; set; }

        [Js(Name = "backgroundAttachment")]
        public string BackgroundAttachment { get; set; }

        [Js(Name = "backgroundColor")]
        public string BackgroundColor { get; set; }

        [Js(Name = "backgroundImage")]
        public string BackgroundImage { get; set; }

        [Js(Name = "backgroundOrigin")]
        public string BackgroundOrigin { get; set; }
        
        [Js(Name = "backgroundPosition")]
        public string BackgroundPosition { get; set; }

        [Js(Name = "backgroundPositionX")]
        public string BackgroundPositionX { get; set; }

        [Js(Name = "backgroundPositionY")]
        public string BackgroundPositionY { get; set; }

        [Js(Name = "backgroundRepeat")]
        public string BackgroundRepeat { get; set; }

        [Js(Name = "backgroundRepeatX")]
        public string BackgroundRepeatX { get; set; }

        [Js(Name = "backgroundRepeatY")]
        public string BackgroundRepeatY { get; set; }

        [Js(Name = "backgroundSize")]
        public string BackgroundSize { get; set; }

        [Js(Name = "border")]
        public string Border { get; set; }

        [Js(Name = "borderBottom")]
        public string BorderBottom { get; set; }

        [Js(Name = "borderBottomColor")]
        public string BorderBottomColor { get; set; }

        [Js(Name = "borderBottomLeftRadius")]
        public string BorderBottomLeftRadius { get; set; }

        [Js(Name = "borderBottomRightRadius")]
        public string BorderBottomRightRadius { get; set; }

        [Js(Name = "borderBottomStyle")]
        public string BorderBottomStyle { get; set; }

        [Js(Name = "borderBottomWidth")]
        public string BorderBottomWidth { get; set; }

        [Js(Name = "borderCollapse")]
        public string BorderCollapse { get; set; }

        [Js(Name = "borderColor")]
        public string BorderColor { get; set; }

        [Js(Name = "borderImage")]
        public string BorderImage { get; set; }
        
        [Js(Name = "borderLeft")]
        public string BorderLeft { get; set; }
        
        [Js(Name = "borderLeftColor")]
        public string BorderLeftColor { get; set; }
        
        [Js(Name = "borderLeftColor")]
        public string BorderLeftStyle { get; set; }
        
        [Js(Name = "borderLeftWidth")]
        public string BorderLeftWidth { get; set; }
        
        [Js(Name = "borderRadius")]
        public string BorderRadius { get; set; }
        
        [Js(Name = "borderRight")]
        public string BorderRight { get; set; }
        
        [Js(Name = "borderRightColor")]
        public string BorderRightColor { get; set; }
        
        [Js(Name = "borderRightStyle")]
        public string BorderRightStyle { get; set; }
        
        [Js(Name = "borderRightWidth")]
        public string BorderRightWidth { get; set; }
        
        [Js(Name = "borderSpacing")]
        public string BorderSpacing { get; set; }
        
        [Js(Name = "borderStyle")]
        public string BorderStyle { get; set; }
        
        [Js(Name = "borderTop")]
        public string BorderTop { get; set; }
        
        [Js(Name = "borderTopColor")]
        public string BorderTopColor { get; set; }
        
        [Js(Name = "borderTopStyle")]
        public string BorderTopStyle { get; set; }
        
        [Js(Name = "borderTopWidth")]
        public string BorderTopWidth { get; set; }
        
        [Js(Name = "borderTopLeftRadius")]
        public string BorderTopLeftRadius { get; set; }
        
        [Js(Name = "borderTopRightRadius")]
        public string BorderTopRightRadius { get; set; }
        
        [Js(Name = "borderWidth")]
        public string BorderWidth { get; set; }
        
        [Js(Name = "bottom")]
        public string Bottom { get; set; }
        
        [Js(Name = "boxShadow")]
        public string BoxShadow { get; set; }
        
        [Js(Name = "boxSizing")]
        public string BoxSizing { get; set; }
        
        [Js(Name = "clear")]
        public string Clear { get; set; }
        
        [Js(Name = "color")]
        public string Color { get; set; }
        
        [Js(Name = "cursor")]
        public string Cursor { get; set; }
        
        [Js(Name = "display")]
        public string Display { get; set; }
        
        [Js(Name = "float")]
        public string Float { get; set; }
        
        [Js(Name = "left")]
        public string Left { get; set; }
        
        [Js(Name = "margin")]
        public string Margin { get; set; }
        
        [Js(Name = "marginLeft")]
        public string MarginLeft { get; set; }
        
        [Js(Name = "marginRight")]
        public string MarginRight { get; set; }
        
        [Js(Name = "marginTop")]
        public string MarginTop { get; set; }
        
        [Js(Name = "marginBottom")]
        public string MarginBottom { get; set; }
        
        [Js(Name = "maxHeight")]
        public string MaxHeight { get; set; }
        
        [Js(Name = "maxWidth")]
        public string MaxWidth { get; set; }
        
        [Js(Name = "minHeight")]
        public string MinHeight { get; set; }
        
        [Js(Name = "minWidth")]
        public string MinWidth { get; set; }
        
        [Js(Name = "opacity")]
        public string Opacity { get; set; }
        
        [Js(Name = "outline")]
        public string Outline { get; set; }
        
        [Js(Name = "outlineColor")]
        public string OutlineColor { get; set; }
        
        [Js(Name = "outlineOffset")]
        public string OutlineOffset { get; set; }
        
        [Js(Name = "outlineStyle")]
        public string OutlineStyle { get; set; }
        
        [Js(Name = "outlineWidth")]
        public string OutlineWidth { get; set; }
        
        [Js(Name = "overflow")]
        public string Overflow { get; set; }
        
        [Js(Name = "overflowWrap")]
        public string OverflowWrap { get; set; }
        
        [Js(Name = "overflowX")]
        public string OverflowX { get; set; }
        
        [Js(Name = "overflowY")]
        public string OverflowY { get; set; }
        
        [Js(Name = "padding")]
        public string Padding { get; set; }
        
        [Js(Name = "paddingBottom")]
        public string PaddingBottom { get; set; }
        
        [Js(Name = "paddingLeft")]
        public string PaddingLeft { get; set; }
        
        [Js(Name = "paddingRight")]
        public string PaddingRight { get; set; }
        
        [Js(Name = "paddingTop")]
        public string PaddingTop { get; set; }
        
        [Js(Name = "position")]
        public string Position { get; set; }
        
        [Js(Name = "right")]
        public string Right { get; set; }
        
        [Js(Name = "textOverflow")]
        public string TextOverflow { get; set; }
        
        [Js(Name = "textShadow")]
        public string TextShadow { get; set; }
        
        [Js(Name = "top")]
        public string Top { get; set; }
        
        [Js(Name = "visibility")]
        public string Visibility { get; set; }
        
        [Js(Name = "whiteSpace")]
        public string WhiteSpace { get; set; }
        
        [Js(Name = "width")]
        public string Width { get; set; }
        
        [Js(Name = "wordBreak")]
        public string WordBreak { get; set; }
        
        [Js(Name = "wordSpacing")]
        public string WordSpacing { get; set; }
        
        [Js(Name = "wordWrap")]
        public string WordWrap { get; set; }
        
        [Js(Name = "zIndex")]
        public string ZIndex { get; set; }
    }
}