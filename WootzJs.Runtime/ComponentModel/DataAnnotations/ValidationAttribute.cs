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

using System.Globalization;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Serves as the base class for all validation attributes.
    /// </summary>
    /// <exception cref="T:System.ComponentModel.DataAnnotations.ValidationException">The <see cref="P:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessageResourceType"/> and <see cref="P:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessageResourceName"/> properties for localized error message are set at the same time that the non-localized <see cref="P:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessage"/> property error message is set.</exception>
    public abstract class ValidationAttribute : Attribute
    {
        private object _syncLock = new object();
        private string _errorMessage;
        private Func<string> _errorMessageResourceAccessor;
        private string _errorMessageResourceName;
        private Type _errorMessageResourceType;
        private bool _isCallingOverload;

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
                this.SetupResourceAccessor();
                return this._errorMessageResourceAccessor();
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
            get { return this._errorMessage; }
            set
            {
                this._errorMessage = value;
                this._errorMessageResourceAccessor = (Func<string>)null;
                this.CustomErrorMessageSet = true;
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
            get { return this._errorMessageResourceName; }
            set
            {
                this._errorMessageResourceName = value;
                this._errorMessageResourceAccessor = (Func<string>)null;
                this.CustomErrorMessageSet = true;
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
            get { return this._errorMessageResourceType; }
            set
            {
                this._errorMessageResourceType = value;
                this._errorMessageResourceAccessor = (Func<string>)null;
                this.CustomErrorMessageSet = true;
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
            this._errorMessageResourceAccessor = errorMessageAccessor;
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
            return string.Format(CultureInfo.CurrentCulture, this.ErrorMessageString, new object[1]
            {
                (object)name
            });
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
            lock (this._syncLock)
            {
                if (this._isCallingOverload)
                    throw new NotImplementedException("Not Implemented");
                this._isCallingOverload = true;
                try
                {
                    return this.IsValid(value, (ValidationContext)null) == null;
                }
                finally
                {
                    this._isCallingOverload = false;
                }
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
            lock (this._syncLock)
            {
                if (this._isCallingOverload)
                    throw new NotImplementedException(DataAnnotationsResources.ValidationAttribute_IsValid_NotImplemented);
                this._isCallingOverload = true;
                try
                {
                    ValidationResult local_0 = ValidationResult.Success;
                    if (!this.IsValid(value))
                    {
                        string[] temp_26;
                        if (validationContext.MemberName == null)
                            temp_26 = (string[])null;
                        else
                            temp_26 = new string[1]
                            {
                                validationContext.MemberName
                            };
                        string[] local_1 = temp_26;
                        local_0 = new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName), (IEnumerable<string>)local_1);
                    }
                    return local_0;
                }
                finally
                {
                    this._isCallingOverload = false;
                }
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
        [__DynamicallyInvokable]
        public ValidationResult GetValidationResult(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
                throw new ArgumentNullException("validationContext");
            ValidationResult validationResult = this.IsValid(value, validationContext);
            if (validationResult != null && (validationResult == null || string.IsNullOrEmpty(validationResult.ErrorMessage)))
                validationResult = new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName), validationResult.MemberNames);
            return validationResult;
        }

        /// <summary>
        /// Validates the specified object.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param><param name="name">The name to include in the error message.</param><exception cref="T:System.ComponentModel.DataAnnotations.ValidationException"><paramref name="value"/> is not valid.</exception>
        public void Validate(object value, string name)
        {
            if (!this.IsValid(value))
                throw new ValidationException(this.FormatErrorMessage(name), this, value);
        }

        /// <summary>
        /// Validates the specified object.
        /// </summary>
        /// <param name="value">The object to validate.</param><param name="validationContext">The <see cref="T:System.ComponentModel.DataAnnotations.ValidationContext"/> object that describes the context where the validation checks are performed. This parameter cannot be null.</param><exception cref="T:System.ComponentModel.DataAnnotations.ValidationException">Validation failed.</exception>
        [__DynamicallyInvokable]
        public void Validate(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
                throw new ArgumentNullException("validationContext");
            ValidationResult validationResult = this.GetValidationResult(value, validationContext);
            if (validationResult != null)
                throw new ValidationException(validationResult, this, value);
        }

        private void SetupResourceAccessor()
        {
            if (this._errorMessageResourceAccessor != null)
                return;
            string localErrorMessage = this._errorMessage;
            bool flag1 = !string.IsNullOrEmpty(this._errorMessageResourceName);
            bool flag2 = !string.IsNullOrEmpty(localErrorMessage);
            bool flag3 = this._errorMessageResourceType != (Type)null;
            if (flag1 == flag2)
                throw new InvalidOperationException(DataAnnotationsResources.ValidationAttribute_Cannot_Set_ErrorMessage_And_Resource);
            if (flag3 != flag1)
                throw new InvalidOperationException(DataAnnotationsResources.ValidationAttribute_NeedBothResourceTypeAndResourceName);
            if (flag1)
                this.SetResourceAccessorByPropertyLookup();
            else
                this._errorMessageResourceAccessor = (Func<string>)(() => localErrorMessage);
        }

        private void SetResourceAccessorByPropertyLookup()
        {
            if (!(this._errorMessageResourceType != (Type)null) || string.IsNullOrEmpty(this._errorMessageResourceName))
                throw new InvalidOperationException(string.Format((IFormatProvider)CultureInfo.CurrentCulture, DataAnnotationsResources.ValidationAttribute_NeedBothResourceTypeAndResourceName, new object[0]));
            PropertyInfo property = this._errorMessageResourceType.GetProperty(this._errorMessageResourceName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (property != (PropertyInfo)null)
            {
                MethodInfo getMethod = property.GetGetMethod(true);
                if (getMethod == (MethodInfo)null || !getMethod.IsAssembly && !getMethod.IsPublic)
                    property = (PropertyInfo)null;
            }
            if (property == (PropertyInfo)null)
                throw new InvalidOperationException(string.Format((IFormatProvider)CultureInfo.CurrentCulture, DataAnnotationsResources.ValidationAttribute_ResourceTypeDoesNotHaveProperty, new object[2]
                {
                    (object)this._errorMessageResourceType.FullName,
                    (object)this._errorMessageResourceName
                }));
            else if (property.PropertyType != typeof (string))
                throw new InvalidOperationException(string.Format((IFormatProvider)CultureInfo.CurrentCulture, DataAnnotationsResources.ValidationAttribute_ResourcePropertyNotStringType, new object[2]
                {
                    (object)property.Name,
                    (object)this._errorMessageResourceType.FullName
                }));
            else
                this._errorMessageResourceAccessor = (Func<string>)(() => (string)property.GetValue((object)null, (object[])null));
        }
    }
}