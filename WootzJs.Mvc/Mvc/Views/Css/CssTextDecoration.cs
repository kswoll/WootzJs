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

using System;

namespace WootzJs.Mvc.Mvc.Views.Css
{
    public enum CssTextDecoration
    {
        None,
        Underline,
        Overline,
        LineThrough
    }

    public static class CssTextDecorations
    {
        public static string GetCssValue(this CssTextDecoration value)
        {
            switch (value)
            {
                case CssTextDecoration.LineThrough:
                    return "line-through";
                case CssTextDecoration.None:
                    return "none";
                case CssTextDecoration.Overline:
                    return "overline";
                case CssTextDecoration.Underline:
                    return "underline";
                default:
                    throw new Exception();
            }
        }

        public static CssTextDecoration Parse(string s)
        {
            switch (s)
            {
                case "line-through":
                    return CssTextDecoration.LineThrough;
                case "none":
                    return CssTextDecoration.None;
                case "overline":
                    return CssTextDecoration.Overline;
                case "underline":
                    return CssTextDecoration.Underline;
                default:
                    throw new Exception();
            }
        }
    }
}