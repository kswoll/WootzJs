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
    public class ElementStyle
    {
        [Js(Name = "background")]
        public extern string Background { get; set; }

        [Js(Name = "backgroundAttachment")]
        public extern string BackgroundAttachment { get; set; }

        [Js(Name = "backgroundColor")]
        public extern string BackgroundColor { get; set; }

        [Js(Name = "backgroundImage")]
        public extern string BackgroundImage { get; set; }

        [Js(Name = "backgroundOrigin")]
        public extern string BackgroundOrigin { get; set; }
        
        [Js(Name = "backgroundPosition")]
        public extern string BackgroundPosition { get; set; }

        [Js(Name = "backgroundPositionX")]
        public extern string BackgroundPositionX { get; set; }

        [Js(Name = "backgroundPositionY")]
        public extern string BackgroundPositionY { get; set; }

        [Js(Name = "backgroundRepeat")]
        public extern string BackgroundRepeat { get; set; }

        [Js(Name = "backgroundRepeatX")]
        public extern string BackgroundRepeatX { get; set; }

        [Js(Name = "backgroundRepeatY")]
        public extern string BackgroundRepeatY { get; set; }

        [Js(Name = "backgroundSize")]
        public extern string BackgroundSize { get; set; }

        [Js(Name = "border")]
        public extern string Border { get; set; }

        [Js(Name = "borderBottom")]
        public extern string BorderBottom { get; set; }

        [Js(Name = "borderBottomColor")]
        public extern string BorderBottomColor { get; set; }

        [Js(Name = "borderBottomLeftRadius")]
        public extern string BorderBottomLeftRadius { get; set; }

        [Js(Name = "borderBottomRightRadius")]
        public extern string BorderBottomRightRadius { get; set; }

        [Js(Name = "borderBottomStyle")]
        public extern string BorderBottomStyle { get; set; }

        [Js(Name = "borderBottomWidth")]
        public extern string BorderBottomWidth { get; set; }

        [Js(Name = "borderCollapse")]
        public extern string BorderCollapse { get; set; }

        [Js(Name = "borderColor")]
        public extern string BorderColor { get; set; }

        [Js(Name = "borderImage")]
        public extern string BorderImage { get; set; }
        
        [Js(Name = "borderLeft")]
        public extern string BorderLeft { get; set; }
        
        [Js(Name = "borderLeftColor")]
        public extern string BorderLeftColor { get; set; }
        
        [Js(Name = "borderLeftColor")]
        public extern string BorderLeftStyle { get; set; }
        
        [Js(Name = "borderLeftWidth")]
        public extern string BorderLeftWidth { get; set; }
        
        [Js(Name = "borderRadius")]
        public extern string BorderRadius { get; set; }
        
        [Js(Name = "borderRight")]
        public extern string BorderRight { get; set; }
        
        [Js(Name = "borderRightColor")]
        public extern string BorderRightColor { get; set; }
        
        [Js(Name = "borderRightStyle")]
        public extern string BorderRightStyle { get; set; }
        
        [Js(Name = "borderRightWidth")]
        public extern string BorderRightWidth { get; set; }
        
        [Js(Name = "borderSpacing")]
        public extern string BorderSpacing { get; set; }
        
        [Js(Name = "borderStyle")]
        public extern string BorderStyle { get; set; }
        
        [Js(Name = "borderTop")]
        public extern string BorderTop { get; set; }
        
        [Js(Name = "borderTopColor")]
        public extern string BorderTopColor { get; set; }
        
        [Js(Name = "borderTopStyle")]
        public extern string BorderTopStyle { get; set; }
        
        [Js(Name = "borderTopWidth")]
        public extern string BorderTopWidth { get; set; }
        
        [Js(Name = "borderTopLeftRadius")]
        public extern string BorderTopLeftRadius { get; set; }
        
        [Js(Name = "borderTopRightRadius")]
        public extern string BorderTopRightRadius { get; set; }
        
        [Js(Name = "borderWidth")]
        public extern string BorderWidth { get; set; }
        
        [Js(Name = "bottom")]
        public extern string Bottom { get; set; }
        
        [Js(Name = "boxShadow")]
        public extern string BoxShadow { get; set; }
        
        [Js(Name = "boxSizing")]
        public extern string BoxSizing { get; set; }
        
        [Js(Name = "clear")]
        public extern string Clear { get; set; }
        
        [Js(Name = "color")]
        public extern string Color { get; set; }
        
        [Js(Name = "cursor")]
        public extern string Cursor { get; set; }
        
        [Js(Name = "display")]
        public extern string Display { get; set; }
        
        [Js(Name = "fontFamily")]
        public extern string FontFamily { get; set; }

        [Js(Name = "fontSize")]
        public extern string FontSize { get; set; }

        [Js(Name = "fontStyle")]
        public extern string FontStyle { get; set; }

        [Js(Name = "float")]
        public extern string Float { get; set; }
        
        [Js(Name = "height")]
        public extern string Height { get; set; }

        [Js(Name = "left")]
        public extern string Left { get; set; }
        
        [Js(Name = "lineHeight")]
        public extern string LineHeight { get; set; }

        [Js(Name = "margin")]
        public extern string Margin { get; set; }
        
        [Js(Name = "marginLeft")]
        public extern string MarginLeft { get; set; }
        
        [Js(Name = "marginRight")]
        public extern string MarginRight { get; set; }
        
        [Js(Name = "marginTop")]
        public extern string MarginTop { get; set; }
        
        [Js(Name = "marginBottom")]
        public extern string MarginBottom { get; set; }
        
        [Js(Name = "maxHeight")]
        public extern string MaxHeight { get; set; }
        
        [Js(Name = "maxWidth")]
        public extern string MaxWidth { get; set; }
        
        [Js(Name = "minHeight")]
        public extern string MinHeight { get; set; }
        
        [Js(Name = "minWidth")]
        public extern string MinWidth { get; set; }
        
        [Js(Name = "opacity")]
        public extern string Opacity { get; set; }
        
        [Js(Name = "outline")]
        public extern string Outline { get; set; }
        
        [Js(Name = "outlineColor")]
        public extern string OutlineColor { get; set; }
        
        [Js(Name = "outlineOffset")]
        public extern string OutlineOffset { get; set; }
        
        [Js(Name = "outlineStyle")]
        public extern string OutlineStyle { get; set; }
        
        [Js(Name = "outlineWidth")]
        public extern string OutlineWidth { get; set; }
        
        [Js(Name = "overflow")]
        public extern string Overflow { get; set; }
        
        [Js(Name = "overflowWrap")]
        public extern string OverflowWrap { get; set; }
        
        [Js(Name = "overflowX")]
        public extern string OverflowX { get; set; }
        
        [Js(Name = "overflowY")]
        public extern string OverflowY { get; set; }
        
        [Js(Name = "padding")]
        public extern string Padding { get; set; }
        
        [Js(Name = "paddingBottom")]
        public extern string PaddingBottom { get; set; }
        
        [Js(Name = "paddingLeft")]
        public extern string PaddingLeft { get; set; }
        
        [Js(Name = "paddingRight")]
        public extern string PaddingRight { get; set; }
        
        [Js(Name = "paddingTop")]
        public extern string PaddingTop { get; set; }
        
        [Js(Name = "position")]
        public extern string Position { get; set; }

        [Js(Name = "pointerEvents")]
        public extern string PointerEvents { get; set; }
        
        [Js(Name = "right")]
        public extern string Right { get; set; }
        
        [Js(Name = "textAlign")]
        public extern string TextAlign { get; set; }

        [Js(Name = "textOverflow")]
        public extern string TextOverflow { get; set; }
        
        [Js(Name = "textShadow")]
        public extern string TextShadow { get; set; }
        
        [Js(Name = "top")]
        public extern string Top { get; set; }

        [Js(Name = "userSelect")]
        public extern string UserSelect { get; set; }
 
        [Js(Name = "webkitUserSelect")]
        public extern string WebkitUserSelect { get; set; }
 
        [Js(Name = "verticalAlign")]
        public extern string VerticalAlign { get; set; }
       
        [Js(Name = "visibility")]
        public extern string Visibility { get; set; }
        
        [Js(Name = "whiteSpace")]
        public extern string WhiteSpace { get; set; }
        
        [Js(Name = "width")]
        public extern string Width { get; set; }
        
        [Js(Name = "wordBreak")]
        public extern string WordBreak { get; set; }
        
        [Js(Name = "wordSpacing")]
        public extern string WordSpacing { get; set; }
        
        [Js(Name = "wordWrap")]
        public extern string WordWrap { get; set; }
        
        [Js(Name = "zIndex")]
        public extern string ZIndex { get; set; }

        public extern string this[string key] { get; set; }
    }
}