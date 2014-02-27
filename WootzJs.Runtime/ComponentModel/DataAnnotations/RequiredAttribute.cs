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
    /// Specifies that a data field value is required.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequiredAttribute : Attribute //ValidationAttribute
    {
        /// <summary>
        /// Gets or sets a value that indicates whether an empty string is allowed.
        /// </summary>
        /// 
        /// <returns>
        /// true if an empty string is allowed; otherwise, false. The default value is false.
        /// </returns>
        public bool AllowEmptyStrings { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.RequiredAttribute"/> class.
        /// </summary>
        public RequiredAttribute()
        {
        }

        /// <summary>
        /// Checks that the value of the required data field is not empty.
        /// </summary>
        /// 
        /// <returns>
        /// true if validation is successful; otherwise, false.
        /// </returns>
        /// <param name="value">The data field value to validate.</param><exception cref="T:System.ComponentModel.DataAnnotations.ValidationException">The data field value was null.</exception>
/*
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            string str = value as string;
            if (str != null && !this.AllowEmptyStrings)
                return str.Trim().Length != 0;
            else
                return true;
        }
*/
    }
}