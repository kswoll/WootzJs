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

namespace WootzJs.Mvc.Views.Css
{
    public enum CssBorderStyle
    {
        None,
        Hidden,
        Dotted,
        Dashed,
        Solid,
        Double,
        Groove,
        Ridge,
        Inset,
        Outset
    }

    public static class CssBorderStyles 
    {
        public static string GetCssValue(this CssBorderStyle value)
        {
            switch (value)
            {
                case CssBorderStyle.Dashed: return "dashed";
                case CssBorderStyle.Dotted: return "dotted";
                case CssBorderStyle.Double: return "double";
                case CssBorderStyle.Groove: return "groove";
                case CssBorderStyle.Hidden: return "hidden";
                case CssBorderStyle.Inset: return "inset";
                case CssBorderStyle.None: return "none";
                case CssBorderStyle.Outset: return "outset";
                case CssBorderStyle.Ridge: return "ridge";
                case CssBorderStyle.Solid: return "solid";
                default: throw new Exception();
            }
        }

        public static CssBorderStyle Parse(string s)
        {
            switch (s)
            {
                case "none": 
                case "": 
                case null: 
                    return CssBorderStyle.None;
                case "dashed": return CssBorderStyle.Dashed;
                case "dotted": return CssBorderStyle.Dotted;
                case "double": return CssBorderStyle.Double;
                case "groove": return CssBorderStyle.Groove;
                case "hidden": return CssBorderStyle.Hidden;
                case "inset": return CssBorderStyle.Inset;
                case "outset": return CssBorderStyle.Outset;
                case "ridge": return CssBorderStyle.Ridge;
                case "solid": return CssBorderStyle.Solid;
                default: throw new Exception();                
            }
        }
    }
}