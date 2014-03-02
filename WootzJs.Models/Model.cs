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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.WootzJs;

namespace WootzJs.Models
{
    public abstract class Model : IAutoNotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IReadOnlyList<Property> properties;
        private Dictionary<string, Property> propertiesByName;

        public IReadOnlyList<Property> Properties
        {
            get { return properties; }
            set
            {
                properties = value;
                propertiesByName = properties.ToDictionary(x => x.Name);
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (propertyName == "Properties" || propertyName == "ControllerContext")
                return;

            var property = GetProperty(propertyName);
            property.NotifyChanged();

            OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Validate(ValidateEvent e)
        {
            foreach (var property in Properties)
            {
                var propertyValidations = new List<Validation>();

                foreach (var validationAttribute in property.PropertyInfo.GetCustomAttributes(typeof(ValidationAttribute), false).Cast<ValidationAttribute>())
                {
                    var validationContext = new ValidationContext(this) { MemberName = property.Name };
                    var result = validationAttribute.GetValidationResult(property.Value, validationContext);
                    Validation validation;
                    if (result != ValidationResult.Success)
                    {
                        validation = new Validation(false, result.ErrorMessage, property);
                    }
                    else
                    {
                        validation = new Validation(true);
                    }
                    e.AddValidation(validation);
                    propertyValidations.Add(validation);
                }
                if (propertyValidations.Any())
                {
                    property.NotifyValidated(propertyValidations.ToArray());
                }
            }
        }

        public Property GetProperty(string name)
        {
            return propertiesByName[name];
        }
    }

    public class Model<T> : Model where T : Model<T>
    {
        public Model()
        {
            var properties = new List<Property>();
            foreach (var prop in GetType().GetProperties())
            {
                var unconstructedType = typeof(Property<,>);
                var constructedType = unconstructedType.MakeGenericType(typeof(T), prop.PropertyType);
                var constructor = constructedType.GetConstructors()[0];
                var property = constructor.Invoke(null, new object[] { this, prop });
                properties.Add(property);
            }
            Properties = properties;
        }

        public Property GetProperty<TValue>(Expression<Func<T, TValue>> expression)
        {
            var propertyName = expression.GetPropertyName();
            return Properties.Single(x => x.Name == propertyName);
        }
    }
}