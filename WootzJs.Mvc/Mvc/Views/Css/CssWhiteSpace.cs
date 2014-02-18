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
    public enum CssWhiteSpace
    {
        Inherit, 

        /// <summary>
        /// Collapses whitespace as for normal, but suppresses line breaks (text wrapping) within text.
        /// </summary>
        NoWrap, 

        /// <summary>
        /// Sequences of whitespace are collapsed. Newline characters in the source are handled as other 
        /// whitespace. Breaks lines as necessary to fill line boxes.
        /// </summary>
        Normal, 

        /// <summary>
        /// Sequences of whitespace are preserved, lines are only broken at newline characters in the 
        /// source and at &lt;br&gt; elements.
        /// </summary>
        Pre, 

        /// <summary>
        /// Sequences of whitespace are preserved. Lines are broken at newline characters, at 
        /// &lt;br&gt;, and as necessary to fill line boxes.
        /// </summary>
        PreWrap, 

        /// <summary>
        /// Sequences of whitespace are collapsed. Lines are broken at newline characters, at 
        /// &lt;br&gt;, and as necessary to fill line boxes.
        /// </summary>
        PreLine
    }

    public static class CssWhiteSpaces
    {
        public static CssWhiteSpace Parse(string s)
        {
            switch (s)
            {
                case "inherit":
                case "":
                case null:
                    return CssWhiteSpace.Inherit;
                case "nowrap":
                    return CssWhiteSpace.NoWrap;
                case "normal":
                    return CssWhiteSpace.Normal;
                case "pre":
                    return CssWhiteSpace.Pre;
                case "pre-line":
                    return CssWhiteSpace.PreLine;
                case "pre-wrap":
                    return CssWhiteSpace.PreWrap;
                default: 
                    throw new Exception();
            }
        }

        public static string GetCssValue(this CssWhiteSpace value)
        {
            switch (value)
            {
                case CssWhiteSpace.Inherit:
                    return "inherit";
                case CssWhiteSpace.NoWrap:
                    return "nowrap";
                case CssWhiteSpace.Normal:
                    return "normal";
                case CssWhiteSpace.Pre:
                    return "pre";
                case CssWhiteSpace.PreLine:
                    return "pre-line";
                case CssWhiteSpace.PreWrap:
                    return "pre-wrap";
                default:
                    throw new Exception();
            }
        }
    }
}