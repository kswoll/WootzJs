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
    /// Represents the exception that occurs during validation of a data field when the <see cref="T:System.ComponentModel.DataAnnotations.ValidationAttribute"/> class is used.
    /// </summary>
    public class ValidationException : Exception
    {
        private ValidationResult _validationResult;

        /// <summary>
        /// Gets the instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationAttribute"/> class that triggered this exception.
        /// </summary>
        /// 
        /// <returns>
        /// An instance of the validation attribute type that triggered this exception.
        /// </returns>
        public ValidationAttribute ValidationAttribute { get; private set; }

        /// <summary>
        /// Gets the <see cref="P:System.ComponentModel.DataAnnotations.ValidationException.ValidationResult"/> instance that describes the validation error.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="P:System.ComponentModel.DataAnnotations.ValidationException.ValidationResult"/> instance that describes the validation error.
        /// </returns>
        public ValidationResult ValidationResult
        {
            get
            {
                if (this._validationResult == null)
                    this._validationResult = new ValidationResult(this.Message);
                return this._validationResult;
            }
        }

        /// <summary>
        /// Gets the value of the object that causes the <see cref="T:System.ComponentModel.DataAnnotations.ValidationAttribute"/> class to trigger this exception.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the object that caused the <see cref="T:System.ComponentModel.DataAnnotations.ValidationAttribute"/> class to trigger the validation error.
        /// </returns>
        public object Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationException"/> class by using a validation result, a validation attribute, and the value of the current exception.
        /// </summary>
        /// <param name="validationResult">The list of validation results.</param><param name="validatingAttribute">The attribute that caused the current exception.</param><param name="value">The value of the object that caused the attribute to trigger the validation error.</param>
        public ValidationException(ValidationResult validationResult, ValidationAttribute validatingAttribute, object value)
            : this(validationResult.ErrorMessage, validatingAttribute, value)
        {
            this._validationResult = validationResult;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationException"/> class using a specified error message, a validation attribute, and the value of the current exception.
        /// </summary>
        /// <param name="errorMessage">The message that states the error.</param><param name="validatingAttribute">The attribute that caused the current exception.</param><param name="value">The value of the object that caused the attribute to trigger validation error.</param>
        public ValidationException(string errorMessage, ValidationAttribute validatingAttribute, object value)
            : base(errorMessage)
        {
            this.Value = value;
            this.ValidationAttribute = validatingAttribute;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationException"/> class using an error message generated by the system.
        /// </summary>
        public ValidationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationException"/> class using a specified error message.
        /// </summary>
        /// <param name="message">A specified message that states the error.</param>
        public ValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationException"/> class using a specified error message and a collection of inner exception instances.
        /// </summary>
        /// <param name="message">The error message. </param><param name="innerException">The collection of validation exceptions.</param>
        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}