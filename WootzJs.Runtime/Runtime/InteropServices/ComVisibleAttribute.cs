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

namespace System.Runtime.InteropServices
{
    /// <summary>
    /// Controls accessibility of an individual managed type or member, or of all types within an assembly, to COM.
    /// </summary>
    [ComVisible(true)]
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
    public sealed class ComVisibleAttribute : Attribute
    {
        internal bool _val;

        /// <summary>
        /// Gets a value that indicates whether the COM type is visible.
        /// </summary>
        /// 
        /// <returns>
        /// true if the type is visible; otherwise, false. The default value is true.
        /// </returns>
        public bool Value
        {
            get { return _val; }
        }

        /// <summary>
        /// Initializes a new instance of the ComVisibleAttribute class.
        /// </summary>
        /// <param name="visibility">true to indicate that the type is visible to COM; otherwise, false. The default is true. </param>
        public ComVisibleAttribute(bool visibility)
        {
            _val = visibility;
        }
    }
}