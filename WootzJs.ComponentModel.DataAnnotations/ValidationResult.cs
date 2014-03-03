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

using System.Collections.Generic;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Represents a container for the results of a validation request.
    /// </summary>
    public class ValidationResult
    {
        private IEnumerable<string> _memberNames;
        private string _errorMessage;

        /// <summary>
        /// Represents the success of the validation (true if validation was successful; otherwise, false).
        /// </summary>
        public static readonly ValidationResult Success;

        /// <summary>
        /// Gets the collection of member names that indicate which fields have validation errors.
        /// </summary>
        /// 
        /// <returns>
        /// The collection of member names that indicate which fields have validation errors.
        /// </returns>
        public IEnumerable<string> MemberNames
        {
            get { return this._memberNames; }
        }

        /// <summary>
        /// Gets the error message for the validation.
        /// </summary>
        /// 
        /// <returns>
        /// The error message for the validation.
        /// </returns>
        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set { this._errorMessage = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult"/> class by using an error message.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public ValidationResult(string errorMessage)
            : this(errorMessage, (IEnumerable<string>)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult"/> class by using an error message and a list of members that have validation errors.
        /// </summary>
        /// <param name="errorMessage">The error message.</param><param name="memberNames">The list of member names that have validation errors.</param>
        public ValidationResult(string errorMessage, IEnumerable<string> memberNames)
        {
            this._errorMessage = errorMessage;
            this._memberNames = memberNames ?? (IEnumerable<string>)new string[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult"/> class by using a <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult"/> object.
        /// </summary>
        /// <param name="validationResult">The validation result object.</param>
        protected ValidationResult(ValidationResult validationResult)
        {
            if (validationResult == null)
                throw new ArgumentNullException("validationResult");
            this._errorMessage = validationResult._errorMessage;
            this._memberNames = validationResult._memberNames;
        }

        /// <summary>
        /// Returns a string representation of the current validation result.
        /// </summary>
        /// 
        /// <returns>
        /// The current validation result.
        /// </returns>
        public override string ToString()
        {
            return this.ErrorMessage ?? base.ToString();
        }
    }
}