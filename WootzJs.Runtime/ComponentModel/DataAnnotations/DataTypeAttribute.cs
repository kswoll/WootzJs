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
    /// Specifies the name of an additional type to associate with a data field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DataTypeAttribute : ValidationAttribute
    {
        private static string[] _dataTypeStrings = Enum.GetNames(typeof(DataType));

        /// <summary>
        /// Gets the type that is associated with the data field.
        /// </summary>
        /// 
        /// <returns>
        /// One of the <see cref="T:System.ComponentModel.DataAnnotations.DataType"/> values.
        /// </returns>
        public DataType DataType { get; private set; }

        /// <summary>
        /// Gets the name of custom field template that is associated with the data field.
        /// </summary>
        /// 
        /// <returns>
        /// The name of the custom field template that is associated with the data field.
        /// </returns>
        public string CustomDataType { get; private set; }

        /// <summary>
        /// Gets a data-field display format.
        /// </summary>
        /// 
        /// <returns>
        /// The data-field display format.
        /// </returns>
        public DisplayFormatAttribute DisplayFormat
        {
            get;
            protected set;
        }

        static DataTypeAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.DataTypeTypeAttribute"/> class by using the specified type name.
        /// </summary>
        /// <param name="dataType">The name of the type to associate with the data field.</param>
        public DataTypeAttribute(DataType dataType)
        {
            DataType = dataType;
            switch (dataType)
            {
                case DataType.Date:
                    DisplayFormat = new DisplayFormatAttribute();
                    DisplayFormat.DataFormatString = "{0:d}";
                    DisplayFormat.ApplyFormatInEditMode = true;
                    break;
                case DataType.Time:
                    DisplayFormat = new DisplayFormatAttribute();
                    DisplayFormat.DataFormatString = "{0:t}";
                    DisplayFormat.ApplyFormatInEditMode = true;
                    break;
                case DataType.Currency:
                    DisplayFormat = new DisplayFormatAttribute();
                    DisplayFormat.DataFormatString = "{0:C}";
                    break;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.DataTypeTypeAttribute"/> class by using the specified field template name.
        /// </summary>
        /// <param name="customDataType">The name of the custom field template to associate with the data field.</param><exception cref="T:System.ArgumentException"><paramref name="customDataType"/> is null or an empty string (""). </exception>
        public DataTypeAttribute(string customDataType)
            : this(DataType.Custom)
        {
            this.CustomDataType = customDataType;
        }

        /// <summary>
        /// Returns the name of the type that is associated with the data field.
        /// </summary>
        /// 
        /// <returns>
        /// The name of the type associated with the data field.
        /// </returns>
        public virtual string GetDataTypeName()
        {
            this.EnsureValidDataType();
            if (this.DataType == DataType.Custom)
                return this.CustomDataType;
            else
                return DataTypeAttribute._dataTypeStrings[(int)this.DataType];
        }

        /// <summary>
        /// Checks that the value of the data field is valid.
        /// </summary>
        /// 
        /// <returns>
        /// true always.
        /// </returns>
        /// <param name="value">The data field value to validate.</param>
        public override bool IsValid(object value)
        {
            this.EnsureValidDataType();
            return true;
        }

        private void EnsureValidDataType()
        {
            if (this.DataType == DataType.Custom && string.IsNullOrEmpty(this.CustomDataType))
                throw new InvalidOperationException();
        }
    }
}