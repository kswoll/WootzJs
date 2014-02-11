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

namespace WootzJs.Mvc.Mvc.Views.Css
{
    public class CssBorderRadius : CssDeclaration
    {
        public CssBorderRadius()
        {
        }

        public CssBorderRadius(CssNumericValue size) 
        {
            Size = size;
        }

        public CssNumericValue Size
        {
            get { return CssNumericValue.Parse(Get("border-radius")); }
            set { Set("border-radius", value); }
        }
        
        public CssNumericValue BottomLeft
        {
            get { return CssNumericValue.Parse(Get("border-bottom-left-radius")); }
            set { Set("border-bottom-left-radius", value); }
        }

        public CssNumericValue TopLeft
        {
            get { return CssNumericValue.Parse(Get("border-top-left-radius")); }
            set { Set("border-top-left-radius", value); }
        }

        public CssNumericValue TopRight
        {
            get { return CssNumericValue.Parse(Get("border-top-right-radius")); }
            set { Set("border-top-right-radius", value); }
        }

        public CssNumericValue BottomRight
        {
            get { return CssNumericValue.Parse(Get("border-bottom-right-radius")); }
            set { Set("border-bottom-right-radius", value); }
        }

        public static implicit operator CssBorderRadius(int sizeInPixels)
        {
            return new CssBorderRadius(sizeInPixels);
        }         
    }
}