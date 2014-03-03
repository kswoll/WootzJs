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

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Specifies how data fields are displayed and formatted by ASP.NET Dynamic Data.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DisplayFormatAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the display format for the field value.
        /// </summary>
        /// 
        /// <returns>
        /// A formatting string that specifies the display format for the value of the data field. The default is an empty string (""), which indicates that no special formatting is applied to the field value.
        /// </returns>
        public string DataFormatString
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text that is displayed for a field when the field's value is null.
        /// </summary>
        /// 
        /// <returns>
        /// The text that is displayed for a field when the field's value is null. The default is an empty string (""), which indicates that this property is not set.
        /// </returns>
        public string NullDisplayText
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates whether empty string values ("") are automatically converted to null when the data field is updated in the data source.
        /// </summary>
        /// 
        /// <returns>
        /// true if empty string values are automatically converted to null; otherwise, false. The default is true.
        /// </returns>
        public bool ConvertEmptyStringToNull
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the formatting string that is specified by the <see cref="P:System.ComponentModel.DataAnnotations.DisplayFormatAttribute.DataFormatString"/> property is applied to the field value when the data field is in edit mode.
        /// </summary>
        /// 
        /// <returns>
        /// true if the formatting string applies to the field value in edit mode; otherwise, false. The default is false.
        /// </returns>
        public bool ApplyFormatInEditMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the field should be HTML-encoded.
        /// </summary>
        /// 
        /// <returns>
        /// true if the field should be HTML-encoded; otherwise, false.
        /// </returns>
        public bool HtmlEncode
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.DisplayFormatAttribute"/> class.
        /// </summary>
        public DisplayFormatAttribute()
        {
            this.ConvertEmptyStringToNull = true;
            this.HtmlEncode = true;
        }
    }
}