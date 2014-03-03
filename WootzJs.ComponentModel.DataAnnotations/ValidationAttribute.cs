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
using System.Globalization;
using System.Reflection;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Serves as the base class for all validation attributes.
    /// </summary>
    /// <exception cref="T:System.ComponentModel.DataAnnotations.ValidationException">The <see cref="P:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessageResourceType"/> and <see cref="P:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessageResourceName"/> properties for localized error message are set at the same time that the non-localized <see cref="P:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessage"/> property error message is set.</exception>
    public abstract class ValidationAttribute : Attribute
    {
        private string _errorMessage;
        private Func<string> _errorMessageResourceAccessor;
        private string _errorMessageResourceName;
        private Type _errorMessageResourceType;
        private bool isCallingOverload;

        /// <summary>
        /// Gets the localized validation error message.
        /// </summary>
        /// 
        /// <returns>
        /// The localized validation error message.
        /// </returns>
        protected string ErrorMessageString
        {
            get
            {
                SetupResourceAccessor();
                return _errorMessageResourceAccessor();
            }
        }

        internal bool CustomErrorMessageSet { get; private set; }

        /// <summary>
        /// Gets a value that indicates whether the attribute requires validation context.
        /// </summary>
        /// 
        /// <returns>
        /// true if the attribute requires validation context; otherwise, false.
        /// </returns>
        public virtual bool RequiresValidationContext
        {
            get { return false; }
        }

        /// <summary>
        /// Gets or sets an error message to associate with a validation control if validation fails.
        /// </summary>
        /// 
        /// <returns>
        /// The error message that is associated with the validation control.
        /// </returns>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                _errorMessageResourceAccessor = null;
                CustomErrorMessageSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the error message resource name to use in order to look up the <see cref="P:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessageResourceType"/> property value if validation fails.
        /// </summary>
        /// 
        /// <returns>
        /// The error message resource that is associated with a validation control.
        /// </returns>
        public string ErrorMessageResourceName
        {
            get { return _errorMessageResourceName; }
            set
            {
                _errorMessageResourceName = value;
                _errorMessageResourceAccessor = null;
                CustomErrorMessageSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the resource type to use for error-message lookup if validation fails.
        /// </summary>
        /// 
        /// <returns>
        /// The type of error message that is associated with a validation control.
        /// </returns>
        public Type ErrorMessageResourceType
        {
            get { return _errorMessageResourceType; }
            set
            {
                _errorMessageResourceType = value;
                _errorMessageResourceAccessor = null;
                CustomErrorMessageSet = true;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationAttribute"/> class.
        /// </summary>
        protected ValidationAttribute()
            : this(() => "Validation Error")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationAttribute"/> class by using the error message to associate with a validation control.
        /// </summary>
        /// <param name="errorMessage">The error message to associate with a validation control.</param>
        protected ValidationAttribute(string errorMessage)
            : this(() => errorMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationAttribute"/> class by using the function that enables access to validation resources.
        /// </summary>
        /// <param name="errorMessageAccessor">The function that enables access to validation resources.</param><exception cref="T:System:ArgumentNullException"><paramref name="errorMessageAccessor"/> is null.</exception>
        protected ValidationAttribute(Func<string> errorMessageAccessor)
        {
            _errorMessageResourceAccessor = errorMessageAccessor;
        }

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// 
        /// <returns>
        /// An instance of the formatted error message.
        /// </returns>
        /// <param name="name">The name to include in the formatted message.</param>
        public virtual string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, new object[] { name });
        }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// 
        /// <returns>
        /// true if the specified value is valid; otherwise, false.
        /// </returns>
        /// <param name="value">The value of the object to validate. </param>
        public virtual bool IsValid(object value)
        {
            if (isCallingOverload)
                throw new NotImplementedException("Not Implemented");
            isCallingOverload = true;
            try
            {
                return IsValid(value, null) == null;
            }
            finally
            {
                isCallingOverload = false;
            }
        }

        /// <summary>
        /// Validates the specified value with respect to the current validation attribute.
        /// </summary>
        /// 
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult"/> class.
        /// </returns>
        /// <param name="value">The value to validate.</param><param name="validationContext">The context information about the validation operation.</param>
        protected virtual ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (isCallingOverload)
                throw new NotImplementedException();
            isCallingOverload = true;
            try
            {
                var result = ValidationResult.Success;
                if (!IsValid(value))
                {
                    string[] memberNames;
                    if (validationContext.MemberName == null)
                        memberNames = null;
                    else
                        memberNames = new string[] { validationContext.MemberName };
                    result = new ValidationResult(FormatErrorMessage(validationContext.DisplayName), memberNames);
                }
                return result;
            }
            finally
            {
                isCallingOverload = false;
            }
        }

        /// <summary>
        /// Checks whether the specified value is valid with respect to the current validation attribute.
        /// </summary>
        /// 
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult"/> class.
        /// </returns>
        /// <param name="value">The value to validate.</param><param name="validationContext">The context information about the validation operation.</param>
        public ValidationResult GetValidationResult(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
                throw new ArgumentNullException("validationContext");
            ValidationResult validationResult = IsValid(value, validationContext);
            if (validationResult != null && string.IsNullOrEmpty(validationResult.ErrorMessage))
                validationResult = new ValidationResult(FormatErrorMessage(validationContext.DisplayName), validationResult.MemberNames);
            return validationResult;
        }

        /// <summary>
        /// Validates the specified object.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <param name="name">The name to include in the error message.</param>
        /// <exception cref="T:System.ComponentModel.DataAnnotations.ValidationException"><paramref name="value"/> 
        /// is not valid.</exception>
        public void Validate(object value, string name)
        {
            if (!IsValid(value))
                throw new ValidationException(FormatErrorMessage(name), this, value);
        }

        /// <summary>
        /// Validates the specified object.
        /// </summary>
        /// <param name="value">The object to validate.</param><param name="validationContext">The <see cref="T:System.ComponentModel.DataAnnotations.ValidationContext"/> object that describes the context where the validation checks are performed. This parameter cannot be null.</param><exception cref="T:System.ComponentModel.DataAnnotations.ValidationException">Validation failed.</exception>
        public void Validate(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
                throw new ArgumentNullException("validationContext");
            ValidationResult validationResult = GetValidationResult(value, validationContext);
            if (validationResult != null)
                throw new ValidationException(validationResult, this, value);
        }

        private void SetupResourceAccessor()
        {
            if (_errorMessageResourceAccessor != null)
                return;
            string localErrorMessage = _errorMessage;
            bool flag1 = !string.IsNullOrEmpty(_errorMessageResourceName);
            bool flag2 = !string.IsNullOrEmpty(localErrorMessage);
            bool flag3 = _errorMessageResourceType != null;
            if (flag1 == flag2)
                throw new InvalidOperationException();
            if (flag3 != flag1)
                throw new InvalidOperationException();
            if (flag1)
                SetResourceAccessorByPropertyLookup();
            else
                _errorMessageResourceAccessor = (() => localErrorMessage);
        }

        private void SetResourceAccessorByPropertyLookup()
        {
            if (_errorMessageResourceType == null || string.IsNullOrEmpty(_errorMessageResourceName))
                throw new InvalidOperationException();
            PropertyInfo property = _errorMessageResourceType.GetProperty(_errorMessageResourceName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (property != null)
            {
                MethodInfo getMethod = property.GetGetMethod(true);
                if (getMethod == null || !getMethod.IsAssembly && !getMethod.IsPublic)
                    property = null;
            }
            if (property == null)
                throw new InvalidOperationException();
            else if (property.PropertyType != typeof (string))
                throw new InvalidOperationException();
            else
                this._errorMessageResourceAccessor = () => (string)property.GetValue(null, null);
        }
    }
}